using DrawABoxPracticeSelector.Application;
using DrawABoxPracticeSelector.Infrastructure;
namespace DrawABoxPracticeSelector.Presentation
{
    public static class ApplicationProperties
    {
        public static bool QuitApplication = false;
        public static ExerciseManagerService exerciseManagerService = new ExerciseManagerService(new RandonExerciseSelector(new RandomNumberGenerator()));
    }
}
