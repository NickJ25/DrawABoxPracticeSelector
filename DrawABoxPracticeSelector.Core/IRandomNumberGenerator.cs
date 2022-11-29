using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawABoxPracticeSelector.Core
{
    public interface IRandomNumberGenerator
    {
        public void SetSeed(int seed);
        public int Next(int minValue, int maxValue);
    }
}
