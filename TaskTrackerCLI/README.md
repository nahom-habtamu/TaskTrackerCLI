# TaskTrackerCLI

A command-line interface application for managing tasks, built with C# and .NET 8.0.

## Prerequisites

Before you begin, ensure you have the following installed:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Git (for cloning the repository)

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

To update the tool in the future:
```bash
dotnet tool update --global --add-source ./nupkg TaskTrackerCLI
```

To uninstall the tool:
```bash
dotnet tool uninstall --global TaskTrackerCLI
```

## Development

To work on the project:

1. Open the solution in your preferred IDE (Visual Studio, VS Code, etc.)
2. Make your changes
3. Build and test your changes:
   ```bash
   dotnet build
   dotnet run
   ```

## Project Structure

- `Program.cs` - The entry point of the application
- `CommandLineInterface.cs` - Handles command-line interface logic
- `TaskManager.cs` - Manages task operations
- `Task.cs` - Defines the Task model
- `storage/` - Directory where task data is stored

## Dependencies

- .NET 8.0
- System.CommandLine (2.0.0-beta4.22272.1)

## License

[Add your license information here]

## Contributing

[Add contribution guidelines here]
