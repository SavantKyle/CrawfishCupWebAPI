using System.Collections.Generic;
using Models.Domain;
using Models.Entity;

namespace Service.Contracts.Mappers
{
    public interface IPlayerMapper
    {
        IEnumerable<Player> Map(IEnumerable<PlayerDto> players, IEnumerable<Rating> ratings, int teamId);
    }
}