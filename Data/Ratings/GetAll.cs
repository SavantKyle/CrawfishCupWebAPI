using System.Collections.Generic;
using DataProvider.Contracts;
using Models.Entity;

namespace Data.Ratings
{
    public class GetAll : IQuery<IEnumerable<Rating>>
    {
        public IEnumerable<Rating> Execute(ICommandQuery commandQuery)
        {
            return commandQuery.Query<Rating>("select * from Ratings");
        }
    }
}