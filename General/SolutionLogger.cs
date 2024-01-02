using System;

namespace AdventOfCode
{
    public static class SolutionLogger
    {
        public static void Intro(ISolutionInfo solutionInfo) 
            => Console.WriteLine($"********** {solutionInfo.Date:DD-MM-yyyy} ~ {solutionInfo.Name} **********");

        public static void Log(string msg) => Console.WriteLine(msg);
    }
}