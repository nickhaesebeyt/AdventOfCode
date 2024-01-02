using System;

namespace AdventOfCode
{
    public interface ISolution
    {
        string Name {get;} 
        DateTime Date {get;}
        string Question { get; }
        string QuestionInterpretation { get; }
        void Execute();
    }
}