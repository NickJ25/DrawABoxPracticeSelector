// See https://aka.ms/new-console-template for more information
using DrawABoxPracticeSelector.Presentation;
using DrawABoxPracticeSelector.Presentation.Menus;

MainMenuPage mainMenuPage = new MainMenuPage();
ConsoleMenu currentMenu = mainMenuPage.consoleMenu;

currentMenu.Open();
while(!ApplicationProperties.QuitApplication)
{
    ConsoleKey consoleKey = Console.ReadKey().Key;
    if (consoleKey == ConsoleKey.UpArrow)
    {
        currentMenu.Up();
    }

    if (consoleKey == ConsoleKey.DownArrow)
    {
        currentMenu.Down();
    }

    if (consoleKey == ConsoleKey.Enter)
    {
        IConsoleMenuPage? consoleMenuPage;
        consoleMenuPage = currentMenu.Select();
        if(consoleMenuPage != null)
        {
            currentMenu = consoleMenuPage.consoleMenu;
            currentMenu.Open();
        }
    }
}

