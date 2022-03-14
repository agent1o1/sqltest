using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //dumb way
            var array = new List<int?>() { 1, 2, 4, 5 };
            var dumbArray = new List<int?>();
            for (int i = array.First().Value; i < array.Last(); i++)
                dumbArray.Add(i);

            var result = from first in dumbArray
                join second in array on first equals second into temp
                from withNull in temp.DefaultIfEmpty()
                where withNull == null
                select first;

            Console.WriteLine(result.FirstOrDefault());

            //smart way (i hope)
            var result1 = from first in array
                join second in array on first + 1 equals second into temp
                from withNull in temp.DefaultIfEmpty()
                where withNull == null
                select new { value = first + 1 };

            Console.WriteLine(result1.FirstOrDefault()?.value);
        }
    }
}
