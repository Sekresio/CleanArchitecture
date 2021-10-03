using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using Domain;

namespace DataAccess.Dapper.Repositories
{
    public class ProjectRepository : RepositoryBase, IProjectRepository
    {
        public ProjectRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public Project GetById(int id)
        {
            return Connection.Query<Project>(
                "SELECT * FROM Projects Where Id = @Id",
                param: new { Id = id},
                transaction: Transaction
            ).FirstOrDefault();
        }

        public IEnumerable<Project> GetAll()
        {
            return Connection.Query<Project>(
                "SELECT * FROM Projects",
                transaction: Transaction
            );
        }

        public void Add(Project entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Project> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(Project entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Project> entities)
        {
            throw new NotImplementedException();
        }
        
    }
}