using System.Linq;
using DataProvider.Contracts;
using Models.Entity;

namespace Data.Teams
{
    public class Insert: IQuery<Team>
    {
        private readonly Team _team;
        public Insert(Team team)
        {
            _team = team;
        }

        Team IQuery<Team>.Execute(ICommandQuery commandQuery)
        {
            var sql = @"Insert into Teams (Gender, Name, RatingId) values (@Gender, @Name, @RatingId); 
                        select cast(scope_identity() as int)";

            _team.Id = commandQuery.Query<int>(sql, new { _team.Gender, _team.Name, _team.RatingId }).First();

            return _team;
        }
    }
}
