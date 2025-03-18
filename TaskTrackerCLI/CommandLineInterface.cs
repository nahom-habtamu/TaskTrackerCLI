using System.CommandLine;

namespace TaskTrackerCLI
{
  public class CommandLineInterface(TaskManager taskManager)
  {
    private readonly TaskManager _taskManager = taskManager;

    public async Task<int> Start(string[] args)
    {
      var rootCommand = new RootCommand
      {
        Description = "Task Tracker CLI Tool - A versatile command line interface for managing tasks"
      };

      var listCommand = new Command("list", "List all tasks");
      var listCommandArgument = new Argument<string>(
        "filterCriteria",
        description: "A filter criteria to list the tasks (all, completed, in-progress)");
      listCommand.AddArgument(listCommandArgument);
      listCommand.SetHandler(
        filterCriteria =>
        {
          var tasks = _taskManager.GetTasksByFilterCriteria(filterCriteria);
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
        },
        listCommandArgument
      );


      var addCommand = new Command("add", "Add a new task");
      var addCommandArgument = new Argument<string>(
        "title",
        description: "Title of the task");
      addCommand.AddArgument(addCommandArgument);
      addCommand.SetHandler(title =>
      {
        _taskManager.AddTask(new Task(title));
      }, addCommandArgument);


      var removeCommand = new Command("remove", "Remove a task");
      var removeCommandArgument = new Argument<int>(
        "id",
        description: "ID of the task to remove");
      removeCommand.AddArgument(removeCommandArgument);
      removeCommand.SetHandler(_taskManager.RemoveTask, removeCommandArgument);


      var markAsCompletedCommand =
        new Command("mark-as-completed", "Mark a task as completed");
      var markAsCompletedCommandArgument = new Argument<int>(
        "id",
        description: "ID of the task to mark as completed"
      );
      markAsCompletedCommand.AddArgument(markAsCompletedCommandArgument);
      markAsCompletedCommand.SetHandler(
        _taskManager.MarkTaskAsCompleted,
        markAsCompletedCommandArgument
      );


      var markAsInProgressCommand =
        new Command("mark-as-in-progress", "Mark a task as in progress");
      var markAsInProgressCommandArgument = new Argument<int>(
        "id",
        description: "ID of the task to mark as in progress"
      );
      markAsInProgressCommand.AddArgument(markAsInProgressCommandArgument);
      markAsInProgressCommand.SetHandler(
        _taskManager.MarkTaskAsInProgress,
        markAsInProgressCommandArgument
      );


      var updateCommand = new Command("update", "Update a task");
      var updateCommandIdArgument = new Argument<int>(
        "id",
        description: "ID of the task to update");
      var updateCommandTitleArgument = new Argument<string>(
        "title",
        description: "Title of the task");


      updateCommand.AddArgument(updateCommandIdArgument);
      updateCommand.AddArgument(updateCommandTitleArgument);
      updateCommand.SetHandler(
        _taskManager.UpdateTask,
        updateCommandIdArgument,
        updateCommandTitleArgument
      );



      var helpCommand = new Command("help", "Show help");
      helpCommand.SetHandler(() =>
      {
        var helpText = $@"
          Task Tracker CLI
          ===============

          A versatile command line interface for managing tasks

          Commands:
            list [filter]               List tasks (filter: all, completed, in-progress)
            add <title>                 Add a new task
            remove <id>                 Remove a task by ID
            update <id> <title>         Update a task's title
            
          Status Commands:
            mark-as-completed <id>      Mark a task as completed
            mark-as-in-progress <id>    Mark a task as in progress

          General:
            help                        Show this help message

          Examples:
            task-tracker add ""Buy groceries""
            task-tracker list completed
            task-tracker mark-as-completed 1
            task-tracker update 1 ""Buy more groceries""
          ";
        Console.WriteLine(helpText);
      });

      rootCommand.AddCommand(listCommand);
      rootCommand.AddCommand(addCommand);
      rootCommand.AddCommand(removeCommand);
      rootCommand.AddCommand(markAsCompletedCommand);
      rootCommand.AddCommand(markAsInProgressCommand);
      rootCommand.AddCommand(updateCommand);
      rootCommand.AddCommand(helpCommand);

      return await rootCommand.InvokeAsync(args);
    }
  }
}