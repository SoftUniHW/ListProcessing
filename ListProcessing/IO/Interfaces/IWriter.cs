namespace ListProcessing.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string textToWrite, bool appendNewLine);
    }
}
