using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Largest Remainder Program , below example 40000 divided between 3 people but when we sum up its 1 extra value");
            var amount = new List<double>()
                        { 
                           15384.61538,
12307.69231,
12307.69231
//1.61538,2.69231,3.69231


                         };
            var number = RoundNumberList(amount,40000);
            var reviseTotal=0;
            foreach (var num in number.ToList())
                {
                Console.WriteLine("Number " +num);
                reviseTotal += num;
            }
            Console.WriteLine("Sum of Number  " + reviseTotal);

            Console.ReadLine();

                }
        



        public static List<int> RoundNumberList(List<double> Numbers,int Total)
        {
            int sum = 0;
            var rounded = new Dictionary<int, double>();

            for (int i = 0; i < Numbers.Count; i++)
            {
                rounded.Add(i, Numbers[i]);
                sum += (int)Numbers[i];
              
            }
            Console.WriteLine(sum);

            if (sum > Total)
                throw new Exception("The sum of all numbers is > ." + Total);

            if (Total - sum > Numbers.Count)
                throw new Exception("The sum of all numbers is too low for rounding: " + sum.ToString());

            if (sum < Total)
            {
                // Sort descending by the decimal portion of the number
                rounded = rounded.OrderByDescending(n => n.Value - (int)n.Value).ToDictionary(x => x.Key, x => x.Value);

                int i = 0;
                int diff = Total - sum;

                foreach (var key in rounded.Keys.ToList())
                {
                    rounded[key]++;
                    i++;
                    if (i >= diff) break;
                }

                // Put back in original order and return just integer portion
                return rounded.OrderBy(n => n.Key).Select(n => (int)n.Value).ToList();
            }
            else
            {
                // Return just integer portion
                return rounded.Select(n => (int)n.Value).ToList();
            }
        }
    }
}
