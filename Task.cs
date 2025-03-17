namespace TaskTrackerCLI
{
  public class Task(string title)
  {
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public void MarkAsCompleted()
    {
      IsCompleted = true;
      UpdatedAt = DateTime.Now;
    }

  }
}