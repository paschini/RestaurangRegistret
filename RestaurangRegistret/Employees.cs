using System;

public class Employees
{
	List<Employee> all = new List<Employee>();

    public Employee Add(string FirstName, string lastName, double salary)
    {
        all.Add(new Employee(FirstName, lastName, salary));
        return all[^1];
    }

    Employee? Find(string firstName, string lastName)
    {
        foreach (var emp in all)
        {
            if (emp.firstName == firstName && emp.lastName == lastName)
            {
                return emp;
            }
        }
        return null;
    }

    Employee? Update(string firstName, string lastName, double newSalary)
    {
        var emp = Find(firstName, lastName);
        if (emp != null)
        {
            emp.salary = newSalary;
        }
        return emp;
    }

    Employee? Remove(string firstName, string lastName)
    {
        var emp = Find(firstName, lastName);
        if (emp != null)
        {
            all.Remove(emp);
        }
        return emp;
    }

    public void ListEmployees()
    {
        if (all.Count > 0)
        {
            foreach (var emp in all)
            {
                Console.WriteLine($"Namn: {emp.firstName} {emp.lastName} Lön: {emp.salary} \n");
            }
        } else
        {
            Console.WriteLine("Inga anställda i registret.\n");
        }
    }
}
