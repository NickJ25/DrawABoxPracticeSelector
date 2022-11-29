namespace DrawABoxPracticeSelector.Presentation
{
    public class ConsoleManager : IConsoleManager
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string GetLine()
        {
            return Console.ReadLine();
        }
    }
}
