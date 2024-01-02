using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._1_12_2023
{
    public class Solution : ISolution
    {
        private static List<string> boos = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        private List<string> case1 = new List<string> { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
        private List<string> case2 = new List<string> {"ar0plr0Sevretwnmeoneprlokla", "6etera6sEvEn", "Eightpra9ltor0", "melko98834prosix98374l95lpp", "ol3pole" , "onetwothreesixpl8rdtped9087onefivesevennine" };

        public void Execute()
        {
            SolutionLogger.LogTitle(this);
            SolutionLogger.LogAssignment(this);

            SolutionLogger.NewLine();
            SolutionLogger.LogStart();
            
            SolutionLogger.Log($"Case 1 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case1));
            AnswerMeNowWithoutLinq(case1, out Dictionary<string, int> case1Answers, out int totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a => $"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();

            SolutionLogger.Log($"Case 2 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case2));
            AnswerMeNowWithoutLinq(case2, out case1Answers, out totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a => $"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();
        }

        private static void AnswerMeNowWithoutLinq(List<string> case1, out Dictionary<string, int> case1Answers, out int totalAnswer)
        {
            case1Answers = new Dictionary<string, int>();
            totalAnswer = 0;
            
            foreach (string toCheck in case1)
            {
                bool append = false;
                List<string> separated = new List<string>();
                foreach (char c in toCheck.ToLower())
                {
                    bool isDigit = char.IsDigit(c);
                    if (isDigit && append)
                    {
                        separated.RemoveAt(separated.Count-1);
                    }
                    
                    if (isDigit)
                    {
                        separated.Add(c.ToString());
                        append = false;
                        continue;
                    }

                    if (char.IsLetter(c))
                    {
                        if (append)
                        {
                            string toAdd = separated.Last();
                            
                            toAdd += c;
                            
                            if (!boos.Any(s => s.Contains(toAdd)))
                            {
                                separated.RemoveAt(separated.Count-1);
                                append = false;
                                
                                if (boos.Any(s => s.First() == c))
                                {
                                    separated.Add(c.ToString());
                                    append = true;
                                } 
                            }
                            else
                            {
                                separated[^1] = toAdd;
                                append = !boos.Contains(toAdd);
                            }
                        }
                        else
                        {
                            if (boos.Any(s => s.First() == c))
                            {
                                separated.Add(c.ToString());
                                append = true;
                            } 
                        }
                    }
                }

                string last = separated.Last();
                if (!boos.Contains(last) && !int.TryParse(last, out int _))
                {
                    separated.RemoveAt(separated.Count-1);
                }
                
                string firstDigitString = separated.First();
                string lastDigitString = separated.Last();

                int firstDigit = boos.Contains(firstDigitString) ? boos.IndexOf(firstDigitString) : int.Parse(firstDigitString);
                int lastDigit = boos.Contains(lastDigitString) ? boos.IndexOf(lastDigitString) : int.Parse(lastDigitString);
                
                int value = firstDigit * 10 + lastDigit;
                case1Answers.Add(toCheck, value);
                totalAnswer += value;
            }
        }

        public string Name => "Trebuchet?!";
        public DateTime Date => new DateTime(2023, 12, 1);

        public string Question => "The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.\n\nFor example:\n\n1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet\nIn this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.\n\nConsider your entire calibration document. What is the sum of all of the calibration values?";
        public string QuestionInterpretation => "From a line of string, create a 2 digit number, combining 1st and last digit. If there is only 1 digit, than make a double digit number from that one (e.g. '7' is '77'). Return the sum of all 2 digit numbers for all the lines.";
    }
}