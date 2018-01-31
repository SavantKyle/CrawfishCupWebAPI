using System.Collections.Generic;

namespace Models.Domain
{
    public class TeamWithPlayers
    {
        public string Name { get; set; }
        public string Ntrp { get; set; }
        public string Gender { get; set; }
        public IEnumerable<PlayerDto> Players { get; set; }
    }
}