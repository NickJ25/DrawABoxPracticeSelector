using DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems;

namespace DrawABoxPracticeSelector.Presentation.Menus
{
    public class RandomExerciseMenu : IConsoleMenuPage
    {
        public ConsoleMenu consoleMenu { get; }

        public RandomExerciseMenu()
        {
            int randomExerciseId = ApplicationProperties.exerciseManagerService.GetRandomExerciseId();
            List<IConsoleMenuItem> consoleMenuItems = new List<IConsoleMenuItem>();
            consoleMenuItems.Add(new ConsoleMenuText("randomExerciseTitleText", "~~~ Random Exercise ~~~"));
            consoleMenuItems.Add(new ConsoleMenuText("randomExerciseText", ApplicationProperties.exerciseManagerService.GetExerciseNameById(randomExerciseId)));
            consoleMenuItems.Add(new ConsoleMenuText("randomExerciseText", ApplicationProperties.exerciseManagerService.GetExerciseDescriptionById(randomExerciseId)));
            consoleMenuItems.Add(new ConsoleMenuRedirectButton("backButton", "Back", ReturnToMainMenu));

            consoleMenu = new ConsoleMenu("randomExerciseMenu", consoleMenuItems, new ConsoleManager());
        }

        private IConsoleMenuPage ReturnToMainMenu()
        {
            return new MainMenuPage();
        }
    }
}
