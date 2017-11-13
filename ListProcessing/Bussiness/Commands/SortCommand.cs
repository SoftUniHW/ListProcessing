namespace ListProcessing.Bussiness.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    public class SortCommand : Command
    {
        public SortCommand(string[] data, List<string> items)
            : base(data, items)
        {
            return;
        }

        public override string Execute()
        {
            if (this.Data.Length == 0)
            {

                List<string> sortedList = this.Items.OrderBy(a => a).ToList();

                this.Items = sortedList;

                return string.Join(" ", this.Items);
            }
            else
            {
                return "Error: invalid command";
            }
        }
    }
}