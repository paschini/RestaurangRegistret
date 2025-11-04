using System;

public class Employees
{
    List<Employee> all = new List<Employee>();

    public Employee Add(string FirstName, string lastName, double salary)
    {
        all.Add(new Employee(all.Count + 1, FirstName, lastName, salary));
        return all[^1];
    }

    public Employee? FindByFullName(string firstName, string lastName)
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

    public Employee? FindById(int id)
    {
        foreach (var emp in all)
        {
            if (emp.id == id)
            {
                return emp;
            }
        }
        return null;
    }

    public Employee? UpdateSalary(int id, double newSalary)
    {
        var emp = FindById(id);
        if (emp != null)
        {
            emp.salary = newSalary;
        }
        return emp;
    }

    public Employee? Remove(string firstName, string lastName)
    {
        var emp = FindByFullName(firstName, lastName);
        if (emp != null)
        {
            all.Remove(emp);
        }
        return emp;
    }

    public Employee? ChangeName(int id, string newFirstName, string newLastName)
    {
        var emp = FindById(id);
        if (emp != null)
        {
            emp.firstName = newFirstName;
            emp.lastName = newLastName;
        }
        return emp;
    }

    public void ListEmployees()
    {
        Console.WriteLine("Lista över alla anställda:\n");
        if (all.Count > 0)
        {
            foreach (var employee in all)
            {
                Console.WriteLine($"ID: {employee.id} Namn: {employee.firstName} {employee.lastName} Lön: {employee.salary} \n");
            }
        } else
        {
            Console.WriteLine("Inga anställda i registret.\n");
        }
    }
}
