namespace DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems
{
    internal class ConsoleMenuText : IConsoleMenuText
    {
        public string Text { get; set; }

        public string Id { get; }

        public bool IsSelectable { get; } = false;

        public ConsoleMenuText(string id, string text)
        {
            Id = id;
            Text = text;
        }
        public string ConsolePrint()
        {
            return Text;
        }
    }
}
