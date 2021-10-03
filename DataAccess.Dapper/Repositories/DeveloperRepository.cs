using System.Collections.Generic;
using System.Data;
using Domain;

namespace DataAccess.Dapper.Repositories
{
    public class DeveloperRepository : RepositoryBase, IDeveloperRepository
    {
        public DeveloperRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            throw new System.NotImplementedException();
        }

        public Developer GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Developer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Developer entity)
        {
            throw new System.NotImplementedException();
        }

        public void AddRange(IEnumerable<Developer> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Developer entity)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Developer> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}