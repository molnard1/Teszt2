using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt2
{
    public class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            char[] nums = new char[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = DoCalc(long.Parse(Console.ReadLine()));
            }

            foreach (var nm in nums)
            {
                Console.WriteLine(nm);
            }
        }

        public static char DoCalc(long n)
        {
            int evenCount = 0, oddCount = 0;
            foreach (var num in GetDivisors(n))
            {
                if (num % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }

            if (evenCount > oddCount)
            {
               return '2';
            }
            return oddCount > evenCount ? '1' : '0';
        }

        private static long[] GetDivisors(long n)
        {
            var divisors = new HashSet<long>();
            int iterator = (int)Math.Sqrt(n);

            for (int i = 1; i <= iterator; i++)
            {
                if (n % i != 0) continue;
                divisors.Add(i);
                if (i != n / i)
                {
                    divisors.Add(n / i);
                }
            }

            return divisors.ToArray();
        }
    }
}