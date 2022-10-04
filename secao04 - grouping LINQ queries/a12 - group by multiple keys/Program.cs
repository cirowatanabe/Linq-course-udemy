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



var multipleKeys = from p in people
                   group p by new { p.Age, p.Gender };
// Here we are grouping people first by their age, then by their gender. For example, Tod (the first on the list) is 26. The query will group everybody that is 26, but will exclude those who are not male – because the second grouping key is gender.

// To group objects by more than 1 key, we need to write 'group object by new { key1, key2 };'. Remember that the group clause ends a query.


foreach (var key in multipleKeys)
{
    Console.WriteLine(key.Key);
    foreach (var p in key)
    {
        Console.WriteLine($"  {p.FirstName}");
    }
}
/*
 { Age = 26, Gender = Male }
  Tod
{ Age = 21, Gender = Male }
  John
  Aaron
{ Age = 22, Gender = Female }
  Anna
{ Age = 29, Gender = Male }
  Kyle
{ Age = 28, Gender = Male }
  Anna
{ Age = 43, Gender = Female }
  Maria
{ Age = 37, Gender = Female }
  John
{ Age = 33, Gender = Male }
  Samba
{ Age = 20, Gender = Female }
  Aby
{ Age = 19, Gender = Female }
  Maddie
{ Age = 18, Gender = Female }
  Lara
*/

Console.WriteLine(new String('=', 40));

// If we wanted to order the collection created by multipleKeys query by showing first the group that has one person, then the group that has 2, and so on, we would need a new query, because the group clause ends the query (so we couldn't write a orderby clause after it in the above query):

var orderedKeys = from g in multipleKeys
                  orderby g.Count()
                  select g;

foreach (var group in orderedKeys)
{
    Console.WriteLine($"Gender: {group.Key.Gender}, Age: {group.Key.Age}");
    foreach (var person in group)
    {
        Console.WriteLine($"  {person.FirstName}");
    }
    Console.WriteLine();
}

// Actually there is a better way to do this, using the 'into' keyword (see next class)

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