using DrawABoxPracticeSelector.Application;
using DrawABoxPracticeSelector.Core;
using DrawABoxPracticeSelector.Infrastructure.Exceptions;

namespace DrawABoxPracticeSelector.Infrastructure
{
    public class ExerciseManagerService
    {
        List<IPracticeExercise> _exercises;
        IRandonExerciseSelector _randomExerciseSelector;
        //IRandomNumberGenerator _randomNumberGenerator;

        public ExerciseManagerService(IRandonExerciseSelector RandomExerciseSelector)
        {
            _exercises = new List<IPracticeExercise>();
            _randomExerciseSelector = RandomExerciseSelector;
        }

        public int GetRandomExerciseId() //int Seed
        {
            IPracticeExercise? practiceExercise = _randomExerciseSelector.GetWeightedRandomActivity(_exercises);
            if(practiceExercise != null)
            {
                return practiceExercise.ExerciseId;
            }
            return -1;
            #region
            //List<int> exerciseIds = new List<int>();
            //List<int> exerciseWeights = new List<int>();
            //foreach (var exercise in _exercises)
            //{
            //    exerciseIds.Add(exercise.ExerciseId);
            //    exerciseWeights.Add((int)((exercise.ExerciseWeight * exercise.CurrentWeight) * 100));
            //}
            //_randomNumberGenerator.SetSeed(Seed);
            //int selectedWeight = _randomNumberGenerator.Next(0, exerciseWeights[exerciseWeights.Count() - 1] + 1);

            //for(int i = 0; i < exerciseWeights.Count(); i++)
            //{
            //    if(exerciseWeights[i] != exerciseWeights.Count())
            //    {
            //        if (selectedWeight >= exerciseWeights[i] || selectedWeight < exerciseWeights[i + 1])
            //        {
            //            return exerciseIds[i];
            //        }

            //    } else
            //    {
            //        if (selectedWeight >= exerciseWeights[i])
            //        {
            //            return exerciseIds[i];
            //        }
            //    }

            //}
            //return -1;
            #endregion
        }

        public void AddExercise(int Id, string ExerciseName, string ExerciseDescription, float ExerciseWeight, float CurrentWeight)
        {
            var practiceExercise = new PracticeExercise();
            practiceExercise.ExerciseId = Id;
            practiceExercise.ExerciseName = ExerciseName;
            practiceExercise.ExerciseDescription = ExerciseDescription;
            practiceExercise.ExerciseWeight = ExerciseWeight;
            practiceExercise.CurrentWeight = CurrentWeight;
            practiceExercise.IsActive = true;
            _exercises.Add(practiceExercise);
        }

        public void SetExerciseWeight(int id, float value)
        {
            int index = FindExerciseIndex(id);
            if (index == -1) throw new ExerciseNotFound(id);


            _exercises[index].ExerciseWeight = value;
        }

        public void SetExerciseName(int id, string name)
        {
            int index = FindExerciseIndex(id);
            if (index == -1) throw new ExerciseNotFound(id);


            _exercises[index].ExerciseName = name;
        }

        public void SetExerciseDescription(int id, string description)
        {
            int index = FindExerciseIndex(id);
            if (index == -1) throw new ExerciseNotFound(id);


            _exercises[index].ExerciseDescription = description;
        }

        public string GetExerciseNameById(int id)
        {
            foreach(var exercise in _exercises)
            {
                if(exercise.ExerciseId == id)
                {
                    return exercise.ExerciseName;
                }
            }

            return "";
        }
        public string GetExerciseDescriptionById(int id)
        {
            foreach (var exercise in _exercises)
            {
                if (exercise.ExerciseId == id)
                {
                    return exercise.ExerciseDescription;
                }
            }

            return "";
        }

        public float GetExerciseWeightById(int id)
        {
            foreach (var exercise in _exercises)
            {
                if (exercise.ExerciseId == id)
                {
                    return exercise.ExerciseWeight;
                }
            }

            return -1;
        }

        public int[] GetAllExercisesId()
        {
            int[] output = new int[_exercises.Count];
            for (var i = 0; i < output.Length; i++)
            {
                output[i] = _exercises[i].ExerciseId;
            }
            return output;
        }

        private int FindExerciseIndex(int id)
        {
            for (var i = 0; i < _exercises.Count; i++)
            {
                if (_exercises[i].ExerciseId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        //public int FindExerciseByName(string name)
        //{
        //    foreach(var exercise in _exercises)
        //    {
        //        if(exercise.ExerciseName == name)
        //        {
        //            return exercise.ExerciseId;
        //        }
        //    }
        //    return -1;
        //}
    }
}
