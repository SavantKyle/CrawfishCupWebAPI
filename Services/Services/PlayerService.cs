using System;
using System.Collections.Generic;
using Data.Players;
using DataProvider.Contracts;
using Models.Entity;
using Service.Contracts.Services;

namespace Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IDatabase _database;

        public PlayerService(IDatabase database)
        {
            _database = database;
        }

        public void InsertMany(IEnumerable<Player> players)
        {
            _database.Execute(new InsertMany(players));
        }
    }
}