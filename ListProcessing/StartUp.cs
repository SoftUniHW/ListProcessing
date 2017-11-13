namespace ListProcessing
{
    using System;
    using System.Collections.Generic;
    using Bussiness;
    using Bussiness.Interfaces;
    using IO;
    using IO.Interfaces;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] patternsToRemove = new[] { " ", "\t" };
            ICommandNameCleaner commandNameCleaner = new CommandNameCleaner(patternsToRemove);
            ICommandInterpreter commandInterpreter = new CommandInterpreter(commandNameCleaner);

            IListExecutor excerciseExecutor = new ListExecutor(commandInterpreter);

            IWriter writer = new ConsoleWriter();
            List<string> items = InputStringCreator();
            IReader reader = new ConsoleReader();

            while (true)
            {
                try
                {
                    string[] input = reader.ReadLine().Split(' ');

                    excerciseExecutor.ExecuteCommand(input, items, writer);
                }
                catch (Exception)
                {
                    writer.Write("Error: invalid command", true);
                }
            }
        }

        private static List<string> InputStringCreator()
        {
            IReader reader = new ConsoleReader();
            List<string> listOfStrings = reader.ReadLine().Split(' ').ToList();

            return listOfStrings;
        }
    }
}