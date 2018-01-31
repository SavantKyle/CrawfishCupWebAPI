using System.Collections.Generic;
using System.Linq;
using Models.Domain;
using Models.Entity;
using Service.Contracts.Mappers;

namespace Services.Mappers
{
    public class PlayerMapper : IPlayerMapper
    {
        public IEnumerable<Player> Map(IEnumerable<PlayerDto> players, IEnumerable<Rating> ratings, int teamId)
        {
            return players.Select(x => new Player()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                RatingId = ratings.Single(y => x.Ntrp == y.Ntrp).Id,
                TeamId = teamId
            }); 
        }
    }
}