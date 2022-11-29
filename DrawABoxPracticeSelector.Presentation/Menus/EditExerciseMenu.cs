using DrawABoxPracticeSelector.Presentation.ConsoleUI.ConsoleMenu.ConsoleMenuItems;

namespace DrawABoxPracticeSelector.Presentation.Menus
{
    internal class EditExerciseMenu : IConsoleMenuPage
    {
        public ConsoleMenu consoleMenu { get; }

        private IConsoleMenuInput? exerciseNameInput;
        private IConsoleMenuInput? exerciseDescriptionInput;
        private IConsoleMenuInput? exerciseWeightInput;
        private int _exerciseId;

        public EditExerciseMenu(int exerciseId)
        {
            _exerciseId = exerciseId;
            List<IConsoleMenuItem> consoleMenuItems = new List<IConsoleMenuItem>();
            consoleMenuItems.Add(new ConsoleMenuText("editMenuText", $"~~~ Edit Exercise ~~~"));
            consoleMenuItems.Add(new ConsoleMenuText("editMenuText", "Exercise Name:"));
            consoleMenuItems.Add(new ConsoleMenuInput("exerciseNameInput"));
            consoleMenuItems.Add(new ConsoleMenuText("editMenuText", "Exercise Description:"));
            consoleMenuItems.Add(new ConsoleMenuInput("exerciseDescriptionInput"));
            consoleMenuItems.Add(new ConsoleMenuText("editMenuText", "Exercise Weight:"));
            consoleMenuItems.Add(new ConsoleMenuInput("exerciseWeightInput"));
            consoleMenuItems.Add(new ConsoleMenuActionButton("applyButton", "Apply Changes", ApplyChanges));
            //consoleMenuItems.Add(new ConsoleMenuActionButton("addNewExerciseButton", "Add New Exercise", OpenAddNewExerciseMenu));
            consoleMenuItems.Add(new ConsoleMenuText("gap", "~~~~~~"));
            consoleMenuItems.Add(new ConsoleMenuRedirectButton("backButton", "Back", ReturnToViewer));

            consoleMenu = new ConsoleMenu("mainMenu", consoleMenuItems, new ConsoleManager());
            exerciseNameInput = (IConsoleMenuInput?)consoleMenu.FindConsoleMenuItemById("exerciseNameInput");
            exerciseDescriptionInput = (IConsoleMenuInput?)consoleMenu.FindConsoleMenuItemById("exerciseDescriptionInput");
            exerciseWeightInput = (IConsoleMenuInput?)consoleMenu.FindConsoleMenuItemById("exerciseWeightInput");

            exerciseNameInput.InputText = ApplicationProperties.exerciseManagerService.GetExerciseNameById(exerciseId);
            exerciseDescriptionInput.InputText = ApplicationProperties.exerciseManagerService.GetExerciseDescriptionById(exerciseId);
            exerciseWeightInput.InputText = ApplicationProperties.exerciseManagerService.GetExerciseWeightById(exerciseId).ToString("0.00");
        }

        private void ApplyChanges()
        {
            ApplicationProperties.exerciseManagerService.SetExerciseName(_exerciseId, exerciseNameInput.InputText);
            ApplicationProperties.exerciseManagerService.SetExerciseDescription(_exerciseId, exerciseDescriptionInput.InputText);
            ApplicationProperties.exerciseManagerService.SetExerciseWeight(_exerciseId, float.Parse(exerciseWeightInput.InputText));
        }

        private IConsoleMenuPage ReturnToViewer()
        {
            return new ViewExerciseMenu();
        }
    }
}
