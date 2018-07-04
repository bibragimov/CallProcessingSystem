using System;
using System.Data;
using System.Data.Entity;
using Domain.Entities.UnitOfWork;

namespace Domain.EF.UnitOfWork
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly DbContextTransaction _transaction;

        public EntityFrameworkUnitOfWork(DbContext dbContext, IsolationLevel isolationLevel)
        {
            _dbContext = dbContext;
            _transaction = dbContext.Database.BeginTransaction(isolationLevel);
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();

            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}