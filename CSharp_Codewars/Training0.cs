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
    class Training0
    {
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

            if (s.IndexOf('-') != -1) return (TranslateNumber(s.Substring(0, s.IndexOf('-'))) + TranslateNumber(s.Substring(s.IndexOf('-') + 1, s.Length - s.IndexOf('-') - 1)));

            return 0;
        }

        public static int ParseInt(string s)
        {
            if ((s == "million") || (s == "one million")) return 1000000;
            if (s == "zero") return 0;

            s = Regex.Replace(s, " and", "");

            string[] words = s.Split(' ');

            int tempResult = 0;

            int a = Array.IndexOf(words, "thousand");
            int b = Array.IndexOf(words, "hundred");

            if (a != -1)
            {
                // compute number of thousands
                if ((b != -1) && (b < a))
                {
                    // compute number of 100000s
                    if (b == 0) tempResult += 100000;
                    else tempResult += (TranslateNumber(words[b - 1]) * 100000);
                }
                tempResult += (TranslateNumber(words[a - 1]) * 1000);

                s = (Regex.Replace(s, "^[ ]?([ a-z-])*thousand", "")).Trim();

                words = s.Split(' ');
            }

            b = Array.IndexOf(words, "hundred");
            if (b != -1)
            {
                if (b == 0) tempResult += 100;
                if (b == 1) tempResult += (TranslateNumber(words[0]) * 100);

                s = (Regex.Replace(s, "^([ a-z-])*hundred", "")).Trim();
                words = s.Split(' ');
            }
            if (s != "") tempResult += TranslateNumber(words[0]);

            return tempResult;
        }


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
            int k = pos - 1;

            while ((k >= 0) && (IsDigitOrComma(s[k]))) k--;

            if ((k >= 0) && (s[k] == '-')) return s.Substring(k, pos - k);
            else return s.Substring(k + 1, pos - k - 1);
        }

        public static string ScanRightNumber(string s, int pos)
        {
            int k = pos + 1;

            while (((k < s.Length) && (IsDigitOrComma(s[k])))
                || ((k == pos + 1) && (s[k] == '-'))) k++;

            return s.Substring(pos + 1, k - pos - 1);
        }

        public static string ComputeSubexpression(string s)
        {
            // Compute value of an expression without parentheses (only numbers and '+','-','*','/' symbols)

            s = HandleDoubleMinuses(s);

            while (Math.Max(s.IndexOf('*'), s.IndexOf('/')) != -1)
            {
                int pos = Math.Min(s.IndexOf('*'), s.IndexOf('/'));
                if (pos == -1) pos = Math.Max(s.IndexOf('*'), s.IndexOf('/'));

                double tempResult;
                string leftString = ScanLeftNumber(s, pos);
                string rightString = ScanRightNumber(s, pos);
                double leftNumber = double.Parse(leftString);
                double rightNumber = double.Parse(rightString);

                string[] partsOfExpression = new string[3];

                if (s[pos] == '*') tempResult = leftNumber * rightNumber;
                else if (s[pos] == '/') tempResult = leftNumber / rightNumber;
                else return ("ERROR");

                if (leftString.Length < pos)
                    partsOfExpression[0] = s.Substring(0, pos - leftString.Length);
                else partsOfExpression[0] = "";

                partsOfExpression[1] = tempResult.ToString();

                if (rightString.Length < s.Length - pos - 2)
                    partsOfExpression[2] = s.Substring(pos + rightString.Length + 1, s.Length - pos - rightString.Length - 1);
                else partsOfExpression[2] = "";

                s = String.Join("", partsOfExpression);
            }
            // There are no more '*' and '/' characters, just '+','-' and numbers

            while ((s.IndexOf('+') != -1) || (s.Length > 1 && s.Substring(1).IndexOf('-') != -1))
            {
                int pos = Math.Min(s.Substring(1).IndexOf('+'), s.Substring(1).IndexOf('-')) + 1;
                if (pos == 0) pos = Math.Max(s.Substring(1).IndexOf('+'), s.Substring(1).IndexOf('-')) + 1;

                double tempResult;
                string leftString = ScanLeftNumber(s, pos);
                string rightString = ScanRightNumber(s, pos);
                double leftNumber = double.Parse(leftString);
                double rightNumber = double.Parse(rightString);

                string[] partsOfExpression = new string[3];

                if (s[pos] == '+') tempResult = leftNumber + rightNumber;
                else if (s[pos] == '-') tempResult = leftNumber - rightNumber;
                else return ("ERROR");

                if (leftString.Length < pos)
                    partsOfExpression[0] = s.Substring(0, pos - leftString.Length);
                else partsOfExpression[0] = "";

                partsOfExpression[1] = tempResult.ToString();

                if (rightString.Length < s.Length - pos - 2)
                    partsOfExpression[2] = s.Substring(pos + rightString.Length + 1, s.Length - pos - rightString.Length - 1);
                else partsOfExpression[2] = "";

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

                while (expression[k] != '(') k--;

                if (k > 0)
                    partsOfExpression[0] = expression.Substring(0, k);
                else partsOfExpression[0] = "";

                partsOfExpression[1] = ComputeSubexpression(expression.Substring(k + 1, expression.IndexOf(')') - k - 1));

                if (expression.IndexOf(')') < expression.Length - 1)
                    partsOfExpression[2] = expression.Substring(expression.IndexOf(')') + 1, expression.Length - expression.IndexOf(')') - 1);
                else partsOfExpression[2] = "";

                expression = String.Join("", partsOfExpression);
            }
            partsOfExpression[1] = ComputeSubexpression(expression);

            return Double.Parse(partsOfExpression[1]);
        }
    }
}