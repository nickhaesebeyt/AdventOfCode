using System;

namespace AdventOfCode
{
    public interface ISolutionInfo
    {
        string Name {get;} 
        DateTime Date {get;}
        string Question { get; }
        string QuestionInterpretation { get; }
    }
}