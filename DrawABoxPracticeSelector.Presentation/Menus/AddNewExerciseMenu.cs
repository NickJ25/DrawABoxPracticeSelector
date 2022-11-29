using DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawABoxPracticeSelector.Presentation.Menus
{
    public class AddNewExerciseMenu : IConsoleMenuPage
    {
        public ConsoleMenu consoleMenu { get; }

        public AddNewExerciseMenu()
        {
            List<IConsoleMenuItem> consoleMenuItems = new List<IConsoleMenuItem>();
            consoleMenuItems.Add(new ConsoleMenuText("mainMenuText", "~~~ Add New Exercise ~~~"));
            consoleMenuItems.Add(new ConsoleMenuText("mainMenuText", "Exercise Name:"));
            consoleMenuItems.Add(new ConsoleMenuInput("exerciseNameInput"));
            consoleMenuItems.Add(new ConsoleMenuText("mainMenuText", "Exercise Description:"));
            consoleMenuItems.Add(new ConsoleMenuInput("exerciseDescriptionInput"));
            consoleMenuItems.Add(new ConsoleMenuText("mainMenuText", "Exercise Weight:"));
            consoleMenuItems.Add(new ConsoleMenuInput("exerciseWeightInput"));
            consoleMenuItems.Add(new ConsoleMenuActionButton("createButton", "Create Exercise", CreateExercise));
            //consoleMenuItems.Add(new ConsoleMenuActionButton("addNewExerciseButton", "Add New Exercise", OpenAddNewExerciseMenu));
            consoleMenuItems.Add(new ConsoleMenuText("gap", "~~~~~~"));
            consoleMenuItems.Add(new ConsoleMenuRedirectButton("backButton", "Back", ReturnToMainMenu));

            consoleMenu = new ConsoleMenu("mainMenu", consoleMenuItems, new ConsoleManager());
        }

        private void CreateExercise()
        {
            IConsoleMenuItem? exerciseNameInput = consoleMenu.FindConsoleMenuItemById("exerciseNameInput");
            IConsoleMenuItem? exerciseDescriptionInput = consoleMenu.FindConsoleMenuItemById("exerciseDescriptionInput");
            IConsoleMenuItem? exerciseWeightInput = consoleMenu.FindConsoleMenuItemById("exerciseWeightInput");

            string exerciseName = exerciseNameInput == null ? string.Empty : ((IConsoleMenuInput)exerciseNameInput).InputText;
            string exerciseDescription = exerciseDescriptionInput == null ? string.Empty : ((IConsoleMenuInput)exerciseDescriptionInput).InputText;
            float exerciseWeight = exerciseWeightInput == null ? 1 : float.Parse(((IConsoleMenuInput)exerciseWeightInput).InputText, CultureInfo.InvariantCulture.NumberFormat);

            int freeId = 0;
            int[] idList = ApplicationProperties.exerciseManagerService.GetAllExercisesId();
            bool idFound = false;
            while (!idFound) {
                idFound = true;

                for (int i = 0; i < idList.Length; i++)
                {
                    if (idList[i] == freeId)
                    {
                        idFound = false;
                        freeId++;
                        break;
                    }
                }
            }

            ApplicationProperties.exerciseManagerService.AddExercise(freeId, exerciseName, exerciseDescription, exerciseWeight, exerciseWeight);
            ((IConsoleMenuInput)exerciseNameInput).InputText = "";
            ((IConsoleMenuInput)exerciseDescriptionInput).InputText = "";
        }

        private IConsoleMenuPage ReturnToMainMenu()
        {
            return new MainMenuPage();
        }
    }
}
