using DrawABoxPracticeSelector.Core;
namespace DrawABoxPracticeSelector.Infrastructure;

public class PracticeExerciseSaveReader
{
    string _fileLocation;
    public PracticeExerciseSaveReader(string fileLocation) => _fileLocation = fileLocation;

    public IEnumerable<IPracticeExercise>? Read()
    {
        string[] fileLines = System.IO.File.ReadAllLines(_fileLocation);
        IPracticeExercise[] output = new IPracticeExercise[fileLines.Length];

        for (int i = 0; i < fileLines.Length; i++)
        {
            var splitFileLine = fileLines[i].Split(new[] { "|" }, StringSplitOptions.None);
            IPracticeExercise activity = new PracticeExercise();
            activity.ExerciseId = int.Parse(splitFileLine[0]);
            activity.ExerciseName = splitFileLine[1];
            activity.ExerciseDescription = splitFileLine[2];
            activity.ExerciseWeight = float.Parse(splitFileLine[3]);
            activity.CurrentWeight = float.Parse(splitFileLine[4]);
            activity.IsActive = bool.Parse(splitFileLine[5]);
            output[i] = activity;
        }

        return output;
    } 
}
