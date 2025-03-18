using TaskTrackerCLI;
using Task = TaskTrackerCLI.Task;

namespace TaskTrackerCLITest
{
    public class TaskManagerTest
    {
        [Fact]
        public void ShouldFetchAllTasks()
        {
            var taskManager = SetUpSut();
            var tasks = taskManager.GetTasksByFilterCriteria("all");
            Assert.Equal(3, tasks?.Count);
        }

        [Fact]
        public void ShouldFetchCompletedTasks()
        {
            var taskManager = SetUpSut();
            var tasks = taskManager.GetTasksByFilterCriteria("completed");
            Assert.Single(tasks);
        }

        [Fact]
        public void ShouldFetchInProgressTasks()
        {
            var taskManager = SetUpSut();
            var tasks = taskManager.GetTasksByFilterCriteria("in-progress");
            Assert.Single(tasks);
        }

        [Fact]
        public void ShouldReturnEmptyListWhenFilterCriteriaIsInvalid()
        {
            var taskManager = SetUpSut();
            Assert.Empty(taskManager.GetTasksByFilterCriteria("invalid"));
        }

        [Fact]
        public void ShouldAddTask()
        {
            var taskManager = SetUpSut();
            var taskTitle = "Add Task Test";

            taskManager.AddTask(new Task(taskTitle));

            var tasks = taskManager
                .GetTasksByFilterCriteria("all");

            Assert.True(tasks?.Any(task => task.Title == taskTitle));
            Assert.Equal(4, tasks?.Count);

            CleanUp();
        }

        [Fact]
        public void ShouldMarkTaskAsCompleted()
        {
            var taskManager = SetUpSut();

            var firstTask = taskManager.GetTasksByFilterCriteria("all").First();
            taskManager.MarkTaskAsCompleted(firstTask.Id);

            Assert.Equal("COMPLETED", firstTask.Status);

            CleanUp();
        }

        [Fact]
        public void ShouldMarkTaskAsInProgress()
        {
            var taskManager = SetUpSut();

            var firstTask = taskManager.GetTasksByFilterCriteria("all").First();
            taskManager.MarkTaskAsInProgress(firstTask.Id);

            Assert.Equal("IN_PROGRESS", firstTask.Status);

            CleanUp();
        }

        [Fact]
        public void ShouldUpdateTask()
        {
            var taskManager = SetUpSut();
            var updatedTaskTitle = "Updated Task";

            var firstTask = taskManager.GetTasksByFilterCriteria("all").First();
            taskManager.UpdateTask(firstTask.Id, updatedTaskTitle);

            Assert.Equal(updatedTaskTitle, firstTask.Title);

            CleanUp();
        }

        [Fact]
        public void ShouldDeleteTask()
        {
            var taskManager = SetUpSut();
            var firstTask = taskManager.GetTasksByFilterCriteria("all").First();
            taskManager.RemoveTask(firstTask.Id);

            Assert.Empty(taskManager.GetTasksByFilterCriteria("all").Where(task => task.Title == firstTask.Title));

            CleanUp();
        }

        private static TaskManager SetUpSut()
        {

            var storage = new InMemoryStorageManager();
            var taskManager = new TaskManager(storage);

            return taskManager;
        }

        private static void CleanUp()
        {
            var storage = new InMemoryStorageManager();
            var taskManager = new TaskManager(storage);

            var tasks = taskManager.GetTasksByFilterCriteria("all").ToList();

            // Remove all tasks
            foreach (var task in tasks)
            {
                taskManager.RemoveTask(task.Id);
            }

            // Add default tasks
            taskManager.AddTask(new Task("Default Task 1"));
            taskManager.AddTask(new Task("In Progress Task 2", "IN_PROGRESS"));
            taskManager.AddTask(new Task("Completed Task 3", "COMPLETED"));
        }
    }
}