using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawABoxPracticeSelector.Infrastructure.Exceptions
{
    public class ExerciseFieldNotFound : Exception
    {
        public ExerciseFieldNotFound(string field) : base($"Exercise field {field} was not found.")
        {
        }
    }
}
