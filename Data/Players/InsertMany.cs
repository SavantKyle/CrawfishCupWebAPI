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
                        {string.Join(" UNION ALL ", _players.Select(x =>
                        $@"select '{x.FirstName}' as FirstName, '{x.LastName}' as LastName, '{x.Email}' as Email, 
                        '{x.Phone}' as Phone, {x.RatingId} as RatingId, {x.TeamId} as TeamId"))}";

            commandQuery.Execute(sql, null);
        }
    }
}