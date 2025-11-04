namespace RestaurangRegistret
{
    internal class Program
    {
        static Employees employees = new Employees();
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void AddEmployee()
        {
            Console.Write("Ange förnamn på den anställde: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Ange efternamn på den anställde: ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Ange lön för den anställde: ");
            double salary;
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange sifran på format: '30000,55'\n");
            }

            Employee addedEmployee = employees.Add(firstName, lastName, salary);

            Console.WriteLine($"\nAnställd tillagd i registret med:\n" +
                $"ID {addedEmployee.id} Namn {addedEmployee.firstName} {addedEmployee.lastName} och lön {addedEmployee.salary} \n");
        }

        static void UpdateEmployee()
        {
            Console.Write("Ange id på den anställde som du vill uppdatera: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange en giltig ID\n");
            }

            Console.Write("Ange den nya lönen för den anställde: ");
            double newSalary;

            while (!double.TryParse(Console.ReadLine(), out newSalary))
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange sifran på format: '30000,55'\n");
            }
            
            Employee? updatedEmployee = employees.UpdateSalary(id, newSalary);
            
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
            Console.Write("Ange id på den anställde som du vill uppdatera: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange en giltig ID\n");
            }

            Employee? removedEmployee = employees.Remove(id);
            
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

        static void ChangeEmployeeName()
        {
            Console.Write("Ange ID på den anställde som du vill byta namn på: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange ett giltigt ID nummer.\n");
            }

            Console.WriteLine("Ange nytt förnamn:");
            string newFirstName = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Ange nytt efternamn:");
            string newLastName = Console.ReadLine() ?? string.Empty;
            
            Employee? updatedEmployee = employees.ChangeName(id, newFirstName, newLastName);
            if (updatedEmployee != null)
            {
                Console.WriteLine($"Anställds namn uppdaterat:\n" +
                    $"ID: {updatedEmployee.id} Namn: {updatedEmployee.firstName} {updatedEmployee.lastName} Lön: {updatedEmployee.salary}\n");
            }
            else
            {
                Console.WriteLine("Anställd hittades inte i registret.\n");
            }
        }

        static void FindEmployeeByFullName()
        {
            Console.Write("Ange förnamn på den anställde du vill hitta: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Ange efternamn på den anställde du vill hitta: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            
            Employee? foundEmployee = employees.FindByFullName(firstName, lastName);
            if (foundEmployee != null)
            {
                Console.WriteLine($"Anställd hittad:\n" +
                    $"ID: {foundEmployee.id} Namn: {foundEmployee.firstName} {foundEmployee.lastName} Lön: {foundEmployee.salary}\n");
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
                Console.WriteLine("3 Hitta anställd via förnamn och efternamn");
                Console.WriteLine("4 Uppdatera anställds lön");
                Console.WriteLine("5 Ta bort anställd");
                Console.WriteLine("6 Bytta Employee namn\n");
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
                        FindEmployeeByFullName();
                        break;

                    case "4":
                        UpdateEmployee();
                        break;

                    case "5":
                        RemoveEmployee();
                        break;

                    case "6":
                        ChangeEmployeeName();
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

    }
}
