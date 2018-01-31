using System.Collections.Generic;
using Data.Ratings;
using DataProvider.Contracts;
using Models.Entity;
using Service.Contracts.Services;

namespace Services.Services
{
    public class RatingService : IRatingService
    {
        private readonly IDatabase _database;

        public RatingService(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Rating> Get()
        {
            return _database.Query(new GetAll());
        }
    }
}