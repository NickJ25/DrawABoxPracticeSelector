namespace DrawABoxPracticeSelector.Core;

public interface IPracticeExercise
{
    int ExerciseId { get; set; }
    string ExerciseName { get; set; }
    string ExerciseDescription { get; set; }
    float ExerciseWeight { get; set; }
    float CurrentWeight { get; set; }
    bool IsActive { get; set; }
}
