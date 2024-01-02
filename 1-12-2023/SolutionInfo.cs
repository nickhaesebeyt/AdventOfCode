using System;
using System.Reflection;

namespace AdventOfCode._1_12_2023
{
    public class SolutionInfo:ISolutionInfo
    {
        public void Execute()
        {
            SolutionLogger.Intro(this);
            
        }

        public string Name => "CalibrationChecker";
        public DateTime Date => new DateTime(2023, 12, 1);
    }
}