using DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems;

namespace DrawABoxPracticeSelector.Presentation.Menus
{
    public class ViewExerciseMenu : IConsoleMenuPage
    {
        public ConsoleMenu consoleMenu { get; }

        public ViewExerciseMenu()
        {
            List<IConsoleMenuItem> consoleMenuItems = new List<IConsoleMenuItem>();
            consoleMenuItems.Add(new ConsoleMenuText("viewExerciseText", "~~~ Exercise(s) ~~~"));
            int[] exerciseIds = ApplicationProperties.exerciseManagerService.GetAllExercisesId();
            if (exerciseIds.Length > 0)
            {
                for(int i = 0; i < exerciseIds.Length; i++)
                {
                    string exerciseButtonTitle = $"[{exerciseIds[i]}] {ApplicationProperties.exerciseManagerService.GetExerciseNameById(i)}, {ApplicationProperties.exerciseManagerService.GetExerciseDescriptionById(i)}";
                    consoleMenuItems.Add(new ConsoleMenuActionParamButton<int>($"exerciseButton{exerciseIds[i]}", exerciseButtonTitle, EditExercise, exerciseIds[i]));
                }
            } else
            {
                consoleMenuItems.Add(new ConsoleMenuText("noExercisesText", "No Exercises Added!"));
            }
            consoleMenuItems.Add(new ConsoleMenuRedirectButton("backButton", "Back", ReturnToMainMenu));

            consoleMenu = new ConsoleMenu("mainMenu", consoleMenuItems, new ConsoleManager());
        }

        private IConsoleMenuPage EditExercise(int exerciseId)
        {
            return 
        }

        private IConsoleMenuPage ReturnToMainMenu()
        {
            return new MainMenuPage();
        }

    }
}
