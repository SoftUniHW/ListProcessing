namespace ListProcessing.IO
{
    using IO.Interfaces;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
