namespace ListProcessing.Bussiness.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    public class RollCommand : Command
    {
        public RollCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            if (this.Data[0].ToLower() == "left")
            {
                string firstItem = this.Items.First();

                for (int i = 0; i < this.Items.Count - 1; i++)
                {
                    this.Items[i] = this.Items[i + 1];
                }

                this.Items[this.Items.Count - 1] = firstItem;

                return string.Join(" ", this.Items);
            }
            else if (this.Data[0].ToLower() == "right")
            {
                return "DO RIGHT";
            }
            else
            {
                return "Error: invalid command parameters";
            }
        }
    }
}
