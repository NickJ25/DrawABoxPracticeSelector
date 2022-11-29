using DrawABoxPracticeSelector.Core;

namespace DrawABoxPracticeSelector.Application
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        Random randomNumberGenerator;

        public RandomNumberGenerator()
        {
            randomNumberGenerator = new Random();
        }
        public int Next(int minValue, int maxValue)
        {
            return randomNumberGenerator.Next(minValue, maxValue);
        }

        public void SetSeed(int seed)
        {
           randomNumberGenerator = new Random(seed);
        }
    }
}
