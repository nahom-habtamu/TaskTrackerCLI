using TaskTrackerCLI.storage;
using Task = TaskTrackerCLI.Task;

namespace TaskTrackerCLITest
{
    public class InMemoryStorageManager : IStorageManager
    {
        private readonly List<Task> tasks = [
            new Task("Default Task 1"),
            new Task("In Progress Task 2", "IN_PROGRESS"),
            new Task("Completed Task 3", "COMPLETED"),
        ];

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public List<Task> GetTasksByFilterCriteria(string filterCriteria = "all")
        {
            if (filterCriteria == "all")
            {
                return tasks;
            }
            else if (filterCriteria == "completed")
            {
                return tasks.Where(task => task.Status == "COMPLETED").ToList();
            }
            else if (filterCriteria == "in-progress")
            {
                return tasks.Where(task => task.Status == "IN_PROGRESS").ToList();
            }
            return [];
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            tasks[taskId].Status = "COMPLETED";
            tasks[taskId].UpdatedAt = DateTime.Now;
        }

        public void MarkTaskAsInProgress(int taskId)
        {
            tasks[taskId].Status = "IN_PROGRESS";
            tasks[taskId].UpdatedAt = DateTime.Now;
        }

        public void RemoveTask(int taskId)
        {
            tasks.RemoveAt(taskId);
        }

        public void UpdateTask(int taskId, string title)
        {
            tasks[taskId].Title = title;
        }
    }
}
