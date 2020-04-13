using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        class IndexTracking
        {
            public int first { get; set; }
            public int second { get; set; }
        }

        static void Main(string[] args)
        {
            ComputeShotSequenceLength("abc");
            ComputeShotSequenceLength("abca");
            ComputeShotSequenceLength("abcacbaciefiefk");
            ComputeShotSequenceLength("");

            Console.ReadLine();

        }

        static Dictionary<char, IndexTracking> PrepareMapping(string input)
        {
            Dictionary<char, IndexTracking> map = new Dictionary<char, IndexTracking>();

            int index = 0;

            foreach (char ch in input)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch].second = index;
                }
                else
                {
                    map.Add(ch, new IndexTracking { first = index, second = index });
                }

                index++;
            }

            return map;
        }

        static void DisplayOutPut(List<int> input, string sequence)
        {
            Console.WriteLine($" for sequence = [{sequence}], ouptut is [{ string.Join( ','.ToString(),input )}]");
        }

        static void ComputeShotSequenceLength(string input)
        {
            var map = PrepareMapping(input);

            List<int> output = new List<int>();
            int start = 0;
            int end = 0;

            int index = 0;
            while(index < input.Length)
            {
                start = map[input[index]].first;
                end = map[input[index]].second;

                if(start == end)
                {
                    output.Add(1);
                    index++;
                    continue;
                }

                while( index < input.Length &&  map[input[index]].first < end)
                {
                    end = Math.Max(end, map[input[index]].second);
                    index++;
                }

                output.Add(end - start + 1);

            }

            DisplayOutPut(output,input);
        }
    }
}
