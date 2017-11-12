namespace ListProcessing.Bussiness.Commands
{
    using System.Collections.Generic;

    public class InsertCommand : Command
    {
        public InsertCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            int index = int.Parse(this.Data[0]);
            string text = this.Data[1];

            this.Items.Insert(index, text);

            return string.Join(" ", this.Items);
        }
    }
}