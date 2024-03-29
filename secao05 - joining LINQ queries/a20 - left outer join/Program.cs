﻿List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "Developers District", Age = 40 },
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


var leftOuterJoin = from s in suppliers
                    join b in buyers on s.District equals b.District into buyersGroup
                    select new
                    {
                        s.Name,
                        s.District,
                        Buyers = buyersGroup.DefaultIfEmpty(
                        new Buyer()
                        {
                            Name = "No one here",
                            District = "I dont exist!"
                        })
                    };

foreach (var item in leftOuterJoin)
{
    Console.WriteLine($"Supplier: {item.Name}, District: {item.District}");
    foreach (var buyer in item.Buyers)
    {
        Console.WriteLine($"        {buyer.Name}");
    }
}

/*
 Supplier: Harrison, District: Fantasy District
        Johny
        Paul
        Pierce
Supplier: Charles, District: Developers District
        Joshua
        Sylvia
        Jaime
Supplier: Hailee, District: Scientists District
        Peter
        Maria
        Rebecca
Supplier: Taylor, District: EarthIsFlat District
        No one here
*/


// There is another way to make the left outer join
Console.WriteLine("===================================");

var alternativeLeftOuterJoin = from s in suppliers
                               join b in buyers on s.District equals b.District into buyersGroup
                               from bG in buyersGroup.DefaultIfEmpty()
                               select new
                               {
                                   s.Name,
                                   s.District,
                                   BuyersName = bG?.Name ?? "No one here",
                                   BuyersDistrict = bG?.District ?? "I dont exist"
                               };

foreach (var item in alternativeLeftOuterJoin)
{
    Console.WriteLine($"{item.Name} - {item.District}");
    Console.WriteLine($"    {item.BuyersName}, {item.BuyersDistrict}");
}

/*
 Harrison - Fantasy District
    Johny, Fantasy District
Harrison - Fantasy District
    Paul, Fantasy District
Harrison - Fantasy District
    Pierce, Fantasy District
Charles - Developers District
    Joshua, Developers District
Charles - Developers District
    Sylvia, Developers District
Charles - Developers District
    Jaime, Developers District
Hailee - Scientists District
    Peter, Scientists District
Hailee - Scientists District
    Maria, Scientists District
Hailee - Scientists District
    Rebecca, Scientists District
Taylor - EarthIsFlat District
    No one here, I dont exist
*/


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

