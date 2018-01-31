using System;
using System.Collections.Generic;
using Data.Teams;
using DataProvider.Contracts;
using Models.Entity;
using Service.Contracts.Services;

namespace Services.Services
{
    public class TeamService : ITeamService
    {
        private readonly IDatabase _database;

        public TeamService(IDatabase database)
        {
            _database = database;
        }

        public Team Insert(Team team)
        {
            return _database.Query(new Insert(team));
        }
    }
}