using System;

namespace domaci_3
{
    class Program
    {
        static void Main()
        {
            Dictionary<Project, List<Task>> inventory = new Dictionary<Project, List<Task>>();
            List<Project> listOfProjects = new List<Project>();
            List<Task> listOfTasks = new List<Task>();
            
            Console.WriteLine("GLAVNI IZBORNIK");
            Console.WriteLine("    1. Ispis svih projekata s pripadajućim zadacima");
            Console.WriteLine("    2. Dodavanje novog projekta");
            Console.WriteLine("    3. Brisanje projekta");
            Console.WriteLine("    4. Prikaz svih zadataka s rokom u sljedećih 7 dana");
            Console.WriteLine("    5. Prikaz projekata filtriranih po statusu");
            Console.WriteLine("    6. Upravljanje pojedinim projektom");
            Console.WriteLine("    7. Upravljanje pojedinim zadatkom");
            Console.WriteLine("    8. Izlaz iz aplikacije");
            
            Console.Write("    Unesite željenu akciju: ");
            var action = 0;
            var check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out action);
                if (action < 1 || action > 8)
                {
                    Console.Write("Upisani broj ne sadržava niti jednu akciju, upišite broj ponovno: ");
                }
                else if (!check)
                {
                    Console.Write("Potrebno je upisati broj, odaberite željenu akciju ponovno: ");
                }
            }

            switch (action)
            {
                case 1:
                    Console.Clear();
                    PrintProject();
                    break;
                case 2:
                    Console.Clear();
                    InputProject(inventory, listOfProjects, listOfTasks);
                    break;
                case 3:
                    Console.Clear();
                    DeleteProject();
                    break;
                case 4:
                    Console.Clear();
                    DisplayProjectDeadline();
                    break;
                case 5:
                    Console.Clear();
                    DisplayProjectStatus();
                    break;
                case 6:
                    Console.Clear();
                    ProjectManagement(inventory, listOfProjects, listOfTasks);
                    break;
                case 7:
                    Console.Clear();
                    TaskManagement();
                    break;
                case 8:
                    break;
                
            }

            static void PrintProject()
            {
                
            }

            static void InputProject(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks)
            {
                
                Console.Write("Unesite ime projekta: ");
                var projectName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(projectName))
                {
                    Console.Write("Unesite ime projekta: ");
                    projectName = Console.ReadLine();
                }
                
                
                Console.Write("Unesite opis projekta: ");
                var projectDescription = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(projectDescription))
                {
                    Console.Write("Unesite opis projekta: ");
                    projectDescription = Console.ReadLine();
                }
                
                Console.Write("Unesite datum početka projekta: ");
                var projectDateStart = DateTime.Now; 
                var check = false;
                while (!check)
                {
                    check = DateTime.TryParse(Console.ReadLine(), out projectDateStart);
                }

                DateTime? projectDateEnd = null;
                var projectStatus = "";
                
                Console.Write("Želite li postaviti projekt da je na čekanju ili aktivan:  ");
                projectStatus = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(projectStatus))
                {
                    Console.Write("Unesite status projekta: ");
                    projectStatus = Console.ReadLine();
                    if (projectStatus != "aktivan" && projectStatus != "na čekanju")
                    {
                        Console.WriteLine("Niste postavili projekt kao aktivan ili na čekanju, unesite ponovno");
                        projectStatus = "";
                    }
                }
                
                Project project = new Project(projectName, projectDescription, projectDateStart, projectDateEnd, projectStatus);
                
                listOfProjects.Add(project);
                inventory.Add(project, listOfTasks);
                Console.Clear();
                Main();

            }

            static void DeleteProject()
            {
                
            }

            static void DisplayProjectDeadline()
            {
                
            }

            static void DisplayProjectStatus()
            {
                
            }

            static void ProjectManagement(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks)
            {
                
                Console.Write("Unesite ime projekta: ");
                var NameOfProject = Console.ReadLine();
                var notFound = false;
                var i = 0;
                Project comparison = new Project("", "", DateTime.Now, null, "");

                 while(i < listOfProjects.Count)
                {
                    notFound = false;
                    var project = listOfProjects[i];
                    if (project.ProjectName == NameOfProject)
                    {
                        comparison = new Project(project.ProjectName, project.ProjectDescription, project.ProjectDateStart, project.ProjectDateEnd, project.ProjectStatus);
                        break;
                    }
                    
                    if(i+1 == listOfProjects.Count)
                    {
                        Console.Write("Ime projekta ne postoji, unesite ponovno: ");
                        NameOfProject = Console.ReadLine();
                        notFound = true;
                        i = 0;
                    }

                    if (!notFound)
                    {
                        i += 1;
                    }
                }
                
                Console.Clear();
                
                Console.WriteLine("PODIZBORNIK");
                Console.WriteLine("    1. Ispis svih zadataka unutar odabranog projekta");
                Console.WriteLine("    2. Prikaz detalja odabranog projekta");
                Console.WriteLine("    3. Uređivanje statusa projekta");
                Console.WriteLine("    4. Dodavanje zadatka unutar projekta");
                Console.WriteLine("    5. Brisanje zadataka iz projekta");
                Console.WriteLine("    6. Prikaz ukupno očekivanog vremena potrebnog za sve aktivne zadatke u projektu");
                Console.WriteLine("    7. Povratak");
                
                Console.Write("    Unesite željenu akciju: ");
                var action = 0;
                var check = false;
                while (!check)
                {
                    check = int.TryParse(Console.ReadLine(), out action);
                    if (action < 1 || action > 7)
                    {
                        Console.Write("Upisani broj ne sadržava niti jednu akciju, upišite broj ponovno: ");
                    }
                    else if (!check)
                    {
                        Console.Write("Potrebno je upisati broj, odaberite željenu akciju ponovno: ");
                    }
                }

                switch (action)
                {
                    case 1:
                        Console.Clear();
                        PrintTasks(inventory, listOfProjects, listOfTasks, comparison);
                        break;
                    case 2:
                        Console.Clear();
                        ProjectDetails(inventory, listOfProjects, listOfTasks, comparison);
                        break;
                    case 3:
                        Console.Clear();
                        EditStatusOfProject();
                        break;
                    case 4:
                        Console.Clear();
                        TaskInput(inventory, listOfProjects, listOfTasks, comparison);
                        break;
                    case 5:
                        Console.Clear();
                        DeleteTasks();
                        break;
                    case 6:
                        Console.Clear();
                        ExpectedTimeForProject();
                        break;
                    case 7:
                        Console.Clear();
                        Main();
                        break;
                }

                static void PrintTasks(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks, Project comparison)
                {
                    var dictionary = inventory[comparison];

                    foreach (var task in dictionary)
                    {
                        Console.WriteLine(task);
                    }
                    
                    Console.WriteLine("");
                    Console.Write("Unesite broj 1 za povratak: ");

                    var back = 0;
                    var check = false;
                    while (!check)
                    {
                        check = int.TryParse(Console.ReadLine(), out back);
                        if (back != 1 && check == true)
                        {
                            Console.Write("Unesen je krivi broj, upišite ponovno: ");
                            check = false;
                        }
                        else if (!check)
                        {
                            Console.Write("Niste unijeli broj, upišite ponovno: ");
                        }
                    }
                    
                    Console.Clear();
                    ProjectManagement(inventory, listOfProjects, listOfTasks);
                }

                static void ProjectDetails(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks, Project comparison)
                {
                    Console.WriteLine("DETALJI ODABRANOG PROJEKTA");
                    Console.WriteLine("");
                    Console.Write("Ime projekta: " + comparison.ProjectName);
                    Console.WriteLine("Opis projekta: " + comparison.ProjectDescription);
                    Console.WriteLine("Datum početka projekta: " + comparison.ProjectDateStart);
                    if (comparison.ProjectDateEnd == null)
                    {
                        Console.WriteLine("Datum završetka projekta: Projekt nema datum završetka");
                    }
                    else
                    {
                        Console.WriteLine("Datum završetka projekta: " + comparison.ProjectDateEnd);
                    }
                    Console.WriteLine("Status projekta: " + comparison.ProjectStatus);
                    
                }

                static void EditStatusOfProject()
                {
                    
                }

                static void TaskInput(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks, Project comparison)
                {
                    
                    Console.Write("Unesite ime zadatka: ");
                    var taskName = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(taskName))
                    {
                        Console.Write("Unesite ime projekta: ");
                        taskName = Console.ReadLine();
                    }
                    
                    Console.Write("Unesite opis zadatka: ");
                    var taskDescription = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(taskDescription))
                    {
                        Console.Write("Unesite ime projekta: ");
                        taskDescription = Console.ReadLine();
                    }
                    
                    Console.Write("Unesite rok za izvršenje zadatka: ");
                    DateTime taskDeadline = DateTime.Today;
                    var taskStatus = "";
                    var check = false;
                    while (!check)
                    {
                        check = DateTime.TryParse(Console.ReadLine(), out taskDeadline);
                        if (taskDeadline.Hour == 0 || taskDeadline.Minute == 0)
                        {
                            Console.Write("Upišite ponovno rok za izvršenje zadataka ovaj put sadržeći sate i minute: ");
                            check = false;
                        }

                        if (check && taskDeadline.Date < DateTime.Now)
                        {
                            Console.WriteLine("Uneseni rok za izvršavanje zadatka je prošao.");
                            Console.WriteLine("Ako je zadatak naknadno unesen možete ga unosom");
                            Console.WriteLine("broja 1 postaviti status kao završen ili unosom");
                            Console.WriteLine("broja 2 ponovno postaviti rok za izvršenje zadatka: ");
                            
                            var action = 0;
                            var check1 = false;
                            while (!check1)
                            {
                                check1 = int.TryParse(Console.ReadLine(), out action);
                            }

                            switch (action)
                            {
                                case 1:
                                    taskStatus = "završen";
                                    break;
                                case 2:
                                    check = false;
                                    break;
                            }
                            
                        }
                    }

                    if (taskDeadline > DateTime.Now)
                    {
                        if (comparison.ProjectStatus == "aktivan")
                        {
                            taskStatus = "aktivan";
                        }
                        else if (comparison.ProjectStatus == "na čekanju")
                        {
                            taskStatus = "odgođen";
                        }
                    }
                    
                    Console.Write("Unesite očekivano vrijeme trajanja zadatka(u minutama): ");
                    var taskDuration = 0;
                    check = false;
                    while (!check)
                    {
                        check = int.TryParse(Console.ReadLine(), out taskDuration);

                        if (check == true)
                        {
                            triba sve ovo dole ubacit vamo
                        }
                        else
                        {
                            Console.Write("Nije unesen broj, unesite ponovno: ");
                        }
                        
                        TimeSpan difference = taskDeadline - DateTime.Now;
                        DateTime diff = new DateTime(0, 0, 0, 0, 0, 0).Add(difference);
                        
                        const int minutesInAnHour = 60;
                        const int hoursInADay = 24;
                        const int daysInAMonth = 30;
                        const int daysInAYear = 365;
                        
                        var years = taskDuration / (minutesInAnHour * hoursInADay * daysInAYear);
                        taskDuration -= years * (minutesInAnHour * hoursInADay * daysInAYear);
                        
                        var months = taskDuration / (minutesInAnHour * hoursInADay * daysInAMonth);
                        taskDuration -= months * (minutesInAnHour * hoursInADay * daysInAMonth);
                        
                        var days = taskDuration / (minutesInAnHour * hoursInADay);
                        taskDuration-= days * (minutesInAnHour * hoursInADay);
                        
                        var hours = taskDuration / minutesInAnHour;
                        taskDuration -= hours * minutesInAnHour;
                        
                        int minutes = taskDuration;
                        
                        DateTime time = new DateTime(years, months, days, hours, minutes, 0);

                        if (diff < time)
                        {
                            Console.WriteLine("Očekivano vrijeme trajanja zadatka je veće od mogućega.");
                            Console.WriteLine("Želite li potvrditi unos: ");
                            Console.WriteLine("1 - Da");
                            Console.WriteLine("2 - Ne");

                            var action = 0;
                            check = false;
                            while(!check)
                            {
                                check = int.TryParse(Console.ReadLine(), out action);
                                if (action != 1 || action != 2)
                                {
                                    Console.Write("Uneseni broj nema sebi pridruženu akciju, unesite ponovno: ");
                                    check = false;
                                }

                                else if (!check)
                                {
                                    Console.Write("Niste unijeli broj, unesite ponovno:");
                                }
                                
                            }

                            switch (action)
                            {
                                case 1:
                                    break;
                                case 2:
                                    check = false;
                                    break;
                            }
                        }
                    }
                    
                    Task task = new Task(taskName, taskDescription, taskDeadline, taskStatus, taskDuration, comparison.ProjectName);
                    
                    listOfTasks.Add(task);
                    inventory[comparison] = listOfTasks;
                    
                }

                static void DeleteTasks()
                {
                    
                }

                static void ExpectedTimeForProject()
                {
                    
                }
                
                
            }

            static void TaskManagement()
            {
                Console.WriteLine("PODIZBORNIK");
                Console.WriteLine("    1. Prikaz detalja odabrnog zadatka");
                Console.WriteLine("    2. Uređivanje statusa zadatka");
                Console.WriteLine("    3. Povratak");
                
                Console.Write("    Unesite željenu akciju: ");
                var action = 0;
                var check = false;
                while (!check)
                {
                    check = int.TryParse(Console.ReadLine(), out action);
                    if (action < 1 || action > 3)
                    {
                        Console.WriteLine("Upisani broj ne sadržava niti jednu akciju, upišite broj ponovno: ");
                    }
                    else if (!check)
                    {
                        Console.WriteLine("Potrebno je upisati broj, odaberite željenu akciju ponovno: ");
                    }
                }

                switch (action)
                {
                    case 1:
                        Console.Clear();
                        TaskDetails();
                        break;
                    case 2:
                        Console.Clear();
                        EditStatusOfTask();
                        break;
                    case 3:
                        Console.Clear();
                        Main();
                        break;
                    
                    
                }

                static void TaskDetails()
                {
                    
                }

                static void EditStatusOfTask()
                {
                    
                }
            }
            
        }
    }
}
