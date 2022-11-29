namespace DrawABoxPracticeSelector.Infrastructure.Exceptions
{
    public class ExerciseNotFound : Exception
    {
        public ExerciseNotFound(string exercise) : base($"Exercise {exercise} was not be found.")
        {
        }

        public ExerciseNotFound(int exerciseId) : base($"Exercise Id {exerciseId} was not be found.")
        {
        }
    }
}
