namespace ListProcessing.IO
{
    using System;
    using IO.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void Write(string textToWrite, bool appendNewLine)
        {
            if (appendNewLine)
            {
                Console.WriteLine(textToWrite);
            }
            else
            {
                Console.Write(textToWrite);
            }
        }
    }
}