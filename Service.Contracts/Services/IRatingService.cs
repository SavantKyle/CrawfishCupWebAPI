using System.Collections.Generic;
using Models.Entity;

namespace Service.Contracts.Services
{
    public interface IRatingService
    {
        IEnumerable<Rating> Get();
    }
}