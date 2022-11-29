namespace DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems
{
    public class ConsoleMenuInput : IConsoleMenuInput
    {
        public string InputText { get; set; } = string.Empty;

        public bool IsSelectable { get; } = true;

        public string Id { get; }

        public ConsoleMenuInput(string id)
        {
            Id = id;
        }

        public string ConsolePrint()
        {
            return $">{InputText}";
        }
    }
}
