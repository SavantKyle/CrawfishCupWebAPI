namespace DataProvider.Contracts
{
    public interface IQuery<out T>
    {
        T Execute(ICommandQuery commandQuery);
    }
}