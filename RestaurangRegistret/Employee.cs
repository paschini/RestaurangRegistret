using System;

public class Employee
{
    public int id { get; private set; }
    public string firstName { get; private set; }
    public string lastName { get; private set; }
    public double salary { get; private set; }

    public void ChangeName(string newFirstName, string newLastName)
    {
        this.firstName = newFirstName;
        this.lastName = newLastName;
    }

    public void ChangeSalary(double newSalary)
    {
        this.salary = newSalary;
    }

    public Employee(int id, string firstName, string lastName, double salary)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
    }
}