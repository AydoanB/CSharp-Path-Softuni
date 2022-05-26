using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._The_V_Logger__Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string vloggerName = input[0];
                if (vloggerName == "Statistics") break;

                if (input[1] == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggers[vloggerName].Add("followers", new HashSet<string>());
                        vloggers[vloggerName].Add("following", new HashSet<string>());

                    }
                }
                else if (input[1] == "followed")
                {
                    string followedVlogger = input[2];
                    if (vloggerName != followedVlogger
                        && vloggers.ContainsKey(vloggerName)
                        && vloggers.ContainsKey(followedVlogger))
                    {
                        vloggers[vloggerName]["following"].Add(followedVlogger);
                        vloggers[followedVlogger]["followers"].Add(vloggerName);
                    }
                }

            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int number = 1;
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                number++;
            }

        }


    }
}

