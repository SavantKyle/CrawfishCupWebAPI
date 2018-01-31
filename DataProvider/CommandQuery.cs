using System.Collections.Generic;
using System.Configuration;
using Dapper;
using DataProvider.Contracts;

namespace DataProvider
{
    public class CommandQuery: ICommandQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommandQuery()
        {
            _unitOfWork = new UnitOfWork(ConfigurationManager.ConnectionStrings["crawfishcup"].ConnectionString);
        }

        public CommandQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _unitOfWork.Transaction(transaction =>
            {
                var result = _unitOfWork.Connection.Query<T>(query, param, transaction);
                return result;
            });
        }

        public void Execute(string sql, object param)
        {
            _unitOfWork.Transaction(transaction => _unitOfWork.Connection.Execute(sql, param, transaction));
        }
    }
}