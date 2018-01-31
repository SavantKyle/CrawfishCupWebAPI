namespace DataProvider.Contracts
{
    public interface ICommand
    {
        void Execute(ICommandQuery commandQuery);
    }
}