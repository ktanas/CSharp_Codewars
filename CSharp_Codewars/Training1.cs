using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Reflection;


namespace CSharp_Codewars
{
    class Training1
    {
        public struct Gap
        {
            public int beginningLength;
            public int gapLength;
        }

        public static List<Gap> listOfGaps;

        public static int min1; public static int max1; public static int total1;
        public static int min0; public static int max0; public static int total0;

        public static int[] count1; public static int[] count0; public static int[] totalcount;

        public static int firstBoundary; public static int secondBoundary;

        public static double optimalAverageWordLength = 5.0;
        public static double optimalAverageCharacterLength = 3.0;

        public static void Startup()
        {
            min1 = 0; max1 = 0; min0 = 0; max0 = 0; total1 = 0; total0 = 0;
            count1 = new int[100]; count0 = new int[100]; totalcount = new int[100];
            for (int i = 0; i < 100; i++)
            {
                count1[i] = 0; count0[i] = 0; totalcount[i] = 0;
            }
            firstBoundary = 0; secondBoundary = 0;
        }

        public static string TrimZeros(string morseCode)
        {
            if (morseCode.IndexOf('1') == -1) return "";
            return morseCode.Substring(morseCode.IndexOf('1'), morseCode.LastIndexOf('1') + 1 - morseCode.IndexOf('1'));
        }

        public static void AddToCount(int length, char ch)
        {
            if (ch == '1')
            {
                total1++;
                count1[length]++;
                totalcount[length]++;
                if ((min1 == 0) || (length < min1)) min1 = length;
                if ((max1 == 0) || (length > max1)) max1 = length;
            }
            else // ch == '0'
            {
                total0++;
                count0[length]++;
                totalcount[length]++;
                if ((min0 == 0) || (length < min0)) min0 = length;
                if ((max0 == 0) || (length > max0)) max0 = length;
            }
        }

        public static void ScanBitStrings(string morseCode)
        {
            int currentLength = 1;
            int pos = 0;

            while (pos < morseCode.Length)
            {
                if ((pos == morseCode.Length - 1) || (morseCode[pos + 1] != morseCode[pos]))
                {
                    AddToCount(currentLength, morseCode[pos]);
                    currentLength = 1;
                }
                else currentLength++;
                pos++;
            }
        }

        public static int PercentageOfOnes() // Statistical approach: find boundary value for which dot/dash ratio is closest to 50%/50%
        {
            double ratio;
            double bestRatio = 0.0;
            int bestBoundary = 0;
            int stringCount = 0; // number of dash/dot strings not longer than i '1' symbols

            List<Gap> longestGapsBeforeMax1 = FindLongestGapsBeforeMax1();

            if (longestGapsBeforeMax1.Count > 0)
            {
                foreach (Gap g in longestGapsBeforeMax1)
                {
                    int i = g.beginningLength;
                    stringCount = 0;
                    for (int j = min1; j < i; j++) stringCount += count1[j];

                    ratio = (double)stringCount / (double)total1;

                    if ((Math.Abs(0.55 - ratio)) < Math.Abs(0.55 - bestRatio))
                    {
                        bestRatio = ratio;
                        bestBoundary = i + 1; // In this program, boundaries state the lowest length which falls into a new category.
                                              // So, for example, all strings of ones shorter than 'firstBoundary' will be classified as dots,
                                              // while those of length equal or longer to firstBoundary are dashes.
                    }
                }
            }
            else // there are no gaps before max1, so we need to check every value in [min1..max1] range
            {
                int i = min1 - 1;

                while (++i <= max1)
                {
                    stringCount += count1[i];
                    ratio = (double)stringCount / (double)total1;

                    if ((Math.Abs(0.55 - ratio)) < Math.Abs(0.55 - bestRatio))
                    {
                        bestRatio = ratio;
                        bestBoundary = i + 1; // In this program, boundaries state the lowest length which falls into a new category.
                                              // So, for example, all strings of ones shorter than 'firstBoundary' will be classified as dots,
                                              // while those of length equal or longer to firstBoundary are dashes.
                    }
                }
            }
            return bestBoundary;
        }

        public static int PercentageOfLengths() // Statistical approach: find boundary value for which total length ratio is closest to 50%/50%
        {
            double ratio;
            double bestRatio = 0.0;
            int bestBoundary = 0;
            int stringCount = 0; // number of dash/dot strings not longer than i '1' or '0' symbols

            int i = Math.Min(min0, min1) - 1;

            while (++i <= Math.Max(max0, max1))
            {
                stringCount += totalcount[i];
                ratio = (double)stringCount / (double)(total1 + total0);

                if ((Math.Abs(0.55 - ratio)) < Math.Abs(0.55 - bestRatio))
                {
                    bestRatio = ratio;
                    bestBoundary = i + 1; // In this program, boundaries state the lowest length which falls into a new category.
                                          // So, for example, all strings of ones shorter than 'firstBoundary' will be classified as dots,
                                          // while those of length equal or longer to firstBoundary are dashes.
                }
            }
            return bestBoundary;
        }
        public static List<Gap> ScanForGaps()
        {
            int currentGapLength = 0;
            List<Gap> gapList = new List<Gap>();


            for (int i = Math.Min(min0, min1); i <= Math.Max(max0, max1); i++)
            {
                if (count0[i] + count1[i] == 0) currentGapLength++;
                else
                {
                    if (currentGapLength > 0)
                    {
                        gapList.Add(new Gap() { beginningLength = i - currentGapLength, gapLength = currentGapLength });
                        currentGapLength = 0;
                    }
                }
            }
            return gapList;
        }

        public static List<Gap> FindLongestGapsBeforeMax1()
        {
            int maxLengthFound = 0;
            List<Gap> gapList = new List<Gap>();

            foreach (Gap g in listOfGaps) // find maximum length of a gap which occurs in dot/dash range 
            {
                if ((g.beginningLength < max1) && (g.gapLength > maxLengthFound))
                    maxLengthFound = g.gapLength;
            }
            foreach (Gap g in listOfGaps) // find all longest gaps which are present in dot/dash length range
            {
                if ((g.beginningLength < max1) && (g.gapLength == maxLengthFound))
                    gapList.Add(new Gap() { beginningLength = g.beginningLength, gapLength = g.gapLength });
            }
            return gapList;
        }

        public static List<Gap> FindLongestGapsAfterMax1()
        {
            int maxLengthFound = 0;
            List<Gap> gapList = new List<Gap>();

            foreach (Gap g in listOfGaps) // find maximum length of a gap which occurs after dot/dash range - to determine second boundary
            {
                if ((g.beginningLength > max1) && (g.gapLength > maxLengthFound))
                    maxLengthFound = g.gapLength;
            }
            foreach (Gap g in listOfGaps) // find all longest gaps which are present after dot/dash length range - to determine second boundary
            {
                if ((g.beginningLength > max1) && (g.gapLength == maxLengthFound))
                    gapList.Add(new Gap() { beginningLength = g.beginningLength, gapLength = g.gapLength });
            }
            return gapList;
        }

        public static int FindFirstGapAfterMax1()
        {
            int currentLength = max1 + 1;

            while ((currentLength < max0) && (totalcount[currentLength] > 0)) currentLength++;
            if (currentLength == max0) return 0;

            while ((currentLength < max0) && (totalcount[currentLength] == 0)) currentLength++;
            return currentLength;
        }

        public static double ComputeAverageWordLength(string decodedMessage)
        {
            string[] arr = decodedMessage.Split(' ');

            int numberOfWords = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] == "*") && ((i > 0) && (i < arr.Length - 1))) numberOfWords++;
            }

            double averageWordLength = (double)(arr.Length - numberOfWords + 1) / (double)numberOfWords;

            return averageWordLength;
        }

        public static double ComputeAverageCharacterLength(string decodedMessage)
        {
            string[] arr = decodedMessage.Split(' ');

            int totalLength = 0;
            int numberOfCharacters = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "*")
                {
                    numberOfCharacters++;
                    totalLength += arr[i].Length;
                }
            }
            return ((double)totalLength / (double)numberOfCharacters);
        }

        public static int FindBoundaryWithOptimalCharacterLength(int minBoundary, int maxBoundary, int secBoundary, string bits)
        {
            secondBoundary = secBoundary;

            double averageCharacterLength;
            double bestAverageLengthFound = 0.0;
            int bestBoundary = 0;

            for (int i = minBoundary; i <= maxBoundary; i++)
            {
                firstBoundary = i;
                averageCharacterLength = ComputeAverageCharacterLength(decodeBitsAdvanced2(bits));

                if (Math.Abs(optimalAverageCharacterLength - averageCharacterLength) < Math.Abs(optimalAverageCharacterLength - bestAverageLengthFound))
                {
                    bestAverageLengthFound = averageCharacterLength;
                    bestBoundary = i;
                }
            }

            return bestBoundary;
        }
        public static int FindBoundaryWithOptimalWordLength(int startBoundary, int endBoundary, string bits)
        {
            double bestFoundAverageWordLength = 0.0;
            int bestBoundary = 0;

            for (int i = startBoundary; i <= endBoundary; i++)
            {
                secondBoundary = i;

                double averageWordLength = ComputeAverageWordLength(decodeBitsAdvanced2(bits));

                if ((Math.Abs(optimalAverageWordLength - averageWordLength)) < Math.Abs(optimalAverageWordLength - bestFoundAverageWordLength))
                {
                    bestFoundAverageWordLength = averageWordLength;
                    bestBoundary = i;
                }

            }
            return bestBoundary;
        }

        public static int FindBoundaryWithOptimalWordLengthForList(List<Gap> gaps, string bits)
        {
            double bestFoundAverageWordLength = 0.0;
            int bestBoundary = 0;

            foreach (Gap gap in gaps)
            {
                secondBoundary = gap.beginningLength;

                double averageWordLength = ComputeAverageWordLength(decodeBitsAdvanced2(bits));

                if ((Math.Abs(optimalAverageWordLength - averageWordLength)) < Math.Abs(optimalAverageWordLength - bestFoundAverageWordLength))
                {
                    bestFoundAverageWordLength = averageWordLength;
                    bestBoundary = gap.beginningLength;
                }

            }
            return bestBoundary;
        }

        public static string decodeBitsAdvanced(string bits)
        {
            return bits;
        }

        public static string decodeBitsAdvanced2(string bits)
        {
            if (bits.IndexOf('1') == -1) return ("");
            if (bits.IndexOf('0') == -1) return (".");

            string result = ""; // the Morse string of dots and dashed decoded from the message

            string currentString = ""; // retrieved Morse code of a single character, i.e. "..-."

            int currentLength = 1;
            int pos = 0;

            while (pos < bits.Length)
            {
                if ((pos == bits.Length - 1) || (bits[pos + 1] != bits[pos]))
                {
                    if (bits[pos] == '1')
                    {
                        if (currentLength >= firstBoundary) currentString += "-";
                        else currentString += ".";
                    }
                    else // bits[pos] == '0'
                    {
                        if ((currentLength >= secondBoundary) && (pos < bits.Length - 1))
                        {
                            currentString = " * "; // our string used by the program to mark as space between words in the message
                        }
                        else if ((currentLength >= firstBoundary) && (pos < bits.Length - 1))
                        {
                            currentString = " "; // our string used by the program to mark as space between characters of the same word in the message
                        }
                        else currentString = ""; // just a pause between dot/dash symbols of the same Morse character
                    }
                    result += currentString;
                    currentString = "";
                    currentLength = 1;
                }
                else currentLength++;
                pos++;
            }

            int startPos = Math.Min(result.IndexOf('-'), result.IndexOf('.'));
            if (startPos == -1) startPos = Math.Max(result.IndexOf('-'), result.IndexOf('.')); // safeguard against an only-dot or only-dash message
            int endPos = Math.Max(result.LastIndexOf('-'), result.LastIndexOf('.'));

            result = result.Substring(startPos, endPos - startPos + 1);
            return result;
        }

        public static string DecodeMorseCharacter(string code)
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

        public static void ComputeFirstBoundary(string bits)
        {
            // Some guessing by trial and error, needed especially for short messages
            if (max1 == 1) { firstBoundary = 2; secondBoundary = 5; }

            else if ((min1 == 1) && (max1 == 2))
            {
                if (max0 <= 2) firstBoundary = 2;
                else if (count0[3] == 0) firstBoundary = 3;
                else if (max0 == 3) firstBoundary = PercentageOfOnes();
                else if (count0[4] == 0) firstBoundary = 4;
                else firstBoundary = PercentageOfOnes();
            }
            else if (((min1 == 1) && (max1 == 3)) && (count1[2] == 0))
            {
                if (count0[2] == 0) firstBoundary = 2;
                else firstBoundary = FindBoundaryWithOptimalCharacterLength(2, 3, 6, bits);
            }
            else if ((min1 == 2) && (max1 == 2))
            {
                if (min0 == 1)
                {
                    if (max0 <= 2) firstBoundary = 2;
                    else if (count0[3] == 0) firstBoundary = 3;
                    else if (max0 == 3) firstBoundary = FindBoundaryWithOptimalCharacterLength(2, 3, 6, bits);
                    else if (count0[4] == 0) firstBoundary = 4;
                    else firstBoundary = FindBoundaryWithOptimalCharacterLength(2, 4, 6, bits);
                }
                else if (min0 == 2)
                {
                    if (count0[3] == 0) firstBoundary = 3;
                    else if (count0[4] == 0) firstBoundary = FindBoundaryWithOptimalCharacterLength(3, 4, 6, bits);
                    else firstBoundary = FindBoundaryWithOptimalCharacterLength(3, 4, 6, bits);
                }
                else if (min0 == 3)
                {
                    if (count0[4] > 0) firstBoundary = FindBoundaryWithOptimalCharacterLength(3, 4, 6, bits);
                    else firstBoundary = 4;
                }
                else firstBoundary = 4;
            }
            else if ((min1 == max1) || (min1 == max1 - 1))
            {
                if (min0 <= (min1 / 2))
                {
                    List<Gap> gaps = FindLongestGapsBeforeMax1();
                    if (gaps.Count > 0) firstBoundary = gaps[0].beginningLength;
                    else firstBoundary = FindBoundaryWithOptimalCharacterLength(min0 + 1, min1 - 1, max1 * 2, bits);
                }
                else if (min0 <= min1 - 2)
                {
                    List<Gap> gaps = FindLongestGapsBeforeMax1();
                    if (gaps.Count > 0) firstBoundary = gaps[0].beginningLength;
                    else firstBoundary = FindBoundaryWithOptimalCharacterLength(min0 + 1, min1 - 1, max1 * 2, bits);
                }
                else if ((min0 == min1 - 1) || (min0 == min1))
                {
                    if ((count0[max1 + 1] == 0) && (count0[max1 + 2] == 0)) firstBoundary = max1 + 1;
                    else if ((count0[max1 + 1] == 0) && (max1 <= 4)) firstBoundary = max1 + 1;
                    else firstBoundary = FindBoundaryWithOptimalCharacterLength(min0, max1 + 1, 2 * max1, bits);
                }
                else // min0 > min1
                {
                    if (max0 >= min1 * 5) // probably all '1' sequences are dots, and there is at least one 'end of word' signal
                    {
                        List<Gap> gaps1 = FindLongestGapsAfterMax1();
                        if (gaps1.Count > 0)
                        {
                            secondBoundary = gaps1[0].beginningLength;
                            if (gaps1[0].gapLength < min1 * 3) // Scan for another gap before the longest one to get first boundary
                            {
                                firstBoundary = FindFirstGapAfterMax1();
                                if (firstBoundary == 0) firstBoundary = FindBoundaryWithOptimalCharacterLength(max1 + 1, gaps1[0].beginningLength - 1, gaps1[0].beginningLength, bits);
                            }
                            else // Probably there are only dots and word pauses in the whole message
                                firstBoundary = gaps1[0].beginningLength;
                        }
                        else // no gaps after max1
                            firstBoundary = FindBoundaryWithOptimalCharacterLength(max1 + 1, max0, max0 + 1, bits);
                    }
                    else // max0 < min1*5, probably there is either at least one dash, or no word pauses
                    {
                        List<Gap> gaps1 = FindLongestGapsAfterMax1();
                        if (gaps1.Count > 0) firstBoundary = gaps1[0].beginningLength;
                        else firstBoundary = FindBoundaryWithOptimalCharacterLength(max1, Math.Max(max0, max1), max1 * 2, bits);
                    }
                }
            }
            else
            { // At last, general case, hopefully some sequences of '1's are dots and some others are dashes, that would make determining firstBoundary easier
                List<Gap> gaps = FindLongestGapsBeforeMax1();
                firstBoundary = PercentageOfOnes();
            }
        }

        public static void ComputeSecondBoundary(string bits)
        {
            // If we are here, it is assumed that first boundary has already been computed

            if (secondBoundary == 0)
            {
                if (firstBoundary >= Math.Max(max0, max1)) { secondBoundary = firstBoundary + 1; }

                if (max1 < firstBoundary) // there are only dots (no dashes) in the message, this is a more complicated case
                {
                    if (max0 < firstBoundary) secondBoundary = firstBoundary + 1; // there are only dots and short pauses
                    else if (max0 < ((double)max1) * 4.5) secondBoundary = Math.Max(max0, max1) + 1; // it is likely that message contains no word pauses

                    else
                    {
                        List<Gap> gaps = FindLongestGapsAfterMax1();
                        if (gaps.Count == 0) secondBoundary = FindBoundaryWithOptimalWordLength(max1 + 1, max0, bits);
                        else if (gaps[0].gapLength > ((double)max1) * 3.5) secondBoundary = gaps[0].beginningLength + gaps[0].gapLength; // there are probably only short and long sequences
                        else secondBoundary = FindBoundaryWithOptimalWordLengthForList(gaps, bits);
                    }
                }
                else // there is at least one dash, this is a more standard case
                {
                    if (max0 < ((double)max1) * 1.6) secondBoundary = Math.Max(max0, max1); // the message probably contains only short and medium strings
                    else // it is likely that the message contains at least one word pause (a long string)
                    {
                        List<Gap> gaps = FindLongestGapsAfterMax1();
                        if (gaps.Count == 0) secondBoundary = FindBoundaryWithOptimalWordLength(max1 + 1, max0, bits);
                        else secondBoundary = FindBoundaryWithOptimalWordLengthForList(gaps, bits);
                    }
                }
            }
        }

        public static string decodeMorse(string morseCode)
        {
            Startup();
            morseCode = TrimZeros(morseCode);

            ScanBitStrings(morseCode);

            listOfGaps = new List<Gap>(ScanForGaps());

            ComputeFirstBoundary(morseCode);
            ComputeSecondBoundary(morseCode);

            string decodedMessage = decodeBitsAdvanced2(morseCode);

            string result = "";

            foreach (string s in decodedMessage.Split(' '))
            {
                if (s == "*") result += " ";
                else result += DecodeMorseCharacter(s);
            }
            return result;
        }
    }
}
