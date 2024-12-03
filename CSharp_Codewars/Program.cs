/*
  Some Regex basics:

  ab   ---> 'ab' substring
  [ab] ---> single 'a' or 'b' character
  [^ab] ---> single character other than 'a' or 'b'
  [a-f] ---> single character from 'a' to 'f'
  [a-fA-F] ---> 'a','b','c','d','e','f','A','B','C','D',E','F'
  . ----> any single character
 \. ----> the dot symbol
 \+ \* ----> special symbols need '\' before them
 \d - any digit (but not necessarily Arabic 0-9)
[0-9] - safer than '\d' if we operate on classic 0..9 digits
 \D - any non-digit character (non-classic 0-9 digits are excluded too)
[^0-9] - not a classic Arabic digit (0-9)
1(20|2) - '120' or '12
(a|c)a - 'aa' or 'ca'
^(expression) - beginning of string
(expression)$ - end of string
^(expression)$ - the expression which must cover the entire string, not some substring
[0-9]{3} - exactly 3 symbols from [0-9] range
([0-9]a){2} - exactly 2 substrings of '[0-9]a' format
[0-9]{3,} - at least 3 consecutive symbols of [0-9] type
[0-9]{2,5} - from 2 to 5 symbols of [0-9] type
[a]* - 0 or more 'a' symbols
[a]+ - 1 or more [a] symbols
[a]? - 0 or 1 'a' symbols

 ^[0-9]{2}-[0-9]{3}$ - Regex for postal code
 ^(0|[1-9a-fA-F][0-9a-fA-F]*)$ - Regex for hex number (not beginning with '0' except the 0 number itself)
 ^.+\.txt$ - Regex for all files with 'txt' extension
 ^http[s]?://(www.)?test123(\.pl|\.com)$ - Regex for web page named 'test123'

 Regex test1 = new Regex("[0-9]{2}");
 Regex test2 = new Regex(@"\.{2}"); '@' is a safeguard against special characters at the beginning of a string, such as '\d' or '\.'

 ------- Basic Regex functions -------
 Match Match(string input) - returns first substring which matches the specified Regex pattern

 string str = DvG74hgg7;
 Regex reg = new Regex("[0-9]");
 Console.WriteLine(reg.Match(str)); // 7

 MatchCollection Matches(string input) - return all matching substrings

 string str = DvG74hgg7;
 Regex reg = new Regex("[0-9]");
 Console.WriteLine(reg.Matches(str)); // 74; 7

 bool IsMatch(string input) - returns true if string contains any substring which matches the given Regex pattern
 string str = DvG74hgg7;
 Regex reg = new Regex("[4-7]{2}");
 Console.WriteLine(reg.Matches(str)); // true
 Regex reg2 = new Regex("[4-6]{2}");
 Console.WriteLine(reg2.Matches(str)); // false



            string test1 = "abaaab";
            string test2 = "baaba";
            string test3 = "abab";

            Regex reg1 = new Regex("[aeiouy]{2}");
            int n = 3;
            Regex reg2 = new Regex("[aeiouy]{"+n+"}");

            Console.WriteLine(reg1.IsMatch(test1));
            Console.WriteLine(reg1.IsMatch(test2));
            Console.WriteLine(reg1.IsMatch(test3));

            Console.WriteLine(reg2.IsMatch(test1));
            Console.WriteLine(reg2.IsMatch(test2));
            Console.WriteLine(reg2.IsMatch(test3));

            Regex reg3 = new Regex("^[^aeiouy]*([aeiouy][^aeiouy]*){3}$"); // exactly 3 wovels

            Console.WriteLine(reg3.IsMatch(test1));
            Console.WriteLine(reg3.IsMatch(test2));
            Console.WriteLine(reg3.IsMatch(test3));

            test1 = "ppppppppppp";
            test2 = "aPpa";
            test3 = "PPPPP";

            Regex reg4 = new Regex("^[^p]*([p][^p]*){0,3}$");

            Console.WriteLine(reg4.IsMatch(test1));
            Console.WriteLine(reg4.IsMatch(test2));
            Console.WriteLine(reg4.IsMatch(test3));

            Console.WriteLine(reg4.IsMatch(test1.ToLower()));
            Console.WriteLine(reg4.IsMatch(test2.ToLower()));
            Console.WriteLine(reg4.IsMatch(test3.ToLower()));

            Regex reg5 = new Regex("^[^p]*([p][^p]*){0,3}$", RegexOptions.IgnoreCase);

            Console.WriteLine(reg5.IsMatch(test1));
            Console.WriteLine(reg5.IsMatch(test2));
            Console.WriteLine(reg5.IsMatch(test3));

            test1 = "Abab";
            test2 = "abAa";
            test3 = "bBBb";

            Regex reg6 = new Regex("^[^a]*(([a][^a]*){2})*$",RegexOptions.IgnoreCase); // check for even number of 'A' and/or 'a' letters

            Console.WriteLine(reg6.IsMatch(test1));
            Console.WriteLine(reg6.IsMatch(test2));
            Console.WriteLine(reg6.IsMatch(test3));

            test1 = "A1B2C3";
            test2 = "AbCdEf";
            test3 = "123X";

            Regex reg7 = new Regex("[A-Z]");

            DisplayCollectionOfCapitalLetters(reg7.Matches(test1));
            DisplayCollectionOfCapitalLetters(reg7.Matches(test2));
            DisplayCollectionOfCapitalLetters(reg7.Matches(test3));

            test1 = "22a44";
            test2 = "a868ab";
            test3 = "2234";

            Regex reg8 = new Regex("[02468]{2,}"); // find all substrings of 2 or more adjacent even digits

            DisplayCollectionOfCapitalLetters(reg8.Matches(test1));
            DisplayCollectionOfCapitalLetters(reg8.Matches(test2));
            DisplayCollectionOfCapitalLetters(reg8.Matches(test3));

            Console.ReadLine();

        }

        static void DisplayCollectionOfCapitalLetters(MatchCollection collection)
        {
            for (int i = 0; i < collection.Count; i++)
                Console.Write(collection[i]+" ");

            Console.WriteLine();
        }
    }
}


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using CSharp_Codewars;

namespace CSharp_Codewars
{
    class Program
    {

        static void Main(string[] args)
        {
        }
    }
}

/*
Console.WriteLine(Training.Encode("Gug hgs g cgt"));
Console.WriteLine(Training.Decode("Gug hgs g cgt"));

Console.ReadLine();

HowManyNumbers.FindAll(10, 3);
HowManyNumbers.FindAll(27, 3);
HowManyNumbers.FindAll(84, 4);
HowManyNumbers.FindAll(35, 6);

Console.WriteLine(WordList.ListPosition("FDACGACCBGAEFCG"));
Console.WriteLine(WordList.ListPosition("QUESTION"));
Console.WriteLine(WordList.ListPosition("BOOKKEEPER"));
Console.WriteLine(WordList.ListPosition("A"));
Console.WriteLine(WordList.ListPosition("AAAB"));
Console.WriteLine(WordList.ListPosition("ABAB"));
Console.WriteLine(WordList.ListPosition("BAAA"));

Console.WriteLine(Training.formatDuration(62));
Console.ReadLine();

Console.WriteLine(Training.CountPatterns('A', 0));
Console.WriteLine(Training.CountPatterns('A', 10));
Console.WriteLine(Training.CountPatterns('B', 1));
Console.WriteLine(Training.CountPatterns('C', 2));
Console.WriteLine(Training.CountPatterns('D', 3));
Console.WriteLine(Training.CountPatterns('E', 4));
Console.WriteLine(Training.CountPatterns('E', 8));
Console.ReadLine();
*/
/*
Console.WriteLine(Training.isPalindrome("aibofobia"));
Training.firstFibonacciNumbers(8);
Console.ReadLine();

/*
Dictionary<string, int> atoms = new Dictionary<string, int>();

//atoms = Training.ParseMolecule("{SO3}");
//atoms = Training.ParseMolecule("K4[ON(SO3)2]2");
atoms = Training.ParseMolecule("N(Fe8N153Ca[Br2(SO4)3N2(H4Ca)2]10H333Fe)4Ca");
//atoms = Training.ParseMolecule("Mg(OH)2");

//atoms = Training.ParseMolecule("H2O");

foreach (KeyValuePair<string, int> atom in atoms)
{
    Console.WriteLine(atom.Key + " " + atom.Value);
}
Console.ReadLine();
*/
/*
int[][] board = {

     new int[]{0,0,0,0,0,1,0,0},
     new int[]{0,0,0,0,0,0,0,0},
     new int[]{0,0,0,0,0,0,0,0},
     new int[]{0,-1,1,0,1,0,0,0},
     new int[]{0,0,0,0,0,-1,0,0},
     new int[]{0,0,0,0,0,0,0,0},
     new int[]{0,0,0,1,0,0,0,0},
     new int[]{-1,0,0,0,0,0,0,0}
};
*/
/*
new int[]{0,0,0,0,0,0,0,1},
new int[]{0,0,0,0,0,0,0,1},
new int[]{0,0,0,0,0,0,0,0},
new int[]{0,0,0,0,0,0,0,0},
new int[]{0,0,0,0,0,0,0,0},
new int[]{0,0,0,0,0,0,0,0},
new int[]{0,0,0,0,0,0,0,0},
new int[]{0,0,0,0,0,0,0,0}
*/
/*
 new int[]{0,0,1,0,0,0,0,0},
 new int[]{0,0,0,-1,0,-1,1,0},
 new int[]{0,0,0,0,0,0,0,0},
 new int[]{-1,0,-1,0,0,0,-1,1},
 new int[]{0,0,0,0,0,0,0,0},
 new int[]{0,0,0,0,0,0,0,0},
 new int[]{0,0,0,0,0,0,1,0},
 new int[]{0,0,0,0,0,0,0,0}
};
*/
/*
Console.WriteLine(Training.BishopsAndRooks(board));
Console.ReadLine();

}
}
}
*/
/*
Console.WriteLine(Training.DuplicateEncode("rEcedE"));

(string type, string[] ranks) result;

string[] holeCards = new string[2];
string[] communityCards = new string[5];

//holeCards = new[] { "K♠", "A♦" };
//communityCards = new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" };

//holeCards = new[] { "K♠", "Q♦" };
//communityCards = new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" };

//holeCards = new[] { "K♠", "J♦" };
//communityCards = new[] { "J♣", "K♥", "9♥", "2♥", "3♦" };

//holeCards = new[] { "4♠", "9♦" };
//communityCards = new[] { "J♣", "Q♥", "Q♠", "2♥", "Q♦" };

//holeCards = new[] { "Q♠", "2♦" };
//communityCards = new[] { "J♣", "10♥", "9♥", "K♥", "3♦" };

//holeCards = new[] { "A♠", "K♦" };
//communityCards = new[] { "J♥", "5♥", "10♥", "Q♥", "3♥" };

//holeCards = new[] { "A♠", "A♦" };
//communityCards = new[] { "K♣", "K♥", "A♥", "Q♥", "3♦" };

//holeCards = new[] { "2♠", "3♦" };
//communityCards = new[] { "2♣", "2♥", "3♠", "3♥", "2♦" };

holeCards = new[] { "8♠", "6♠" };
communityCards = new[] { "7♠", "5♠", "9♠", "J♠", "10♠" };

result = Training.Hand(holeCards, communityCards);

Console.WriteLine("result.type=" + result.type);
Console.Write("result.ranks=");
for (int i = 0; i < result.ranks.Length; i++) Console.Write(result.ranks[i] + " ");
Console.WriteLine();
Console.ReadLine();
}
}
}
*/
/*

//int[,] tab = Training.GetGeneration(new int[,] { { 1, 0, 0 }, { 0, 1, 1 }, { 1, 1, 0 } }, 2);
//int[,] tab = Training.GetGeneration(new int[,] { { 0, 1, 1 }, { 1, 0, 0 }, { 0, 0, 1 } },2);

int[,] tab2 = new int[,] { { 1, 3 }, { 7, 1 } };

Console.WriteLine("tab2[1,0]=" + tab2[1, 0]);
Console.WriteLine("tab2[0,1]=" + tab2[0, 1]);
Console.ReadLine();

//int[,] tab = Training.GetGeneration(new int[,] { { 0, 1, 1 }, { 1, 0, 0 }, { 0, 0, 1 } },0);
int[,] tab = Training.GetGeneration(new int[,] { { 0, 0, 0, 1, 1, 1, 0, 1 }, { 0, 1, 1, 1, 1, 1, 1, 0 }, { 1, 0, 1, 1, 1, 0, 0, 0 } }, 2);

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 8; j++)
    {
        Console.Write(tab[i, j]);
    }
    Console.WriteLine();
}
Console.ReadLine();
}
}
}
*/
/*
Console.WriteLine(Training.peakSeek(new int[] { 2, 1, 3, 1, 2, 2, 2, 2 }));

Console.ReadLine();
*/

//Console.WriteLine(Training.PathFinder("7"));

/*
Console.WriteLine(Training.PathFinder("0321\n" +
       "0005\n" +
       "3292\n" +
       "4100"));

Console.ReadLine();
*/
/*
Console.WriteLine(Training.PathFinder("000\n" +
       "000\n" +
       "000"));
*/
//Console.WriteLine(Training.print(0));
//Console.WriteLine(Training1.decodeMorse(Training1.decodeBitsAdvanced("0000000011011010011100000110000001111110100111110011111100000000000111011111111011111011111000000101100011111100000111110011101100000100000")));
//Console.WriteLine(Training1.decodeMorse(Training1.decodeBitsAdvanced("10011101110011101")));
//Console.WriteLine(Training1.decodeMorse(Training1.decodeBitsAdvanced("111011111000111000000001110011111")));
//Console.WriteLine(Training1.decodeMorse(Training1.decodeBitsAdvanced("00001110000")));
//Console.WriteLine(Training1.decodeMorse(Training1.decodeBitsAdvanced("0110000011111")));
//Console.WriteLine(Training1.decodeMorse(Training1.decodeBitsAdvanced("111100000111110000000000011100011110000001110000011111")));
//Console.WriteLine(Training1.decodeMorse(Training1.decodeBitsAdvanced("00000000000000011111111000000011111111111100000000000111111111000001111111110100000000111111111111011000011111111011111111111000000000000000000011111111110000110001111111111111000111000000000001111111111110000111111111100001100111111111110000000000111111111111011100001110000000000000000001111111111010111111110110000000000000001111111111100001111111111110000100001111111111111100000000000111111111000000011000000111000000000000000000000000000011110001111100000111100000000111111111100111111111100111111111111100000000011110011111011111110000000000000000000000111111111110000000011111000000011111000000001111111111110000000001111100011111111000000000111111111110000011000000000111110000000111000000000011111111111111000111001111111111001111110000000000000000000001111000111111111100001111111111111100100000000001111111100111111110111111110000000011101111111000111000000001001111111000000001111111111000000000111100001111111000000000000011111111100111111110111111111100000000000111111110000001100000000000000000000111111101010000010000001111111100000000011111000111111111000000111111111110011111111001111111110000000011000111111110000111011111111111100001111100001111111100000000000011110011101110001000111111110000000001111000011111110010110001111111111000000000000000000111111111110000000100000000000000000011110111110000001000011101110000000000011111111100000011111111111100111111111111000111111111000001111111100000000000001110111111111111000000110011111111111101110001111111111100000000111100000111100000111111111100000111111111111000000011111111000000000001000000111100000001000001111100111111111110000000000000000000010001111111100000011111111100000000000000100001111111111110111001111111111100000111111100001111111111000000000000000000000000011100000111111111111011110000000010000000011111111100011111111111100001110000111111111111100000000000000111110000011111001111111100000000000011100011100000000000011111000001111111111101000000001110000000000000000000000000000111110010000000000111111111000011111111110000000000111111111111101111111111100000000010000000000000011111111100100001100000000000000111100111100000000001100000001111111111110000000011111111111000000000111100000000000000000000111101111111111111000000000001111000011111000011110000000001100111111100111000000000100111000000000000111110000010000011111000000000000001111111111100000000110111111111100000000000000111111111111100000111000000000111111110001111000000111111110111111000000001111000000000010000111111111000011110001111111110111110000111111111111000000000000000000000000111111111110000000111011111111100011111110000000001111111110000011111111100111111110000000001111111111100111111111110000000000110000000000000000001000011111111110000000001111111110000000000000000000000011111111111111000000111111111000001111111110000000000111111110000010000000011111111000011111001111111100000001110000000011110000000001011111111000011111011111111110011011111111111000000000000000000100011111111111101111111100000000000000001100000000000000000011110010111110000000011111111100000000001111100011111111111101100000000111110000011110000111111111111000000001111111111100001110111111111110111000000000011111111101111100011111111110000000000000000000000000010000111111111100000000001111111110111110000000000000000000000110000011110000000000001111111111100110001111111100000011100000000000111110000000011111111110000011111000001111000110000000011100000000000000111100001111111111100000111000000001111111111000000111111111100110000000001111000001111111100011100001111111110000010011111111110000000000000000000111100000011111000001111000000000111111001110000000011111111000100000000000011111111000011001111111100000000000110111000000000000111111111111000100000000111111111110000001111111111011100000000000000000000000000")));
//Console.WriteLine(Training1bhp.decodeMorse(Training1bhp.decodeBitsAdvanced("011000011111")));
//Console.WriteLine(Training1bhp.decodeMorse("0000000011011010011100000110000001111110100111110011111100000000000111011111111011111011111000000101100011111100000111110011101100000100000"));
//Console.WriteLine(Training1bhp.decodeMorse("10011101110011101"));
//Console.WriteLine(Training1bhp.decodeMorse("111011111000111000000001110011111"));
//Console.WriteLine(Training1bhp.decodeMorse("00001110000"));

//Console.ReadLine();
/*
//Console.WriteLine(Training.LastDigit(new int[] {1449,10,73,15,16,0,8}));

//Random rnd = new Random();
//int rand1 = rnd.Next(0, 100);
//            int rand2 = rnd.Next(0, 10);

//            int[] tab = new int[] ({ rand1 }, (rand1 % 10));


//            Console.WriteLine("tab =");
//           for (int i = 0; i < tab.Length; i++) Console.Write(tab[i] + " ");

//           Console.WriteLine(Training.LastDigit(tab));

//Console.WriteLine(Training.LastDigit(new int[] { rand1 }, rand1 % 10));

//Console.WriteLine(Training.LastDigit(new int[] { 2,2,2,0 }));
//Console.ReadLine();

//Console.WriteLine(Training.MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
//Console.ReadLine();

}
}
}
*/
/*
Console.WriteLine(Training.Expand("(x+1)^2"));
Console.WriteLine(Training.Expand("(p-1)^3"));
Console.WriteLine(Training.Expand("(2f+4)^6"));
Console.WriteLine(Training.Expand("(-2a-4)^0"));
Console.WriteLine(Training.Expand("(-12t+43)^2"));
Console.WriteLine(Training.Expand("(r+0)^203"));
Console.WriteLine(Training.Expand("(-x-1)^2"));
*/
//Console.WriteLine(Training.Expand("(8v-10)^10"));
//Console.ReadLine();
//Console.WriteLine(Training.SubsetsParity(2, 1));

/*
Console.WriteLine(Training0.Evaluate("2 /2+3 * 4.75- -6"));

Console.WriteLine(Training0.Evaluate("(123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) - (123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) + (13 - 2)/ -(-11) "));

Console.WriteLine(Training0.Evaluate("2 / (2 + 3) * 4.33 - -6"));

Console.WriteLine(Training0.Evaluate("((2.33 / (2.9+3.5)*4) - -6)"));

Console.WriteLine(Training0.Evaluate("123.45*(678.90 / (-2.5+ 11.5)-(80 -19) *33.25) / 20 + 11"));
*/
/*
            Console.WriteLine(Training0.Evaluate("12*-1"));
            Console.WriteLine(Training0.Evaluate("12* 123/-(-5 + 2)"));
            Console.WriteLine(Training0.Evaluate("((80 - (19)))"));
            Console.WriteLine(Training0.Evaluate("(1 - 2) + -(-(-(-4)))"));
            Console.WriteLine(Training0.Evaluate("-1+--4"));
            Console.WriteLine(Training0.Evaluate("12* 123/(-5 + 2)"));
            Console.WriteLine(Training0.Evaluate("((6-3.25))*7/2+100*(8-2)"));
            Console.WriteLine(Training0.Evaluate("19.25/2"));
            Console.WriteLine(Training0.Evaluate("2 / 2 + 3 * 4 - 6"));
*/
//Console.ReadLine();


//Console.WriteLine(Training.DecodeMorse(Training.DecodeBits(("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011"))));
//Console.WriteLine(Training.DecodeMorse(Training.DecodeBits("0000111000111000")));
//Console.ReadLine();

/*
string a = ".W.\n" +
           ".W.\n" +
           "...",

       b = ".W.\n" +
           ".W.\n" +
           "W..",

       c = "......\n" +
           "......\n" +
           "......\n" +
           "......\n" +
           "......\n" +
           "......",

       d = "......\n" +
           "......\n" +
           "......\n" +
           "......\n" +
           ".....W\n" +
           "....W.";

Console.WriteLine(Training.PathFinder(a));
Console.ReadLine();
/*
Console.WriteLine(Training.NextBiggerNumber(10999999999));
Console.ReadLine();
*/

/*
Console.WriteLine(Training.CountCombinations(10, new[] {2, 3, 5}));
Console.ReadLine();
*/
/*
    Training good2 = new Training(
       new int[][] {
       new int[] {1,4, 2,3},
       new int[] {3,2, 4,1},
       new int[] {4,1, 3,2},
       new int[] {2,3, 1,4}
     });
*/
/*
Training good1 = new Training(
   new int[][] {
   new int[] {7,8,4, 1,5,9, 3,2,6},
   new int[] {5,3,9, 6,7,2, 8,4,1},
   new int[] {6,1,2, 4,3,8, 7,5,9},

   new int[] {9,2,8, 7,1,5, 4,6,3},
   new int[] {3,5,7, 8,4,6, 1,9,2},
   new int[] {4,6,1, 9,2,3, 5,8,7},

   new int[] {8,7,6, 3,9,4, 2,1,5},
   new int[] {2,4,3, 5,6,1, 9,7,8},
   new int[] {1,9,5, 2,8,7, 6,3,4}
});
*/
/*
Training badSudoku2 = new Training(
  new int[][] {
  new int[] {1,2,3,4,5},
  new int[] {1,2,3,4},

  new int[] {1,2,3,4},
  new int[] {1}
});
//Console.WriteLine(good1.IsValid());
Console.WriteLine(good2.IsValid());
Console.ReadLine();
*/
/*
Bagel bagel = Training.Bagel;

PropertyInfo bag = typeof(Bagel).GetProperty("Value");
bag.SetValue(bagel, 4);

Console.WriteLine(bagel.Value);
Console.ReadLine();
*/
//Training.DigitalRoot(50172);

/*
Console.WriteLine(Training.BalancedParens(5));
Console.ReadLine();
*/
//Training.Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 });

/*
Training.sieve();

IEnumerable<int> list = new List<int>();

list = Training.Stream();
*/
/*
            list.Clear();
            list.Add(2);
            list.Add(3);
            list.Add(5);
            list.Add(7);

            int i = 1;

            while (list.Count < 1000000)
            {
                if (Training.IsPrime(10 * i + 1, 2)) list.Add(10 * i + 1);
                if (Training.IsPrime(10 * i + 3, 2)) list.Add(10 * i + 3);
                if (Training.IsPrime(10 * i + 7, 2)) list.Add(10 * i + 7);
                if (Training.IsPrime(10 * i + 9, 2)) list.Add(10 * i + 9);
                i++;
            }
*/
/*
int[][] test = new int[][] { new[] { 2, 5, 3 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } };

Console.WriteLine(Training.Determinant(test));
Console.WriteLine(Training.Determinant(test));
Console.ReadLine();
*/
/*
Console.WriteLine(Training.FromRoman("MMMDCCXLVII"));

Console.WriteLine(Training.ToRoman(3747));
Console.ReadLine();
*/

/*
Console.WriteLine(Training.sumStrings("9999999999", "8789078169879"));
Console.ReadLine();
*/


/*
Node node = new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1);

Training.TreeByLevels(node);
*/
//int[,] t = Training.Spiralize(6);

/*
Console.WriteLine(Training.SquareDigits(8117300));
*/

/*
int[,] field = new int[10, 10]
   {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
    {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
    {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
    {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
    {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
    {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

Console.WriteLine(Training.ValidateBattlefield(field));
Console.ReadLine();
*/
/*
List<string> myList = new List<string>()
{
    "C_Yellow",
    "E_Red",
    "G_Yellow",
    "B_Red",
    "D_Yellow",
    "B_Red",
    "B_Yellow",
    "G_Red",
    "C_Yellow",
    "C_Red",
    "D_Yellow",
    "F_Red",
    "E_Yellow",
    "A_Red",
    "A_Yellow",
    "G_Red",
    "A_Yellow",
    "F_Red",
    "F_Yellow",
    "D_Red",
    "B_Yellow",
    "E_Red",
    "D_Yellow",
    "A_Red",
    "G_Yellow",
    "D_Red",
    "D_Yellow",
    "C_Red"
};


Console.WriteLine(Training.WhoIsWinner(myList));
Console.ReadLine();
*/

/*
int[][] tab = { new[] { 1, 2, 3 },new[] { 4, 5, 6 },new[] { 7, 8, 9 } };
Console.WriteLine(tab[0].Length);
Console.WriteLine(tab[2][1]);
Console.WriteLine(tab[2][2]);
Training.Snail(tab);

Console.ReadLine();
*/
/*
for (int i=0; i<9; i++)
{
    for (int j=0; j<9; j++)
    {
        int a = (j / 3) + 3*(i % 3);
        int b = 3*(i / 3) + (j % 3);

        Console.WriteLine("validate(" + a + "," + b + ")");
    }
    Console.WriteLine();
}
Console.ReadLine();
*/

/*
PokerHand karty1 = new PokerHand("4S 5H 6C 7D TD");
PokerHand karty2 = new PokerHand("TS 7H 6C 5D 4H");
PokerHand.Result wynik = karty1.CompareWith(karty2);

if (wynik == PokerHand.Result.Win) Console.WriteLine("Wygrana");
if (wynik == PokerHand.Result.Loss) Console.WriteLine("Przegrana");
if (wynik == PokerHand.Result.Tie) Console.WriteLine("Remis");
Console.ReadLine();
*/

/*
Console.WriteLine(Training.FirstNonRepeatingLetter("gDFififrD$FAADGR"));
Console.ReadLine();
*/

/*
Console.WriteLine(Training.GetReadableTime(11454));
Console.ReadLine();
*/

/*
List<String> xx = new List<String>();
    xx = Training.GetPINs("369");
foreach (string s in xx) Console.WriteLine(s);
Console.ReadLine();
*/

/*
Console.WriteLine(Training.Rot13("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
Console.ReadLine();
*/
/*
Console.WriteLine(Training.Rgb(5, 6, 8));
Console.ReadLine();
*/
/*
for (long i=1; i<100000; i++)
{
    if (Training.IsPowerSum(i)) Console.WriteLine("IsPowerSum(" + i + ")");
}

Console.ReadLine();
*/
/*
long h = 23632;
Console.WriteLine("XXX" + h.ToString());
string s = h.ToString();
Console.WriteLine("XXX" + s);
Console.ReadLine();
*/
/*
string s = Console.ReadLine();
Console.WriteLine(Training.SongDecoder(s)+"*");
Console.ReadLine();
*/
/*
Console.WriteLine(Training.AlphabetPosition("A"));
Console.ReadLine();
*/
/*
Console.WriteLine(Training.IsPangram("WEzdfRTYUIOPqsdfghjklAXCVBNM"));
Console.ReadLine();
*/
/*
int[] a = { 1,1,1 };

Console.WriteLine(Training.binaryArrayToNumber(a));
Console.ReadLine();
*/
/*
Console.WriteLine(Training.rowSumOddNumbers(3));
Console.ReadLine();
*/
/*
string[] arr = { "e", "e", "w", "s", "w", "w", "e", "e", "n", "w" };

Console.WriteLine(Training.IsValidWalk(arr));
Console.ReadLine();
*/

/*
string n = Console.ReadLine();
Console.WriteLine(Training.IsSquare(Int32.Parse(n)));
Console.ReadLine();
*/
/*
string s = Console.ReadLine();
Console.WriteLine(TransformString.TransformWordsWithAtLeastFiveLetters(s));
Console.ReadLine();
*/
/*
int num = 12390532;
long bigNum = num;

float myFloat = 13.37f;
double myNewDouble = myFloat;

double myDouble = 13.37;
int myInt;

myInt = (int)myDouble;

string myString = myDouble.ToString();
string myFloatString = myFloat.ToString();

Console.WriteLine(num);
Console.WriteLine(bigNum);
Console.WriteLine(myFloat);
Console.WriteLine(myNewDouble);
Console.WriteLine(myFloatString);

Console.ReadLine();
*/
/*
}
}
}
*/
/*
try
{
    char[] tab = { 'l', 'i', 't', 'e', 'r', 'k', 'i' };
    Array.Reverse(tab);

    for (int i = 0; i < tab.Length; i++)
        Console.Write(tab[i]);

    Car car1 = new Car("Ferrari", "Testarossa",300);
    Car car2 = new Car("Fiat", "126p", 90);
    Car car3 = new Car("Porsche", "Cayenne", 250);
    Car car4 = new Car("BMW", "X6", 240);

    List<Car> listOfCars = new List<Car>();
    listOfCars.Add(car1);
    listOfCars.Add(car2);
    listOfCars.Add(car3);
    listOfCars.Add(car4);

    foreach (Car car in listOfCars)
    {
        Console.WriteLine(car.model);
    }
*/

/*
var number = "1234";
byte b = Convert.ToByte(number);
Console.WriteLine(b);
*/
/*
string str = "true";
bool b = Convert.ToBoolean(str);
Console.WriteLine(b);
*/
/*
}
catch (Exception)
{
Console.WriteLine("The following exception occurred:");
}
*/
//Console.WriteLine("{0} {1}", byte.MinValue, byte.MaxValue);

/*
String name = "John";
int age;
age = 17;
*/
/*   char ch = 'A';
   float fl = 2.0;
   bool bo = true;
*/
/*   Console.WriteLine(name+" is "+age+" years old");
   Console.WriteLine(name.ToLower());
   Console.WriteLine(name.ToLower().Contains("john"));
   Console.WriteLine(name.ToLower().Contains("John"));
   Console.WriteLine(name[0]);
   Console.WriteLine(name.IndexOf('C'));
   Console.WriteLine(name.Substring(2));
   Console.WriteLine(name.Substring(2,2));
   Console.WriteLine(-3.456);
   Console.WriteLine(3 * 5 + 5);
   Console.WriteLine("Hello World!");
   Console.WriteLine(Math.Abs(-2.482));
   Console.WriteLine(Math.Pow(2, 3));
   Console.WriteLine(Math.Max(-5, 1));

   Console.WriteLine("Enter a new name");
   name = Console.ReadLine();
   Console.WriteLine("Enter a new age");
   age = Convert.ToInt32(Console.ReadLine());
*/
// Console.WriteLine(name + " is " + age + " years old");

/*   Console.WriteLine("Enter first number");
   double d1 = Convert.ToDouble(Console.ReadLine());
   Console.WriteLine("Enter second number");
   double d2 = Convert.ToDouble(Console.ReadLine());
   Console.WriteLine("sum of numbers equals "+  (d1 + d2));
*/
/*
Console.WriteLine("Enter name");
name = Console.ReadLine();
Console.WriteLine("Hello "+name);
*/
/*
int[] numbers = { -255, 6, -3, -3, 3, 0, 1574 };
Console.WriteLine(numbers[0]);
string[] names = new string[3];
names[0] = "Anne";
names[1] = "Peter";
names[2] = "Thomas";
*/
/*
writeAaa();
sayHello("Robert");
sayHello("Catherine");
*/
//Console.WriteLine(cube(3));
/*
bool yes = true;
yes = false;
if (yes)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}

bool isWhite = true;
bool isLong = true;

if (isWhite || isLong)
{
    Console.WriteLine("Long or white");
}
else
{
    Console.WriteLine("Neither long or white");
}

*/

//Console.WriteLine(GetMax(12, 3));

/*
Console.WriteLine(GetDay(3));
Console.WriteLine(GetDay(7));
Console.WriteLine(GetDay(8));
*/
/*
int i = 0;

while (i < 5)
{
    Console.WriteLine("i=" + i++);
}

do
{
    Console.WriteLine("i=" + i++);
} while (i <= 10);
*/

/*
string[] names = { "Adam", "Peter", "John Paul", "Robert James" };

for (int i=0; i<names.Length; i++)
{
    Console.WriteLine("i=" + i + " names[i]="+names[i]);
}
*/

//Console.WriteLine(GetPow(9, 9));

/*
int[,,] numberGrid = { { { 1, 2, 0, -1 }, { 3, 4, -17, -5 }, { 5, 6, -3, -2 } },
                       { { 7, 8, 9, 100 },{ 10, 11, 12, 99 },{ 13, 14, 15, 98 } },
                       { {16,17,18,19 },{20,21,22,23 },{24,25,26,27 } } };

Console.WriteLine(numberGrid[0, 1, 2]);
*/
/*
try
{
    double num1 = Convert.ToDouble(Console.ReadLine());
    double num2 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("result is " + (num1 / num2));
}
catch (DivideByZeroException e)
{
    Console.WriteLine("Pamiętaj cholero nie dzielić przez zero!");
}
catch (FormatException e)
{
    Console.WriteLine("Incorrect data format");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("This text will always appear, no matter if an exception was raised or not");
}
*/
/*
Book ksiazka1 = new Book();
ksiazka1.title = "Pan Tadeusz";
ksiazka1.author = "Adam Mickiewicz";
ksiazka1.pages = 345;

Book ksiazka2 = new Book();
ksiazka2.title = "Quo Vadis";
ksiazka2.author = "Henryk Sienkiewicz";
ksiazka2.pages = 285;
*/
//Book ksiazka3 = new Book("Balladyna", "Juliusz Słowacki", 196);
/*
Film film = new Film("nazwa", "autor", 100);
Console.WriteLine(film.Rating);
film.Rating = 0;
Console.WriteLine(film.Rating);
film.Rating = 3333;
Console.WriteLine(film.Rating);

Film film2 = new Film("nazwa", "autor", 100);

int numberOfFilms = film2.getFilmCount();
Console.WriteLine("Number of films = " + numberOfFilms);
*/

//Console.WriteLine(Math.Sqrt(144));

/*
Chef chef = new Chef();
chef.MakeChicken();

ItalianChef ital = new ItalianChef();
ital.MakeChicken();
ital.MakeSpaghetti();

chef.MakeSpecialDish();
ital.MakeSpecialDish();

Console.ReadLine();  
}
*/
/*
        static void writeAaa()
        {
            Console.WriteLine("Aaa");
        }
        static void sayHello(string name)
        {
            Console.WriteLine("Hello " + name);
        }
*/
/*
static int cube(int a)
{
    return a * a * a;
}
static int GetMax(int a, int b)
{
    if (a < b) return b;
    else return a;
}
*/
/*
static string GetDay(int dayNumber)
{
    switch (dayNumber)
    {
        case 1: return "Monday";
        case 2: return "Tuesday";
        case 3: return "Wednesday";
        case 4: return "Thursday";
        case 5: return "Friday";
        case 6: return "Saturday";
        case 7: return "Sunday";
        default: return "Invalid day number";
    }
}
*/
/*
static int GetPow(int x, int y)
{
    int result = 1;

    for (int i = 0; i < y; i++)
        result *= x;

    return result;
}
*/