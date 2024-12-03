using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharp_Codewars
{
    public static class WordList
    {
        public static long factorial(int n)
        {
            int counter = 2;
            long tempResult = 1;

            while (n >= counter)
            {
                tempResult *= counter;
                counter++;
            }
            return tempResult;
        }

        public static long letterSum(string s, Dictionary<char, int> dict, char startingLetter)
        {
            Dictionary<char, int> tempDict = new Dictionary<char, int>(dict);

            tempDict[startingLetter]--;

            long result = factorial(s.Length - 1);
            foreach (int i in tempDict.Values)
            {
                result /= factorial(i);
            }

            return result;
        }

        public static long ComputeRank(long currentRank, string s, Dictionary<char, int> dict)
        {

            if (s.Length == 1) return currentRank + 1;
            long rankIncrease = 0;

            int i = 0;

            while (dict.ElementAt(i).Key != s[0])
            {
                rankIncrease += letterSum(s, dict, dict.ElementAt(i).Key);
                i++;
            }

            char currentLetter = dict.ElementAt(i).Key;

            dict[currentLetter]--;
            if (dict[currentLetter] == 0) dict.Remove(currentLetter);

            return ComputeRank(currentRank + rankIncrease, s.Substring(1), dict);
        }

        public static long ListPosition(string s)
        {
            HashSet<char> letterSet = new HashSet<char>();
            for (int i = 0; i < s.Length; i++) letterSet.Add(s[i]);

            List<char> letterList = new List<char>();
            letterList = letterSet.ToList();
            letterList.Sort();

            Dictionary<char, int> letterCountDict = new Dictionary<char, int>();

            foreach (char l in letterList)
            {
                letterCountDict.Add(l, 0);
            }
            for (int i=0; i<s.Length; i++)
            {
                letterCountDict[s[i]]++;
            }

            return ComputeRank(0, s, letterCountDict);
        }
    }
}
