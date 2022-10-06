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

// O inner join exclui aqueles itens que não possuem um 'match' com a outra tabela. No caso, se estivermos comparando os distritos de suppliers e buyers, o supplier Taylor seria excluído da query, já que não há nenhum buyer do distrito EarthIsFlat.
// A diferença do outerjoin é que ele não exclui Taylor da query. No caso, o 'match' de taylor é vazio, mas podemos atribuir valores padrões a esse 'match'.

var leftOuterJoin = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
    (s, buyersGroup) => new
    {
        s.Name,
        s.District,
        Buyers = buyersGroup.OrderBy(b => b.Name)
    })
    .SelectMany(s => s.Buyers.DefaultIfEmpty(),
    (s, b) => new
    {
        s.Name,
        s.District,
        BuyersName = b?.Name ?? "No name", // Se b for vazio então BuyersName recebe "No name"
        BuyersDistrict = b?.District ?? "No place" // Se b for vazio então BuyersDistrict recebe "No place"
    });

// Essa query, porém, é muito verbosa, além de que o resultado é uma colação de objetos com Name, District, BuyersName e BuyersDistrict. Um supplier que tem vários buyers correspondentes (compartilham o mesmo distrito) resultará em vários objetos 'repetidos' (ver abaixo). O ideal seria uma coleção de objetos que possuem Name, District e uma coleção de buyers.

foreach (var item in leftOuterJoin)
{
    Console.WriteLine($"{item.District}");
    Console.WriteLine($"    {item.Name} - {item.BuyersName}");
}

/*
 Fantasy District
    Harrison - Johny            Harrison do distrito fantasy se repete 3x 
Fantasy District
    Harrison - Paul
Fantasy District
    Harrison - Pierce
Developers District
    Charles - Jaime
Developers District
    Charles - Sylvia
Scientists District
    Hailee - Joshua
Scientists District
    Hailee - Maria
Scientists District
    Hailee - Peter
Scientists District
    Hailee - Rebecca
EarthIsFlat District
    Taylor - No name
*/

// Com a sintaxe de query ficaria desse modo: 

var queryLeftOuterJoin = from supplier in suppliers
                         join buyer in buyers on supplier.District equals buyer.District into buyersGroup
                         from bg in buyersGroup.DefaultIfEmpty()
                         select new
                         {
                             supplier.Name,
                             supplier.District,
                             BuyersName = bg?.Name ?? "No buyer",
                             BuyersDistrict = bg?.District ?? "Nowhere"
                         };

// Agora, o melhor modo de fazer o outerjoin:

var betterOuterJoin = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
    (s, buyersGroup) => new
    {
        s.Name,
        s.District,
        Buyers = buyersGroup.DefaultIfEmpty(new Buyer()
        {
            Name = "No one",
            District = "No place"
        })
    });

SeparatingLine();

foreach (var obj in betterOuterJoin)
{
    Console.WriteLine($"{obj.Name} - {obj.District}");
    foreach (var buyer in obj.Buyers) 
    {
        Console.WriteLine($"    {buyer.Name}");
    }
}
/*
 Harrison - Fantasy District
    Johny
    Paul
    Pierce
Charles - Developers District
    Sylvia
    Jaime
Hailee - Scientists District
    Peter
    Maria
    Joshua
    Rebecca
Taylor - EarthIsFlat District
    No one
*/

// Com a sintaxe de query ficaria assim: 

var queryOuterJoinBetterVersion = from s in suppliers
                                  orderby s.District
                                  join b in buyers on s.District equals b.District into buyersGroup
                                  select new
                                  {
                                      SupplierName = s.Name,
                                      s.District,
                                      Buyers = buyersGroup.DefaultIfEmpty(new Buyer()
                                      {
                                          Name = "No one here",
                                          District = "No place here"
                                      })
                                  };



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