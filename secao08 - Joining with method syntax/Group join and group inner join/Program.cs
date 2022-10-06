using System.Runtime.Versioning;

List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "Scientists District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
            };
List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 }
            };



var groupJoin = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
    (s, buyersGroup) => new
    {
        s.Name,
        s.District,
        Buyers = buyersGroup.OrderBy(b => b.Name)
    });

foreach (var supplier in groupJoin)
{
    Console.WriteLine($"Supplier: {supplier.Name}, District: {supplier.District}");
    foreach (var buyer in supplier.Buyers)
    {
        Console.WriteLine($"    {buyer.Name}");
    }
}

/*
 Supplier: Harrison, District: Fantasy District
    Johny
    Paul
    Pierce
Supplier: Charles, District: Developers District
    Sylvia
    Jaime
Supplier: Hailee, District: Scientists District
    Peter
    Maria
    Joshua
    Rebecca
Supplier: Taylor, District: EarthIsFlat District
*/



static void SeparatingLine()
{
    Console.WriteLine(new string('-', 40));
}

internal class Supplier
{
    public string Name { get; set; }
    public string District { get; set; }
    public int Age { get; set; }
}

internal class Buyer
{
    public string Name { get; set; }
    public string District { get; set; }
    public int Age { get; set; }
}