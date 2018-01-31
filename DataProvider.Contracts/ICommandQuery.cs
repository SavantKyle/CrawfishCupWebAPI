using System.Collections.Generic;

namespace DataProvider.Contracts
{
    public interface ICommandQuery
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string sql, object param);
    }
}