namespace ListProcessing.IO
{
    using System;
    using IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}