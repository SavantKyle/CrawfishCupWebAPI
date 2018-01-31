using System.Collections.Generic;
using System.Linq;
using Models.Domain;
using Models.Entity;
using Service.Contracts.Mappers;

namespace Services.Mappers
{
    public class TeamMapper : ITeamMapper
    {
        public Team Map(TeamWithPlayers teamWithPlayers, IEnumerable<Rating> ratings)
        {
            return new Team()
            {
                Name = teamWithPlayers.Name,
                Gender = teamWithPlayers.Gender,
                RatingId = ratings.Single(x => x.Ntrp == teamWithPlayers.Ntrp).Id
            };
        }
    }
}