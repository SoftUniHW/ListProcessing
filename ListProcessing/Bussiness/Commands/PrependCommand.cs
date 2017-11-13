using System;
using System.Collections.Generic;
using System.Text;

namespace ListProcessing.Bussiness.Commands
{
    public class PrependCommand:Command
    {
        public PrependCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            string text = this.Data[0];

            this.Items.Insert(0, text);

            return string.Join(" ", this.Items);
        }
    }
}
