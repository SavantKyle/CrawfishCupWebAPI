using System.Collections.Generic;
using Models.Entity;

namespace Service.Contracts.Services
{
    public interface IPlayerService
    {
        void InsertMany(IEnumerable<Player> player);
    }
}