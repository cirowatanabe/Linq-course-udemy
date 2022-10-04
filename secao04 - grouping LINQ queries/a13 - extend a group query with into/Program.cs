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


var peopleByAge = from p in people
                  group p by p.Age into groupAge
                  orderby groupAge.Key
                  select groupAge;

// The 'into' keyword allows us to group a list by some property and continue with the query. In some ways, it is similar to the 'let' keyword, because it also creates a new variable to work with. In this example we created a new variable called 'groupAge', which groups the list of people by their age, and then we worked on this variable ordering it by its key.

foreach (var group in peopleByAge)
{
    Console.WriteLine($"Age: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($"    {person.FirstName}");
    }
}

/*
 Age: 18
    Lara
Age: 19
    Maddie
Age: 20
    Aby
Age: 21
    John
    Aaron
Age: 22
    Anna
Age: 26
    Tod
Age: 28
    Anna
Age: 29
    Kyle
Age: 33
    Samba
Age: 37
    John
Age: 43
    Maria
*/

Console.WriteLine(new String('=', 40));

// Improving the last lecture's example

var peopleByGenderAndAge = from p in people
                           group p by new { p.Gender, p.Age } into groupAux
                           orderby groupAux.Count()
                           select groupAux;

foreach (var group in peopleByGenderAndAge)
{
    Console.WriteLine($"Gender: {group.Key.Gender}, Age: {group.Key.Age}");
    foreach (Person person in group)
    {
        Console.WriteLine($"   {person.FirstName}");
    }
}

/*
 Gender: Male, Age: 26
   Tod
Gender: Female, Age: 22
   Anna
Gender: Male, Age: 29
   Kyle
Gender: Male, Age: 28
   Anna
Gender: Female, Age: 43
   Maria
Gender: Female, Age: 37
   John
Gender: Male, Age: 33
   Samba
Gender: Female, Age: 20
   Aby
Gender: Female, Age: 19
   Maddie
Gender: Female, Age: 18
   Lara
Gender: Male, Age: 21
   John
   Aaron
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