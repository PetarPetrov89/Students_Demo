using System;
using System.Collections.Generic;
using System.Linq;

namespace ListNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> nums = new List<int>() { 1, 2, 3, 21, 14, 42, 63, 8, 9, 14 };

            //List<int> filterdNums = nums.FindAll(num => num % 7 == 0 && num % 3 == 0);

            //Console.WriteLine(string.Join(", ", filterdNums));

            Dictionary<string, decimal> products = new Dictionary<string, decimal>()
            {
                { "Apple", 5.20m},
                { "Orange", 4.20m},
                { "Lemon", 2.20m},
                { "Kiwi", 1.20m},
                { "Banana", 15.20m},
                { "WaterMelon", 55.20m}
            };

            var top3Products = products.OrderByDescending(kvp => kvp.Value).Take(3);



            foreach (var kvp in top3Products)
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
