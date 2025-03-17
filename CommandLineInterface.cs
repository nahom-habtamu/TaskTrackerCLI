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
      var listFormatOption = new Option<string>(
        "--format",
        description: "Output format (table, json, csv)",
        getDefaultValue: () => "table");
      listCommand.AddOption(listFormatOption);
      listCommand.SetHandler(format =>
      {
        _taskManager.ListTasks();

      }, listFormatOption);


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
        Console.WriteLine("Task Tracker CLI Tool - A versatile command line interface for managing tasks" +
          "\nAvailable commands:\n" +
          "list - List all tasks\n" +
          "add <title> - Add a new task\n" +
          "remove <id> - Remove a task\n" +
          "mark-as-completed <id> - Mark a task as completed\n" +
          "update <id> <title> - Update a task\n" +
          "help - Show help");
      });

      rootCommand.AddCommand(listCommand);
      rootCommand.AddCommand(addCommand);
      rootCommand.AddCommand(removeCommand);
      rootCommand.AddCommand(markAsCompletedCommand);
      rootCommand.AddCommand(updateCommand);
      rootCommand.AddCommand(helpCommand);

      return await rootCommand.InvokeAsync(args);
    }
  }
}