using DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems;
using DrawABoxPracticeSelector.Presentation.Menus;

namespace DrawABoxPracticeSelector.Presentation
{
    public class ConsoleMenu
    {
        int _currentItemNum = 0;
        string _title = string.Empty;
        bool _IsCursorPresent = true;
        IEnumerable<IConsoleMenuItem> _items;
        IConsoleManager _manager;

        public ConsoleMenu(string menuTitle, IEnumerable<IConsoleMenuItem> items, IConsoleManager consoleManager)
        {
            _title = menuTitle;
            _items = items;
            _manager = consoleManager;
        }

        public void Open()
        {
            _IsCursorPresent = DoesCursorExist();
            WriteMenuToConsole();
        }

        public void Up()
        {
            if (_IsCursorPresent)
            {
                if (_items.Count() > 1)
                {
                    _currentItemNum--;
                    _currentItemNum = MenuNumberClamp(_currentItemNum);

                    do
                    {
                        if (_items.ElementAt(_currentItemNum).IsSelectable == false)
                        {
                            _currentItemNum--;
                        }
                        _currentItemNum = MenuNumberClamp(_currentItemNum);
                    }
                    while (_items.ElementAt(_currentItemNum).IsSelectable == false);
                }
                WriteMenuToConsole();
            }
        }

        public void Down()
        {
            if (_IsCursorPresent)
            {
                if (_items.Count() > 1)
                {
                    _currentItemNum++;
                    _currentItemNum = MenuNumberClamp(_currentItemNum);

                    do
                    {
                        if(_items.ElementAt(_currentItemNum).IsSelectable == false)
                        {
                            _currentItemNum++;
                        }
                        _currentItemNum = MenuNumberClamp(_currentItemNum);
                    }
                    while(_items.ElementAt(_currentItemNum).IsSelectable == false);                    
                }
                WriteMenuToConsole();
            }
        }

        private int MenuNumberClamp(int itemNumber)
        {
            if (itemNumber >= _items.Count())
            {
                return 0;
            }
            if (itemNumber < 0)
            {
                return _items.Count() - 1;
            }
            return itemNumber;
        }

        public IConsoleMenuPage? Select()
        {
            var selectedItem = _items.ElementAt(_currentItemNum);
            if (selectedItem is IConsoleMenuRedirectButton)
            {
                return ((IConsoleMenuRedirectButton)selectedItem).Redirect();
            }

            if (selectedItem is IConsoleMenuActionButton)
            {
                ((IConsoleMenuActionButton)selectedItem).Select();
            }
            
            if (selectedItem is IConsoleMenuInput)
            {
                ((IConsoleMenuInput)selectedItem).InputText = _manager.GetLine();
                WriteMenuToConsole();
            }

            return null;
        }

        private void WriteMenuToConsole()
        {
            _manager.Clear();
            for(int i = 0; i < _items.Count(); i++)
            {
                if(i == _currentItemNum)
                {
                    _manager.Write("-> ");
                } else
                {
                    _manager.Write("   ");
                }

                Console.WriteLine(_items.ElementAt(i).ConsolePrint());
            }
        }

        private bool DoesCursorExist()
        {
            foreach(var item in _items)
            {
                if(item.IsSelectable)
                    return true;
            }
            return false;
        }

        public IConsoleMenuItem? FindConsoleMenuItemById(string Id)
        {
            foreach(IConsoleMenuItem item in _items)
            {
                if(item.Id == Id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
