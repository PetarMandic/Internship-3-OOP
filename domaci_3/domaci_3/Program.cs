using System;

namespace domaci_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Project, List<Task>> inventory = new Dictionary<Project, List<Task>>();
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
            
            Console.WriteLine("    Unesite željenu akciju: ");
            var action = 0;
            var check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out action);
                if (action < 1 || action > 8)
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
                    PrintProject();
                    break;
                case 2:
                    Console.Clear();
                    InputProject(inventory, listOfTasks);
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
                    ProjectManagement();
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

            static void InputProject(Dictionary<Project, List<Task>> inventory, List<Task>listOfTasks)
            {
                
                Console.Write("Unesite ime projekta: ");
                var projectName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(projectName))
                {
                    Console.WriteLine("Unesite ime projekta: ");
                    projectName = Console.ReadLine();
                }
                
                
                Console.Write("Unesite opis projekta: ");
                var projectDescription = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(projectDescription))
                {
                    Console.WriteLine("Unesite opis projekta: ");
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

                if (projectDateStart < DateTime.Now)
                {
                    projectStatus = "aktivan";
                }
                
                else if (projectDateStart > DateTime.Now)
                {
                    projectStatus = "na čekanju";
                }
                
                Project project = new Project(projectName, projectDescription, projectDateStart, projectDateEnd, projectStatus);
                
                inventory.Add(project, listOfTasks);

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

            static void ProjectManagement()
            {
                Console.WriteLine("PODIZBORNIK");
                Console.WriteLine("    1. Ispis svih zadataka unutar odabranog projekta");
                Console.WriteLine("    2. Prikaz detalja odabranog projekta");
                Console.WriteLine("    3. Uređivanje statusa projekta");
                Console.WriteLine("    4. Dodavanje zadatka unutar projekta");
                Console.WriteLine("    5. Brisanje zadataka iz projekta");
                Console.WriteLine("    6. Prikaz ukupno očekivanog vremena potrebnog za sve aktivne zadatke u projektu");
                Console.WriteLine("    7. Povratak");
                
                Console.WriteLine("    Unesite željenu akciju: ");
                var action = 0;
                var check = false;
                while (!check)
                {
                    check = int.TryParse(Console.ReadLine(), out action);
                    if (action < 1 || action > 8)
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                }
            }

            static void TaskManagement()
            {
                
            }
            
        }
    }
}
