using System.Text.Json;

namespace TaskTrackerCLI
{
  public class StorageManager
  {
    private readonly string _storagePath;

    public StorageManager(string storagePath = "tasks.json")
    {
      _storagePath = storagePath;
      EnsureStorageFileExists();
    }

    private void EnsureStorageFileExists()
    {
      if (!File.Exists(_storagePath))
      {
        try
        {
          File.WriteAllText(_storagePath, "[]");
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Error creating storage file: {ex.Message}");
          throw;
        }
      }
    }

    private List<Task> LoadTasks()
    {
      try
      {
        var json = File.ReadAllText(_storagePath);
        return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error loading tasks: {ex.Message}");
        return [];
      }
    }

    private void SaveTasks(List<Task> tasks)
    {
      try
      {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_storagePath, json);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error saving tasks: {ex.Message}");
        throw;
      }
    }

    public List<Task> GetTasks()
    {
      return LoadTasks();
    }

    public void AddTask(Task task)
    {
      var tasks = LoadTasks();
      task.Id = tasks.Count + 1;
      tasks.Add(task);
      SaveTasks(tasks);
    }

    public void UpdateTask(int taskId, string title)
    {
      var tasks = LoadTasks();
      var updatedTasks = tasks.Select(t =>
      {
        if (t.Id == taskId)
        {
          t.Title = title;
        }
        return t;
      }).ToList();

      SaveTasks(updatedTasks);
    }

    public void RemoveTask(int taskId)
    {
      var tasks = LoadTasks();
      tasks.RemoveAll(t => t.Id == taskId);
      SaveTasks(tasks);
    }

    public void MarkTaskAsCompleted(int taskId)
    {
      var tasks = LoadTasks();
      var task = tasks.FirstOrDefault(t => t.Id == taskId);

      if (task == null)
      {
        Console.WriteLine("Task not found");
        return;
      }

      task.MarkAsCompleted();
      SaveTasks(tasks);
    }

    public void MarkTaskAsInProgress(int taskId)
    {
      var tasks = LoadTasks();
      var task = tasks.FirstOrDefault(t => t.Id == taskId);

      if (task == null)
      {
        Console.WriteLine("Task not found");
        return;
      }

      task.MarkAsInProgress();
      SaveTasks(tasks);
    }
  }
}