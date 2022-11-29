namespace DrawABoxPracticeSelector.Presentation
{
    public interface IConsoleManager
    {
        void Clear();
        void Write(string text);
        void WriteLine(string text);
        string GetLine();
    }
}