namespace TaskTrackerCLI
{
  public class TaskManager(StorageManager storageManager)
  {
    private readonly StorageManager _storageManager = storageManager;

    public void AddTask(Task task)
    {
      _storageManager.AddTask(task);
      Console.WriteLine($"✓ Task added successfully: {task.Title}");
    }

    public void UpdateTask(int taskId, string title)
    {
      _storageManager.UpdateTask(taskId, title);
      Console.WriteLine($"✓ Task updated successfully");
    }

    public void RemoveTask(int taskId)
    {
      _storageManager.RemoveTask(taskId);
      Console.WriteLine($"✓ Task removed successfully");
    }

    public void MarkTaskAsCompleted(int taskId)
    {
      _storageManager.MarkTaskAsCompleted(taskId);
      Console.WriteLine($"✓ Task marked as completed");
    }

    public void MarkTaskAsInProgress(int taskId)
    {
      _storageManager.MarkTaskAsInProgress(taskId);
      Console.WriteLine($"✓ Task marked as in progress");
    }

    public void ListTasks(string filterCriteria = "all")
    {
      if (filterCriteria != "all" && filterCriteria != "completed" && filterCriteria != "in-progress")
      {
        Console.WriteLine("Invalid filter criteria. Please use 'all', 'completed', or 'in-progress'.");
        return;
      }

      var tasks = _storageManager.GetTasks(filterCriteria);

      if (tasks.Count == 0)
      {
        Console.WriteLine("No tasks found.");
        return;
      }

      Console.WriteLine("\nTask List:");
      Console.WriteLine("----------------------------------------");
      foreach (var task in tasks)
      {
        string status = task.Status == "COMPLETED" ? "[✓]" : task.Status == "IN_PROGRESS" ? "[⚙️]" : "[ ]";
        Console.WriteLine($"{task.Id}.{task.Title} {status}");
      }
      Console.WriteLine("----------------------------------------\n");
    }

  }
}
