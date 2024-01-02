using System;

namespace AdventOfCode
{
    public static class SolutionLogger
    {
        public static void Intro(ISolutionInfo solutionInfo) 
            => Log($"{solutionInfo.Date:dd-MM-yyyy} ~ {solutionInfo.Name}", "H1");

        public static void Log(string msg, string format = null)
        {
            switch (format)
            {
                case "H1":
                    Console.WriteLine($"************ {msg} ************");
                    break;
                case "H2":
                    Console.WriteLine($"****** {msg} ******");
                    break;
                case "H3":
                    Console.WriteLine($"*** {msg} ***");
                    break;
                default:
                    Console.WriteLine(msg);
                    break;
            }
        }

        public static void NewLine() => Console.WriteLine();
    }
}