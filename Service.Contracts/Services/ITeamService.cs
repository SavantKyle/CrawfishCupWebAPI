using System.Collections.Generic;
using Models.Entity;

namespace Service.Contracts.Services
{
    public interface ITeamService
    {
        Team Insert(Team team);
    }
}