namespace TaskTrackerCLITest;
using TaskTrackerCLI;

public class TaskTest
{
  [Fact]
  public void ShouldUpdateStatusAndUpdatedAtFieldWhenMarkedAsCompleted()
  {
    var task = new Task("Test task");
    var updatedAtValueBeforeCompletion = task.UpdatedAt;

    task.MarkAsCompleted();

    Assert.Equal("COMPLETED", task.Status);
    Assert.NotEqual(updatedAtValueBeforeCompletion, task.UpdatedAt);
  }

  [Fact]
  public void ShouldUpdateStatusAndUpdatedAtFieldWhenMarkedAsInProgress()
  {
    var task = new Task("Test task");
    var updatedAtValueBeforeBeingMarkedAsInProgress = task.UpdatedAt;

    task.MarkAsInProgress();

    Assert.Equal("IN_PROGRESS", task.Status);
    Assert.NotEqual(updatedAtValueBeforeBeingMarkedAsInProgress, task.UpdatedAt);
  }
}