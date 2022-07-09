List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var evenNumbers = numbers.Where(n => n % 2 == 0);

Console.WriteLine(string.Join(", ", evenNumbers));

var evenIndex = numbers.Where((n, i) =>
{
    return (i % 2 == 0);
});

Console.WriteLine(string.Join(", ", evenIndex));