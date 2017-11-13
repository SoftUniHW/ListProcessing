namespace ListProcessing.Bussiness.Commands
{
    using System;
    using System.Collections.Generic;

    public class DeleteCommand : Command
    {
        public DeleteCommand(string[] data, List<string> items)
            : base(data, items)
        {
        }

        public override string Execute()
        {
            int result;

            if (this.Data.Length == 1 && int.TryParse(this.Data[0], out result) == true)
            {
                int index = int.Parse(this.Data[0]);
                if (index >= 0 && index <= this.Items.Count - 1)
                {
                    this.Items.RemoveAt(index);
                    return string.Join(" ", this.Items);
                }
                else
                {
                    return $"Error: invalid index {index}";
                }
            }
            else
            {
                return "Error: invalid command parameters";
            }              
        }
    }
}
