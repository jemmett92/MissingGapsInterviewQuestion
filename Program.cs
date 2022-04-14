using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

//Write a function in the language of your choice that accepts an arbitrary number of lists of natural numbers,
//each list of arbitrary length, and returns all the gaps that exist in the union of all the lists.
//For example the lists { 3, 5 } { 2, 7, 3 } { 6 }
//have a gap of length 1 starting at the number 3.
//Applications that do not include a working solution to the above problem will not be considered.


        static void Main(string[] args)
        {
            int[] list1 = { 3, 5 };
            int[] list2 = { 2, 7, 3 };
            int[] list3 = { 6 };
            int[] list4 = { 6, 23, 12 };

            var combinedList = list1.Union(list2).Union(list3).Union(list4).OrderBy(x => x).ToList();

            var Gaps = FindMissing(combinedList);

            Console.WriteLine("All Numbers: " + string.Join(",", combinedList.Select(x => x.ToString()).ToArray()));
            int index = 1;
            foreach (var gap in Gaps)
            {
                Console.WriteLine("Gap Number " + index + " : "  + gap);
                index++;
            }

            Console.WriteLine();
        }

        public static List<int> FindMissing(IEnumerable<int> sequence)
        {

            List<int> Gaps = Enumerable.Range(sequence.First(),
                                  sequence.Last() - sequence.First() + 1)
                           .Except(sequence).ToList();

            return Gaps;
        }
    }
}
