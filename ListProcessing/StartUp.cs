namespace ListProcessing
{
    using System.Collections.Generic;
    using Bussiness;
    using Bussiness.Interfaces;
    using IO;
    using IO.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            string[] patternsToRemove = new[] { " ", "\t" };
            ICommandNameCleaner commandNameCleaner = new CommandNameCleaner(patternsToRemove);
            ICommandInterpreter commandInterpreter = new CommandInterpreter(commandNameCleaner);

            IListExecutor excerciseExecutor = new ListExecutor(commandInterpreter);

            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            List<string> items = new List<string>() { "space", "separated", "list", "of", "items" };
            string[] input = reader.ReadLine().Split(' ');

            excerciseExecutor.ExecuteCommand(input, items, writer);
        }
    }
}