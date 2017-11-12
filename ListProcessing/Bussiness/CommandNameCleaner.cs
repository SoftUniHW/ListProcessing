namespace ListProcessing.Bussiness
{
    using System.Collections.Generic;
    using System.Linq;
    using Bussiness.Interfaces;

    public class CommandNameCleaner : ICommandNameCleaner
    {
        private IEnumerable<string> symbolsToRemove;

        public CommandNameCleaner(params string[] patternsToRemove)
        {
            this.symbolsToRemove = patternsToRemove.Distinct();
        }

        public string CleanCommandName(string commandName)
        {
            foreach (string patternToRemove in this.symbolsToRemove)
            {
                commandName = commandName.Replace(patternToRemove, string.Empty);
            }

            return commandName;
        }
    }
}