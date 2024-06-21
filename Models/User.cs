using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Models
{
    internal class User
    {
        public string? Name { get; set; }

        public decimal Weight { get; set; }

        public decimal? LiterOfWater { get; set; }

        public decimal NeededWater { get; set; }

        public DateTime Day { get; set; }

        public User() 
        {
            LiterOfWater = 0;
        }
        public User(string? name,decimal weight) 
        {
            this.Name = name;

            this.Weight = weight;

            LiterOfWater = 0;

            Day = DateTime.Now;
        }

        public void DrinkWater(decimal liter)
        {
            LiterOfWater += liter;
        }

        public void CalculateTheWater()
        {
            NeededWater = Weight / 30;
        }

        public void EndTheDay()
        {
            if(NeededWater > LiterOfWater)
            {
                Console.WriteLine("You need to drink more water");
            }
            else
            {
                Console.WriteLine("Congrats");
            }
           Day.AddDays(1);
        }

        public void History()
        {
            Console.WriteLine($"{Day.ToShortDateString()}  {LiterOfWater}");
        }
    }
}
