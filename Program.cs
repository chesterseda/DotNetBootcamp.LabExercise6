using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharp.LabExercise6
{
    public class Scrabble
    {
        public int totalScore { get; set; }

        private static Dictionary<char, int> letters = new Dictionary<char, int>(){
            {'A',1}, {'B',3}, {'C',3}, {'D',2}, {'E',1}, {'F',4},
            {'G',2}, {'H',4}, {'I',1}, {'J',8}, {'K',5}, {'L',1},
            {'M',3}, {'N',1}, {'O',1}, {'P',3}, {'Q',10}, {'R',1},
            {'S',1}, {'T',1}, {'U',1}, {'V',4}, {'W',4}, {'X',8},
            {'Y',4}, {'Z',10}
        };

        private int point;

        public int Score(string word)
        {
            totalScore = 0;
            foreach (char letter in word)
            {
                letters.TryGetValue(letter, out point);
                totalScore += point;
            }
            return totalScore;
        }
        static void Main(string[] args)
        {
            Regex rgx = new Regex("[^A-Za-z]");
            string willcontinue = "y";
            
            while (willcontinue.Trim().ToLower().Equals("y"))
            {
                Console.Write("Enter word: ");
                string enteredWord = Console.ReadLine();

                bool invalidInput = rgx.IsMatch(enteredWord);

                if (enteredWord == "")
                {
                    Console.WriteLine("~Invalid. Please enter a word.~");
                }

                else if (invalidInput)
                {
                    Console.WriteLine("~Invalid Input. Must not contain spaces, special character or number.~");
                }

                else
                {
                    Scrabble scrabble = new Scrabble();
                    int wordScore = scrabble.Score(enteredWord.ToUpper());
                    Console.WriteLine("Score: {0}", wordScore);
                }

                Console.Write("\nEnter another word? (y/n) : ");
                willcontinue = Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
