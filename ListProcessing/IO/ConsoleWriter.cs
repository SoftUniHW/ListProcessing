namespace ListProcessing.IO
{
    using IO.Interfaces;
    using System;

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
