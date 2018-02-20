using System.Collections.Generic;
using System.Linq;
using DataProvider.Contracts;
using Models.Entity;

namespace Data.Players
{
    public class InsertMany : ICommand
    {
        private readonly IEnumerable<Player> _players;

        public InsertMany(IEnumerable<Player> players)
        {
            _players = players;
        }

        public void Execute(ICommandQuery commandQuery)
        {
            var sql = $@"Insert into Players (FirstName, LastName, Email, Phone, RatingId, TeamId)
                        values (@FirstName, @LastName, @Email, @Phone, @RatingId, @TeamId)";

            commandQuery.Execute(sql, _players);
        }
    }
}