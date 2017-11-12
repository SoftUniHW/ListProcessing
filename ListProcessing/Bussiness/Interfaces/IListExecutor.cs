namespace ListProcessing.Bussiness.Interfaces
{
    using IO.Interfaces;

    public interface IListExecutor
    {
        void ExecuteCommand(string commandName, IWriter writer);
    }
}
