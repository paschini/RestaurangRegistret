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

        static void ShowEmployees()
        {
            Console.WriteLine("Lista över alla anställda:\n");
            employees.ListEmployees();
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
                Console.WriteLine("x Avsluta programmet\n");

                option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        AddEmployee();
                        break;

                    case "2":
                        ShowEmployees();
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
