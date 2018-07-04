using System.Data;
using System.Data.Entity;
using Domain.Entities.UnitOfWork;

namespace Domain.EF.UnitOfWork
{
    public class EntityFrameworkUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkUnitOfWorkFactory(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new EntityFrameworkUnitOfWork(_dbContext, isolationLevel);
        }
    }
}