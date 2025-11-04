namespace RestaurangRegistret
{
    internal class Program
    {
        static Employees employees = new Employees();
        static void AddEmployee()
        {
            Console.WriteLine("Ange förnamn på den anställde:");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ange efternamn på den anställde:");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ange lön för den anställde:");
            double salary;
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange sifran på format: '30000,55'\n");
            }

            Employee addedEmployee = employees.Add(firstName, lastName, salary);

            Console.WriteLine($"Anställd tillagd i registret med:\n" +
                $"Namn {addedEmployee.firstName} {addedEmployee.lastName} och lön {addedEmployee.salary} \n");
        }

        static void UpdateEmployee()
        {
            Console.WriteLine("Ange förnamn på den anställde som du vill uppdatera:");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ange efternamn på den anställde som du vill uppdatera:");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ange den nya lönen för den anställde:");
            double newSalary;

            while (!double.TryParse(Console.ReadLine(), out newSalary))
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange sifran på format: '30000,55'\n");
            }
            
            Employee? updatedEmployee = employees.Update(firstName, lastName, newSalary);
            
            if (updatedEmployee != null)
            {
                Console.WriteLine($"Anställd uppdaterad:\n" +
                    $"Namn {updatedEmployee.firstName} {updatedEmployee.lastName} med ny lön {updatedEmployee.salary} \n");
            }
            else
            {
                Console.WriteLine("Anställd hittades inte i registret.\n");
            }
        }

        static void RemoveEmployee()
        {
            Console.WriteLine("Ange förnamn på den anställde som du vill ta bort:");
            string firstName = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Ange efternamn på den anställde som du vill ta bort:");
            string lastName = Console.ReadLine() ?? string.Empty;
            
            Employee? removedEmployee = employees.Remove(firstName, lastName);
            
            if (removedEmployee != null)
            {
                Console.WriteLine($"Anställd borttagen från registret:\n" +
                    $"Namn {removedEmployee.firstName} {removedEmployee.lastName}\n");
            }
            else
            {
                Console.WriteLine("Anställd hittades inte i registret.\n");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Välkomen till Restaurang registret\n");

            string option = string.Empty;
            while (option != "x")
            {
                Console.WriteLine("Välj ett alternativ från menyn:\n");
                Console.WriteLine("Meny:\n");
                Console.WriteLine("1 Lägg till anställd");
                Console.WriteLine("2 Visa alla anställda");
                Console.WriteLine("3 Uppdatera anställds lön");
                Console.WriteLine("4 Ta bort anställd\n");
                Console.WriteLine("x Avsluta programmet");

                option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        AddEmployee();
                        break;

                    case "2":
                        employees.ListEmployees();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        RemoveEmployee();
                        break;
                    case "x":
                        Console.WriteLine("Avslutar programmet...");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            ShowMenu();            
        }
    }
}
