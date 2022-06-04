int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var groupEvenOdd = from n in numbers
                   orderby n
                   let evenOrOdd = (n % 2 == 0)
                   group n by evenOrOdd into nums
                   orderby nums.Count()
                   select nums;

foreach (var group in groupEvenOdd)
{
    Console.WriteLine(group.Key ? "Pares" : "Ímpares");
    foreach (var number in group)
    {
        Console.Write(number + ", ");
    }
    Console.WriteLine();
}

//List<int> even = new List<int>();
//List<int> odd = new List<int>();

//foreach (int n in numbers)
//{
//    if (n % 2 == 0)
//    {
//        even.Add(n);
//    }
//    else
//    {
//        odd.Add(n);
//    }
//}

//Dictionary<bool, List<int>> dict = new Dictionary<bool, List<int>>();
//dict.Add(true, odd);
//dict.Add(false, even);