List<Person> people = new List<Person>()
{
    new Person("Tod", 180, 70, Gender.Male),
    new Person("John", 170, 88, Gender.Male),
    new Person("Anna", 150, 48, Gender.Female),
    new Person("Kyle", 164, 77, Gender.Male),
    new Person("Anna", 164, 77, Gender.Female),
    new Person("Maria", 160, 55, Gender.Female),
    new Person("John", 160, 55, Gender.Male)
};

var fourCharPeople = from p in people
                     where p.Name.Length == 4
                     orderby p.Name descending, p.Height ascending
                     select p;

foreach (var person in fourCharPeople)
{
    Console.WriteLine($"Name: {person.Name}, height: {person.Height}");
}



internal class Person
{
    private string name;
    private int height;
    private int weight;

    private Gender gender;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public Gender Gender { get; set; }

    public Person(string name, int height, int weight, Gender gender)
    {
        Name = name;
        Height = height;
        Weight = weight;
        Gender = gender;
    }
}

internal enum Gender
{
    Male,
    Female
}