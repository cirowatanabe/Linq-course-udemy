List<Person> people = new List<Person>()
{
    new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
    new Person("John", "Johnson", 2, 170, 21, Gender.Male),
    new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
    new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
    new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
    new Person("Maria", "Ann", 6, 160, 43, Gender.Female),
    new Person("John", "Jones", 7, 160, 37, Gender.Female),
    new Person("Samba", "TheLion", 8, 175, 33, Gender.Male),
    new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
    new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
    new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
    new Person("Lara", "Croft", 12, 162, 18, Gender.Female)
};



var youngPeople = from p in people
                  where p.Age < 25
                  select new { Name = p.FirstName, Age = p.Age };
// Here we created anonymous objects with the properties Name and Age. If we didn't name those properties, they would inherit the names of the propertiies we selected (FirstName, Age).

// It is also possible to instantiate objects of classes we have already created:

var youngClass = from p in people
                 where p.Age < 25
                 select new YoungPerson { FullName = string.Format($"{p.FirstName} {p.LastName}"), Age = p.Age };
// Notice that before assigning values to YoungPerson properties, it is possible to perform actions/operations over variables

foreach (var p in youngPeople)
{
    Console.WriteLine($"Name: {p.Name}, age: {p.Age}");
}

foreach (var p in youngClass)
{
    Console.WriteLine($"Now with the class we created:\n" +
        $"Name: {p.FullName}\n" +
        $"Age: {p.Age}");
}


internal class YoungPerson
{
    public string FullName { get; set; }
    public int Age { get; set; }
}

internal class Person
{
    private string firstName;
    private string lastName;
    private int id;
    private int height;
    private int age;

    private Gender gender;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Gender Gender { get; set; }

    public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Id = id;
        Height = height;
        Gender = gender;
        Age = age;
    }
}

internal enum Gender
{
    Male,
    Female
}