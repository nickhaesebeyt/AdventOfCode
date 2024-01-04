using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2_12_2023
{
    public class Solution : ISolution
    {
        public string Name => "Cube Conundrum";
        public DateTime Date => new DateTime(2023, 12, 2);
        public string Question => "You play several games and record the information from each game (your puzzle input). Each game is listed with its ID number (like the 11 in Game 11: ...) followed by a semicolon-separated list of subsets of cubes that were revealed from the bag (like 3 red, 5 green, 4 blue).\n\nFor example, the record of a few games might look like this:\n\nGame 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green\nIn game 1, three sets of cubes are revealed from the bag (and then put back again). The first set is 3 blue cubes and 4 red cubes; the second set is 1 red cube, 2 green cubes, and 6 blue cubes; the third set is only 2 green cubes.\n\nThe Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes?\n\nIn the example above, games 1, 2, and 5 would have been possible if the bag had been loaded with that configuration. However, game 3 would have been impossible because at one point the Elf showed you 20 red cubes at once; similarly, game 4 would also have been impossible because the Elf showed you 15 blue cubes at once. If you add up the IDs of the games that would have been possible, you get 8.";
        public string QuestionInterpretation => "You get input about dice, always a number and what type of dice (RGB). Every set is separated by ;. Check which games are possible for a given amount of max dice per type (RGB). Return the sum of the idxs of the possible games.";

        private string exampleInput = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        private string question1 = "Game 1: 1 blue, 2 green, 3 red; 7 red, 8 green; 1 green, 2 red, 1 blue; 2 green, 3 red, 1 blue; 8 green, 1 blue\nGame 2: 12 blue, 3 green, 5 red; 1 green, 1 blue, 8 red; 2 green, 12 blue, 5 red; 7 red, 2 green, 13 blue\nGame 3: 7 red, 4 blue, 13 green; 14 green, 1 blue, 1 red; 1 red, 11 green, 5 blue; 10 green, 3 blue, 3 red; 5 red, 5 blue, 3 green\nGame 4: 3 red, 1 green, 17 blue; 11 red, 6 green, 18 blue; 4 red, 9 blue, 5 green; 2 blue, 2 green, 1 red; 1 red, 2 green; 7 green, 9 red, 2 blue\nGame 5: 1 blue, 9 green, 5 red; 12 green, 1 blue, 15 red; 17 green, 8 red, 4 blue; 7 green, 12 red\nGame 6: 4 blue, 9 green, 7 red; 1 red, 7 green, 4 blue; 4 blue, 8 green, 3 red; 2 green, 1 red, 2 blue\nGame 7: 3 green, 1 blue; 11 red, 2 blue; 2 red, 3 blue, 6 green\nGame 8: 8 blue, 1 red, 11 green; 11 blue, 10 red, 7 green; 4 blue, 6 green, 4 red; 3 blue, 2 green, 6 red; 4 green, 4 red, 1 blue; 5 blue, 12 red, 9 green\nGame 9: 2 green, 20 blue, 4 red; 3 green, 7 red, 2 blue; 3 green, 17 blue; 20 blue, 7 red, 2 green; 4 green, 6 red, 1 blue; 7 red, 5 green, 19 blue\nGame 10: 2 red, 9 green, 8 blue; 16 green, 1 red, 7 blue; 3 blue, 5 red, 9 green; 5 blue, 2 red, 11 green\nGame 11: 6 blue, 3 green, 8 red; 6 blue, 4 green; 1 red, 3 green, 4 blue\nGame 12: 18 red, 16 blue, 9 green; 10 green, 6 blue; 12 blue, 5 green, 15 red; 16 blue, 4 red, 8 green\nGame 13: 2 green; 1 blue, 4 green; 1 green, 3 blue, 6 red; 2 red, 2 blue; 3 red, 2 green; 8 red, 2 blue, 5 green\nGame 14: 8 red, 3 blue, 3 green; 3 green; 4 red, 7 blue, 5 green; 10 blue, 15 red, 1 green; 4 green, 14 red, 7 blue\nGame 15: 8 red, 9 blue; 1 green, 4 red, 3 blue; 15 red, 3 blue, 1 green; 17 red, 6 blue\nGame 16: 1 green, 10 blue, 13 red; 16 red, 1 green; 7 red; 9 blue, 12 red, 1 green; 6 red, 13 blue, 1 green\nGame 17: 6 green, 1 blue, 1 red; 2 blue, 9 green, 1 red; 6 green, 1 blue, 2 red\nGame 18: 5 red, 4 green, 1 blue; 5 blue, 6 red, 6 green; 12 red, 16 blue, 11 green\nGame 19: 6 red, 9 green; 1 blue, 4 red; 12 green; 5 green, 2 blue, 9 red\nGame 20: 15 blue, 15 red, 1 green; 2 green, 5 red, 13 blue; 15 red, 2 green, 15 blue; 3 green, 3 red, 13 blue; 6 blue, 1 green, 8 red\nGame 21: 3 red, 3 blue; 4 blue, 3 red; 4 red, 8 blue, 1 green; 1 blue, 2 red, 7 green; 3 green, 3 blue; 3 blue\nGame 22: 5 green, 3 blue, 7 red; 7 green, 1 blue, 5 red; 5 red, 3 blue, 3 green; 12 green, 7 red, 1 blue; 2 red, 3 blue; 7 green, 11 red, 1 blue\nGame 23: 9 blue, 8 red; 9 blue, 9 green, 8 red; 3 red, 6 blue, 14 green; 3 blue, 4 red; 5 red, 14 green, 9 blue; 12 blue, 8 red, 8 green\nGame 24: 15 green, 1 red, 1 blue; 6 red, 2 green, 7 blue; 7 blue, 2 green, 4 red; 8 blue, 5 red, 8 green; 5 blue, 3 red, 7 green; 6 blue, 12 green\nGame 25: 7 blue, 16 green, 1 red; 13 green; 4 red, 9 green, 2 blue; 11 green, 1 red, 1 blue; 3 blue, 5 green, 5 red\nGame 26: 2 blue, 11 red, 10 green; 5 green, 1 blue, 2 red; 7 green, 5 red, 14 blue; 11 green, 1 blue, 10 red\nGame 27: 2 green, 8 blue, 2 red; 1 blue, 1 red, 5 green; 3 green, 7 blue\nGame 28: 9 green, 15 red, 1 blue; 3 blue, 3 green; 18 green, 15 red, 7 blue; 3 red, 10 blue, 7 green; 6 red, 5 green, 8 blue; 2 blue, 7 red, 3 green\nGame 29: 5 blue, 3 red, 7 green; 17 blue, 8 red, 11 green; 6 red, 5 blue, 12 green; 3 red, 10 blue, 10 green; 4 blue, 10 green; 6 red, 2 blue, 9 green\nGame 30: 4 green, 5 blue, 1 red; 19 red, 18 blue, 3 green; 18 red, 18 blue, 1 green; 5 green, 14 blue, 4 red; 4 red, 3 green, 18 blue; 6 blue, 3 green, 17 red\nGame 31: 2 red, 2 green; 13 red, 9 blue; 4 blue, 3 green, 1 red; 12 blue, 12 red, 4 green; 9 red, 6 blue; 12 red, 1 green, 2 blue\nGame 32: 11 red, 5 blue, 9 green; 3 blue, 8 red, 15 green; 3 green, 7 blue, 17 red; 2 green, 9 red, 1 blue; 2 blue, 6 green, 2 red\nGame 33: 13 blue, 2 green; 1 green, 1 red, 14 blue; 3 green, 6 blue, 1 red; 12 blue, 1 green; 9 blue, 2 green; 4 blue, 1 red\nGame 34: 15 green, 2 red, 13 blue; 1 green, 6 blue; 2 red, 1 green, 7 blue\nGame 35: 1 green, 12 red, 2 blue; 3 red, 5 blue; 6 red; 3 red, 3 blue; 4 red\nGame 36: 6 blue, 8 red, 1 green; 7 green, 6 blue, 10 red; 7 blue, 9 green, 5 red; 7 green, 1 red, 1 blue\nGame 37: 6 blue, 2 green, 4 red; 2 green, 3 blue, 6 red; 1 green, 17 red, 14 blue; 10 red, 2 blue; 19 red, 1 green, 8 blue; 2 red, 2 green\nGame 38: 6 red, 1 green, 5 blue; 2 blue, 15 green, 6 red; 10 green, 3 blue, 6 red; 5 blue, 8 green, 2 red\nGame 39: 8 blue, 5 green, 5 red; 4 green, 5 blue; 2 red, 7 blue; 3 green, 15 blue, 4 red\nGame 40: 8 green, 12 red, 10 blue; 8 blue, 8 red, 9 green; 1 green, 10 blue, 9 red; 17 red, 7 green, 2 blue; 6 green, 11 red; 2 green, 2 blue, 8 red\nGame 41: 11 red, 5 green, 1 blue; 5 green; 3 green; 2 red\nGame 42: 8 blue, 11 red, 1 green; 12 red, 10 green, 6 blue; 2 red, 6 blue, 16 green; 18 blue, 2 red, 4 green; 10 blue, 10 green, 3 red\nGame 43: 4 red, 3 blue; 2 blue, 10 red, 4 green; 3 blue, 7 red, 5 green; 2 green, 8 red; 1 green, 3 blue; 10 red, 1 green\nGame 44: 1 red, 9 blue; 2 red, 19 blue; 2 green, 6 red, 15 blue; 11 blue, 8 red, 4 green\nGame 45: 7 green, 4 blue, 1 red; 5 blue, 8 green; 5 blue, 8 green; 5 blue, 6 green; 6 green, 3 blue\nGame 46: 2 red, 2 green; 6 red, 5 blue, 2 green; 13 green, 8 blue, 2 red\nGame 47: 1 red, 5 green; 1 blue, 15 red, 5 green; 6 red, 6 green, 3 blue; 5 blue, 4 red; 4 blue, 7 red\nGame 48: 16 blue, 16 red; 11 blue, 16 red; 15 red, 1 green; 6 blue, 1 green, 2 red\nGame 49: 9 green, 20 blue, 7 red; 16 blue, 6 red; 9 green, 1 blue, 1 red; 8 red, 12 green, 15 blue; 3 blue, 2 green, 8 red\nGame 50: 9 red, 6 green, 9 blue; 6 blue, 2 red, 6 green; 7 green, 4 red, 6 blue; 2 red, 7 blue, 9 green; 4 red, 8 green, 9 blue\nGame 51: 1 blue, 2 red, 6 green; 1 blue, 4 red; 6 red, 2 green; 6 red, 8 green, 2 blue; 2 blue, 8 green, 4 red\nGame 52: 10 green, 1 blue; 5 blue, 5 green; 5 blue, 2 red, 4 green; 2 blue, 12 green\nGame 53: 3 blue, 8 red, 7 green; 7 blue, 7 red, 12 green; 8 blue, 9 green, 7 red; 7 red, 10 blue, 1 green\nGame 54: 3 green, 4 blue; 1 blue, 5 red, 4 green; 7 red, 4 blue; 2 green, 4 blue; 1 red, 4 blue; 1 blue, 6 red, 5 green\nGame 55: 7 red, 13 blue; 7 blue, 1 red, 1 green; 3 red, 5 blue\nGame 56: 6 red, 3 green, 1 blue; 7 blue, 2 green, 5 red; 4 green, 4 red; 8 blue, 1 green; 6 green, 6 blue, 4 red\nGame 57: 14 blue, 12 green, 8 red; 1 red, 20 blue, 10 green; 4 red, 16 green, 15 blue\nGame 58: 3 blue, 12 red; 9 red, 3 blue, 2 green; 2 blue, 2 red; 7 red, 4 green, 5 blue; 10 red, 1 blue\nGame 59: 7 red, 11 blue, 17 green; 5 red, 4 green, 7 blue; 8 red, 6 blue, 17 green; 16 green, 7 red, 6 blue; 5 blue, 12 green, 9 red; 7 blue, 3 red, 9 green\nGame 60: 4 red, 5 green, 4 blue; 15 green, 4 red, 18 blue; 6 blue, 1 red, 1 green; 14 blue, 12 green, 1 red; 2 green, 5 red, 4 blue; 2 green, 1 blue, 5 red\nGame 61: 3 green, 2 blue; 4 green, 6 blue; 2 red, 12 green, 11 blue; 1 red, 9 green, 7 blue; 2 red, 11 green, 19 blue; 9 blue, 1 red, 2 green\nGame 62: 17 green; 3 blue, 14 red, 14 green; 17 red, 16 green, 5 blue; 17 green, 5 blue, 1 red; 4 blue, 17 red, 13 green\nGame 63: 4 green, 2 red, 2 blue; 10 green, 15 blue, 3 red; 5 green, 5 blue, 5 red\nGame 64: 9 red, 10 blue, 2 green; 1 green, 4 red, 1 blue; 5 green, 2 blue, 11 red\nGame 65: 1 blue, 10 red, 5 green; 1 blue, 4 green, 2 red; 3 blue, 1 green; 11 red, 2 blue, 5 green; 9 green, 11 red, 3 blue\nGame 66: 6 blue, 13 green, 2 red; 5 green, 1 red, 7 blue; 11 green, 3 red; 5 blue, 1 red, 2 green\nGame 67: 1 red, 10 green, 4 blue; 5 blue, 3 red, 9 green; 4 blue, 3 red, 1 green; 14 red, 4 blue, 10 green\nGame 68: 12 green, 3 red, 3 blue; 2 green, 1 red, 2 blue; 1 blue, 3 green, 3 red; 1 green, 1 red, 6 blue\nGame 69: 3 blue, 10 red, 4 green; 4 green, 1 blue, 6 red; 1 blue, 1 red, 6 green; 4 red, 3 blue, 5 green\nGame 70: 9 blue, 3 green; 1 red, 2 green, 6 blue; 9 blue, 2 green; 6 blue, 1 red; 6 green, 1 red, 6 blue; 3 blue, 1 red, 2 green\nGame 71: 2 blue; 2 red, 3 blue; 12 blue, 3 red, 1 green; 1 green; 1 red, 7 blue; 1 red, 9 blue\nGame 72: 1 red, 1 green, 5 blue; 19 blue, 1 red, 3 green; 3 green, 1 red; 1 red, 13 blue, 1 green; 1 red, 1 green, 19 blue; 6 blue\nGame 73: 12 blue, 5 red, 5 green; 12 blue, 1 red, 4 green; 7 green, 4 red, 6 blue; 1 green, 4 blue, 10 red; 9 blue, 14 green\nGame 74: 9 blue, 1 green, 2 red; 7 blue, 15 red; 5 red, 2 green, 17 blue\nGame 75: 8 red; 1 green, 14 red; 2 blue, 3 green, 10 red; 2 blue, 4 green\nGame 76: 2 red, 3 blue; 6 blue, 8 red; 6 blue, 9 red; 7 blue; 7 red, 1 green, 5 blue\nGame 77: 6 green, 5 red, 12 blue; 16 blue, 5 red, 11 green; 4 blue, 5 green; 10 blue, 4 red, 9 green\nGame 78: 7 blue, 2 red; 1 green, 5 red; 4 blue\nGame 79: 3 green, 4 blue; 4 blue, 1 green, 2 red; 8 blue, 3 green\nGame 80: 10 red, 8 green; 4 red, 1 blue; 7 red, 4 green, 4 blue; 6 green, 1 red, 3 blue; 9 red, 3 blue; 4 green, 8 blue, 13 red\nGame 81: 3 red, 6 green, 9 blue; 9 red, 1 blue, 3 green; 5 red, 11 green, 1 blue\nGame 82: 6 green, 11 blue, 8 red; 16 green, 9 red, 7 blue; 6 blue, 17 green, 4 red\nGame 83: 6 blue, 1 green, 8 red; 3 green, 5 blue; 4 red, 2 green, 8 blue\nGame 84: 2 green, 1 red, 5 blue; 1 red, 2 green, 5 blue; 2 blue; 9 blue\nGame 85: 9 blue, 2 red; 7 green, 13 blue, 3 red; 11 green, 17 blue\nGame 86: 2 green, 15 red; 12 red, 1 blue, 3 green; 2 blue, 4 red, 3 green; 5 red; 6 green, 2 blue\nGame 87: 17 blue, 3 red; 3 red, 4 green, 10 blue; 3 red, 14 blue, 4 green\nGame 88: 13 green, 10 blue, 10 red; 14 green, 3 red, 4 blue; 13 blue, 7 red, 16 green; 10 blue, 6 green, 1 red; 9 red, 4 green, 14 blue\nGame 89: 3 green, 16 blue, 14 red; 4 green, 13 red, 1 blue; 6 red, 17 blue, 1 green; 4 red, 7 blue\nGame 90: 2 blue, 2 red; 5 blue, 10 red, 6 green; 10 red, 3 green, 1 blue; 10 blue, 6 green, 7 red\nGame 91: 15 green, 5 blue, 12 red; 9 red, 1 green, 4 blue; 2 red, 15 green, 3 blue; 18 green, 5 blue, 2 red\nGame 92: 7 green, 7 blue, 12 red; 7 blue, 9 red, 2 green; 11 blue, 10 red, 10 green; 2 green, 4 red, 11 blue; 12 red, 4 blue; 2 red, 6 green\nGame 93: 2 green, 8 blue; 2 blue, 1 red, 3 green; 4 blue, 8 green, 1 red; 8 blue, 5 green; 3 green\nGame 94: 16 red, 1 green, 5 blue; 11 red, 9 blue; 5 red, 2 green, 6 blue\nGame 95: 4 blue, 7 red; 7 red, 10 green; 11 green; 2 red, 10 green; 6 blue, 8 red; 8 red, 2 green, 6 blue\nGame 96: 9 blue, 12 green; 6 green, 9 blue, 11 red; 7 blue, 5 green, 10 red\nGame 97: 1 green, 6 red, 1 blue; 6 red, 3 green, 6 blue; 9 green, 5 blue, 9 red; 13 red, 7 green\nGame 98: 9 red, 12 green, 2 blue; 1 blue, 11 green, 10 red; 10 red, 2 green\nGame 99: 4 red, 13 blue, 7 green; 7 green, 5 blue, 6 red; 7 green, 11 blue; 10 green, 2 red, 8 blue\nGame 100: 2 green, 1 blue; 9 red, 8 green, 1 blue; 4 red, 10 green, 1 blue; 17 green, 8 red; 5 green, 1 blue, 7 red; 14 red, 12 green";
        public void Execute()
        {
            List<Game> game = Parse(exampleInput);
            SolutionLogger.Log(SumOfAllPossibleIndices(game, 12,13,14).ToString());
            
            game = Parse(question1);
            SolutionLogger.Log(SumOfAllPossibleIndices(game, 12,13,14).ToString());
            SolutionLogger.Log(CalculateSumOfPower(game).ToString());
        }

        private int SumOfAllPossibleIndices(IReadOnlyList<Game> games, int allowedRedDiceCount, int allowedGreenDiceCount, int allowedBlueDiceCount)
        {
            int result = 0;
            for (int i = 0; i < games.Count; i++)
            {
                if (IsPossible(games[i],
                        allowedRedDiceCount,
                        allowedGreenDiceCount,
                        allowedBlueDiceCount))
                {
                    result += (i+1);
                }
            }

            return result;
        }

        private bool IsPossible(Game game, int allowedRedDiceCount, int allowedGreenDiceCount, int allowedBlueDiceCount)
        {
            foreach (Round gameRound in game.Rounds)
            {
                if (gameRound.GetRollsCount(DiceType.Red) > allowedRedDiceCount)
                    return false;

                if (gameRound.GetRollsCount(DiceType.Green) > allowedGreenDiceCount)
                    return false;

                if (gameRound.GetRollsCount(DiceType.Blue) > allowedBlueDiceCount)
                    return false;
            }

            return true;
        }

        private int CalculateSumOfPower(List<Game> games)
        {
            int sum = 0;
            
            foreach (Game game in games)
            {
                Dictionary<DiceType, int> lowestRolls = GetLowestPossibleDiceRoll(game);
                int power = lowestRolls.Values.Aggregate(1, (current, lowestRollsValue) => current * lowestRollsValue);
                sum += power;
            }

            return sum;
        }

        private Dictionary<DiceType, int> GetLowestPossibleDiceRoll(Game game)
        {
            Dictionary<DiceType, int> result = new Dictionary<DiceType, int>();
            List<DiceType> types = new List<DiceType>();
            for (int i = 0; i < (int)DiceType.COUNT; i++)
            {
                DiceType type = (DiceType)i;
                if (type != DiceType.None)
                {
                    result.Add(type, 0);
                    types.Add(type);
                }
            }

            foreach (Round round in game.Rounds)
            {
                foreach (DiceType type in types)
                {
                    int rollsCount = round.GetRollsCount(type);
                    
                    if (rollsCount >= result[type])
                    {
                        result[type] = rollsCount;
                    }
                }
            }

            return result;
        }

        private enum DiceType
        {
            None,
            Red,
            Green,
            Blue,
            COUNT
        }

        private class DiceRoll
        {
            public DiceType Type = DiceType.None;
            public int Count = 0;
        }

        private class Round
        {
            public readonly List<DiceRoll> Rolls = new List<DiceRoll>();

            public int GetRollsCount(DiceType type)
            {
                return Rolls.Where(r => r.Type == type).Sum(r => r.Count);
            }
        }

        private class Game
        {
            public readonly List<Round> Rounds = new List<Round>();
        }

        private List<Game> Parse(string input)
        {
            List<string> gamesString = input.Split(new[] { "\n" }, StringSplitOptions.None).ToList();
            List<Game> games = new List<Game>();
            foreach (string s in gamesString)
            {
                Game game = new Game();
                string replaced = s.Remove(0, s.IndexOf(':') + 1);
                replaced = replaced.Replace(" ", "");
                List<string> roundsString = replaced.Split(new[] { ";" }, StringSplitOptions.None).ToList();

                foreach (string s1 in roundsString)
                {
                    Round round = new Round();
                    List<string> rollString = s1.Split(new[] { "," }, StringSplitOptions.None).ToList();
                    foreach (string s2 in rollString)
                    {
                        DiceRoll roll = new DiceRoll();
                        if (s2.Contains("red"))
                        {
                            roll.Type = DiceType.Red;
                            roll.Count = int.Parse(s2.Replace("red", ""));
                        }
                        else if (s2.Contains("green"))
                        {
                            roll.Type = DiceType.Green;
                            roll.Count = int.Parse(s2.Replace("green", ""));
                        }
                        else if (s2.Contains("blue"))
                        {
                            roll.Type = DiceType.Blue;
                            roll.Count = int.Parse(s2.Replace("blue", ""));
                        }

                        round.Rolls.Add(roll);
                    }

                    game.Rounds.Add(round);
                }

                games.Add(game);
            }

            return games;
        }
    }
}