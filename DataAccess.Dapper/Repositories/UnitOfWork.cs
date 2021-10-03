using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Dapper.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        private IDeveloperRepository _developerRepository;
        private IProjectRepository _projectRepository;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IDeveloperRepository Developers => _developerRepository ??= new DeveloperRepository(_transaction);
        public IProjectRepository Projects => _projectRepository ??= new ProjectRepository(_transaction);

        public int Complete()
        {
            try
            {
                _transaction.Commit();
                return 0;
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void ResetRepositories()
        {
            _developerRepository = null;
            _projectRepository = null;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}