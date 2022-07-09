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

var groupByGender = people.GroupBy(p => p.Gender);

// In this case, GroupBy() iterates over the people's list, receiving as an argument a key selector function. This function has to receive a person as an argument, and it has to return a person's property. The GroupBy clause will then return a IGrouping<Key, Person> (in this case Key = Gender).

foreach (var group in groupByGender)
{
    Console.WriteLine(group.Key);
    foreach (var person in group)
    {
        Console.WriteLine($"   {person.FirstName}");
    }
}

//Male
//   Tod
//   John
//   Kyle
//   Anna
//   John
//   Samba
//   Aaron
//Female
//   Anna
//   Maria
//   Aby
//   Maddie
//   Lara

Separator();

// GroupBy has many overloads. In one of them, it receives a key selector function and an element selector function. The element selector function specifies a property which will be returned by GroupBy after it separates people in groups. 

var fetchNamesByGender = people.GroupBy(p => p.Gender, p => p.FirstName);
// fetchNamesByGender is an IGrouping<Gender, string>

// Also, it is possible to filter the list before grouping it:

var shortPeopleByGender = people.Where(p => p.Height >= 170)
                            .GroupBy(p => p.Gender);


foreach (var group in shortPeopleByGender)
{
    Console.WriteLine(group.Key);
    foreach (var person in group)
    {
        Console.WriteLine($"   {person.FirstName}, {person.Height}");
    }
}
/*Male
   Tod, 180
   John, 170
   Samba, 175
   Aaron, 182
*/

Separator();

var peopleByName = people.OrderBy(p => p.FirstName)
                        .GroupBy(p => p.FirstName.ToLower()[0]);


foreach (var group in peopleByName)
{
    Console.WriteLine(group.Key);
    foreach (var person in group)
    {
        Console.WriteLine($"   {person.FirstName}");
    }
}
/*a
   Aaron
   Aby
   Anna
   Anna
j
   John
   John
k
   Kyle
l
   Lara
m
   Maddie
   Maria
s
   Samba
t
   Tod*/


Separator();

// It is possible to group by more than one property. 

var multiKey = people.GroupBy(p => new {p.Gender, p.Age}).OrderBy(p => p.Count());

foreach (var group in multiKey)
{
    Console.WriteLine(group.Key);
    foreach (var person in group)
    {
        Console.WriteLine($"   {person.FirstName}");
    }
}

/*{ Gender = Male, Age = 26 }
   Tod
{ Gender = Female, Age = 22 }
   Anna
{ Gender = Male, Age = 29 }
   Kyle
{ Gender = Male, Age = 28 }
   Anna
{ Gender = Female, Age = 20 }
   Aby
{ Gender = Female, Age = 23 }
   Lara
{ Gender = Male, Age = 22 }
   John
   John
{ Gender = Female, Age = 19 }
   Maria
   Maddie
{ Gender = Male, Age = 23 }
   Samba
   Aaron*/


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