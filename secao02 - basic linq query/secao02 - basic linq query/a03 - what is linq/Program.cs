string sentence = "I love cats";
string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var getTheNumbers = from number in numbers
                    where number < 5
                    select number;

List<int> newNumbers = new List<int>();

foreach (var number in numbers)
{
    if (number < 5)
    {
        newNumbers.Add(number);
    }
}

Console.WriteLine(string.Join(", ", getTheNumbers));
Console.WriteLine(string.Join(", ", newNumbers));