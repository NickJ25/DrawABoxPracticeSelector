using DrawABoxPracticeSelector.Presentation.Menus;

namespace DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems
{
    public interface IConsoleMenuRedirectButton : IConsoleMenuItem
    {
        public string Title { get; }
        public IConsoleMenuPage Redirect();

    }
}
