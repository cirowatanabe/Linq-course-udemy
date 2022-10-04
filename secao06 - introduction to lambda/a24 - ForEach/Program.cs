List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };


// printing warriors height in one line with ForEach method

warriors.ForEach(w => Console.Write(w.Height + " "));
// 100 80 100 70

Separator();

// we can also manipulate the list

warriors.ForEach(w => w.Height *= 2);
warriors.ForEach(w => Console.Write(w.Height + " "));
//200 160 200 140




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