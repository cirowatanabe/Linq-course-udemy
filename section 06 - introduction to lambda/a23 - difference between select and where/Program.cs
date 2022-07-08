List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };


var warriorsHeight = warriors.Select(w => w.Height);
var heightsDoubled = warriors.Select(w => w.Height * 2);
var warriorsHeightSum = warriors.Select(w => w.Height).Sum();

Console.WriteLine(String.Join(", ", warriorsHeight));
//100, 80, 100, 70

Console.WriteLine(String.Join(", ", heightsDoubled));
//200, 160, 200, 140

Console.WriteLine(warriorsHeightSum);
//350

Separator();

// It is possible to combine Where and Select to select specific things in a list filtering it by some condition 

var shortHeights = warriors.Where(w => w.Height == 100)
                            .Select(w => w.Height);
// First we filtered the list of warriors by the warriors that have height equals to 100. Then we selected just their heights.

Console.WriteLine(String.Join(", ", shortHeights));
//100, 100

Separator();

string aleatoria = "abcde";
int[] newIntArray = aleatoria.Split(' ')
                                .Select(element => int.Parse(element))
                                .ToArray();
Console.WriteLine(String.Join(", ", newIntArray));


void Separator()
{
    Console.WriteLine();
    Console.WriteLine(new String('-', 40));
    Console.WriteLine();
}

internal class Warrior
{
    public int Height { get; set; }
}

    
