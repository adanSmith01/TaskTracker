namespace TaskTracker.Entities;

public enum State
{
    ToDo,
    InProgress,
    Done
}

/// <summary>
/// This name was chosen to avoid confunsion (and problems) 
/// with the 'Task' class related to 'Threads'
/// </summary>

public class UserTask
{
    public int Id { get; set;}

    public string Description { get; set;}

    public State StateTask{ get; set;}

    public DateTime CreatedAt { get; set;}
    
    public DateTime UpdatedAt { get; set;}
}