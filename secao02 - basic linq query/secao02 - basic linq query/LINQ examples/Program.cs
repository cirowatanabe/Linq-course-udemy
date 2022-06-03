string sentence = "I love cats";
string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var catsWithA = from cat in catNames
                where cat.Contains('a') && (cat.Length < 5)
                select cat;

Console.WriteLine(String.Join(", ", catsWithA));

var numbersBetweenFiveAndTen = from num in numbers
                           where (num > 5) && (num < 10)
                           orderby num // ascending / descending
                           select num;

Console.WriteLine(String.Join(", ", numbersBetweenFiveAndTen));