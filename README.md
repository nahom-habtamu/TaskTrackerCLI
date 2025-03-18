# TaskTrackerCLI

A command-line interface application for managing tasks, built with C# and .NET 8.0.

## Prerequisites

Before you begin, ensure you have the following installed:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Git (for cloning the repository)

## Project URL 
https://github.com/nahom-habtamu/TaskTrackerCLI


## Getting Started

### Option 1: Run Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/nahom-habtamu/TaskTrackerCLI.git
   cd TaskTrackerCLI
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

### Option 2: Install as a Global Tool

1. Clone the repository:
   ```bash
   git clone https://github.com/nahom-habtamu/TaskTrackerCLI.git
   cd TaskTrackerCLI
   ```

2. Install the tool globally:
   ```bash
   dotnet tool install --global --add-source ./nupkg TaskTrackerCLI
   ```

3. Now you can use the tool from anywhere in your terminal:
   ```bash
   task-tracker-cli [commands]
   ```

To update the tool:
```bash
dotnet tool update --global --add-source ./nupkg TaskTrackerCLI
```

To uninstall the tool:
```bash
dotnet tool uninstall --global TaskTrackerCLI
```

## Project Structure

- `Program.cs` - The entry point of the application
- `CommandLineInterface.cs` - Handles command-line interface logic
- `TaskManager.cs` - Manages task operations
- `Task.cs` - Defines the Task model
- `storage/` - Directory where task data is stored

## Testing

The project includes comprehensive unit tests covering the core functionality of task management.

### Test Structure

The tests are organized into two main test classes:

#### TaskManagerTest
Tests the core task management functionality:

1. **Task Retrieval Tests**
   - `ShouldFetchAllTasks`: Verifies that all tasks (3 by default) are retrieved
   - `ShouldFetchCompletedTasks`: Ensures only completed tasks are returned
   - `ShouldFetchInProgressTasks`: Confirms in-progress tasks are filtered correctly
   - `ShouldReturnEmptyListWhenFilterCriteriaIsInvalid`: Validates handling of invalid filter criteria

2. **Task CRUD Operations**
   - `ShouldAddTask`: Tests task creation and verifies the total count increases
   - `ShouldUpdateTask`: Validates task title updates
   - `ShouldDeleteTask`: Ensures tasks are properly removed
   - `ShouldMarkTaskAsCompleted`: Tests task status change to completed
   - `ShouldMarkTaskAsInProgress`: Verifies task status change to in-progress

#### TaskTest
Tests the Task entity behavior:
- `ShouldUpdateStatusAndUpdatedAtFieldWhenMarkedAsCompleted`: Verifies status and timestamp updates
- `ShouldUpdateStatusAndUpdatedAtFieldWhenMarkedAsInProgress`: Confirms status and timestamp updates

### Running the Tests

1. Navigate to the test project directory:
   ```bash
   cd TaskTrackerCLITest
   ```
2. Run the tests:
   ```bash
   dotnet test
   ```

### Test Data

The tests use an `InMemoryStorageManager` that initializes with three default tasks:
- "Default Task 1" (default status)
- "In Progress Task 2" (IN_PROGRESS status)
- "Completed Task 3" (COMPLETED status)

Each test method that perform mutation includes a `CleanUp()` call to reset the test data to this initial state.

## Dependencies

- .NET 8.0
- System.CommandLine (2.0.0-beta4.22272.1)
- xUnit (for testing)

## License

[Add your license information here]

## Contributing

[Add contribution guidelines here]
