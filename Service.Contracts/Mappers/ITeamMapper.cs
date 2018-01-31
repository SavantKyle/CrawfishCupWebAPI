using System.Collections.Generic;
using Models.Domain;
using Models.Entity;

namespace Service.Contracts.Mappers
{
    public interface ITeamMapper
    {
        Team Map(TeamWithPlayers teamWithPlayers, IEnumerable<Rating> ratings);
    }
}