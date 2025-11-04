using System;

public class Employee
{
    public int id { get; private set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public double salary { get; set; }
    public Employee(int id, string firstName, string lastName, double salary)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
    }
}