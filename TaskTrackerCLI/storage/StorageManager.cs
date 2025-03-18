namespace TaskTrackerCLI.storage;

public interface IStorageManager
{
  List<Task> GetTasksByFilterCriteria(string filterCriteria = "all");
  void AddTask(Task task);
  void UpdateTask(int taskId, string title);
  void RemoveTask(int taskId);
  void MarkTaskAsCompleted(int taskId);
  void MarkTaskAsInProgress(int taskId);
}