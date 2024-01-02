using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode._1_12_2023
{
    public class Solution:ISolutionInfo
    {
        private List<string> case1 = new List<string>{"1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"};
        private List<string> case2 = new List<string>{"6etera6", "pra8ltor0", "melko98834pro98374l95lpp", "ol3pole", "ar0plr0", "pl8rdtped9087"};
        
        public void Execute()
        {
            SolutionLogger.LogTitle(this);
            SolutionLogger.LogAssignment(this);
            
            SolutionLogger.NewLine();
            SolutionLogger.LogStart();
            
            SolutionLogger.Log($"Case 1 Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case1));
            AnswerMeNowWithLinq(case1, out Dictionary<string, int> case1Answers, out int totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a=>$"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();
            
            SolutionLogger.Log($"Case 2 Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case2));
            AnswerMeNowWithLinq(case2, out case1Answers, out totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a=>$"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();
            
            SolutionLogger.Log($"Case 1 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case1));
            AnswerMeNowWithoutLinq(case1, out case1Answers, out totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a=>$"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();
            
            SolutionLogger.Log($"Case 2 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case2));
            AnswerMeNowWithoutLinq(case2, out case1Answers, out totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a=>$"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();
        }

        private static void AnswerMeNowWithLinq(List<string> case1, out Dictionary<string, int> case1Answers, out int totalAnswer)
        {
            case1Answers = new Dictionary<string, int>();
            totalAnswer = 0;
            foreach (string s in case1)
            {
                if (!s.Any(char.IsDigit))
                {
                    case1Answers.Add(s, 0);
                    continue;
                }
                
                string copy = s.Replace(".", string.Empty);
                copy = copy.Replace(",", string.Empty);

                char[] substr = copy.Where(char.IsDigit).ToArray();
                char first = substr.First();
                char last = substr.Last();
                string doubleDigitString = new string(new[] { first, last });
                int value = int.Parse(doubleDigitString);
                case1Answers.Add(s, value);
                totalAnswer += value;
            }
        }
        
        private static void AnswerMeNowWithoutLinq(List<string> case1, out Dictionary<string, int> case1Answers, out int totalAnswer)
        {
            case1Answers = new Dictionary<string, int>();
            totalAnswer = 0;
            foreach (string s in case1)
            {
                char first = '/';
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    if (!char.IsDigit(c)) 
                        continue;
                    
                    first = c;
                    break;
                }

                if (first == '/')
                {
                    first = '0';
                }

                char last = '/';
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    char c = s[i];
                    if (!char.IsDigit(c)) 
                        continue;
                    
                    last = c;
                    break;
                }

                if (last == '/')
                {
                    last = first;
                }
    
                string doubleDigitString = new string(new[] { first, last });
                int value = int.Parse(doubleDigitString);
                case1Answers.Add(s, value);
                totalAnswer += value;
            }
        }

        public string Name => "CalibrationChecker";
        public DateTime Date => new DateTime(2023, 12, 1);
        
        public string Question => "The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.\n\nFor example:\n\n1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet\nIn this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.\n\nConsider your entire calibration document. What is the sum of all of the calibration values?";
        public string QuestionInterpretation => "From a line of string, create a 2 digit number, combining 1st and last digit. If there is only 1 digit, than make a double digit number from that one (e.g. '7' is '77'). Return the sum of all 2 digit numbers for all the lines.";
    }
}