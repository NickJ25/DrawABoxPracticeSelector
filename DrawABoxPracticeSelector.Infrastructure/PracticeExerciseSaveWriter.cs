using DrawABoxPracticeSelector.Core;
namespace DrawABoxPracticeSelector.Infrastructure;

public class PracticeExerciseSaveWriter
{
    string _fileLocation;
    public PracticeExerciseSaveWriter(string fileLocation) => _fileLocation = fileLocation;

    public void Save(IEnumerable<IPracticeExercise> practiveActivityData) 
    { 
        string[] saveData = new string[practiveActivityData.Count()];
        for (int i = 0; i < saveData.Length; i++)
        {
            saveData[i] = ($"{practiveActivityData.ElementAt(i).ExerciseId}|" +
                $"{practiveActivityData.ElementAt(i).ExerciseName}|" +
                $"{practiveActivityData.ElementAt(i).ExerciseDescription}|" +
                $"{practiveActivityData.ElementAt(i).ExerciseWeight}|" +
                $"{practiveActivityData.ElementAt(i).CurrentWeight}|" +
                $"{practiveActivityData.ElementAt(i).IsActive}|");
        }
        File.WriteAllLines(_fileLocation, saveData);
    }
}
