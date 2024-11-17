using System;

namespace domaci_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GLAVNI IZBORNIK");
            Console.WriteLine("    1. Ispis svih projekata s pripadajućim zadacima");
            Console.WriteLine("    2. Dodavanje novog projekta");
            Console.WriteLine("    3. Brisanje projekta");
            Console.WriteLine("    4. Prikaz svih zadataka s rokom u sljedećih 7 dana");
            Console.WriteLine("    5. Prikaz projekata filtriranih po statusu");
            Console.WriteLine("    6. Upravljanje pojedinim projektom");
            Console.WriteLine("    7. Izlaz iz aplikacije");
            
            Console.WriteLine("    Unesite željenu akciju: ");
            var FirstAction = 0;
            var Check = false;
            while (!Check)
            {
                Check = int.TryParse(Console.ReadLine(), out FirstAction);
                if (FirstAction < 1 || FirstAction > 7)
                {
                    Console.WriteLine("Upisani broj ne sadržava niti jednu akciju, upišite broj ponovno: ");
                }
                else if (!Check)
                {
                    Console.WriteLine("Potrebno je upisati broj, odaberite željenu akciju ponovno: ");
                }
            }

            switch (FirstAction)
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

            static void PrintProject()
            {
                
            }

            static void InputProject()
            {
                
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
                
            }
            
        }
    }
}
