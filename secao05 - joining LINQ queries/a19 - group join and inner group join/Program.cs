List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District", Age = 40 },
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


var groupJoin = from s in suppliers
                join b in buyers on s.District equals b.District into buyersGroup // buyersGroup is IEnumerable
                select new
                {
                    s.Name,
                    s.District,
                    Buyers = from b in buyersGroup
                             orderby b.Age
                             select b
                    // Here we made another linq search to define the Buyers attribute. When we have a linq inside a group join, we have a inner group join
                };

foreach (var supplier in groupJoin)
{
    Console.WriteLine($"Supplier: {supplier.Name}; District: {supplier.District}");
    foreach (var buyer in supplier.Buyers)
    {
        Console.WriteLine($"    {buyer.Name}, {buyer.Age}");
    }
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

