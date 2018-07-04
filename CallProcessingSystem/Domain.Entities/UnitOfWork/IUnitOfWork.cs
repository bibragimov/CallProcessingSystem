using System;

namespace Domain.Entities.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Rollback();
        void Commit();
    }
}