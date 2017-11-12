namespace ListProcessing.Bussiness.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SortCommand : Command
    {
        public SortCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            List<string> sortedList = this.Items.OrderBy(a => a).ToList();

            this.Items = sortedList;

            return string.Join(" ", this.Items);
        }
    }
}