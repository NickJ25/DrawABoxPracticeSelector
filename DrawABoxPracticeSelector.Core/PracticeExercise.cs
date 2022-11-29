namespace DrawABoxPracticeSelector.Core;

public class PracticeExercise : IPracticeExercise
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }
    public string ExerciseDescription { get; set; }
    public float ExerciseWeight { get; set; }
    public float CurrentWeight { get; set; }
    public bool IsActive { get; set; }
}
