namespace domaci_3;

public class Project
{
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public DateTime ProjectDateStart { get; set; }
    public DateTime? ProjectDateEnd { get; set; }
    public string ProjectStatus { get; set; }

    public Project(string projectName, string projectDescription, DateTime projectDateStart, DateTime? projectDateEnd, string projectStatus)
    {
        
        ProjectName = projectName;
        ProjectDescription = projectDescription;
        ProjectDateStart = projectDateStart;
        ProjectDateEnd = projectDateEnd;
        ProjectStatus = projectStatus;
    }
    
}