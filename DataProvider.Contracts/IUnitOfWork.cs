using System;
using System.Data;

namespace DataProvider.Contracts
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
        T Transaction<T>(Func<IDbTransaction, T> query);
        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();
    }
}