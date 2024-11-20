using System.Runtime.InteropServices.JavaScript;

namespace domaci_3;

public class Task
{
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public DateTime TaskDeadline { get; set; }
    public string TaskStatus { get; set; }
    public int TaskDuration { get; set; }
    public string NameOfProject { get; set; }

    public Task(string taskName, string taskDescription, DateTime taskDeadline, string taskStatus, int taskDuration,
        string nameOfProject)
    {
        TaskName = taskName;
        TaskDescription = taskDescription;
        TaskDeadline = taskDeadline;
        TaskStatus = taskStatus;
        TaskDuration = taskDuration;
        NameOfProject = nameOfProject;
    }
    
}