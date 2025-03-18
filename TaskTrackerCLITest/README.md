# TaskTrackerCLI Tests

This project contains unit tests for the TaskTrackerCLI application. The tests cover the core functionality of task management including CRUD operations and task status management.

## Test Structure

The tests are organized into two main test classes:

### TaskManagerTest
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

### TaskTest
Tests the Task entity behavior:
- `ShouldUpdateStatusAndUpdatedAtFieldWhenMarkedAsCompleted`: Verifies status and timestamp updates
- `ShouldUpdateStatusAndUpdatedAtFieldWhenMarkedAsInProgress`: Confirms status and timestamp updates

## Running the Tests

1. Ensure you have .NET 8.0 SDK installed
2. Navigate to the test project directory:
   ```bash
   cd TaskTrackerCLITest
   ```
3. Run the tests:
   ```bash
   dotnet test
   ```

## Test Data

The tests use an `InMemoryStorageManager` that initializes with three default tasks:
- "Default Task 1" (default status)
- "In Progress Task 2" (IN_PROGRESS status)
- "Completed Task 3" (COMPLETED status)

Each test method includes a `CleanUp()` call to reset the test data to this initial state.

## Test Dependencies

- xUnit: Testing framework
- TaskTrackerCLI: Main project containing the implementation
- InMemoryStorageManager: Test implementation of IStorageManager for isolated testing
