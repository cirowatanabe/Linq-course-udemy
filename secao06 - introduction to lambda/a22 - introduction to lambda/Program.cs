List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var evenNumbers = numbers.Where(n => n % 2 == 0);

Console.WriteLine(string.Join(", ", evenNumbers));
//6, 2, 6, 8, 4, 234, 54, 14, 4, 6

var evenIndex = numbers.Where((n, i) =>
{
    return (i % 2 == 0);
});

Console.WriteLine(string.Join(", ", evenIndex));
// 5, 3, 1, 6, 8, 234, 14, 3, 5, 7