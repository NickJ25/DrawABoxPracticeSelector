using DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems;
using DrawABoxPracticeSelector.Presentation.Menus;

namespace DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems
{
    public class ConsoleMenuActionButton : IConsoleMenuActionButton
    {
        private Action _selectAction;
        public string Title { get; }

        public string Id { get; }
        public bool IsSelectable { get; set; } = true;

        public ConsoleMenuActionButton(string id, string title, Action selectAction)
        {
            Id = id;
            Title = title;
            _selectAction = selectAction;
        }

        public string ConsolePrint()
        {
            return $"[{Title}]";
        }

        public void Select()
        {
            _selectAction.Invoke();
        }
    }
}
