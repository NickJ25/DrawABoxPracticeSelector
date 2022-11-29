using DrawABoxPracticeSelector.Presentation.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems
{
    public class ConsoleMenuRedirectButton : IConsoleMenuRedirectButton
    {
        private Func<IConsoleMenuPage> _redirectAction;
        public string Title { get; }

        public string Id { get; }
        public bool IsSelectable { get; set; } = true;

        public ConsoleMenuRedirectButton(string id, string title, Func<IConsoleMenuPage> redirectAction)
        {
            Id = id;
            Title = title;
            _redirectAction = redirectAction;
        }

        public string ConsolePrint()
        {
            return $"[{Title}]";
        }

        public IConsoleMenuPage Redirect()
        {
            return _redirectAction.Invoke();
        }
    }
}
