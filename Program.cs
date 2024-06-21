using Lesson12.Models;
using System.Text;
using System.Text.Json;

string? name = "";
decimal weight = 0;
User user;
bool check = true;
if (!File.Exists("User.txt"))
{
    var userFile = new FileStream("User.txt", FileMode.Create, FileAccess.Write);
    Console.Write("Enter the name : ");
    name = Console.ReadLine();
    Console.Write("Enter your weight : ");
    weight = decimal.Parse(Console.ReadLine());
    user = new User(name, weight);
    user.CalculateTheWater();
    Console.WriteLine(user.Day);
    Console.WriteLine($"Needed water for per day : {user.NeededWater}");
    Console.WriteLine($"Today : {user.LiterOfWater}");
    while (check)
    {
        Console.WriteLine("1.Drink water");
        Console.WriteLine("2.Hisstory");
        Console.WriteLine("3.End the day");
        Console.WriteLine("4.Exit");
        string? choice;
        Console.Write("Enter your choice : ");
        choice = Console.ReadLine();
        byte[] bytes = new byte[name.Length];
        var data =  JsonSerializer.Serialize(user);
        userFile.Write(Encoding.UTF8.GetBytes(data));
        userFile.Flush();
        switch (choice)
        {
            case "1":
                decimal liter;
                Console.Write("Enter the amount of water you drink today :");
                liter = decimal.Parse(Console.ReadLine());
                user.DrinkWater(liter);
                Console.Clear();
                break;
            case "2":
                user.History();
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "3":
                user.EndTheDay();
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "4":
                check = false;
                break;
            default:
                break;
        }
    }
}
else
{
    var userFile = new FileStream("User.txt", FileMode.Open, FileAccess.Write);
    user = new User(name, weight);
    byte[] bytes = new byte[name.Length];
    var data = JsonSerializer.Serialize(user);
    userFile.Write(Encoding.UTF8.GetBytes(data));
    userFile.Flush();
    Console.WriteLine(user.Day);
    Console.WriteLine($"Needed water for per day : {user.NeededWater}");
    Console.WriteLine($"Today : {user.LiterOfWater}");
    while (check)
    {
        Console.WriteLine("1.Drink water");
        Console.WriteLine("2.Hisstory");
        Console.WriteLine("3.End the day");
        Console.WriteLine("4.Exit");
        string? choice;
        Console.Write("Enter your choice : ");
        choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                decimal liter;
                Console.Write("Enter the amount of water you drink today :");
                liter = decimal.Parse(Console.ReadLine());
                user.DrinkWater(liter);
                Console.Clear();
                break;
            case "2":
                user.History();
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "3":
                user.EndTheDay();
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "4":
                check = false;
                break;
            default:
                break;
        }
    }
}



