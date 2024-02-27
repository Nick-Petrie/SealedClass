interface IEmployee
{
    // Properties
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }

    // Methods
    string Fullname();
    double Pay();
}

class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee() { }

    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Fullname()
    {
        return FirstName + " " + LastName;
    }

    public virtual double Pay()
    {
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        double salary = double.Parse(Console.ReadLine());
        return salary;
    }
}

sealed class Executive : Employee
{
    public string Title { get; set; }
    public double Salary { get; set; }

    public Executive() { }

    public Executive(int id, string firstName, string lastName, string title, double salary) : base(id, firstName, lastName)
    {
        Title = title;
        Salary = salary;
    }

    public override double Pay()
    {
        Salary = double.Parse(Console.ReadLine());
        return Salary;
    }

    public double Pay(double bonus)
    {
        Salary += bonus;
        return Salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee(1, "Nick", "Petrie");
        Console.WriteLine($"{employee.Fullname()}");

        Executive executive = new Executive(2, "McKenzie", "Petrie", "Wife", 1000000);
        Console.WriteLine($"{executive.Fullname()}, {executive.Title}, {executive.Salary}");
    }
}
