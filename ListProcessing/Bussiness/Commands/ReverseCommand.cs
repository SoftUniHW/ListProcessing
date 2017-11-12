using System;
using System.Collections.Generic;
using System.Text;

namespace ListProcessing.Bussiness.Commands
{
    class ReverseCommand : Command
    {

        public ReverseCommand(List<string> items)
            : base(items)
        {
        }

        public override string Execute()
        {
            this.Items.Reverse();

            return string.Join(" ", this.Items);
        }
    }
    
}
