namespace DrawABoxPracticeSelector.Presentation
{
    public interface IConsoleMenuItem
    {
        string Id { get; }
        bool IsSelectable { get; }

        public string ConsolePrint();
    }
}