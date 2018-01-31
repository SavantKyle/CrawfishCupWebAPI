using Models.Domain;

namespace Facade.Contracts
{
    public interface IRegisterFacade
    {
        void RegisterTeam(TeamWithPlayers teamWithPlayers);
    }
}