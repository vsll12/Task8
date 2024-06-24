using DrinkWater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrinkWater.Services
{
    internal class ControlPanel
    {
        User? User { get; set; }

        public ControlPanel()
        {
            Initialize();

        }

        public void Initialize()
        {
            if (File.Exists("User.json"))
            {
                var data = File.ReadAllText("User.json");

                User = JsonSerializer.Deserialize<User>(data);

            }

            if (User is null)
            {
                Console.WriteLine("Name : ");
                string? name;
                name = Console.ReadLine();
                Console.WriteLine("Weight : ");
                double.TryParse(Console.ReadLine(), out double weight);
                User = new User()
                {
                    Name = name,
                    Weight = weight,
                    CurrentDate = DateTime.Now,
                    CurrentLitr = 0,
                    History = new List<HistoryItem>()
                };

            }

        }

        public void EndDay()
        {
            Console.Clear();
            if (User == null) throw new Exception("User not found");
            var item = new HistoryItem(User.CurrentDate.ToString("dd.MM.yyyy"), User.CurrentLitr);
            User.History.Add(item);
            User.CurrentDate = User.CurrentDate.AddDays(1);
            User.CurrentLitr = 0;
        }
        
        public void DrinkWater()
        {
            Console.Clear();
            Console.WriteLine("Litr : ");
            double.TryParse(Console.ReadLine(), out double litr);
            User.CurrentLitr += litr;
        }

        public void ShowHistory()
        {
            Console.Clear();

            Console.WriteLine("History :");

            foreach (var item in User.History)
            {
                Console.WriteLine($"{item.Date}  {item.Litr}");
            }
        }

        public void Start()
        {

            string? choice;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Su ich");
                Console.WriteLine("2.History");
                Console.WriteLine("3.Gunu bitir");
                Console.WriteLine("4.Chixish");
                Console.WriteLine($"Gundelik norma  : {User.Norm}");
                Console.WriteLine("Secimi daxil edin : ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DrinkWater();
                        break;
                    case "2":
                        ShowHistory();
                        Thread.Sleep(3000);
                        break;
                    case "3":
                        EndDay();
                        break;
                    case "4":
                        return;
                }
            }
        }

        public void SaveChanges()
        {
            if (User == null) throw new Exception("User not found");

            var dataa = JsonSerializer.Serialize(User);

            File.WriteAllText("User.json", dataa);
        }
    }
}
