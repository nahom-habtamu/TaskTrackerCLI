using TaskTrackerCLI;
using TaskTrackerCLI.storage;

var storageManager = new JSONStorageManager();
var taskManager = new TaskManager(storageManager);
var commandLineInterface = new CommandLineInterface(taskManager);

await commandLineInterface.Start(args);
