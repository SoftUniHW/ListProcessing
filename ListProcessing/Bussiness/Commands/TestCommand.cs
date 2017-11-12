namespace ListProcessing.Bussiness.Commands
{
    using Bussiness.Commands.Interfaces;

    public class TestCommand : ICommand
    {
        public string Execute()
        {
            return "WORK";
        }
    }
}
