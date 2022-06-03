string sentence = "I love cats";
string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

// Simple Linq Example
var simpleLinq = from s in sentence
                 select s;

Console.WriteLine(String.Join(", ", simpleLinq));

foreach (char s in simpleLinq)
{
    Console.WriteLine(s);
}

//for (int i = 0; i < simpleLinq.Count(); i++)
//{
//    Console.WriteLine(simpleLinq[i]);
//}

// Linq queries return IEnumerable objects. IEnumerable interface only supports foreach operations, it is not possible to access elements of an IEnumerable object by thier index.
