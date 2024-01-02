using System;

namespace AdventOfCode
{
    public static class SolutionLogger
    {
        public static void LogTitle(ISolutionInfo solutionInfo, string format = "H1")
        {
            Log($"{solutionInfo.Date:dd-MM-yyyy} ~ {solutionInfo.Name}", format);
        }
        
        public static void LogAssignment(ISolutionInfo solutionInfo, string format = "H2")
        {
            Log($"Assignment", format);
            Log(solutionInfo.Question);
            
            Log($"Interpretation", format);
            Log(solutionInfo.QuestionInterpretation);
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