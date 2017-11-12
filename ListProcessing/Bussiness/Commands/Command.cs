namespace ListProcessing.Bussiness.Commands
{
    using System.Collections.Generic;
    using ListProcessing.Bussiness.Commands.Interfaces;

    public abstract class Command : ICommand
    {
        public Command(List<string> items)
        {
            this.Items = items;
        }

        public Command(string[] data, List<string> items)
        {
            this.Data = data;
            this.Items = items;
        }

        public string[] Data { get; set; }

        public List<string> Items { get; set; }

        public abstract string Execute();
    }
}