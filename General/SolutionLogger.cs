using System;

namespace AdventOfCode
{
    public static class SolutionLogger
    {
        public static void LogTitle(ISolution solution, string format = "H1")
        {
            Log($"{solution.Date:dd-MM-yyyy} ~ {solution.Name}", format);
        }
        
        public static void LogAssignment(ISolution solution, string format = "H2")
        {
            Log($"Assignment", format);
            Log(solution.Question);
            
            Log($"Interpretation", format);
            Log(solution.QuestionInterpretation);
        }

        public static void LogStart(string format = "H2")
        {
            Log("Solution", format);
        }

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