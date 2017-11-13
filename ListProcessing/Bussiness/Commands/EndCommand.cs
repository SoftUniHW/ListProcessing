using System;
using System.Collections.Generic;
using System.Text;

namespace ListProcessing.Bussiness.Commands
{
    class EndCommand : Command
    {
        public EndCommand(string[] data, List<string> items) 
            : base(data, items)
        {
        }

        public override string Execute()
        {
            if (this.Data.Length == 0)
            {
                Console.WriteLine("Finished");
                Environment.Exit(0);
            }
            else
            {
                return "Error: invalid command parameters";
            }
            
            return "";
        }
    }
}
