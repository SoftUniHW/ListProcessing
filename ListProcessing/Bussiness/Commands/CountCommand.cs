namespace ListProcessing.Bussiness.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    public class CountCommand : Command
    {
        public CountCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            string wordToFind = this.Data[0];

            var count = this.Items.Where(a => a == wordToFind).Count();

            return count.ToString();
        }
    }
}