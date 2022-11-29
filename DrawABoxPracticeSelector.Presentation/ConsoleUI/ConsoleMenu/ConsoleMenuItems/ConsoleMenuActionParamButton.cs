using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems
{
    public class ConsoleMenuActionParamButton<T> : IConsoleMenuActionParamButton<T>
    {
        private Action<T> _action;
        private T _functionParameter;
        public string Title { get; }

        public string Id { get; }
        public bool IsSelectable { get; set; } = true;

        public ConsoleMenuActionParamButton(string id, string title, Action<T> function, T functionParameter)
        {
            Id = id;
            Title = title;
            _action = function;
            _functionParameter = functionParameter;
        }

        public void Select()
        {
            _action(_functionParameter);
        }

        public string ConsolePrint()
        {
            return $"[{Title}]";
        }
    }
}
