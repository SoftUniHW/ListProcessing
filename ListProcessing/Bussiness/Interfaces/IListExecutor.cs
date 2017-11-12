namespace ListProcessing.Bussiness.Interfaces
{
    using System.Collections.Generic;
    using IO.Interfaces;

    public interface IListExecutor
    {
        void ExecuteCommand(string[] input, List<string> items, IWriter writer);
    }
}