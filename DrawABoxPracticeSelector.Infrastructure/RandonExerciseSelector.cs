
using DrawABoxPracticeSelector.Core;
namespace DrawABoxPracticeSelector.Application
{
    public class RandonExerciseSelector : IRandonExerciseSelector
    {
        IRandomNumberGenerator _randomNumberGenerator;

        public RandonExerciseSelector(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public IPracticeExercise? GetWeightedRandomActivity(IEnumerable<IPracticeExercise> _activities)
        {
            IPracticeExercise? output = null;
            float totalCurrentWeight = 0;

            // Calculate the total of all existing weights
            foreach (var activity in _activities)
            {
                totalCurrentWeight += activity.CurrentWeight;
            }

            if (totalCurrentWeight > 0)
            {
                _randomNumberGenerator.SetSeed(Guid.NewGuid().GetHashCode());

                // Multiply by 100 so decimal isn't trauncated.
                int randomNumber = _randomNumberGenerator.Next(0, (int)(totalCurrentWeight * 100) + 1);

                float currentWeight = randomNumber * 0.01f;
                for (int i = 0; i < _activities.Count(); i++)
                {
                    currentWeight -= _activities.ElementAt(i).CurrentWeight;
                    if (currentWeight <= 0)
                    {
                        return _activities.ElementAt(i);
                    }
                }
            }

            return output;
        }

    }


}
