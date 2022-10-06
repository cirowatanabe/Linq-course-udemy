// Este é um exemplo de junção múltipla apresentado na documentação da microsoft:
// https://learn.microsoft.com/pt-br/dotnet/csharp/linq/perform-inner-joins

Person magnus = new(FirstName: "Magnus", LastName: "Hedlund");
Person terry = new("Terry", "Adams");
Person charlotte = new("Charlotte", "Weiss");
Person arlene = new("Arlene", "Huff");
Person rui = new("Rui", "Raposo");
Person phyllis = new("Phyllis", "Harris");

List<Person> people = new() { magnus, terry, charlotte, arlene, rui, phyllis };

List<Cat> cats = new()
{
    new(Name: "Barley", Owner: terry),
    new("Boots", terry),
    new("Whiskers", charlotte),
    new("Blue Moon", rui),
    new("Daisy", magnus),
};

List<Dog> dogs = new()
{
    new(Name: "Four Wheel Drive", Owner: phyllis),
    new("Duke", magnus),
    new("Denim", terry),
    new("Wiley", charlotte),
    new("Snoopy", rui),
    new("Snickers", arlene),
};

// 1 - A query a seguir faz uma junção interna (inner join ou apenas join) da tabela people com a tabela cats, com base na propriedade Owner de Cat. Isso significa que apenas as pessoas que possuem gato (ou seja, dão 'match' com cat.Owner de algum gato) serão selecionadas.
// 2 - Depois, um novo join é realizado a partir do resultado da primeira junção com a tabela dogs, comparando uma chave composta com as propriedades Owner e Letter (primeira letra do nome do gato e do cão). Assim, apenas poderão ser selecionados os gatos e cachorros que compartilham o dono e a primeira letra do nome (além do dono ele mesmo).
// 3 - Ao final, o que é selecionado é um objeto anônimo com as propriedades CatName, DogName e OwnersName.

var query = from person in people
            join cat in cats on person equals cat.Owner
            join dog in dogs on new
            {
                Owner = person,
                Letter = cat.Name.Substring(0, 1)
            } equals new
            {
                dog.Owner,
                Letter = dog.Name.Substring(0, 1)
            }
            select new
            {
                CatName = cat.Name,
                DogName = dog.Name,
                OwnersName = person.FirstName
            };

foreach (var obj in query)
{
    Console.WriteLine($"The cat {obj.CatName} shares a house, and the first letter of their name, with the dog {obj.DogName}. Their owner is called {obj.OwnersName}");
}
//The cat Daisy lives, and shares the name's first letter, with the dog Duke.
//The cat Whiskers lives, and shares the name's first letter, with the dog Wiley.



public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string FirstName, string LastName)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
}

public class Cat
{
    public string Name { get; set; }
    public Person Owner { get; set; }

    public Cat(string Name, Person Owner)
    {
        this.Name = Name;
        this.Owner = Owner;
    }
}

public class Dog
{
    public string Name { get; set; }
    public Person Owner { get; set; }

    public Dog(string Name, Person Owner)
    {
        this.Name = Name;
        this.Owner = Owner;
    }
}