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
                    TaskManagement(inventory, listOfProjects, listOfTasks);
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
                    Console.Write("Niste unijeli ime, upišite ponovno: ");
                    projectName = Console.ReadLine();
                }
                
                
                Console.Write("Unesite opis projekta: ");
                var projectDescription = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(projectDescription))
                {
                    Console.Write("Niste unijeli opis, upišite ponovno: ");
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
                        EditStatusOfProject(inventory, listOfProjects, listOfTasks, comparison);
                        break;
                    case 4:
                        Console.Clear();
                        TaskInput(inventory, listOfProjects, listOfTasks, comparison);
                        break;
                    case 5:
                        Console.Clear();
                        DeleteTasks(inventory, listOfProjects, listOfTasks, comparison);
                        break;
                    case 6:
                        Console.Clear();
                        ExpectedTimeForProject(inventory, listOfProjects, listOfTasks, comparison);
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

                static void EditStatusOfProject(Dictionary<Project, List<Task>> inventory, List<Project> listOfProjects, List<Task> listOfTasks, Project comparison)
                {
                    Console.WriteLine("Trenutni status projekta - " + comparison.ProjectStatus);
                    Console.WriteLine("");
                    Console.Write("Promjena status: ");
                    var newProjectStatus = Console.ReadLine();
                    var changeStatus = false;
                    var check = false;

                    while (!check)
                    {
                        newProjectStatus = Console.ReadLine();
                        if (newProjectStatus == "aktivan" || newProjectStatus == "na čekanju" ||
                            newProjectStatus == "završen")
                        {
                            check = true;
                            if (newProjectStatus == comparison.ProjectStatus)
                            {
                                Console.WriteLine("Projekt već sadrži ovakav status.");
                                Console.WriteLine("Želite li ostaviti status ili ga želite promjeniti. ");
                                Console.WriteLine("1 - Ostavit status");
                                Console.WriteLine("2 - Ponovan unos");

                                var action = 0;
                                var check1 = false;
                                while (!check1)
                                {
                                    check1 = int.TryParse(Console.ReadLine(), out action);
                                    if (action != 1 && action != 2)
                                    {
                                        Console.Write("Uneseni broj nema sebi pridruženu akciju, unesite ponovno: ");
                                        check1 = false;
                                    }
                                    else if (!check1)
                                    {
                                        Console.Write("Niste unijeli broj, unesite ponovo: ");
                                    }
                                }

                                switch (action)
                                {
                                    case 1:
                                        Console.WriteLine("Status projekta je ostao isti - " +
                                                          comparison.ProjectStatus);
                                        Console.Write("Unesite broj 1 za povratak: ");

                                        var back = 0;
                                        var check2 = false;
                                        while (!check2)
                                        {
                                            check2 = int.TryParse(Console.ReadLine(), out back);
                                            if (back != 1 && check2 == true)
                                            {
                                                Console.Write("Unesen je krivi broj, upišite ponovno: ");
                                                check = false;
                                            }
                                            else if (!check2)
                                            {
                                                Console.Write("Niste unijeli broj, upišite ponovno: ");
                                            }
                                        }

                                        Console.Clear();
                                        ProjectManagement(inventory, listOfProjects, listOfTasks);
                                        break;

                                    case 2:
                                        changeStatus = true;

                                        Console.Clear();
                                        EditStatusOfProject(inventory, listOfProjects, listOfTasks, comparison);
                                        break;
                                }

                            }

                            else if (newProjectStatus == "aktivan")
                            {
                                var dictionary = inventory[comparison];
                                foreach (var task in dictionary)
                                {
                                    task.TaskStatus = newProjectStatus;
                                }
                            }

                            else if (newProjectStatus == "na čekanju")
                            {
                                var dictionary = inventory[comparison];
                                foreach (var task in dictionary)
                                {
                                    task.TaskStatus = "odgođen";
                                }
                            }

                            else if (newProjectStatus == "završen")
                            {
                                var dictionary = inventory[comparison];
                                foreach (var task in dictionary)
                                {
                                    task.TaskStatus = newProjectStatus;
                                }
                            }
                        }

                        else
                        {
                            Console.Write("Nije unesena mogućnost postavke statusa, unesite ponovno: ");
                        }
                    }

                    Console.WriteLine("Status projekta je postavljen na : " + newProjectStatus);
                    switch (newProjectStatus)
                    {
                        case "aktivan":
                            Console.WriteLine(
                                "Status svih zadataka u projektu su automatski postavljeni na - aktivan - ");
                            break;
                        case "na čekanju":
                            Console.WriteLine(
                                "Status svih zadataka u projektu su automatski postavljeni na - odgođen -");
                            break;
                        case "završen":
                            Console.WriteLine(
                                "Status svih zadataka u projektu su automatski postavljeni na - završen -");
                            break;
                    }
                    
                    Console.WriteLine("");
                    Console.Write("Unesite broj 1 za povratak: ");

                    var back2 = 0;
                    check = false;
                    while (!check)
                    {
                        check = int.TryParse(Console.ReadLine(), out back2);
                        if (back2 != 1 && check == true)
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
                        Console.Write("Unesite opis projekta: ");
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
                        else
                        {
                            Console.Write("Nije unesen broj, unesite ponovno: ");
                        }
                        
                    }
                    
                    Task task = new Task(taskName, taskDescription, taskDeadline, taskStatus, taskDuration, comparison.ProjectName);
                    
                    listOfTasks.Add(task);
                    inventory[comparison] = listOfTasks;
                    
                }

                static void DeleteTasks(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks, Project comparison)
                {
                    var deleteTaskName = "";
                    while (string.IsNullOrEmpty(deleteTaskName))
                    {
                        Console.Write("Upišite ime zadatka");
                        deleteTaskName = Console.ReadLine();
                    }
                    
                    var dictionary = inventory[comparison];
                    var check = false;
                    while (!check)
                    {
                        foreach (var task in dictionary)
                        {
                            if (task.TaskName == deleteTaskName)
                            {
                                Console.WriteLine("Želite li zaista izbrisati taj zadatak: ");
                                Console.WriteLine("-> Da");
                                Console.WriteLine("-> Ne");

                                var action = Console.ReadLine();
                                while (string.IsNullOrEmpty(action))
                                {
                                    Console.Write("Unos ne odgovara niti jednoj mogućnosti, unesite ponovno: ");
                                    action = Console.ReadLine();
                                }

                                switch (action)
                                {
                                    case "Da":
                                        dictionary.Remove(task);
                                        inventory[comparison] = dictionary;
                                        Console.WriteLine("Zadatak je uspiješno izbrisan.");
                                        check = true;
                                        break;
                                    case "Ne":
                                        Console.WriteLine("Zadatak nije izbrisan.");
                                        check = true;
                                        break;
                                }

                                break;
                            }
                        }

                        if (!check)
                        {
                            Console.Write("Ime zadatka nije pronađeno, unesite ime ponovno: ");
                            deleteTaskName = Console.ReadLine();
                        }
                    }
                }

                static void ExpectedTimeForProject(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks, Project comparison)
                {
                    var dictionary = inventory[comparison];
                    var timeForAllActiveTasks = 0;
                    
                    foreach (var task in dictionary)
                    {
                        if (task.TaskStatus == "akitvan")
                        {
                            timeForAllActiveTasks += task.TaskDuration;
                        }
                        
                    }
                    
                    const int minutesInAnHour = 60;
                    const int hoursInADay = 24;
                    const int daysInAMonth = 30;
                    const int daysInAYear = 365;
                            
                    var years = timeForAllActiveTasks / (minutesInAnHour * hoursInADay * daysInAYear);
                    timeForAllActiveTasks -= years * (minutesInAnHour * hoursInADay * daysInAYear);
                            
                    var months = timeForAllActiveTasks / (minutesInAnHour * hoursInADay * daysInAMonth);
                    timeForAllActiveTasks -= months * (minutesInAnHour * hoursInADay * daysInAMonth);
                            
                    var days = timeForAllActiveTasks / (minutesInAnHour * hoursInADay);
                    timeForAllActiveTasks-= days * (minutesInAnHour * hoursInADay);
                            
                    var hours = timeForAllActiveTasks / minutesInAnHour;
                    timeForAllActiveTasks -= hours * minutesInAnHour;
                            
                    var minutes = timeForAllActiveTasks;
                    
                    Console.WriteLine("Očekivano vrijeme za sve aktivne zadatke u projektu:");
                    Console.WriteLine("");
                    Console.WriteLine(years + " godina");
                    Console.WriteLine(months + " mjeseca");
                    Console.WriteLine(days + " dan");
                    Console.WriteLine(hours + " sat");
                    Console.WriteLine(minutes + " minuta");

                }
                
                
            }

            static void TaskManagement(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks)
            {
                
                Console.Write("Unesite ime projekta u kojem se nalazi željeni zadatak: ");
                var NameOfProject = Console.ReadLine();
                var notFound = false;
                var i = 0;
                Project comparisonProject = new Project("", "", DateTime.Now, null, "");
                Task comparisonTask = new Task("", "", DateTime.Now, "", 0, "");

                while(i < listOfProjects.Count)
                {
                    notFound = false;
                    var project = listOfProjects[i];
                    if (project.ProjectName == NameOfProject)
                    {
                        comparisonProject = new Project(project.ProjectName, project.ProjectDescription, project.ProjectDateStart, project.ProjectDateEnd, project.ProjectStatus);
                        
                        Console.WriteLine("Unesite ime zadatka: ");
                        var NameOfTask = Console.ReadLine();
                        var dictionary = inventory[comparisonProject];
                        var check = false;
                        while (!check)
                        {
                            foreach (var task in dictionary)
                            {
                                if (task.TaskName == NameOfTask)
                                {
                                    comparisonTask = new Task(task.TaskName, task.TaskDescription, task.TaskDeadline,
                                        task.TaskStatus, task.TaskDuration, task.NameOfProject);
                                    check = true;
                                    break;
                                }
                            
                            }

                            if (!check)
                            {
                                Console.Write("Ime zadatka ne postoji, unesite ponovno: ");
                                NameOfTask = Console.ReadLine();
                            }
                        }
                        
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
                
                Console.WriteLine("PODIZBORNIK");
                Console.WriteLine("    1. Prikaz detalja odabrnog zadatka");
                Console.WriteLine("    2. Uređivanje statusa zadatka");
                Console.WriteLine("    3. Povratak");
                
                Console.Write("    Unesite željenu akciju: ");
                var action = 0;
                var check1 = false;
                while (!check1)
                {
                    check1 = int.TryParse(Console.ReadLine(), out action);
                    if (action < 1 || action > 3)
                    {
                        Console.WriteLine("Upisani broj ne sadržava niti jednu akciju, upišite broj ponovno: ");
                    }
                    else if (!check1)
                    {
                        Console.WriteLine("Potrebno je upisati broj, odaberite željenu akciju ponovno: ");
                    }
                }

                switch (action)
                {
                    case 1:
                        Console.Clear();
                        TaskDetails(inventory, listOfProjects, listOfTasks, comparisonProject, comparisonTask);
                        break;
                    case 2:
                        Console.Clear();
                        EditStatusOfTask(inventory, listOfProjects, listOfTasks, comparisonProject, comparisonTask);
                        break;
                    case 3:
                        Console.Clear();
                        Main();
                        break;
                    
                    
                }

                static void TaskDetails(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks, Project comparisonProject,Task comparisonTask)
                {
                    Console.WriteLine("Detalji zadatka " + comparisonTask.TaskName +" u projektu " + comparisonProject.ProjectName);
                    Console.Clear();
                    Console.WriteLine("Ime zadatka: " + comparisonTask.TaskName);
                    Console.WriteLine("Opis zadatka: " + comparisonTask.TaskDescription);
                    Console.WriteLine("Rok za izvršenje zadatka: " + comparisonTask.TaskDeadline);
                    Console.WriteLine("Status zadatka: " + comparisonTask.TaskStatus);
                    Console.WriteLine("Očekivano vrijeme za zadatak(u minutama): " + comparisonTask.TaskDuration);
                    Console.WriteLine("Ime projekta: " + comparisonTask.NameOfProject);
                }

                static void EditStatusOfTask(Dictionary<Project, List<Task>> inventory, List<Project>listOfProjects, List<Task>listOfTasks, Project comparisonProject,Task comparisonTask)
                {
                    var newStatus = "";
                    Console.Write("Unesite status koji želite postaviti na zadatak: ");
                    newStatus = Console.ReadLine();
                    while (newStatus != "aktivan" && newStatus != "završen" && newStatus != "odgođen")
                    {
                        Console.Write("Niste unijeli moguću opciju za status zadatka unesite ponovno: ");
                        newStatus = Console.ReadLine();
                    }

                    if (newStatus == comparisonTask.TaskStatus)
                    {
                        Console.WriteLine("Status zadatka je već postavljen kao "+ newStatus);
                        Console.WriteLine("Želite li ostaviti status ili ga promjeniti");
                        Console.WriteLine("1 - Promjeni");
                        Console.WriteLine("2 - Ostavi kako je postavljeno");
                        
                        Console.WriteLine("");
                        Console.Write("Unos: ");
                        var input = 0;
                        var check = false;
                        while (!check)
                        {
                            check = int.TryParse(Console.ReadLine(), out input);
                            if (input != 1 && input != 2)
                            {
                                Console.Write("Upisani broj ne sadržava nikakvu akciju, upišite ponovno: ");
                                check = false;
                            }
                            else if (!check)
                            {
                                Console.Write("Niste unijeli broj, upišite ponovno");
                            }
                        }   

                        switch (input)
                        {
                            case 1:
                                Console.Clear();
                                EditStatusOfTask(inventory, listOfProjects, listOfTasks, comparisonProject, comparisonTask);
                                break;
                            case 2:
                                break;
                        }
                    }
                    
                    switch (newStatus)
                    {
                        case "aktivan":
                            
                            listOfTasks.Remove(comparisonTask);
                            
                            comparisonTask = new Task(comparisonTask.TaskName, comparisonTask.TaskDescription,
                                comparisonTask.TaskDeadline,
                                "aktivan", comparisonTask.TaskDuration, comparisonTask.NameOfProject);
                            
                            listOfTasks.Add(comparisonTask);
                            inventory[comparisonProject] = listOfTasks;
                            
                            break;
                        case "završen":
                            
                            listOfTasks.Remove(comparisonTask);
                            
                            comparisonTask = new Task(comparisonTask.TaskName, comparisonTask.TaskDescription,
                                comparisonTask.TaskDeadline,
                                "završen", comparisonTask.TaskDuration, comparisonTask.NameOfProject);
                            
                            listOfTasks.Add(comparisonTask);
                            inventory[comparisonProject] = listOfTasks;
                            
                            break;
                        case "odgođen":
                            
                            listOfTasks.Remove(comparisonTask);
                            
                            comparisonTask = new Task(comparisonTask.TaskName, comparisonTask.TaskDescription,
                                comparisonTask.TaskDeadline,
                                "odgođen", comparisonTask.TaskDuration, comparisonTask.NameOfProject);
                            
                            listOfTasks.Add(comparisonTask);
                            inventory[comparisonProject] = listOfTasks;
                            
                            break;
                    }
                }
            }
            
        }
    }
}
