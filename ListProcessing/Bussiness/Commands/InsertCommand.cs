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
            if (this.Data.Length < 2 || this.Data.Length > 2)
            {
                return "Error: invalid command parameters";
            }

            int index = int.Parse(this.Data[0]);
            string text = this.Data[1];

            if (index < 0 || index > this.Items.Count)
            {
                return $"Error: invalid index {index}";
            }
            else if (string.IsNullOrEmpty(text))
            {
                return "Error: invalid command parameters";
            }
            else
            {
                this.Items.Insert(index, text);

                return string.Join(" ", this.Items);
            }
        }
    }
}