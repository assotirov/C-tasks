using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegExp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Just a test to see if it works with latin words such as (4,20 лв) .Therefore, the directional indication of a chart corresponds to the base currency. Using the earlier example, when a trader takes a long position in the EUR/USD currency at 1,50 .As the rate increases to 1,70.The euro increases in strength (as indicated in the price chart) and the USD weakens. Now it takes $1,70 (more dollars) to purchase the same euro, making the dollar weaker and/or the euro stronger.";

            string pattern = @"([A-Z][^\\.\\?\\!]*(USD|EUR|€|$|лв|dollar|euro)[^\\.\\?\\!])*"; // pattern that matches sentances that have the specific words 

            Match match = Regex.Match(input, pattern); // getting the first match

            while(match.Success) // cycle through the sentances from the given input
            {
                Match matchWord = Regex.Match(match.Value, @"\b\w+\b");
                while(matchWord.Success) //cycle through the words fromt the sentance 
                {
                    if (IsNoun(matchWord.Value))  // checking if the word is a noun
                    {
                        Console.WriteLine(matchWord.Value); // printing the word
                    }

                    matchWord = matchWord.NextMatch(); // getting the next word form the sentance
                }
                match = match.NextMatch(); // getting the next sentance which have the specific words USD,EUR,€,$,лв,dollar,euro
            }

            Console.ReadKey();
        }

        static bool IsNoun(string word)   // Function that checks if the word is a noun or not (poorly implemented with just random words)
        {
            if(word == "test" || word == "words" || word == "chart" || word == "currency" || word == "trader" || word == "example" || word == "position" || word == "rate" || word == "euro" || word == "dollar" || word == "strength")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
