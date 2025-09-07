
using Philosophers.Model;

namespace Philosophers.Step;

public class Program
{
    public static void Main()
    {
        var namePath = "names.txt";
        var names = File.Exists(namePath) 
                    ? File.ReadAllLines(namePath).Where(s => !string.IsNullOrWhiteSpace(s)).ToList()
                    : ["Платон", "Аристотель", "Сократ", "Декарт", "Кант"];

        if (names.Count != 5)
        {
            Console.WriteLine("Имен не 5");
        }

        var table = new Table(names);
        table.Run();
    }
}