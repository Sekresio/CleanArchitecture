using System.Data;

namespace DataAccess.Dapper.Repositories
{
    public abstract class RepositoryBase
    {
        protected IDbTransaction Transaction { get; }

        protected IDbConnection Connection => Transaction.Connection;

        protected RepositoryBase(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
    }
}