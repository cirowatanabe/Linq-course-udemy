
List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 22, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Male),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 23, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };

int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var evenOrOdd = arrayOfNumbers.OrderBy(n => n).GroupBy(n => (n % 2 == 0) ? "Even" : "Odd");

foreach (var group in evenOrOdd)
{
    Console.WriteLine(group.Key);
    foreach (var number in group)
    {
        Console.WriteLine($"   {number}");
    }
}

/*
Odd
   1
   3
   3
   5
   5
   5
   7
   7
   653
Even
   2
   4
   6
   6
   14
   54
   234
*/

Separator();

var ageGroups = people.GroupBy(p =>
{
    var adultOrSenior = (p.Age <= 22) ? "Adult" : "Senior";
    return (p.Age < 20) ? "Young" : adultOrSenior;
});


foreach (var group in ageGroups) 
{
    Console.WriteLine(group.Key);
    foreach (var person in group)
    {
        Console.WriteLine($"  {person.FirstName}");
    }
}
/*
Senior
  Tod
  Kyle
  Anna
  Samba
  Aaron
  Lara
Adult
  John
  Anna
  John
  Aby
Young
  Maria
  Maddie
*/

Separator();

var howManyOfEachGroup = people.GroupBy(p => p.Gender)
                               .Select(g => new
                               {
                                   Gender = g.Key,
                                   NumOfPeople = g.Count()
                               });

// Here we grouped people by their gender then we selected a new anonymous object. This object has Gender and NumOfPeople as properties.

foreach (var group in howManyOfEachGroup)
{
    Console.WriteLine(group.Gender);
    Console.WriteLine($"   {group.NumOfPeople}");
}
/*
Male
   7
Female
   5
*/





void Separator()
{
    Console.WriteLine(new String('-', 50));
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
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
        }
    }

    public int ID
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public int Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.height = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public Gender Gender
    {
        get
        {
            return this.gender;
        }
        set
        {
            this.gender = value;
        }
    }

    public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.Height = height;
        this.Age = age;
        this.Gender = gender;
    }
}

internal enum Gender
{
    Male,
    Female
}