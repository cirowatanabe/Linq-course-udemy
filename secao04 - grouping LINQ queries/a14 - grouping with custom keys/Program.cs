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


var youngAdultOrSenior = from p in people
                         let adultOrSenior = (p.Age < 31) ? "Adults" : "Senior"
                         let youngOrOlder = (p.Age < 21) ? "Young" : adultOrSenior
                         group p by youngOrOlder;

// Here we nested a ternary operator inside a ternary operator. This way we can divide the list of people into three different categories: young, adult and senior.


foreach (var group in youngAdultOrSenior)
{
    Console.WriteLine(group.Key);
    foreach (Person p in group)
    {
        Console.WriteLine($"  {p.FirstName}, {p.Age}");
    }
}

/*
 Adults
  Tod, 26
  John, 21
  Anna, 22
  Kyle, 29
  Anna, 28
  Aaron, 21
Senior
  Maria, 43
  John, 37
  Samba, 33
Young
  Aby, 20
  Maddie, 19
  Lara, 18
*/



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