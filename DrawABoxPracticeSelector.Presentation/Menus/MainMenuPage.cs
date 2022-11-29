using DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawABoxPracticeSelector.Presentation.Menus
{
    public class MainMenuPage : IConsoleMenuPage
    {
        public ConsoleMenu consoleMenu { get; }

        public MainMenuPage()
        {
            List<IConsoleMenuItem> consoleMenuItems = new List<IConsoleMenuItem>();
            consoleMenuItems.Add(new ConsoleMenuText("mainMenuText", "~~~ Main Menu ~~~"));
            consoleMenuItems.Add(new ConsoleMenuRedirectButton("addNewExerciseButton", "Add New Exercise", OpenAddNewExerciseMenu));
            consoleMenuItems.Add(new ConsoleMenuRedirectButton("viewExercisesButton", "View all Exercise(s)", OpenViewExerciseMenu));
            consoleMenuItems.Add(new ConsoleMenuRedirectButton("randomExerciseButton", "Get a Random Exercise", OpenRandomExerciseMenu));
            consoleMenuItems.Add(new ConsoleMenuActionButton("quitButton", "Quit", QuitApplication));

            consoleMenu = new ConsoleMenu("mainMenu", consoleMenuItems, new ConsoleManager());
        }

        private IConsoleMenuPage OpenAddNewExerciseMenu()
        {
            return new AddNewExerciseMenu();
        }

        private IConsoleMenuPage OpenViewExerciseMenu()
        {
            return new ViewExerciseMenu();
        }

        private IConsoleMenuPage OpenRandomExerciseMenu()
        {
            return new RandomExerciseMenu();
        }

        private void QuitApplication()
        {
           ApplicationProperties.QuitApplication = true;
        }
    }
}
