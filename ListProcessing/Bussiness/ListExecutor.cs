namespace ListProcessing.Bussiness
{
    using Bussiness.Interfaces;
    using IO.Interfaces;
    using System;

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

        
        public void ExecuteCommand(string commandName, IWriter writer)
        {
            string commandResult = this.CommandInterpreter.InterpredCommand(commandName);

            writer.Write(commandResult, true);
        }
    }
}
