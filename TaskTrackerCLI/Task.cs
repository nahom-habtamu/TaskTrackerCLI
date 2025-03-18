namespace TaskTrackerCLI
{
  public class Task(string title, string status = "DEFAULT")
  {
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public string Status { get; set; } = status;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public void MarkAsCompleted()
    {
      Status = "COMPLETED";
      UpdatedAt = DateTime.Now;
    }

    public void MarkAsInProgress()
    {
      Status = "IN_PROGRESS";
      UpdatedAt = DateTime.Now;
    }
  }
}