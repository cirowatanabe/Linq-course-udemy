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



var innerJoin = suppliers.Join(buyers, s => s.District, b => b.District,
                                (s, b) => new
                                {
                                    SupplierName = s.Name,
                                    BuyerName = b.Name,
                                    District = s.District
                                });

foreach (var item in innerJoin)
{
    Console.WriteLine($"District: {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}.");
}
/*
 District: Fantasy District, Supplier: Harrison, Buyer: Johny.
District: Fantasy District, Supplier: Harrison, Buyer: Paul.
District: Fantasy District, Supplier: Harrison, Buyer: Pierce.
District: Developers District, Supplier: Charles, Buyer: Sylvia.
District: Developers District, Supplier: Charles, Buyer: Jaime.
District: Scientists District, Supplier: Hailee, Buyer: Peter.
District: Scientists District, Supplier: Hailee, Buyer: Maria.
District: Scientists District, Supplier: Hailee, Buyer: Joshua.
District: Scientists District, Supplier: Hailee, Buyer: Rebecca.
*/

SeparatingLine();

// JOIN BY COMPOSITE KEY

var compositeJoin = suppliers.Join(buyers,
    s => new { s.District, s.Age },
    b => new { b.District, b.Age },
    (s, b) => new
    {
        SupplierName = s.Name,
        BuyerName = b.Name,
        District = s.District,
        Age = b.Age
    });

foreach (var item in compositeJoin)
{
    Console.WriteLine($"{item.District}, Age: {item.Age}");
    Console.WriteLine($"{item.SupplierName}, buyer: {item.BuyerName}");
}
/*
Fantasy District, Age: 22
Harrison, buyer: Johny
Scientists District, Age: 35
Hailee, buyer: Maria
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