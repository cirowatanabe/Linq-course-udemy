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


var genderGroup = from p in people
                   group p by p.Gender;
                   

foreach (var person in genderGroup)
{
    Console.WriteLine();
    Console.WriteLine($"{person.Key}");
    Console.WriteLine(new String('-', 40));
    Console.WriteLine();
    foreach (var p in person)
    {
        Console.WriteLine($"    {p.FirstName} {p.LastName}");
    }
}

var groupWithConditions = from p in people
                          where p.Age > 20
                          orderby p.Age
                          group p by p.Age;

foreach (var age in groupWithConditions)
{
    Console.WriteLine(age.Key);
    Console.WriteLine(new String('=', 30));
    foreach (var person in age)
    {
        Console.WriteLine($"    {person.FirstName}, {person.Age}");
    }
}

var alphabeticalGroup = from p in people
                        orderby p.FirstName
                        group p by p.FirstName[0];

foreach (var letter in alphabeticalGroup)
{
    Console.WriteLine($"Letter {letter.Key}");
    foreach (var p in letter)
    {
        Console.WriteLine($"    {p.FirstName}");
    }
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