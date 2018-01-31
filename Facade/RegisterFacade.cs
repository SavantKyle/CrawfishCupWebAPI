using System.Linq;
using Facade.Contracts;
using Models.Domain;
using Service.Contracts.Mappers;
using Service.Contracts.Services;

namespace Facade
{
    public class RegisterFacade : IRegisterFacade
    {
        private readonly IRatingService _ratingService;
        private readonly ITeamMapper _teamMapper;
        private readonly IPlayerMapper _playerMapper;
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public RegisterFacade(IRatingService ratingService, ITeamMapper teamMapper,
            IPlayerMapper playerMapper, ITeamService teamService, IPlayerService playerService)
        {
            _ratingService = ratingService;
            _teamMapper = teamMapper;
            _playerMapper = playerMapper;
            _teamService = teamService;
            _playerService = playerService;
        }

        public void RegisterTeam(TeamWithPlayers teamWithPlayers)
        {
            var ratings = _ratingService.Get().ToList();

            var team = _teamMapper.Map(teamWithPlayers, ratings);
            var teamId = _teamService.Insert(team).Id;

            var players = _playerMapper.Map(teamWithPlayers.Players, ratings, teamId);
            _playerService.InsertMany(players);
        }
    }
}