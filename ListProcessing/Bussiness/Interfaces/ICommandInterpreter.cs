using System.Collections.Generic;

namespace ListProcessing.Bussiness.Interfaces
{
    public interface ICommandInterpreter
    {
        string InterpredCommand(string commandName, List<string> items, string[] input);
    }
}