using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Reflection;
using System.ComponentModel;

namespace CSharp_Codewars
{
    public class Training
    {
        public static double Solution(int[] firstArray, int[] secondArray)
        {
            double[] thirdArray = new double[firstArray.Length];

            for (int i=0; i<firstArray.Length; i++)
                thirdArray[i] = Math.Abs(firstArray[i] - secondArray[i]) * Math.Abs(firstArray[i] - secondArray[i]);
            return thirdArray.Sum() / thirdArray.Length;
        }
    }
}
/*
        public static string str1 = "GADERYPOLUKIgaderypoluki";
        public static string str2 = "AGEDYROPULIKagedyropulik";

        public static string Encode(string str)
        {
            string resultStr = "";
            for (int i=0; i<str.Length; i++)
            {
                if (str1.IndexOf(str[i]) == -1) resultStr += str[i];
                else resultStr += str2[str1.IndexOf(str[i])];
            }
            return resultStr;

        }

        public static string Decode(string str)
        {
            string resultStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str1.IndexOf(str[i]) == -1) resultStr += str[i];
                else resultStr += str2[str1.IndexOf(str[i])];
            }
            return resultStr;
        }

        /*
        public static int[] resultArray = new int[5];

        public static string[] timePeriods = { "year", "day", "hour", "minute", "second" };
        public static int[] divNumbers = { 365 * 24 * 60 * 60, 24 * 60 * 60, 60 * 60, 60, 1 };

        public static string formatDuration(int n)
        {
            if (n == 0) return ("now");

            int reducedN = n;
            string resultString = "";

            for (int i = 0; i < 5; i++)
            {
                resultArray[i] = reducedN / divNumbers[i];
                reducedN -= resultArray[i] * divNumbers[i];

                if (resultArray[i] > 0)
                {
                    if (resultString.Length > 0) resultString += ", ";
                    resultString = resultString + resultArray[i].ToString() + " " + timePeriods[i].ToString();
                    if (resultArray[i] > 1) resultString += "s";
                }
            }

            int lastComma = resultString.LastIndexOf(',');
            if (lastComma != -1) resultString = resultString.Remove(lastComma, 1).Insert(lastComma, " and");

            return resultString;
        }
    }
}
*/
/*
public static int patternCount;
public static int length;

static Dictionary<(char, char), char> forbiddenConfigurations = new Dictionary<(char, char), char>
{
    {('C','A'),'B'},
    {('A','C'),'B'},
    {('A','G'),'D'},
    {('G','A'),'D'},
    {('D','F'),'E'},
    {('F','D'),'E'},
    {('B','H'),'E'},
    {('H','B'),'E'},
    {('G','I'),'H'},
    {('I','G'),'H'},
    {('C','I'),'F'},
    {('I','C'),'F'},
    {('A','I'),'E'},
    {('I','A'),'E'},
    {('C','G'),'E'},
    {('G','C'),'E'}
};


public static void scanPattern(string currentStr)
{
    //Console.WriteLine("scanPattern: currentStr = {0}", currentStr);

    if (currentStr.Length == length)
    {
        //Console.WriteLine("currentStr=" + currentStr);
        patternCount++;
    }

    else {

        for (char i = 'A'; i < 'J'; i++)
        {
            if ((currentStr.IndexOf(i) == -1) &&
               (!(forbiddenConfigurations.ContainsKey((currentStr[currentStr.Length - 1],i))) ||
               (currentStr.IndexOf(forbiddenConfigurations[(currentStr[currentStr.Length - 1], i)]) != -1)))
            {
                string newStr = currentStr + i.ToString();
                scanPattern(newStr);
            }
        }
    }
}

public static int CountPatterns(char firstDot, int l)
{
    patternCount = 0;
    length = l;

    if ((l>0) && (l<10)) 
      scanPattern(firstDot.ToString());

    return patternCount;
}
}
}
*/


/*
public static bool isPalindrome(string s)
{
    if (s.Length < 2) return true;

    int a = 0;
    int b = s.Length - 1;

    while (a < b)
    {
        if (s[a] != s[b]) return false;
        b--; a++;
    }
    return true;
}

public static void firstFibonacciNumbers (int n) {

    int i = 0;

    int beforePrevious = 0; int previous = 1;
    int result = 0;

    while (i <= n)
    {
        if (i == 0) Console.WriteLine(0);
        else if (i == 1) Console.WriteLine(1);
        else
        {
            result = beforePrevious + previous;
            Console.WriteLine(result);
            beforePrevious = previous;
            previous = result;
        }
        i++;
    }

}

*/

/*
public static bool isPalindrome(string s)
{
    if (s.Length < 2) return true;

    int a = 0;
    int b = s.Length - 1;

    while (a < b)
    {
        if (s[a] != s[b]) return false;
        b--; a++;
    }
    return true;
}

public static void firstFibonacciNumbers (int n) {

    int i = 0;

    int beforePrevious = 0; int previous = 1;
    int result = 0;

    while (i <= n)
    {
        if (i == 0) Console.WriteLine(0);
        else if (i == 1) Console.WriteLine(1);
        else
        {
            result = beforePrevious + previous;
            Console.WriteLine(result);
            beforePrevious = previous;
            previous = result;
        }
        i++;
    }

}
*/


/*
static Dictionary<string, int> result;
static string currentFormula;

public static bool IsLowercaseLetter(char c)
{
    return (c >= 'a') && (c <= 'z');
}
public static bool IsUppercaseLetter(char c)
{
    return (c >= 'A') && (c <= 'Z');
}

public static string MultiplyAtoms(int startSubstringPos, int endSubstringPos)
{
    Console.WriteLine("MultiplyAtoms: startSubstringPos = " + startSubstringPos + ", endSubstringPos = " + endSubstringPos);

    // Find multiplier for the innermost expression containing number of atoms
    int multiplier = 1;

    int t = endSubstringPos + 1;

    while ((t < currentFormula.Length) && (Char.IsDigit(currentFormula[t])))
       t++;

    Console.WriteLine("MultiplyAtoms: t = " + t);

    if (t > endSubstringPos + 1)
       multiplier = int.Parse(currentFormula.Substring(endSubstringPos + 1, t - endSubstringPos - 1));

    Console.WriteLine("MultiplyAtoms: multiplier = " + multiplier);

    // Multiply every atom quantity in the expression by the found multiplier
    // e.g. (Mg3SO4)2 becomes Mg6S2O8
    string oldString = currentFormula.Substring(startSubstringPos + 1, endSubstringPos - startSubstringPos - 1);

    Console.WriteLine("MultiplyAtoms: oldString = " + oldString);

    // Analyze the substring of currentFormula (e.g.) Mg3SO4 and increase atom quantites by current multiplier
    string newString = "";

    int i = 0;
    while (i < oldString.Length) {

        int currentAtomStartPos = i;
        Console.WriteLine("MultiplyAtoms: currentAtomStartPos = " + currentAtomStartPos);

        // Scan the current atom name beginning with a capital letter - e.g. 'S', 'Mg', etc.
        while ((i < oldString.Length - 1) && IsLowercaseLetter(oldString[i + 1])) i++;

        newString = String.Concat(newString, oldString.Substring(currentAtomStartPos, i - currentAtomStartPos + 1));
        Console.WriteLine("MultiplyAtoms: newString = " + newString);
        Console.WriteLine("MultiplyAtoms: oldString = " + oldString);
        Console.WriteLine("i = " + i);

        if ((i == oldString.Length - 1) || (!Char.IsDigit(oldString[i + 1])))
        {
            // No digits are present just after the found atom name,
            // just write the number times the multiplier found outside parentheses

            if (multiplier != 1)
                newString = String.Concat(newString, multiplier.ToString());
            Console.WriteLine("MultiplyAtoms: newString = " + newString);

        }
        else // oldString[i+1] is a digit, we need to count number of atoms of the found type 
        {

            int firstDigitPos = ++i; // position of first digit associated with currently found atom type in the string

            Console.WriteLine("MultiplyAtoms: firstDigitPos = " + firstDigitPos);

            while ((i < oldString.Length - 1) && Char.IsDigit(oldString[i + 1])) i++;

            int multipliedNumberOfAtoms = int.Parse(oldString.Substring(firstDigitPos, i - firstDigitPos + 1)) * multiplier;
            newString = String.Concat(newString,multipliedNumberOfAtoms.ToString());

            Console.WriteLine("MultiplyAtoms: multipliedNumberOfAtoms = " + multipliedNumberOfAtoms);
            Console.WriteLine("MultiplyAtoms: newString = " + newString);
        }

        i++;
    }
    /* New string with multiplied atom numbers has been constructed for the currently handled expression inside parentheses.
       Now we need to replace the corresponding fragment of currentFormula, including parentheses and multiplier, with our
       new string.
    */

/*
        string newCurrentFormula;
        if (startSubstringPos == 0) newCurrentFormula = String.Copy(newString);
        else newCurrentFormula = String.Concat(String.Copy(currentFormula.Substring(0, startSubstringPos)),newString);
        if (t < currentFormula.Length)
            newCurrentFormula = String.Concat(newCurrentFormula, currentFormula.Substring(t, currentFormula.Length - t));

        Console.WriteLine("MultiplyAtoms: newCurrentFormula = " + newCurrentFormula);

        return newCurrentFormula;
    }

    public static void HandleInnerExpression()
    {

        while ((currentFormula.IndexOf(']') + currentFormula.IndexOf(')') + currentFormula.IndexOf('}')) != -3)
        {
            int a;
            int b;

            int x = currentFormula.IndexOf(')');
            int y = currentFormula.IndexOf(']');
            int z = currentFormula.IndexOf('}');

            b = x;
            if (((b == -1) || ((y != -1) && (y < b)))) b = y;
            if ((b == -1) || ((z != -1) && (z < b))) b = z;

            if (currentFormula[b] == ')') a = currentFormula.Substring(0, b + 1).LastIndexOf('(');
            else if (currentFormula[b] == ']') a = currentFormula.Substring(0, b + 1).LastIndexOf('[');
            else a = currentFormula.Substring(0, b + 1).LastIndexOf('{');

            Console.WriteLine("HandleInnerExpression - before MultiplyAtoms: a = " + a + ", b = " + b);

            Console.WriteLine("HandleInnerExpression - before MultiplyAtoms: currentFormula = " + currentFormula);
            currentFormula = MultiplyAtoms(a, b);
            Console.WriteLine("HandleInnerExpression - after MultiplyAtoms: currentFormula = " + currentFormula);
        }

    }

    public static void RemoveMultipleOccurrences()
    {
        // Remove multiple occurrences of the same atom type when computing total number of atoms of each element
        // i.e. Mg20S3ONa4Mg14O5Mg6Na is changed to Mg40S3O6Na5

        Console.WriteLine("RemoveMultipleOccurrences: currentFormula = " + currentFormula);
        Console.ReadLine();
        int i = 0;

        while (i < currentFormula.Length)
        {
            int currentAtomStartPos = i;

            Console.WriteLine("RemoveMultipleOccurrences: currentAtomStartPos = " + currentAtomStartPos);

            // Scan the current atom name beginning with a capital letter - e.g. 'S', 'Mg', etc.
            while ((i < currentFormula.Length - 1) && IsLowercaseLetter(currentFormula[i + 1])) i++;

            string currentAtomString = currentFormula.Substring(currentAtomStartPos, i - currentAtomStartPos + 1);
            Console.WriteLine("RemoveMultipleOccurrences: currentAtomString = " + currentAtomString);

            int currentAtomCount;

            if ((i == currentFormula.Length - 1) || IsUppercaseLetter(currentFormula[i + 1])) currentAtomCount = 1;
            else
            {
                // Next character is a digit, we need to count number of atoms

                int firstDigitPos = ++i; // position of first digit associated with currently found atom type in the string
                Console.WriteLine("RemoveMultipleOccurrences: firstDigitPos = " + firstDigitPos);

                while ((i < currentFormula.Length - 1) && Char.IsDigit(currentFormula[i + 1])) i++;

                currentAtomCount = int.Parse(currentFormula.Substring(firstDigitPos, i - firstDigitPos + 1));
                Console.WriteLine("RemoveMultipleOccurrences: currentAtomCount = " + currentAtomCount);
            }

            /* We know type and count of atoms in the currently analyzed fragment of currentFormula, now we need to check
               if it is already in the result dictionary.
               If so, the total number of atoms of the given element is increased by the number found in this substring of
               currentFormula.
               If this is the first occurrence of this element in currentFormula, a new entry is added to the result
               dictionary, and its count is set to the number of atoms found in this substring.
            */
/*
            Console.WriteLine("RemoveMultipleOccurrences: i = " + i);
            Console.ReadLine();

            if (result.ContainsKey(currentAtomString))
                result[currentAtomString] += currentAtomCount;
            else
                result.Add(currentAtomString, currentAtomCount);

            i++;
        }


    }
*/
/*
    public static Dictionary<string, int> ParseMolecule(string formula)
    {
        Console.WriteLine("ParseMolecule: currentFormula = " + currentFormula);

        currentFormula = String.Copy(formula);

        result = new Dictionary<string, int>();

        HandleInnerExpression();

        RemoveMultipleOccurrences();

        return result;
    }
}
}
*/

/*
static int[][] board;
// -1 - bishop
// 1 - rook
// 0 - empty square

static bool[][] isAttacked;

static bool Scan(int x, int y)
{
    // check if the given field is unoccupied

    if (board[x][y] != 0) return true;

    int xp = x; int yp = y;

    // check if the given field is attacked by a bishop

    while (((xp > 0) && (yp > 0)) && (board[xp - 1][yp - 1] == 0)) { xp--; yp--; }
    if (((xp > 0) && (yp > 0)) && ((board[xp - 1][yp - 1] == -1))) return true;

    xp = x; yp = y;

    while (((xp < 7) && (yp > 0)) && (board[xp + 1][yp - 1] == 0)) { xp++; yp--; }
    if (((xp < 7) && (yp > 0)) && ((board[xp + 1][yp - 1] == -1))) return true;

    xp = x; yp = y;

    while (((xp > 0) && (yp < 7)) && (board[xp - 1][yp + 1] == 0)) { xp--; yp++; }
    if (((xp > 0) && (yp < 7)) && ((board[xp - 1][yp + 1] == -1))) return true;

    xp = x; yp = y;

    while (((xp < 7) && (yp < 7)) && (board[xp + 1][yp + 1] == 0)) { xp++; yp++; }
    if (((xp < 7) && (yp < 7)) && ((board[xp + 1][yp + 1] == -1))) return true;

    xp = x; yp = y;

    // check if the given field is attacked by a rook

    while ((xp > 0) && (board[xp - 1][yp] == 0)) xp--;
    if ((xp > 0) && (board[xp - 1][yp] == 1)) return true;

    xp = x;

    while ((xp < 7) && (board[xp + 1][yp] == 0)) xp++;
    if ((xp < 7) && (board[xp + 1][yp] == 1)) return true;

    xp = x;

    while ((yp > 0) && (board[xp][yp - 1] == 0)) yp--;
    if ((yp > 0) && (board[xp][yp - 1] == 1)) return true;

    yp = y;

    while ((yp < 7) && (board[xp][yp + 1] == 0)) yp++;
    if ((yp < 7) && (board[xp][yp + 1] == 1)) return true;

    return false;
}

public static void Initialize(int[][] newBoard)
{
    board = new int[8][];
    isAttacked = new bool[8][];

    board = newBoard.Select(e => e.ToArray()).ToArray();

    isAttacked = new bool[][]
    {
        new bool[]{false,false,false,false,false,false,false,false},
        new bool[]{false,false,false,false,false,false,false,false},
        new bool[]{false,false,false,false,false,false,false,false},
        new bool[]{false,false,false,false,false,false,false,false},
        new bool[]{false,false,false,false,false,false,false,false},
        new bool[]{false,false,false,false,false,false,false,false},
        new bool[]{false,false,false,false,false,false,false,false},
        new bool[]{false,false,false,false,false,false,false,false}
    };
}

public static int CountAttackedFields()
{
    int counter = 0;

    for (int i = 0; i < 8; i++)
        for (int j = 0; j < 8; j++)
            if (isAttacked[i][j]) counter++;
    return counter;
}


public static int BishopsAndRooks(int[][] ChessBoard)
{

    Initialize(ChessBoard);

    for (int i = 0; i < 8; i++)
        for (int j = 0; j < 8; j++)
            isAttacked[i][j] = Scan(i, j);

    return 64-CountAttackedFields();
}
}
}
*/
/*
public static string DuplicateEncode(string word)
{
    string s = "";
    string w = word.ToLower();

    for (int i=0; i<word.Length; i++)
    {
        if (w.Count(x => (x == w[i])) > 1) s = String.Concat(s, ")");
        else s = String.Concat(s, "(");
    }

    return s;
}

}
}
*/
/*
    {                               //     A K Q J 10 9 8 7 6 5 4 3 2
        static bool[,] cardExists;  // ♥
                                    // ♦   true if a given card exists in total hand (hole + community)
                                    // ♣   false otherwise
                                    // ♠ 


        static int[] cardQuantities; // A K Q J 10 9 8 7 6 5 4 3 2
                                     // number of cards of certain values in the total hand

        static int[] suitQuantities; // ♥ ♦ ♣ ♠
                                     // number of cards of certain suit in the total hand

        static Dictionary<string, int> cardValue; // A K Q J 10 9 8 7 6 5  4  3  2
                                                // 0 1 2 3  4 5 6 7 8 9 10 11 12
                                                // array implemented for technical purposes

        static Dictionary<char, int> suitValue; // ♥ ♦ ♣ ♠
                                                // 0 1 2 3
                                                // array implemented for technical purposes

        public static readonly string[] cardTypes = { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };
        public static readonly char[] suitTypes = { '♥', '♦', '♣', '♠' };

        public static void SetupInitialValues()
        {
            cardExists = new bool[13, 4];

            for (int i = 0; i < 13; i++)
                for (int j = 0; j < 4; j++)
                    cardExists[i, j] = false;

            cardQuantities = new int[13];

            for (int i = 0; i < 13; i++)
                cardQuantities[i] = 0;

            suitQuantities = new int[4];

            for (int i = 0; i < 4; i++)
                suitQuantities[i] = 0;

            cardValue = new Dictionary<string, int>();
            cardValue.Add("A", 0);
            cardValue.Add("K", 1);
            cardValue.Add("Q", 2);
            cardValue.Add("J", 3);
            cardValue.Add("10", 4);
            cardValue.Add("9", 5);
            cardValue.Add("8", 6);
            cardValue.Add("7", 7);
            cardValue.Add("6", 8);
            cardValue.Add("5", 9);
            cardValue.Add("4", 10);
            cardValue.Add("3", 11);
            cardValue.Add("2", 12);

            suitValue = new Dictionary<char, int>();
            suitValue.Add('♥', 0);
            suitValue.Add('♦', 1);
            suitValue.Add('♣', 2);
            suitValue.Add('♠', 3);

        }
        public static void SetupHand(string[] hole, string[] comm)
        {
            for (int i=0; i<2; i++) // analyze the hole cards
            {
                string rank = hole[i].Substring(0, hole[i].Length - 1);
                char suit = hole[i][hole[i].Length - 1];

                cardExists[cardValue[rank], suitValue[suit]] = true;
                cardQuantities[cardValue[rank]]++;
                suitQuantities[suitValue[suit]]++;
            }

            for (int i=0; i<5; i++) // analyze the community cards
            {
                string rank = comm[i].Substring(0, comm[i].Length - 1);
                char suit = comm[i][comm[i].Length - 1];

                cardExists[cardValue[rank], suitValue[suit]] = true;
                cardQuantities[cardValue[rank]]++;
                suitQuantities[suitValue[suit]]++;
            }
        }

        public static int GetFlushSuit()
        {
            for (int i = 0; i < 4; i++) if (suitQuantities[i] >= 5) return i;
            return -1;
        }

        public static int CheckStraightFlush()
        {
            int f = GetFlushSuit();
            if (f == -1) return -1;

            int longestSequenceLength = 0;
            int longestSequenceStartingIndex = 0;
            int currentSequenceLength = 0;
            int currentSequenceStartingIndex = 0;

            int i = 0;

            while ((i<=12) && (longestSequenceLength<5))
            {
                if (cardExists[i,f])
                {
                    if (++currentSequenceLength == 1)
                        currentSequenceStartingIndex = i;

                    if (currentSequenceLength>longestSequenceLength)
                    {
                        longestSequenceLength = currentSequenceLength;
                        longestSequenceStartingIndex = currentSequenceStartingIndex;
                    }
                }
                else currentSequenceLength = 0;
                i++;
            }

            if (longestSequenceLength < 5) return -1;
            else return longestSequenceStartingIndex;
        }

        public static int CheckStraight()
        {
            // CheckStraight should be used only when there is no straight flush (CheckStraightFlush returned -1)

            int longestSequenceLength = 0;
            int longestSequenceStartingIndex = 0;
            int currentSequenceLength = 0;
            int currentSequenceStartingIndex = 0;

            int i = 0;

            while ((i <= 12) && (longestSequenceLength < 5))
            {
                if (cardQuantities[i] > 0)
                {
                    if (++currentSequenceLength == 1)
                        currentSequenceStartingIndex = i;

                    if (currentSequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = currentSequenceLength;
                        longestSequenceStartingIndex = currentSequenceStartingIndex;
                    }
                }
                else currentSequenceLength = 0;
                i++;
            }
            if (longestSequenceLength < 5) return -1;
            else return longestSequenceStartingIndex;
        }

        public static int[] SortCardQuantities()
        {
            int[] result = (int[])cardQuantities.Clone();
            Array.Sort(result);
            Array.Reverse(result);
            return result;
        }

        public static (string type, string[] ranks) Hand(string[] holeCards, string[] communityCards)
        {
            SetupInitialValues();
            SetupHand(holeCards, communityCards);

            string resultString;
            string[] resultArray;

            int sfl = CheckStraightFlush();

            if (sfl>-1)
            {
                resultString = "straight-flush";
                resultArray = new string[5];

                for (int i = 0; i < 5; i++) resultArray[i] = cardTypes[sfl + i];
                return (resultString, resultArray);
            }

            int[] sortedCardQuantities = SortCardQuantities();

            if (sortedCardQuantities[0] == 4)
            {
                resultString = "four-of-a-kind";
                resultArray = new string[2];

                int pos4 = Array.IndexOf(cardQuantities, 4);
                resultArray[0] = cardTypes[pos4];

                cardQuantities[pos4] = 0;

                int i = 0;
                while (cardQuantities[i] == 0) i++;
                resultArray[1] = cardTypes[i];

                return (resultString, resultArray);
            }

            if ((sortedCardQuantities[0] == 3) && (sortedCardQuantities[1] >= 2))
            {
                resultString = "full house";
                resultArray = new string[2];

                int pos3 = Array.IndexOf(cardQuantities, 3);
                resultArray[0] = cardTypes[pos3];

                cardQuantities[pos3] = 0;

                int i = 0;
                while (cardQuantities[i] < 2) i++;
                resultArray[1] = cardTypes[i];

                return (resultString, resultArray);
            }

            int f = GetFlushSuit();

            if (f>-1)
            {
                resultString = "flush";
                resultArray = new string[5];

                int selectedCardCount = 0;
                int i = 0;

                while (selectedCardCount < 5)
                {
                    if (cardExists[i,f])
                        resultArray[selectedCardCount++] = cardTypes[i];

                    i++;
                }

                return (resultString, resultArray);
            }

            int s = CheckStraight();

            if (s>-1)
            {
                resultString = "straight";
                resultArray = new string[5];

                for (int i = 0; i < 5; i++) resultArray[i] = cardTypes[s + i];

                return (resultString, resultArray);
            }

            if (sortedCardQuantities[0] == 3)
            {
                resultString = "three-of-a-kind";
                resultArray = new string[3];

                int pos3 = Array.IndexOf(cardQuantities, 3);
                resultArray[0] = cardTypes[pos3];

                cardQuantities[pos3] = 0;

                int selectedCardCount = 1;
                int i = 0;

                while (selectedCardCount < 3)
                {
                    if (cardQuantities[i] == 1) resultArray[selectedCardCount++] = cardTypes[i];
                    i++;
                }

                return (resultString, resultArray);
            }

            if (sortedCardQuantities[0] == 2)
            {
                if (sortedCardQuantities[1] == 2)
                {
                    resultString = "two pair";
                    resultArray = new string[3];

                    int pos2 = Array.IndexOf(cardQuantities, 2);
                    resultArray[0] = cardTypes[pos2];

                    cardQuantities[pos2] = 0;

                    pos2 = Array.IndexOf(cardQuantities, 2);
                    resultArray[1] = cardTypes[pos2];

                    cardQuantities[pos2] = 0;

                    int i = 0;
                    while (cardQuantities[i] == 0) i++;
                    resultArray[2] = cardTypes[i];

                    return (resultString, resultArray);
                }
                else
                {
                    resultString = "pair";
                    resultArray = new string[4];

                    int pos2 = Array.IndexOf(cardQuantities, 2);
                    resultArray[0] = cardTypes[pos2];

                    cardQuantities[pos2] = 0;

                    int selectedCardCount = 1;
                    int i = 0;

                    while (selectedCardCount < 4)
                    {
                        if (cardQuantities[i] == 1) resultArray[selectedCardCount++] = cardTypes[i];
                        i++;
                    }
                    return (resultString, resultArray);
                }
            }

            else
            {
                resultString = "nothing";
                resultArray = new string[5];

                int selectedCardCount = 0;
                int i = 0;

                while (selectedCardCount < 5)
                {
                    if (cardQuantities[i] == 1) resultArray[selectedCardCount++] = cardTypes[i];
                    i++;
                }
                return (resultString, resultArray);
            }
        }

    }
}
*/
/*
        static int[,] oldBoard;
        static int[,] newBoard;
        static int m,n;
 
        static void Startup (int[,] board)
        {
            m = board.GetLength(0);
            n = board.GetLength(1);

            //Console.WriteLine("m=" + m + " n=" + n);
            //Console.ReadLine();

            oldBoard = new int[m, n];
            newBoard = new int[m, n];

            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n; j++)
                {
                    oldBoard[i, j] = board[i, j];
                }
            }

            //Buffer.BlockCopy(board, 0, oldBoard, 0, board.Length * sizeof(int));

            //Array.Copy(board, oldBoard, board.Length);
        }

        static int ScanOnes (int x, int y)
        {
            int result = 0;

            if (((x > 0) && (y > 0)) && (oldBoard[x - 1, y - 1] == 1)) result++;
            if ((x > 0) && (oldBoard[x - 1, y] == 1)) result++;
            if (((x > 0) && (y < n-1)) && (oldBoard[x - 1, y + 1] == 1)) result++;
            if (((x < m-1) && (y > 0)) && (oldBoard[x + 1, y - 1] == 1)) result++;
            if ((x < m-1) && (oldBoard[x + 1, y] == 1)) result++;
            if (((x < m-1) && (y < n - 1)) && (oldBoard[x + 1, y + 1] == 1)) result++;
            if ((y > 0) && (oldBoard[x, y - 1] == 1)) result++;
            if ((y < n-1) && (oldBoard[x, y + 1] == 1)) result++;

            //Console.WriteLine("ScanOnes: x=" + x + " y=" + y + " result=" + result);

            return result;
        }

        static void ProcessGeneration()
        {
            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (oldBoard[i,j] == 0) { if (ScanOnes(i, j) == 3) newBoard[i, j] = 1; else newBoard[i, j] = 0; }
                    if (oldBoard[i,j] == 1) { if ((ScanOnes(i, j) == 2) || (ScanOnes(i,j) == 3)) newBoard[i, j] = 1; else newBoard[i, j] = 0; }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    oldBoard[i, j] = newBoard[i, j];
                }
            }


            //Array.Copy(newBoard, oldBoard, m * n);
            //Buffer.BlockCopy(newBoard, 0, oldBoard, 0, oldBoard.Length * sizeof(int));
         }

        public static int[,] GetGeneration(int[,] cells, int generation)
        {
            Startup(cells);
            for (int a = 0; a < generation; a++) ProcessGeneration();
            return oldBoard;
        }

    }
}
*/
/*
static List<int> pos;
static List<int> peaks;

public static Dictionary<String, List<int>> peakSeek(int[] arr)
{
    pos = new List<int>();
    peaks = new List<int>();
    int i = 0;

    while (++i < arr.Length - 1)
    {
        if (arr[i-1] < arr[i])
        {
            if (arr[i + 1] < arr[i]) { pos.Add(i); peaks.Add(arr[i]); }
            if (arr[i+1] == arr[i])
            {
                int j = i;

                while ((i < arr.Length - 1) && (arr[i] == arr[i + 1])) i++;
                if ((i < arr.Length - 1) && (arr[i+1] < arr[j])) { pos.Add(j); peaks.Add(arr[j]); };
            }
        }
    }
    Dictionary<String, List<int>> dict = new Dictionary<String, List<int>>();

    dict.Add("pos", pos);
    dict.Add("peaks", peaks);
    return dict;
}
}
}
*/
/*

public struct vertex
{
    public int x;
    public int y;
};

public static int[,] map;
public static int[,] minDistance;
public static vertex[,] previous;
public static bool[,] alreadyProcessed;
public static bool[,] addedToList;
public static int n;
public static List<vertex> waitingList;

public static int Diff(int x1, int y1, int x2, int y2)
{
    return Math.Abs(map[x1, y1] - map[x2, y2]);
}

public static vertex FindUnprocessedVertexWithMinimumDistance()
{
    int minDistanceFound = 999999999;
    vertex bestVertex = new vertex { x = -1, y = -1 };

    foreach (vertex v in waitingList)
    {
        if ((alreadyProcessed[v.x,v.y] == false) && (minDistance[v.x,v.y] < minDistanceFound))
        {
            minDistanceFound = minDistance[v.x, v.y];
            bestVertex.x = v.x;
            bestVertex.y = v.y;
        }
    }
    return bestVertex;
}

public static void Scan(int x, int y, int dist)
{
    if (minDistance[x,y] > dist) minDistance[x, y] = dist;
    alreadyProcessed[x, y] = true;

    while (alreadyProcessed[n-1,n-1] == false)
    {
        if ((x < n - 1) && (alreadyProcessed[x+1,y] == false))
        {
            if (dist + Diff(x, y, x + 1, y) < minDistance[x + 1, y])
            {
                minDistance[x + 1, y] = dist + Diff(x, y, x + 1, y);
                previous[x + 1, y].x = x; previous[x + 1, y].y = y;
                if (addedToList[x + 1, y] == false)
                {
                    waitingList.Add(new vertex { x = x + 1, y = y });
                    addedToList[x + 1, y] = true;
                }
            }
        }

        if ((x > 0) && (alreadyProcessed[x - 1, y] == false))
        {
            if (dist + Diff(x, y, x - 1, y) < minDistance[x - 1, y])
            {
                minDistance[x - 1, y] = dist + Diff(x, y, x - 1, y);
                previous[x - 1, y].x = x; previous[x - 1, y].y = y;
                if (addedToList[x - 1, y] == false)
                {
                    waitingList.Add(new vertex { x = x - 1, y = y });
                    addedToList[x - 1, y] = true;
                }
            }
        }

        if ((y < n - 1) && (alreadyProcessed[x,y+1] == false))
        {
            if (dist + Diff(x, y, x, y+1) < minDistance[x, y+1])
            {
                minDistance[x, y+1] = dist + Diff(x, y, x, y+1);
                previous[x, y+1].x = x; previous[x, y+1].y = y;
                if (addedToList[x, y+1] == false)
                {
                    waitingList.Add(new vertex { x = x, y = y + 1 });
                    addedToList[x, y+1] = true;
                }
            }
        }

        if ((y > 0) && (alreadyProcessed[x, y - 1] == false))
        {
            if (dist + Diff(x, y, x, y - 1) < minDistance[x, y - 1])
            {
                minDistance[x, y - 1] = dist + Diff(x, y, x, y - 1);
                previous[x, y - 1].x = x; previous[x, y - 1].y = y;
                if (addedToList[x, y - 1] == false)
                {
                    waitingList.Add(new vertex { x = x, y = y - 1 });
                    addedToList[x, y - 1] = true;
                }
            }

        }

        /*
                        if ((x < n - 1) && (dist + Diff(x, y, x + 1, y) < minDistance[x + 1, y]))
                        {
                            minDistance[x + 1, y] = dist + Diff(x, y, x + 1, y);
                            previous[x + 1, y].x = x; previous[x + 1, y].y = y;
                            if (addedToList[x+1,y] == false)
                            {
                                waitingList.Add(new vertex { x = x + 1, y = y});
                                addedToList[x + 1, y] = true;
                            }
                        }

        if ((x > 0) && (dist + Diff(x, y, x - 1, y) < minDistance[x - 1, y]))
        {
            minDistance[x - 1, y] = dist + Diff(x, y, x - 1, y);
            previous[x - 1, y].x = x; previous[x - 1, y].y = y;
            if (addedToList[x - 1, y] == false)
            {
                waitingList.Add(new vertex { x = x - 1, y = y });
                addedToList[x - 1, y] = true;
            }
        }

        if ((y < n - 1) && (dist + Diff(x, y, x, y + 1) < minDistance[x, y + 1]))
        {
            minDistance[x, y + 1] = dist + Diff(x, y, x, y + 1);
            previous[x, y + 1].x = x; previous[x, y + 1].y = y;
            if (addedToList[x, y + 1] == false)
            {
                waitingList.Add(new vertex { x = x, y = y + 1});
                addedToList[x, y + 1] = true;
            }
        }

        if ((y > 0) && (dist + Diff(x, y, x, y - 1) < minDistance[x, y - 1]))
        {
            minDistance[x, y - 1] = dist + Diff(x, y, x, y - 1);
            previous[x, y - 1].x = x; previous[x, y - 1].y = y;
            if (addedToList[x, y - 1] == false)
            {
                waitingList.Add(new vertex { x = x, y = y - 1 });
                addedToList[x, y - 1] = true;
            }
        }

        vertex v = FindUnprocessedVertexWithMinimumDistance();
        Scan(v.x, v.y, minDistance[v.x, v.y]);
    }

}

public static int PathFinder(string maze)
{
    if (maze.Length <= 1) return 0;

    n = maze.IndexOf('\n');
    maze = maze.Replace("\n",string.Empty);

    map = new int[n, n];
    minDistance = new int[n, n];
    previous = new vertex[n, n];
    alreadyProcessed = new bool[n, n];
    addedToList = new bool[n, n];
    waitingList = new List<vertex>();

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            map[i, j] = maze[n * i + j] - 48;
            minDistance[i, j] = 999999999;
            previous[i, j].x = -1;
            previous[i, j].y = -1;
            alreadyProcessed[i, j] = false;
            addedToList[i, j] = false;
        }
    }
    Scan(0, 0, 0);
    return minDistance[n - 1, n - 1];
}

}
}
*/
/*
public static string GenerateStars(int i, int n)
{
    string s = "";
    int numberOfStars = n - 2 * Math.Abs(i - (n / 2 + 1));

    for (int a = 1; a <= (n - numberOfStars) / 2; a++) s = s + " ";
    for (int a = 1; a <= numberOfStars; a++) s = s + "*";
    //for (int a = 1; a <= (n - numberOfStars) / 2; a++) s = s + " ";
    s = s + "\n";
    return s;
}

public static string print(int n)
{
    if ((n < 0) || (n % 2 == 0)) return null;

    string result = "";

    for (int i = 1; i <= n; i++) result = result + GenerateStars(i, n);
    return result;
}

}
}
*/
/*
public static bool ValidParentheses(string input)
{
    int i = -1;
    int c = 0;

    while (++i<input.Length)
    {
        if (input[i] == '(') c++;
        if (input[i] == ')')
        {
            if (c == 0) return false;
            else c--;
        }
    }
    if (c == 0) return true;
    else return false;
}
}
}
*/

/*

public static int SumIntervals((int, int)[] intervals)
{
    bool[] intervalExists = new bool[2000000];
    for (int i = 0; i < 2000000; i++) intervalExists[i] = false;

    // intervalExists[999999]  = interval (-1,0)
    // intervalExists[1000000] = interval (0,1)
    // intervalExists[1000001] = interval (1,2)

    for (int i=0; i<intervals.Length; i++)
    {
        for (int j = 1000000 + intervals[i].Item1; j < 1000000 + intervals[i].Item2; j++) intervalExists[j] = true;
    }

    int intervalCounter = 0;

    for (int i = 0; i < 2000000; i++) if (intervalExists[i]) intervalCounter++;

    return intervalCounter;
}

}
}
*/
/* 
public static int DescendingOrder(int num)
        {
            char[] a = num.ToString().ToCharArray();
            Array.Sort(a);
            Array.Reverse(a);
            return Int32.Parse(new String(a));
        }
    }
}
*/
/*
        public int IsSolved(int[,] board)
        {
            bool zeroExists = false;

            for (int i=0; i<3; i++)
            {
                if (((board[i, 0] == board[i, 1]) && (board[i, 0] == board[i, 2])) && (board[i, 0] != 0)) return board[i, 0];
                if (((board[0, i] == board[1, i]) && (board[0, i] == board[2, i])) && (board[0, i] != 0)) return board[0, i];

                for (int j = 0; j < 3; j++) if (board[i, j] == 0) zeroExists = true;
            }
            if ((board[0, 0] == board[1, 1]) && (board[0, 0] == board[2, 2]) && (board[0, 0] != 0)) return board[0, 0];
            if ((board[2, 0] == board[1, 1]) && (board[2, 0] == board[0, 2]) && (board[2, 0] != 0)) return board[2, 0];

            if (zeroExists) return -1;
            else return 0;
        }
    }
}
*/

/*
        public static int[] EliminateZeros(int[] array)
        {
            int i = array.Length - 1;

            while ((i >= 0) && (array[i] > 0)) i--;

            if (i == -1) return array;
            else if (i == 0) return (new int[]{0});
            else
            {
                int[] arr2 = new int[i];
                for (int j = 0; j < i-1; j++) arr2[j] = array[j];
                arr2[i - 1] = 1;
                return EliminateZeros(arr2);
            }
        }

        public static int[] EliminateOnes(int[] array)
        {
            int i = Array.IndexOf(array, 1);
            if ((i == -1) || (array.Length<2)) return array;

            else
            {
                int[] arr2 = new int[i];
                for (int j = 0; j < i; j++) arr2[j] = array[j];
                return arr2;
            }
        }
        public static int ComputeCycleLength(int a, int n)
        {
            int tempLength = 1;
            int tempNumber = a;

            while (((tempNumber*a) % n) != a)
            {
                tempNumber *= a;
                tempLength++;
                if ((tempNumber == 0) && (a != 0)) return 0;
            }
            return tempLength;
        }

        public static int ComputeRemainderFromCycle(int index, int a, int n)
        {
            int k;
            if (index == 0) k = ComputeCycleLength(a, n);
            else k = index;

            int tempLength = 0;
            int tempNumber = a;

            while (++tempLength < k)
            {
                tempNumber *= a;
                tempNumber %= n;
            }
            return tempNumber;
        }

        public static int ScanMultiply(int[] array, int index, int n)
        {
            int tempResult = array[index] % n;

            int i = index + 1;

            while ((i < array.Length) && (array[i] != 1))
            {
               int counter = 1;
                while ((++counter <= array[i]) && (tempResult < n))
                    tempResult *= (array[index] % n);

                if (tempResult >= n) return 0;
                i++;
            }
            Console.WriteLine("tempResult =" + tempResult);
            return tempResult;
        }

        public static int Compute(int[] array, int i, int n)
        {
            if (i == array.Length - 1) return (array[i] % n);

            else if (ComputeCycleLength(array[i]%n,n) == 0)
            {
                return ScanMultiply(array, i, n);
            }
            else return ComputeRemainderFromCycle(Compute(array,i+1,ComputeCycleLength(array[i] % n,n)),array[i]%n,n);
        }

        public static int LastDigit(int[] array)
        {
//            if (array.Length == 0) return 1;
//            if (array.Length == 1) return array[0] % 10;

            array = EliminateZeros(array);
            array = EliminateOnes(array);

            if (array.Length == 0) return 1;
            if (array.Length == 1) return array[0] % 10;

            return Compute(array, 0, 10);
        }

    }
}
*/

/*
public static int[] MoveZeroes(int[] arr)
{
    int[] b = new int[arr.Length];

    int counter = 0;

    for (int i=0; i<arr.Length; i++)
    {
        if (arr[i] != 0) b[counter++] = arr[i];
    }
    while (counter < arr.Length) b[counter++] = 0;
    return b;
}
}
}
*/
/*
public static int[,] Mul(int[,] A, int[,] B)
{
    int n = (int)Math.Sqrt(A.Length);

    int[,] C = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            C[i, j] = 0;
            for (int k = 0; k < n; k++)
            {
                C[i, j] += (A[i, k] * B[k, j]);
            }
        }
    }
    return C;
}



public static int TranslateNumber(string s)
{
    switch (s)
    {
       case "one": return 1;
       case "two": return 2;
       case "three": return 3;
       case "four": return 4;
       case "five": return 5;
       case "six": return 6;
       case "seven": return 7;
       case "eight": return 8;
       case "nine": return 9;
       case "ten": return 10;
       case "eleven": return 11;
       case "twelve": return 12;
       case "thirteen": return 13;
       case "fourteen": return 14;
       case "fifteen": return 15;
       case "sixteen": return 16;
       case "seventeen": return 17;
       case "eighteen": return 18;
       case "nineteen": return 19;
       case "twenty": return 20;
       case "thirty": return 30;
       case "forty": return 40;
       case "fifty": return 50;
       case "sixty": return 60;
       case "seventy": return 70;
       case "eighty": return 80;
       case "ninety": return 90;
       default:
       break;
    }

    if (s.IndexOf('-') != -1) return (TranslateNumber(s.Substring(0, s.IndexOf('-'))) + TranslateNumber(s.Substring(s.IndexOf('-') + 1, s.Length - s.IndexOf('-') - 1)) );

    return 0;
}

public static int ParseInt(string s)
{
    if ((s == "million") || (s == "one million")) return 1000000;
    if (s == "zero") return 0;

    s = Regex.Replace(s, " and", "");

    string[] words = s.Split(' ');

    int tempResult = 0;

    int a = Array.IndexOf(words,"thousand");
    int b = Array.IndexOf(words,"hundred");


    if (a != -1)
    {
        // compute number of thousands
        if ((b != -1) && (b<a))
        {
            // compute number of 100000s
            if (b == 0) tempResult += 100000;
            else tempResult += (TranslateNumber(words[b-1]) * 100000);
        }
        tempResult += (TranslateNumber(words[a - 1]) * 1000);

        s = (Regex.Replace(s,"^[ ]?([ a-z-])*thousand", "")).Trim();

        words = s.Split(' ');
    }

    b = Array.IndexOf(words, "hundred");
    if (b != -1)
    {
        if (b == 0) tempResult += 100;
        if (b == 1) tempResult += (TranslateNumber(words[0])*100);

        s = (Regex.Replace(s, "^([ a-z-])*hundred", "")).Trim();
        words = s.Split(' ');
     }
    if (s != "") tempResult += TranslateNumber(words[0]);

    return tempResult;
}

}
}
*/
/*
public static long[] Multiply(long[] c, int a, int b, int i)
{
    c[i] = c[i - 1] * a;
    for (int j = i - 1; j > 0; j--)
        c[j] = c[j - 1] * a + c[j] * b;
    c[0] = c[0] * b;

    return c;
}

public static string Expand(string expr)
{
    int a = 1;
    while (!Char.IsLetter(expr[a])) a++;

    int pos = a;

    int coeff1, coeff2;

    if (a == 1) coeff1 = 1;
    else if ((a == 2) && (expr[a-1] == '-')) coeff1 = -1;
    else coeff1 = int.Parse(expr.Substring(1, a - 1));

    char letter = expr[a++];

    while ((expr[++a]) != ')');


    if (expr[pos + 1] == '+') coeff2 = int.Parse(expr.Substring(pos+2,a-pos-2));
    else coeff2 = int.Parse(expr.Substring(pos + 1, a - pos - 1)); // negative number

    int totalPower = int.Parse(expr.Substring(expr.IndexOf('^')+1, expr.Length - expr.IndexOf('^') - 1));
    if (totalPower == 0) return "1";

    long[] currentCoeff = new long[totalPower + 1];
    for (int i = 2; i < totalPower + 1; i++) currentCoeff[i] = 0;
    currentCoeff[1] = coeff1;
    currentCoeff[0] = coeff2;

    for (int i = 2; i <= totalPower; i++) currentCoeff = Multiply(currentCoeff, coeff1, coeff2, i);

    string result = "";

    for (int i = totalPower; i>=0; i--)
    {
       if (currentCoeff[i] > 0)
        {
            if (i < totalPower) result = result + "+";

            if ((i==0) || (currentCoeff[i] != 1)) result = result + currentCoeff[i].ToString();

            if (i > 0) result = result + letter.ToString();
            if (i > 1) result = result + "^" + i.ToString();
        }
        if (currentCoeff[i] < 0)
        {
            if ((i == totalPower) && (currentCoeff[i] == -1)) result = result + "-";
            if ((i==0) || (currentCoeff[i] != -1)) result = result + currentCoeff[i].ToString();
            if (i > 0) result = result + letter.ToString();
            if (i > 1) result = result + "^" + i.ToString();
        }
    }
    return result;
}
}
}
*/
/*
public static string SubsetsParity(int n, int k)
{
    if (k > n) return "EVEN";
    else if (n + k <= 2) return "ODD";
    else
    {
        int a = 2;
        while (n >= a) a *= 2;

        if ((n - k >= a / 2) || (k >= a / 2)) return SubsetsParity(n % (a / 2), k % (a / 2));
        else return "EVEN";
    }
}
}
}
*/

/*
public static string HandleDoubleMinuses(string s)
{
    int i = -1;

    while (++i < s.Length - 1)
    {
        if ((s[i] == '-') && (s[i + 1] == '-'))
        {
            if (i == 0)
            {
                s = s.Substring(2, s.Length - 2);
                i--;
            }

            else if (((((s[i - 1] == '-') || (s[i - 1] == '+')) || (s[i - 1] == '*'))
                      || (s[i - 1] == '/')) || (s[i - 1] == '('))
            {
                if (i < s.Length - 2)
                {
                    s = s.Substring(0, i) + s.Substring(i + 2, s.Length - i - 2);
                    i--;
                }
                else
                {
                    s = s.Substring(0, s.Length - 2);
                    i--;
                }
            }
            else // s[i-1] is a digit or ')'
            {
                s = s.Substring(0, i) + "+" + s.Substring(i + 2, s.Length - i - 2);
                i--;
            }
            Console.WriteLine("HandleDoubleMinuses: new string=" + s);
            Console.ReadLine();
        }
    }
    return s;
}

public static bool IsDigitOrComma(char c)
{
    if (c == ',') return true;
    int a = (int)c;

    if ((a >= 48) && (a <= 57)) return true;
    return false;
}

public static string ScanLeftNumber(string s, int pos)
{
    Console.WriteLine("ScanLeftNumber: string=" + s + ",pos=" + pos);
    Console.ReadLine();

    int k = pos - 1;

    while ((k >= 0) && (IsDigitOrComma(s[k])))
    {
        Console.WriteLine("ScanLeftNumber: k=" + k);
        k--;
    }

    if ((k >= 0) && (s[k] == '-')) return s.Substring(k, pos - k);
    else return s.Substring(k + 1, pos - k - 1);
}

public static string ScanRightNumber(string s, int pos)
{
    Console.WriteLine("ScanRightNumber: string=" + s + ",pos=" + pos);
    Console.ReadLine();

    int k = pos + 1;

    while (((k < s.Length) && (IsDigitOrComma(s[k])))
        || ((k == pos + 1) && (s[k] == '-')))
    {
        Console.WriteLine("ScanRightNumber: k=" + k);
        k++;
    }
    return s.Substring(pos + 1, k - pos - 1);
}

public static string ComputeSubexpression(string s)
{
    Console.WriteLine("ComputeSubexpression: string=" + s);
    Console.ReadLine();
    // Compute value of an expression without parentheses (only numbers and '+','-','*','/' symbols)

    s = HandleDoubleMinuses(s);

    Console.WriteLine("ComputeSubexpression after removing double minuses: string=" + s);
    Console.ReadLine();

    while (Math.Max(s.IndexOf('*'), s.IndexOf('/')) != -1)
    {
        int pos = Math.Min(s.IndexOf('*'), s.IndexOf('/'));
        if (pos == -1) pos = Math.Max(s.IndexOf('*'), s.IndexOf('/'));

        Console.WriteLine("* / pos=" + pos);
        Console.ReadLine();

        double tempResult;
        string leftString = ScanLeftNumber(s, pos);
        string rightString = ScanRightNumber(s, pos);
        double leftNumber = double.Parse(leftString);
        double rightNumber = double.Parse(rightString);

        Console.WriteLine("* / leftString=" + leftString + ",rightString=" + rightString + ",leftNumber=" + leftNumber + ",rightNumber=" + rightNumber);
        Console.ReadLine();

        string[] partsOfExpression = new string[3];

        if (s[pos] == '*') tempResult = leftNumber * rightNumber;
        //tempResult = Math.Round((leftNumber * rightNumber) * 1000000.0d) / 1000000.0d;
        else if (s[pos] == '/') tempResult = leftNumber / rightNumber;
        //tempResult = Math.Round((leftNumber / rightNumber) * 1000000.0d) / 1000000.0d;
        else return ("ERROR");

        if (leftString.Length < pos)
            partsOfExpression[0] = s.Substring(0, pos - leftString.Length);
        else partsOfExpression[0] = "";

        partsOfExpression[1] = tempResult.ToString();

        if (rightString.Length < s.Length - pos - 2)
            partsOfExpression[2] = s.Substring(pos + rightString.Length + 1, s.Length - pos - rightString.Length - 1);
        else partsOfExpression[2] = "";

        Console.WriteLine("* / partsOfExpression[0]=" + partsOfExpression[0] + " partsOfExpression[1]=" + partsOfExpression[1] + " partsOfExpression[2]=" + partsOfExpression[2]);
        Console.ReadLine();

        s = String.Join("", partsOfExpression);
    }
    // There are no more '*' and '/' characters, just '+','-' and numbers

    while ((s.IndexOf('+') != -1) || (s.Length > 1 && s.Substring(1).IndexOf('-') != -1))
    {
        int pos = Math.Min(s.Substring(1).IndexOf('+'), s.Substring(1).IndexOf('-')) + 1;
        if (pos == 0) pos = Math.Max(s.Substring(1).IndexOf('+'), s.Substring(1).IndexOf('-')) + 1;

        Console.WriteLine("+- pos=" + pos);
        Console.ReadLine();

        double tempResult;
        string leftString = ScanLeftNumber(s, pos);
        string rightString = ScanRightNumber(s, pos);
        double leftNumber = double.Parse(leftString);
        double rightNumber = double.Parse(rightString);

        Console.WriteLine("+- leftString=" + leftString + ",rightString=" + rightString + ",leftNumber=" + leftNumber + ",rightNumber=" + rightNumber);
        Console.ReadLine();

        string[] partsOfExpression = new string[3];

        if (s[pos] == '+') tempResult = leftNumber + rightNumber;
        //tempResult = Math.Round((leftNumber + rightNumber) * 1000000.0d) / 1000000.0d;
        else if (s[pos] == '-') tempResult = leftNumber - rightNumber;
        // tempResult = Math.Round((leftNumber - rightNumber) * 1000000.0d) / 1000000.0d;
        else return ("ERROR");

        if (leftString.Length < pos)
            partsOfExpression[0] = s.Substring(0, pos - leftString.Length);
        else partsOfExpression[0] = "";

        partsOfExpression[1] = tempResult.ToString();

        if (rightString.Length < s.Length - pos - 2)
            partsOfExpression[2] = s.Substring(pos + rightString.Length + 1, s.Length - pos - rightString.Length - 1);
        else partsOfExpression[2] = "";

        Console.WriteLine("+- partsOfExpression[0]=" + partsOfExpression[0] + " partsOfExpression[1]=" + partsOfExpression[1] + " partsOfExpression[2]=" + partsOfExpression[2]);
        Console.ReadLine();

        s = String.Join("", partsOfExpression);
    }
    return s;
}


public static double Evaluate(string expression)
{
    expression = expression.Replace('.', ',');
    expression = Regex.Replace(expression, " ", "");

    expression = HandleDoubleMinuses(expression);

    string[] partsOfExpression = new string[3];

    while (expression.IndexOf(')') != -1)
    {
        int k = expression.IndexOf(')') - 1;

        Console.WriteLine("Evaluate: expression=" + expression, ",k=" + k);
        Console.ReadLine();

        while (expression[k] != '(') k--;

        if (k > 0)
            partsOfExpression[0] = expression.Substring(0, k);
        else partsOfExpression[0] = "";

        partsOfExpression[1] = ComputeSubexpression(expression.Substring(k + 1, expression.IndexOf(')') - k - 1));

        if (expression.IndexOf(')') < expression.Length - 1)
            partsOfExpression[2] = expression.Substring(expression.IndexOf(')') + 1, expression.Length - expression.IndexOf(')') - 1);
        else partsOfExpression[2] = "";

        Console.WriteLine("Evaluate: partsOfExpression[0]=" + partsOfExpression[0] + " partsOfExpression[1]=" + partsOfExpression[1] + " partsOfExpression[2]=" + partsOfExpression[2]);
        Console.ReadLine();

        expression = String.Join("", partsOfExpression);
    }
    partsOfExpression[1] = ComputeSubexpression(expression);

    return Double.Parse(partsOfExpression[1]);
}

}
}
*/
/*
public static string ComputeCodeToAdd(int counter, int interval, char c)
{
    if (c == '1')
    {
        if (counter == interval) return ".";
        if (counter == 3 * interval) return "-";
    }
    if (c == '0')
    {
        if (counter == interval) return "";
        if (counter == 3 * interval) return " ";
        if (counter == 7 * interval) return " * ";
    }

    return ""; // for correct input code, this place should never be reached
}

public static string DecodeBits(string bits)
{
    string resultCode = "";
    int intervalLength = 0;

    int a = bits.IndexOf('1');
    if (a == -1) return "";

    int counter = 1;
    while ((a + counter < bits.Length) && (bits[a + counter] == '1')) counter++;
    intervalLength = counter;

    int b = a + counter;
    bool intervalOfDifferentLengthFound = false;
    counter = intervalLength;
    int k = 0;

    while (!intervalOfDifferentLengthFound && ((b+k) < bits.Length))
    {
        if (bits[b + k] == '1') counter++;
        else
        {
            if ((bits[b+k-1] == '1') && (counter != intervalLength))
                intervalOfDifferentLengthFound = true;
            else counter = 0;
        }
        k++;
    }

    if ((intervalOfDifferentLengthFound) && (counter < intervalLength)) intervalLength = counter;

    if (!intervalOfDifferentLengthFound)
    {
        b = bits.IndexOf('1');
        counter = 0;
        k = 0;

        while (!intervalOfDifferentLengthFound && ((b + k) < bits.Length))
        {
            if (bits[b + k] == '0') counter++;
            else
            {
                if ((k>0) && (((((bits[b + k - 1]) == '0')
                    && (counter != intervalLength))
                    && (counter != 3 * intervalLength))
                    && (counter != 7 * intervalLength)))
                {
                    intervalLength /= 3;
                    intervalOfDifferentLengthFound = true;
                }
                else
                    counter = 0;
            }
            k++;
        }
    }

    counter = 0;
    char lastChar = bits[0];

    for (int i=0; i<bits.Length; i++)
    {
        if (bits[i] == lastChar) counter++;
        else
        {
            resultCode = String.Concat(resultCode,ComputeCodeToAdd(counter, intervalLength, lastChar));
            lastChar = bits[i];
            counter = 1;
        }
    }
    resultCode = String.Concat(resultCode, ComputeCodeToAdd(counter, intervalLength, lastChar));

    return resultCode;
}


public static string DecodeLetter(string code)
{
    switch (code)
    {
        case "*": return " ";
        case ".-": return "A";
        case "-...": return "B";
        case "-.-.": return "C";
        case "-..": return "D";
        case ".": return "E";
        case "..-.": return "F";
        case "--.": return "G";
        case "....": return "H";
        case "..": return "I";
        case ".---": return "J";
        case "-.-": return "K";
        case ".-..": return "L";
        case "--": return "M";
        case "-.": return "N";
        case "---": return "O";
        case ".--.": return "P";
        case "--.-": return "Q";
        case ".-.": return "R";
        case "...": return "S";
        case "-": return "T";
        case "..-": return "U";
        case "...-": return "V";
        case ".--": return "W";
        case "-..-": return "X";
        case "-.--": return "Y";
        case "--..": return "Z";
        case "...---...": return "SOS";
        case ".----": return "1";
        case "..---": return "2";
        case "...--": return "3";
        case "....-": return "4";
        case ".....": return "5";
        case "-.....": return "6";
        case "--...": return "7";
        case "---..": return "8";
        case "----.": return "9";
        case "-----": return "0";
        case ".-.-.-": return ".";
        case "--..--": return ",";
        case "..--..": return "?";
        case "-.-.--": return "!";
        case ".----.": return "'";
        case ".-..-.": return "\"";
        case "-.--.": return "(";
        case "-.--.-": return ")";
        case ".-...": return "&";
        case "---...": return ":";
        case "-.-.-.": return ";";
        case "-..-.": return "/";
        case "..--.-": return "_";
        case "-...-": return "=";
        case ".-.-.": return "+";
        case "-....-": return "-";
        case "...-..-": return "$";
        case ".--.-.": return "@";

        default:
            break;
    }
    return "";
}

public static string DecodeMorse(string morseCode)
{
    string[] codeWords = Regex.Replace(morseCode,"   "," * ").Split(' ');
    string result = "";

    for (int i=0; i<codeWords.Length; i++)
    {
        result = String.Concat(result,DecodeLetter(codeWords[i]));
    }
    result = result.TrimEnd();
    result = result.TrimStart();
    return result;
}
}
}
*/
/*
public static bool[,] IsWall;
public static bool[,] AlreadyVisited;
public static int n;
public static void Step(int x, int y)
{
    AlreadyVisited[x,y] = true;

    if (((x > 0) && (!IsWall[x - 1, y])) && (!AlreadyVisited[x - 1, y]))
        Step(x - 1, y);
    if (((x < n-1) && (!IsWall[x + 1, y])) && (!AlreadyVisited[x + 1, y]))
        Step(x + 1, y);
    if (((y > 0) && (!IsWall[x, y - 1])) && (!AlreadyVisited[x, y - 1]))
        Step(x, y - 1);
    if (((y < n-1) && (!IsWall[x, y + 1])) && (!AlreadyVisited[x, y + 1]))
        Step(x, y + 1);
}


public static bool PathFinder(string maze)
{
    string s = maze.Replace("\n", string.Empty);
    n = (int)Math.Sqrt(s.Length);

    IsWall = new bool[n, n];
    AlreadyVisited = new bool[n, n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            AlreadyVisited[i, j] = false;
            if (s[i * n + j] == 'W') IsWall[i, j] = true;
            else IsWall[i, j] = false;
        }
    }
    Step(0, 0);

    return AlreadyVisited[n-1,n-1];
}
}
}
*/
/*
public static int GetVowelCount(string str)
{
    return (str.Length) - Regex.Replace(str, "[aeiou]", "").Length;
}
}
}
*/
/*
public static long NextBiggerNumber(long n)
{
    String str = GetNumbers(n);
    for (long i = n + 1; i <= long.Parse(str); i++)
    {
        Console.WriteLine("i=" + i);

        if (GetNumbers(n) == GetNumbers(i))
        {
            return i;
        }
    }
    return -1;
}
public static string GetNumbers(long number)
{
    return string.Join("", number.ToString().ToCharArray().OrderByDescending(x => x));
}

}
}
*/
/*
       public static long ExchangeAndSort(char[] arr, int index)
       {
           int currentIndex = index+1;

           for (int i=index+1; i<arr.Length; i++)
           {
               if ((arr[i] > arr[index]) && (arr[i] < arr[currentIndex]))
                   currentIndex = i;
           }
           char temp = arr[index];
           arr[index] = arr[currentIndex];
           arr[currentIndex] = temp;

           char[] arr2 = new char[arr.Length - index - 1];
           for (int i = 0; i < arr2.Length; i++)
               arr2[i] = arr[index+1+i];

           Array.Sort(arr2);

           for (int i = 0; i < arr2.Length; i++)
               arr[index + 1 + i] = arr2[i];

           long l = long.Parse(String.Join("", arr));
           return l;
       }

       public static long NextBiggerNumber(long n)
       {
           string s = n.ToString();
           char[] digitChars = new char[s.Length];
           digitChars = s.ToCharArray();

           int i = digitChars.Length - 1;

           while ((i > 0) && (digitChars[i - 1] >= digitChars[i])) i--;
           if (i == 0) return -1;

           return ExchangeAndSort(digitChars,i-1);
       }
   }
}
*/
/*
        public static int numberOfCombinationsFound;
        public static int[] sortedCoinValues;

        public static void SearchCombinations(int expectedValue, int currentValue, int index)
        {
            Console.WriteLine("SearchCombinations(" + expectedValue + "," + currentValue + "," + index + ")");

            if (expectedValue == currentValue) numberOfCombinationsFound++;

            else
            {
                int counter = index;
                while ((counter >= 0) && (currentValue + sortedCoinValues[counter] > expectedValue))
                    counter--;

                for (int i = counter; i >= 0; i--)
                    SearchCombinations(expectedValue, currentValue + sortedCoinValues[i], i);
            }
        }

        public static int CountCombinations(int money, int[] coins)
        {
            sortedCoinValues = new int[coins.Length];
            Array.Copy(coins,sortedCoinValues,coins.Length);
            Array.Sort(sortedCoinValues);

            numberOfCombinationsFound = 0;

            SearchCombinations(money, 0, sortedCoinValues.Length-1);

            return numberOfCombinationsFound;
        }

    }
}
*/
/*
public static int n;
public static int[][] board;

public Training (int[][] startData)
{
    int l = startData[0].Length;
    int i = 1;

    while (i<l)
    {
        if (startData[i++].Length != l) l = -1;
    }
    if (l != -1)
    {
        n = (int)Math.Sqrt(l);
        board = startData;
    }
    else n = -1;
}

public static bool SingleValidation(int[] a)
{
    int[] correctArray = new int[n * n];
    for (int i = 0; i < n * n; i++) correctArray[i] = i + 1;

    int[] testArray = new int[n*n];

    Array.Copy(a, testArray, n*n);
    Array.Sort(testArray);

    return Enumerable.SequenceEqual(testArray, correctArray);
}

public bool IsValid()
{
    if (n == -1) return false;

    int[] arrayToValidate1 = new int[n*n];
    int[] arrayToValidate2 = new int[n*n];
    int[] arrayToValidate3 = new int[n*n];

    for (int i = 0; i < n*n; i++)
    {
        for (int j = 0; j < n*n; j++)
        {
            arrayToValidate1[j] = board[i][j];
            arrayToValidate2[j] = board[j][i];
            arrayToValidate3[j] = board[n*(i/n)+(j/n)][n*(i%n)+(j%n)];
        }
        if (SingleValidation(arrayToValidate1) == false) return false;
        if (SingleValidation(arrayToValidate2) == false) return false;
        if (SingleValidation(arrayToValidate3) == false) return false;
    }
    return true;
}

}
}
*/
/*
public static Bagel Bagel
{
    get
    {
        Bagel bagel = new Bagel();

        PropertyInfo bag = typeof(Bagel).GetProperty("Value");
        bag.SetValue(bagel, 4);

        return bagel;
    }
}
}
}
*/
/*
public static int DigitalRoot(long n)
{
    long newRoot = 0;
    long mul = 1;

    while (n/mul > 0)
    {
        newRoot += ((n / mul) % 10);
        mul *= 10;
    }
    if (newRoot < 10) return (int)newRoot;
    else return DigitalRoot(newRoot);
}
}
}
*/
/*
public static string Add(string a, string b)
{
    return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString();
}
}
}
*/
/*
public static List<string> resultList;

public static void NextParenthesis(string partialString, int n, int a, int b)
{
    if (a + b == 2 * n)
        resultList.Add(partialString);
    else
    {
        if (a > b)
            NextParenthesis(String.Concat(partialString, ")"), n, a, b + 1);
        if (a < n)
            NextParenthesis(String.Concat(partialString, "("), n, a + 1, b);
    }
}

public static List<string> BalancedParens(int n)
{
    resultList = new List<string>();
    resultList.Clear();

    if (n==0)
        resultList.Add("");
    else
        NextParenthesis("(",n,1,0);

    return resultList;
}
}
}
*/
/*
public static string Extract(int[] args)
{
    string result = "";
    int counter = 1;
    int firstInSequence = args[0];

    if (args.Length == 1) return args[0].ToString();

    for (int i=1; i<=args.Length; i++)
    {
        if ((i<args.Length) && (args[i] == firstInSequence + counter)) counter++;
        else
        {
            if (result.Length > 0) result = String.Concat(result, ",");

            if (counter>=3)
                result = String.Concat(result, (firstInSequence.ToString() + "-" + (firstInSequence + counter - 1).ToString()));
            else if (counter==2)
                result = String.Concat(result, (firstInSequence.ToString() + ",") + (firstInSequence + 1).ToString());
            else
                result = String.Concat(result, firstInSequence.ToString());

            counter = 1;
            if (i<args.Length) firstInSequence = args[i];
        }
    }
    return result;
}
}
}
*/
/*
public static bool[] IsPrime;

public static void sieve()
{
    IsPrime = new bool[16000000];
    for (int i = 0; i < 16000000; i++) IsPrime[i] = true;

    for (int i = 4; i < 16000000; i += 2) IsPrime[i] = false;

    int j = 3;

    while (j <= Math.Sqrt(16000000))
    {
        if (IsPrime[j])
          for (int k = j*2; k < 16000000; k += j) IsPrime[k] = false;
        j += 2;
    }
}

public static IEnumerable<int> Stream()
{

    List<int> list = new List<int>();
    list.Clear();
    list.Add(2);
    list.Add(3);
    list.Add(5);
    list.Add(7);

    sieve();

    int i = 1;

    while (list.Count < 1000000)
    {
        if (IsPrime[10 * i + 1]) list.Add(10 * i + 1);
        if (IsPrime[10 * i + 3]) list.Add(10 * i + 3);
        if (IsPrime[10 * i + 7]) list.Add(10 * i + 7);
        if (IsPrime[10 * i + 9]) list.Add(10 * i + 9);
        i++;
    }
    return list;
}
}
}
*/
/*
public static bool IsPrime(int n, int k)
{ // Miller-Rabin primality test
    if ((n < 2) || (n % 2 == 0)) return (n == 2);

    int s = n - 1;
    while (s % 2 == 0) s >>= 1;

    Random r = new Random();
    for (int i = 0; i < k; i++)
    {
        int a = r.Next(n - 1) + 1;
        int temp = s;
        long mod = 1;
        for (int j = 0; j < temp; ++j) mod = (mod * a) % n;
        while (temp != n - 1 && mod != 1 && mod != n - 1)
        {
            mod = (mod * mod) % n;
            temp *= 2;
        }

        if (mod != n - 1 && temp % 2 == 0) return false;
    }
    return true;
}
public static IEnumerable<int> Stream()
{
    List<int> list = new List<int>();
    list.Add(2);
    list.Add(3);
    list.Add(5);
    list.Add(7);

    int i = 1;

    while (i <= 214748363)
    {
        if (Training.IsPrime(10 * i + 1, 2)) list.Add(i);
        if (Training.IsPrime(10 * i + 3, 2)) list.Add(i);
        if (Training.IsPrime(10 * i + 7, 2)) list.Add(i);
        if (Training.IsPrime(10 * i + 9, 2)) list.Add(i);
        i++;
    }
    return list;
}
*/

/*
public static int counter;
public static bool startupAlreadyMade = false;

public static int[][] Minor(int[][] A, int n, int x)
{
    int[][] M = new int[n - 1][];
    for (int i = 0; i < n - 1; i++) M[i] = new int[n - 1];

    for (int i=0; i<n-1; i++)
    {
        for (int j=0; j<n-1; j++)
        {
            if (j >= x) M[i][j] = A[i + 1][j + 1];
            else M[i][j] = A[i + 1][j];
        }
    }
   return M;
}
public static int Determinant(int[][] matrix)
{
    if (startupAlreadyMade == false)
    {
        counter = 0;
        startupAlreadyMade = true;
    }

    if (matrix[0].Length == 1) return matrix[0][0];
    else if (matrix[0].Length == 2) return (matrix[0][0] * matrix[1][1] - matrix[1][0] * matrix[0][1]);

    else
    {
        for (int i=0; i<matrix[0].Length; i++)
        {
            if (i % 2 == 0)
                counter += (matrix[0][i] * Determinant(Minor(matrix, matrix[0].Length, i)));
            else
                counter -= (matrix[0][i] * Determinant(Minor(matrix, matrix[0].Length, i)));
        }
    }
    int result = counter;
    counter = 0;
    startupAlreadyMade = false;
    return result;
}

}
}
*/
/*
public static int RomanValue(char c)
{
    switch (c)
    {
        case 'I':
            return 1;
        case 'V':
            return 5;
        case 'X':
            return 10;
        case 'L':
            return 50;
        case 'C':
            return 100;
        case 'D':
            return 500;
        case 'M':
            return 1000;
        default:
            return -999999;
    }
}

public static string ToRoman(int n)
{
    string result = "";
    int remainingNumber = n;

    int[] valueArray = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    string[] romanArray = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

    int position = 0;

    while (remainingNumber > 0)
    {
        if (remainingNumber >= valueArray[position])
        {
            result = String.Concat(result, romanArray[position]);
            remainingNumber -= valueArray[position];
            position = 0;
        }
        else position++;
    }

    return result;
}

public static int FromRoman(string romanNumeral)
{
    int counter = 0;
    int position = 0;

    while (position < romanNumeral.Length)
    {
        if (position == romanNumeral.Length - 1)
        {
            counter += RomanValue(romanNumeral[position]);
            return counter;
        }
        else
        {
            if (RomanValue(romanNumeral[position]) < RomanValue(romanNumeral[position+1]))
            {
                counter += (RomanValue(romanNumeral[position + 1]) - RomanValue(romanNumeral[position]));
                position += 2;
            }
            else
            {
                counter += RomanValue(romanNumeral[position]);
                position++;
            }
        }
    }
    return counter;
}
}
}
*/
/*
public static string sumStrings(string a, string b)
{
    string c = "";
    string d = "";
    int tempResult = 0;
    int aux = 0;

    if (a.Length>b.Length)
    {
        string[] zeros = new string[a.Length - b.Length];
        for (int i = 0; i < a.Length - b.Length; i++) zeros[i] = "0";
        b = string.Concat(string.Join("", zeros),b);
    }
    if (b.Length > a.Length)
    {
        string[] zeros = new string[b.Length - a.Length];
        for (int i = 0; i < b.Length - a.Length; i++) zeros[i] = "0";
        a = string.Concat(string.Join("",zeros),a);
    }

    for (int i=Math.Max(a.Length,b.Length); i>=1; i--)
    {
        tempResult = ((((int)a[i-1]) - 48)) + (((int)b[i-1]) - 48) + aux;
        if (tempResult > 9) aux = 1;
        else aux = 0;

        d = ((char)((tempResult % 10) + 48)).ToString();
        c = String.Concat(d, c);
    }
    if (aux == 1) c = String.Concat("1", c);
    return c.TrimStart(new char[] { '0' });
}
}
}
*/
/*
        public static List<int> TreeByLevels(Node node)
        {
            List<int> result = new List<int>();
            List<Node> nodeQueue = new List<Node>();

            if (node != null) nodeQueue.Add(node);

            Node currentNode;

            while (nodeQueue.Any())
            {
                currentNode = nodeQueue[0];
                result.Add(currentNode.Value);
                if (currentNode.Left != null) nodeQueue.Add(currentNode.Left);
                if (currentNode.Right != null) nodeQueue.Add(currentNode.Right);
                nodeQueue.RemoveAt(0);
            }
            return result;
        }
    }
}
*/
/*
        public static int moveLength;
        public static int xPos;
        public static int yPos;
        public static int[,] t;

        public static void Move(int[,] array, char direction)
        {
            switch (direction)
            {
                case 'R':
                    for (int i = 0; i < moveLength; i++)
                        t[yPos, ++xPos] = 1;
                    break;
                case 'L':
                    for (int i = 0; i < moveLength; i++)
                        t[yPos, --xPos] = 1;
                    break;
                case 'U':
                    for (int i = 0; i < moveLength; i++)
                        t[--yPos, xPos] = 1;
                    break;
                case 'D':
                    for (int i = 0; i < moveLength; i++)
                        t[++yPos, xPos] = 1;
                    break;
                default:
                    break;
            }
        }

        public static int[,] Spiralize(int n)
        {
            t = new int[n,n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    t[i, j] = 0;


            t[0, 0] = 1;

            moveLength = n - 1;
            xPos = 0;
            yPos = 0;

            while (moveLength > 0)
            {
                if (moveLength == n - 1)
                {
                    Move(t, 'R'); Move(t, 'D'); Move(t, 'L');
                }
                else if (moveLength == 1)
                {
                    if (n % 4 == 0) Move(t, 'U');
                    else Move(t, 'D');
                }
                else if (((n - moveLength) % 4) == 3)
                {
                    Move(t, 'U'); Move(t, 'R');
                }
                else
                {
                    Move(t, 'D'); Move(t, 'L');
                }
                moveLength -= 2;
            }
            return t;
        }
    }
}
*/
/*
public static int SquareDigits(int n)
{
    string inputString = n.ToString();
    string outputString = "";

    int[] t = { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };

    for (int i = 0; i < inputString.Length; i++)
        outputString = String.Concat(outputString, t[(int)(inputString[i] - 48)].ToString());
    return int.Parse(outputString);
}
}
}
*/
/*
public static int[] auxBoard;
public static int[] numberOfValidShips;

public static int CheckShipSurroundings(int x, int y, int size, bool isHorizontal)
{
    if (isHorizontal)
    {
        for (int i = 0; i < size; i++)
            auxBoard[y * 10 + x + i] = 2;

        if ((x > 0) && (auxBoard[y * 10 + x - 1] != 0)) return -1;
        if ((x + size < 10) && (auxBoard[y * 10 + x + size] != 0)) return -1;

        if (y > 0)
        {
            for (int i = x - 1; i <= x + size; i++)
                if (((i >= 0) && (i < 10)) && (auxBoard[(y - 1) * 10 + i] != 0)) return -1;
        }
        if (y < 10)
        {
            for (int i = x - 1; i <= x + size; i++)
                if (((i >= 0) && (i < 10)) && (auxBoard[(y + 1) * 10 + i] != 0)) return -1;
        }
    }
    else
    {
        for (int i = 0; i < size; i++)
            auxBoard[(y + i) * 10 + x] = 2;

        if ((y > 0) && (auxBoard[(y - 1) * 10 + x] != 0)) return -1;
        if ((y + size < 10) && (auxBoard[(y + size) * 10 + x] != 0)) return -1;

        if (x > 0)
        {
            for (int i = y - 1; i <= y + size; i++)
                if (((i >= 0) && (i < 10)) && (auxBoard[i * 10 + x - 1] != 0)) return -1;
        }
        if (x < 10)
        {
            for (int i = y - 1; i <= y + size; i++)
                if (((i >= 0) && (i < 10)) && (auxBoard[i * 10 + x + 1] != 0)) return -1;
        }
    }
    numberOfValidShips[4-size]++;
    return size;
}

public static int ValidateShip(int x, int y)
{
    int currentShipSize = 1;
    int i = 1;

    int leftDiff = 0;
    int upDiff = 0;

    while ((x-i>0) && (auxBoard[y*10+x-i] == 1))
    {
        currentShipSize++; leftDiff++; i++;
    }
    i = 1;
    while ((x + i < 10) && (auxBoard[y * 10 + x + i] == 1))
    {
        currentShipSize++; i++;
    }
    if (currentShipSize > 4) return -1;
    else if (currentShipSize > 1) return CheckShipSurroundings(x - leftDiff, y, currentShipSize, true);
    else
    {
        while ((y - i > 0) && (auxBoard[(y-i) * 10 + x] == 1))
        {
            currentShipSize++; upDiff++; i++;
        }
        i = 1;
        while ((y + i < 10) && (auxBoard[(y + i) * 10 + x] == 1))
        {
            currentShipSize++; i++;
        }
        if (currentShipSize > 4) return -1;
        else return CheckShipSurroundings(x, y-upDiff, currentShipSize, false);
    }
}

public static bool ValidateBattlefield(int[,] field)
{
    auxBoard = new int[100];

    for (int i = 0; i < 10; i++)
        for (int j = 0; j < 10; j++)
            auxBoard[10 * i + j] = field[i, j];


    numberOfValidShips = new int[4];
    for (int i = 0; i < 4; i++)
        numberOfValidShips[i] = 0;

    while (Array.IndexOf(auxBoard,1) > -1)
    {
        int a = Array.IndexOf(auxBoard, 1);
        if (ValidateShip(a % 10, a / 10) == -1) return false;
    }

    for (int i = 0; i < 4; i++)
        if (numberOfValidShips[i] != i + 1) return false;
    return true;
}
}
}
*/
/*
public static char[,] board;
public static int[] currentRowHeight;

public static void ClearBoard()
{
    board = new char[7, 6];
    for (int i = 0; i < 7; i++)
        for (int j = 0; j < 6; j++)
            board[i, j] = ' ';

    currentRowHeight = new int[7];
    for (int i = 0; i < 7; i++)
        currentRowHeight[i] = 0;
}

public static bool Move(int rowNumber, char color) // returns true if this was a winning move, false otherwise
{
    int x = rowNumber;
    int y = currentRowHeight[x]++;

    board[x, y] = color;

    int i = 1;
    int lineLength = 1;
    while ((x - i >= 0) && (board[x - i++, y] == color)) lineLength++;
    i = 1;
    while ((x + i <= 6) && (board[x + i++, y] == color)) lineLength++;
    if (lineLength >= 4) return true;

    i = 1;
    lineLength = 1;
    while ((y - i >= 0) && (board[x, y - i++] == color)) lineLength++;
    //while ((y + i <= 5) && (board[x, y + i++] == color)) lineLength++;
    if (lineLength >= 4) return true;

    i = 1;
    lineLength = 1;
    while (((x - i >= 0) && (y - i >= 0)) && (board[x - i, y - i++] == color)) lineLength++;
    i = 1;
    while (((x + i <= 6) && (y + i <= 5)) && (board[x + i, y + i++] == color)) lineLength++;
    if (lineLength >= 4) return true;

    i = 1;
    lineLength = 1;
    while (((x - i >= 0) && (y + i <= 5)) && (board[x - i, y + i++] == color)) lineLength++;
    i = 1;
    while (((x + i <= 6) && (y - i >= 0)) && (board[x + i, y - i++] == color)) lineLength++;
    if (lineLength >= 4) return true;

    return false;
}

public static string WhoIsWinner(List<string> piecesPositionList)
{
    ClearBoard();

    foreach (string s in piecesPositionList)
    {
        if (Move(((int)s[0] - 65), s[2]) == true)
        {
            if (s[2] == 'Y') return ("Yellow");
            else return ("Red");
        }
    }
    return ("Draw");
}
}
}
*/
/*
public static int moveLength;
public static int tIndex;
public static int xPos;
public static int yPos;
public static int[] t;

public static void Move(int[][] array, char direction)
{
    switch (direction)
    {
        case 'R':
            for (int i=0; i<moveLength; i++)
                t[tIndex++] = array[yPos][++xPos];
            break;
        case 'L':
            for (int i = 0; i < moveLength; i++)
                t[tIndex++] = array[yPos][--xPos];
            break;
        case 'U':
            for (int i = 0; i < moveLength; i++)
                t[tIndex++] = array[--yPos][xPos];
            break;
        case 'D':
            for (int i = 0; i < moveLength; i++)
                t[tIndex++] = array[++yPos][xPos];
            break;
        default:
            break;
    }
}

public static int[] Snail(int[][] array)
{
    int n = array[0].Length;
    if (n == 0) return new int[0];
    t = new int[n*n];

    t[0] = array[0][0];

    moveLength = n - 1;
    tIndex = 1;
    xPos = 0;
    yPos = 0;

    while (moveLength>0)
    {
        if (moveLength == n-1)
        {
            Move(array, 'R'); Move(array, 'D'); Move(array, 'L');
        }
        else if (((n-moveLength)%2)==0)
        {
            Move(array, 'U'); Move(array, 'R');
        }
        else
        {
            Move(array, 'D'); Move(array, 'L');
        }
        moveLength--;
    }
    return t;
}
}
}
*/
/*
public static BigInteger[,] Mul (BigInteger[,] A, BigInteger[,] B)
{
    BigInteger[,] C = new BigInteger[2, 2];

    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 2; j++)
        {
            C[i,j] = 0;
            for (int k=0; k<2; k++)
            {
                C[i, j] += (A[i, k] * B[k, j]);
            }
        }
    }
    return C;
}

public static BigInteger[,] ResetMatrix (BigInteger[,] matrix)
{
    matrix[0, 0] = 0; matrix[0, 1] = 1;
    matrix[1, 0] = 1; matrix[1, 1] = 1;
    return matrix;
}

public static BigInteger fib(int n)
{
    if (n == 0) return BigInteger.Zero;

    BigInteger[,] baseMatrix = { { 0, 1 }, { 1, 1 } };
    BigInteger[,] resultMatrix = new BigInteger[2, 2];
    BigInteger[,] tempMatrix = new BigInteger[2, 2];

    ResetMatrix(resultMatrix);
    ResetMatrix(tempMatrix);

    string binaryCode = Convert.ToString(Math.Abs(n) - 1, 2); //n-1, because resultMatrix[1,1] shows n+1th element

    for (int i=binaryCode.Length-1; i>=0; i--)
    {
        if (binaryCode[i] == '1') { resultMatrix = Mul(resultMatrix, tempMatrix); }
        tempMatrix = Mul(tempMatrix, tempMatrix);
    }
    if ((n < 0) && (n%2==0))  return (-1) * resultMatrix[0, 1];
    else return resultMatrix[0, 1];
}
*/
/*
for (int i=0; i<binaryCode.Length; i++)
{
    ResetMatrix(tempMatrix);
    if (binaryCode[i] == '1')
    {
        for (int j = 0; j < (binaryCode.Length - i - 1); j++)
        {
            tempMatrix = Mul(tempMatrix, tempMatrix);
        }
        resultMatrix = Mul(resultMatrix, tempMatrix);
    }
}
}
*/


/*
public static bool[,] IsWall;
public static int[,] ShortestDistance;
public static int n;

public static void Step(int x, int y, int currentDistance)
{
    if ((ShortestDistance[x, y] == -1) || (ShortestDistance[x, y] > currentDistance))
        ShortestDistance[x, y] = currentDistance;

    if (((x > 0) && (!IsWall[x - 1, y])) &&
       ((ShortestDistance[x - 1, y] > currentDistance + 1) || (ShortestDistance[x - 1, y] == -1)))
        Step(x - 1, y, currentDistance + 1);

    if (((x < n-1) && (!IsWall[x + 1, y])) &&
       ((ShortestDistance[x + 1, y] > currentDistance + 1) || (ShortestDistance[x + 1, y] == -1)))
        Step(x + 1, y, currentDistance + 1);

    if (((y > 0) && (!IsWall[x , y-1])) &&
        ((ShortestDistance[x, y-1] > currentDistance + 1) || (ShortestDistance[x, y-1] == -1)))
        Step(x, y-1, currentDistance + 1);

    if (((y < n-1) && (!IsWall[x, y + 1])) &&
        ((ShortestDistance[x, y + 1] > currentDistance + 1) || (ShortestDistance[x, y + 1] == -1)))
        Step(x, y + 1, currentDistance + 1);
}


public static int PathFinder(string maze)
{
    string s = maze.Replace("\n", string.Empty);
    n = (int)Math.Sqrt(s.Length);

    IsWall = new bool[n,n];
    ShortestDistance = new int[n,n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            ShortestDistance[i, j] = -1; // -1 - no path found yet

            if (s[i * n + j] == 'W') IsWall[i, j] = true;
            else IsWall[i, j] = false;
        }
    }

    Step(0, 0, 0);

    return ShortestDistance[n-1,n-1];
}
}
*/
/*
public static bool SingleValidation(int[] a)
{
int[] correctArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int[] testArray = new int[9];

Array.Copy(a,testArray,9);
Array.Sort(testArray);

return Enumerable.SequenceEqual(testArray,correctArray);
}

public static bool ValidateSolution(int[][] board)
{
int[] arrayToValidate1 = new int[9];
int[] arrayToValidate2 = new int[9];
int[] arrayToValidate3 = new int[9];

for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        arrayToValidate1[j] = board[i][j];
        arrayToValidate2[j] = board[j][i];
        arrayToValidate3[j] = board[3*(j / 3) + i % 3][3*(i / 3) + j % 3];
    }
    if (SingleValidation(arrayToValidate1) == false) return false;
    if (SingleValidation(arrayToValidate2) == false) return false;
    if (SingleValidation(arrayToValidate3) == false) return false;
}
return true;
}

public static bool IsUppercaseLetter(char c)
{
if (((int)c >= 65) && ((int)c <= 90)) return true;
else return false;
}
public static bool IsLowercaseLetter(char c)
{
if (((int)c >= 97) && ((int)c <= 122)) return true;
else return false;
}

public static string FirstNonRepeatingLetter(string s)
{
int[] letterCount = new int[26];
int[] otherCount = new int[65536];

Array.Clear(letterCount, 0, letterCount.Length);
Array.Clear(otherCount, 0, otherCount.Length);

for (int i = 0; i < s.Length; i++)
{
    if (IsUppercaseLetter(s[i])) ++letterCount[(int)s[i] - 65];
    else if (IsLowercaseLetter(s[i])) ++letterCount[(int)s[i] - 97];
    else otherCount[(int)s[i]]++;
}
for (int i = 0; i < s.Length; i++)
{
    if ((IsUppercaseLetter(s[i])) && (letterCount[(int)s[i] - 65] == 1))
        return s[i].ToString();

    if ((IsLowercaseLetter(s[i])) && (letterCount[(int)s[i] - 97] == 1))
        return s[i].ToString();

    if (otherCount[(int)s[i]] == 1)
        return s[i].ToString();

}
return ("");
}

public static string GetReadableTime(int seconds)
{
int h; int m; int s;
s = seconds % 60;
m = (seconds / 60) % 60;
h = seconds / 3600;

return (h.ToString("D2") + ":" + m.ToString("D2") + ":" + s.ToString("D2"));

}

public static List<String> PINList = new List<String>();
public static int[][] adjacents = new int[][]
{
new int[] { 0, 8 },
new int[] { 1, 2, 4 },
new int[] { 1, 2, 3, 5 },
new int[] { 2,3,6 },
new int[] { 1,4,5,7},
new int[] {2,4,5,6,8},
new int[] {3,5,6,9},
new int[] {4,7,8},
new int[] {5,7,8,9,0},
new int[] {6,8,9}
};

public static void ProcessPIN (String partialPIN, String remainingPIN)
{
if (remainingPIN.Equals("")) PINList.Add(partialPIN);
else
    foreach (int i in adjacents[(int)remainingPIN[0]-48])
        ProcessPIN(partialPIN + i.ToString(), remainingPIN.Substring(1));
}

public static List<string> GetPINs(string observed)
{
PINList.Clear();
ProcessPIN("", observed);
return PINList;
}


public static bool Alphanumeric(string str)
{
if (str.Equals("")) return false;
Regex r = new Regex(@"^[a-zA-Z0-9]");

return r.IsMatch(str);
}

public static string Rot13(string message)
{
char[] s = message.ToCharArray();

for (int i = 0; i < s.Length; i++)
{
    if ((s[i] >= (char)65) && (s[i] <= (char)90))
        s[i] = (char)(65 + (((s[i]-65 + 13)) % 26));
    if ((s[i] >= (char)97) && (s[i] <= (char)122))
        s[i] = (char)(97 + (((s[i]-97 + 13)) % 26));
}
return new string(s);
}


public static string Rgb(int r, int g, int b)
{
int r1 = r; int g1 = g; int b1 = b;
if (r1 < 0) r1 = 0;
if (r1 > 255) r1 = 255;
if (g1 < 0) g1 = 0;
if (g1 > 255) g1 = 255;
if (b1 < 0) b1 = 0;
if (b1 > 255) b1 = 255;

string r1s = r1.ToString("X");
if (r1 < 16) r1s = "0" + r1s;
string g1s = g1.ToString("X");
if (g1 < 16) g1s = "0" + g1s;
string b1s = b1.ToString("X");
if (b1 < 16) b1s = "0" + b1s;

return r1s + g1s + b1s;
}



public static bool validSmiley (string s)
{
if (new List<String>{":)",";)",":D",";D",":-)",":~)",":-D",":~D",";-)",";~)",";-D",";~D"}.Contains(s)) return true;
return false;
}

public static int CountSmileys(string[] smileys)
{
int count = 0;
for (int i = 0; i < smileys.Length; i++) if (validSmiley(smileys[i])) count++;
return count;
}


public static string High(string s)
{
string[] arr = s.Split(' ');
int hiScore = 0;
int currentScore = 0;
string bestWord = "";

for (int i=0; i<arr.Length; i++)
{
    for (int j=0; j<arr[i].Length; j++)
    {
        currentScore += (((int)arr[i][j]) - 96);
    }
    if (currentScore > hiScore)
    {
        hiScore = currentScore;
        bestWord = String.Copy(arr[i]);
    }
    currentScore = 0;
}
return bestWord;
}


public static string[] dirReduc(String[] arr)
{
List<String> lista = arr.ToList();

int counter = 0;

while ((lista.Count()>=2) && (counter < lista.Count() - 1))
{
    if ((((lista[counter] == "NORTH") && (lista[counter + 1] == "SOUTH"))
    || ((lista[counter] == "SOUTH") && (lista[counter + 1] == "NORTH")))
    || (((lista[counter] == "WEST") && (lista[counter + 1] == "EAST"))
    || ((lista[counter] == "EAST") && (lista[counter + 1] == "WEST"))))
    {
        lista.RemoveAt(counter + 1);
        lista.RemoveAt(counter);
        counter = 0;
    }
    else counter++;
}
return lista.ToArray();
}


public static int Solution(int value)
{
int sum = 0;
for (int i = 0; i < value; i += 3) sum += i;
for (int j=0; j< value; j += 5) if (j % 15 > 0) sum += j;
return sum;
}


public static bool IsPowerSum(long n)
{
string s = n.ToString();
double counter = 0;
for (int i = 0; i < s.Length; i++)
     counter += Math.Pow((long)s[i]-48, i + 1);

if (counter == n) return true;
else return false;
}

public static long[] SumDigPow (long a, long b)
{
List<long> liczby = new List<long>();

for (long i = a; i <= b; i++) if (IsPowerSum(i)) liczby.Add(i);

return liczby.ToArray();
}


public static float BouncingBall(float h, float bounce, float window)
{
if (((h <= 0) || (bounce <= 0)) || ((bounce >= 1) || (window >= h))) return -1;

int n = 1;

do
{
    h = h * bounce;
    if (h == window) return n + 1;
    if (h < window) return n;
    n += 2;
} while (true);
}


public static bool IsSquare(int n)
{
if ((n >= 0) && (Math.Sqrt(n) == Math.Truncate(Math.Sqrt(n)))) return true;
return false;
}

public static bool IsValidWalk(string[] walk)
{
string s = string.Join("",walk);

if (((s.Length == 10) && (s.Split('w').Length == s.Split('e').Length))
    && (s.Split('n').Length == s.Split('s').Length)) return true;
return false;

}

public static long rowSumOddNumbers(long n)
{
return n * (1 + n * (n - 1)) + n * (n - 1);
}
public static int binaryArrayToNumber(int[] BinaryArray)
{
int result = 0;
int adder = 1;

for (int i=BinaryArray.Length-1; i>=0;i--)
{
    if (BinaryArray[i] == 1) result = result + adder;
    adder *= 2;
}
return result;

}

public static bool IsPangram(string str)
{
for (int i=97; i<=122; i++)
    if (str.ToLower().IndexOf((char)i) == -1) return false;
return true;
}

public static string AlphabetPosition(string text)
{
string s = text.ToLower();
string result = "";
for (int i=0; i<s.Length; i++)
{
    if (((int)s[i] >= 97) && ((int)s[i] <= 122))
    {
        if (result.Length > 0) result = result + " ";
        result = result + ((int)(s[i] - 96)).ToString();
    }
}
return result;
}
public static string SongDecoder(string input)
{
string result = String.Copy(input);

while (result.IndexOf("WUB") > -1)
{
   int w = result.IndexOf("WUB");
   int l = result.Length;

   if (w == 0) result = result.Substring(3, l - 3);
   else if (result.Substring(l-3,3).Equals("WUB")) result = result.Substring(0, l - 3);
   else result = result.Substring(0, w)+" "+ result.Substring(w + 3, l - w - 3);
   Console.WriteLine("result=" + result+"*");

}

while (result.IndexOf("  ") > -1)
{
  int w = result.IndexOf("  ");
  int l = result.Length;

  result = result.Substring(0, w) + " " + result.Substring(w + 2, l - w - 2);
  Console.WriteLine("result=" + result+"*");

}
return result;
}
}
}



}
/*
public static bool SingleValidation(int[] a)
{
int[] correctArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int[] testArray = new int[9];

Array.Copy(a,testArray,9);
Array.Sort(testArray);

return Enumerable.SequenceEqual(testArray,correctArray);
}

public static bool ValidateSolution(int[][] board)
{
int[] arrayToValidate1 = new int[9];
int[] arrayToValidate2 = new int[9];
int[] arrayToValidate3 = new int[9];

for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        arrayToValidate1[j] = board[i][j];
        arrayToValidate2[j] = board[j][i];
        arrayToValidate3[j] = board[3*(j / 3) + i % 3][3*(i / 3) + j % 3];
    }
    if (SingleValidation(arrayToValidate1) == false) return false;
    if (SingleValidation(arrayToValidate2) == false) return false;
    if (SingleValidation(arrayToValidate3) == false) return false;
}
return true;
}

public static bool IsUppercaseLetter(char c)
{
if (((int)c >= 65) && ((int)c <= 90)) return true;
else return false;
}
public static bool IsLowercaseLetter(char c)
{
if (((int)c >= 97) && ((int)c <= 122)) return true;
else return false;
}

public static string FirstNonRepeatingLetter(string s)
{
int[] letterCount = new int[26];
int[] otherCount = new int[65536];

Array.Clear(letterCount, 0, letterCount.Length);
Array.Clear(otherCount, 0, otherCount.Length);

for (int i = 0; i < s.Length; i++)
{
    if (IsUppercaseLetter(s[i])) ++letterCount[(int)s[i] - 65];
    else if (IsLowercaseLetter(s[i])) ++letterCount[(int)s[i] - 97];
    else otherCount[(int)s[i]]++;
}
for (int i = 0; i < s.Length; i++)
{
    if ((IsUppercaseLetter(s[i])) && (letterCount[(int)s[i] - 65] == 1))
        return s[i].ToString();

    if ((IsLowercaseLetter(s[i])) && (letterCount[(int)s[i] - 97] == 1))
        return s[i].ToString();

    if (otherCount[(int)s[i]] == 1)
        return s[i].ToString();

}
return ("");
}

public static string GetReadableTime(int seconds)
{
int h; int m; int s;
s = seconds % 60;
m = (seconds / 60) % 60;
h = seconds / 3600;

return (h.ToString("D2") + ":" + m.ToString("D2") + ":" + s.ToString("D2"));

}

public static List<String> PINList = new List<String>();
public static int[][] adjacents = new int[][]
{
new int[] { 0, 8 },
new int[] { 1, 2, 4 },
new int[] { 1, 2, 3, 5 },
new int[] { 2,3,6 },
new int[] { 1,4,5,7},
new int[] {2,4,5,6,8},
new int[] {3,5,6,9},
new int[] {4,7,8},
new int[] {5,7,8,9,0},
new int[] {6,8,9}
};

public static void ProcessPIN (String partialPIN, String remainingPIN)
{
if (remainingPIN.Equals("")) PINList.Add(partialPIN);
else
    foreach (int i in adjacents[(int)remainingPIN[0]-48])
        ProcessPIN(partialPIN + i.ToString(), remainingPIN.Substring(1));
}

public static List<string> GetPINs(string observed)
{
PINList.Clear();
ProcessPIN("", observed);
return PINList;
}


public static bool Alphanumeric(string str)
{
if (str.Equals("")) return false;
Regex r = new Regex(@"^[a-zA-Z0-9]");

return r.IsMatch(str);
}

public static string Rot13(string message)
{
char[] s = message.ToCharArray();

for (int i = 0; i < s.Length; i++)
{
    if ((s[i] >= (char)65) && (s[i] <= (char)90))
        s[i] = (char)(65 + (((s[i]-65 + 13)) % 26));
    if ((s[i] >= (char)97) && (s[i] <= (char)122))
        s[i] = (char)(97 + (((s[i]-97 + 13)) % 26));
}
return new string(s);
}


public static string Rgb(int r, int g, int b)
{
int r1 = r; int g1 = g; int b1 = b;
if (r1 < 0) r1 = 0;
if (r1 > 255) r1 = 255;
if (g1 < 0) g1 = 0;
if (g1 > 255) g1 = 255;
if (b1 < 0) b1 = 0;
if (b1 > 255) b1 = 255;

string r1s = r1.ToString("X");
if (r1 < 16) r1s = "0" + r1s;
string g1s = g1.ToString("X");
if (g1 < 16) g1s = "0" + g1s;
string b1s = b1.ToString("X");
if (b1 < 16) b1s = "0" + b1s;

return r1s + g1s + b1s;
}



public static bool validSmiley (string s)
{
if (new List<String>{":)",";)",":D",";D",":-)",":~)",":-D",":~D",";-)",";~)",";-D",";~D"}.Contains(s)) return true;
return false;
}

public static int CountSmileys(string[] smileys)
{
int count = 0;
for (int i = 0; i < smileys.Length; i++) if (validSmiley(smileys[i])) count++;
return count;
}


public static string High(string s)
{
string[] arr = s.Split(' ');
int hiScore = 0;
int currentScore = 0;
string bestWord = "";

for (int i=0; i<arr.Length; i++)
{
    for (int j=0; j<arr[i].Length; j++)
    {
        currentScore += (((int)arr[i][j]) - 96);
    }
    if (currentScore > hiScore)
    {
        hiScore = currentScore;
        bestWord = String.Copy(arr[i]);
    }
    currentScore = 0;
}
return bestWord;
}


public static string[] dirReduc(String[] arr)
{
List<String> lista = arr.ToList();

int counter = 0;

while ((lista.Count()>=2) && (counter < lista.Count() - 1))
{
    if ((((lista[counter] == "NORTH") && (lista[counter + 1] == "SOUTH"))
    || ((lista[counter] == "SOUTH") && (lista[counter + 1] == "NORTH")))
    || (((lista[counter] == "WEST") && (lista[counter + 1] == "EAST"))
    || ((lista[counter] == "EAST") && (lista[counter + 1] == "WEST"))))
    {
        lista.RemoveAt(counter + 1);
        lista.RemoveAt(counter);
        counter = 0;
    }
    else counter++;
}
return lista.ToArray();
}


public static int Solution(int value)
{
int sum = 0;
for (int i = 0; i < value; i += 3) sum += i;
for (int j=0; j< value; j += 5) if (j % 15 > 0) sum += j;
return sum;
}


public static bool IsPowerSum(long n)
{
string s = n.ToString();
double counter = 0;
for (int i = 0; i < s.Length; i++)
     counter += Math.Pow((long)s[i]-48, i + 1);

if (counter == n) return true;
else return false;
}

public static long[] SumDigPow (long a, long b)
{
List<long> liczby = new List<long>();

for (long i = a; i <= b; i++) if (IsPowerSum(i)) liczby.Add(i);

return liczby.ToArray();
}


public static float BouncingBall(float h, float bounce, float window)
{
if (((h <= 0) || (bounce <= 0)) || ((bounce >= 1) || (window >= h))) return -1;

int n = 1;

do
{
    h = h * bounce;
    if (h == window) return n + 1;
    if (h < window) return n;
    n += 2;
} while (true);
}


public static bool IsSquare(int n)
{
if ((n >= 0) && (Math.Sqrt(n) == Math.Truncate(Math.Sqrt(n)))) return true;
return false;
}

public static bool IsValidWalk(string[] walk)
{
string s = string.Join("",walk);

if (((s.Length == 10) && (s.Split('w').Length == s.Split('e').Length))
    && (s.Split('n').Length == s.Split('s').Length)) return true;
return false;

}

public static long rowSumOddNumbers(long n)
{
return n * (1 + n * (n - 1)) + n * (n - 1);
}
public static int binaryArrayToNumber(int[] BinaryArray)
{
int result = 0;
int adder = 1;

for (int i=BinaryArray.Length-1; i>=0;i--)
{
    if (BinaryArray[i] == 1) result = result + adder;
    adder *= 2;
}
return result;

}

public static bool IsPangram(string str)
{
for (int i=97; i<=122; i++)
    if (str.ToLower().IndexOf((char)i) == -1) return false;
return true;
}

public static string AlphabetPosition(string text)
{
string s = text.ToLower();
string result = "";
for (int i=0; i<s.Length; i++)
{
    if (((int)s[i] >= 97) && ((int)s[i] <= 122))
    {
        if (result.Length > 0) result = result + " ";
        result = result + ((int)(s[i] - 96)).ToString();
    }
}
return result;
}
public static string SongDecoder(string input)
{
string result = String.Copy(input);

while (result.IndexOf("WUB") > -1)
{
   int w = result.IndexOf("WUB");
   int l = result.Length;

   if (w == 0) result = result.Substring(3, l - 3);
   else if (result.Substring(l-3,3).Equals("WUB")) result = result.Substring(0, l - 3);
   else result = result.Substring(0, w)+" "+ result.Substring(w + 3, l - w - 3);
   Console.WriteLine("result=" + result+"*");

}

while (result.IndexOf("  ") > -1)
{
  int w = result.IndexOf("  ");
  int l = result.Length;

  result = result.Substring(0, w) + " " + result.Substring(w + 2, l - w - 2);
  Console.WriteLine("result=" + result+"*");

}
return result;
}
}
}*/
