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


var innerJoin = from s in suppliers
                join b in buyers on s.District equals b.District
                select new
                {
                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    s.District // Its the same of District = s.District *
                };
// * If the property name is the same of the selected property, we can ommit it

foreach (var item in innerJoin)
{
    Console.WriteLine(item);
    Console.WriteLine();
}
/*
 { SupplierName = Harrison, BuyerName = Johny, District = Fantasy District }

{ SupplierName = Harrison, BuyerName = Paul, District = Fantasy District }

{ SupplierName = Harrison, BuyerName = Pierce, District = Fantasy District }

{ SupplierName = Charles, BuyerName = Sylvia, District = Developers District }

{ SupplierName = Charles, BuyerName = Jaime, District = Developers District }

{ SupplierName = Hailee, BuyerName = Peter, District = Scientists District }

{ SupplierName = Hailee, BuyerName = Maria, District = Scientists District }

{ SupplierName = Hailee, BuyerName = Rebecca, District = Scientists District }

{ SupplierName = Taylor, BuyerName = Joshua, District = EarthIsFlat District }
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
    
