using System;
using System.Collections.Generic;
using System.Text;

namespace ListProcessing.Bussiness.Commands
{
    class DeleteCommand : Command
    {

        public DeleteCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            int index = int.Parse(this.Data[0]);

            if (index >= 0 && index <= this.Items.Count-1)
            {
                this.Items.RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"Error: invalid index {index}");
            }

            return string.Join(" ", this.Items);
        }
    }
}
