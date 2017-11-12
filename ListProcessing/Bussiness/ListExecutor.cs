namespace ListProcessing.Bussiness
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bussiness.Interfaces;
    using IO.Interfaces;

    public class ListExecutor : IListExecutor
    {
        private ICommandInterpreter commandInterpreter;

        public ListExecutor(ICommandInterpreter commandInterpreter)
        {
            this.CommandInterpreter = commandInterpreter;
        }

        private ICommandInterpreter CommandInterpreter
        {
            get
            {
                return this.commandInterpreter;
            }

            set
            {
                this.ThrowExceptionIfObjectIsNull(value);
                this.commandInterpreter = value;
            }
        }

        private void ThrowExceptionIfObjectIsNull<T>(T value) where T : class
        {
            if (value == default(T))
            {
                throw new ArgumentNullException();
            }
        }

        public void ExecuteCommand(string[] input, List<string> items, IWriter writer)
        {
            string commandName = input[0];
            string[] data = input.Skip(1).ToArray();

            string commandResult = this.CommandInterpreter.InterpredCommand(commandName, items, data);

            writer.Write(commandResult, true);
        }
    }
}