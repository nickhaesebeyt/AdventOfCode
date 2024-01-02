using System;

namespace AdventOfCode
{
    public interface ISolutionInfo
    {
        string Name {get;} 
        DateTime Date {get;}
    }

    public interface IQuestionInfo
    {
        string Question { get; }
        string QuestionInterpretation { get; }
    }
}