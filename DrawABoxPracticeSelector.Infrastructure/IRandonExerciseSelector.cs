using DrawABoxPracticeSelector.Core;

namespace DrawABoxPracticeSelector.Application
{
    public interface IRandonExerciseSelector
    {
        IPracticeExercise? GetWeightedRandomActivity(IEnumerable<IPracticeExercise> _activities);
    }
}