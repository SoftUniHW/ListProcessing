namespace ListProcessing
{
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
            string commandName = reader.ReadLine();

            excerciseExecutor.ExecuteCommand(commandName, writer);
        }
    }
}
