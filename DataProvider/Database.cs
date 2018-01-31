using DataProvider.Contracts;

namespace DataProvider
{
    public class Database : IDatabase
    {
        private readonly ICommandQuery _commandQuery;

        public Database(ICommandQuery commandQuery)
        {
            _commandQuery = commandQuery;
        }

        public T Query<T>(IQuery<T> query)
        {
            return query.Execute(_commandQuery);
        }

        public void Execute(ICommand command)
        {
            command.Execute(_commandQuery);
        }
    }
}