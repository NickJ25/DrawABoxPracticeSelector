using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems
{
    public interface IConsoleMenuActionParamButton<T> : IConsoleMenuItem
    {
        string Title { get; }
        public void Select();
    }

}
