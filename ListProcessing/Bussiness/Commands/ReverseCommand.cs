namespace ListProcessing.Bussiness.Commands
{
    using System.Collections.Generic;

    public class ReverseCommand : Command
    {
        public ReverseCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            this.Items.Reverse();

            return string.Join(" ", this.Items);
        }
    }  
}
