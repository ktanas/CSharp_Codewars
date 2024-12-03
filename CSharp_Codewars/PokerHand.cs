using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Codewars
{
    public class PokerHand
    {
        public string hand;

        public enum Result
        {
            Win,
            Loss,
            Tie
        }

        public string Hand1;
        public string Hand2;
        public int[] CardRanksInHand1 = new int[13]; // number of the following cards in hand:
        public int[] CardRanksInHand2 = new int[13]; // A K Q J T 9 8 7 6 5 4 3 2


        public PokerHand(string hand)
        {
            this.hand = hand;
            Hand1 = this.hand;
        }
        public bool IsFlush(string hand)
        {
            if (hand[1] != hand[4]) return false;
            if (hand[1] != hand[7]) return false;
            if (hand[1] != hand[10]) return false;
            if (hand[1] != hand[13]) return false;
            return true;
        }

        public static int[] DetermineCardRanksOfHand(string hand)
        {
            int[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 13; i += 3)
            {
                switch (hand[i])
                {
                    case 'A':
                        result[0]++;
                        break;
                    case 'K':
                        result[1]++;
                        break;
                    case 'Q':
                        result[2]++;
                        break;
                    case 'J':
                        result[3]++;
                        break;
                    case 'T':
                        result[4]++;
                        break;
                    case '9':
                        result[5]++;
                        break;
                    case '8':
                        result[6]++;
                        break;
                    case '7':
                        result[7]++;
                        break;
                    case '6':
                        result[8]++;
                        break;
                    case '5':
                        result[9]++;
                        break;
                    case '4':
                        result[10]++;
                        break;
                    case '3':
                        result[11]++;
                        break;
                    case '2':
                        result[12]++;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public int IsStraight(int[] rankedHand)
        {
            if (((((rankedHand[0] == 1) && (rankedHand[1] == 1)) && (rankedHand[2] == 1)) && (rankedHand[3] == 1)) && (rankedHand[4] == 1))
                return 13; // Ace-high straight
            if (((((rankedHand[1] == 1) && (rankedHand[2] == 1)) && (rankedHand[3] == 1)) && (rankedHand[4] == 1)) && (rankedHand[5] == 1))
                return 12; // King-high straight
            if (((((rankedHand[2] == 1) && (rankedHand[3] == 1)) && (rankedHand[4] == 1)) && (rankedHand[5] == 1)) && (rankedHand[6] == 1))
                return 11; // Queen-high straight
            if (((((rankedHand[3] == 1) && (rankedHand[4] == 1)) && (rankedHand[5] == 1)) && (rankedHand[6] == 1)) && (rankedHand[7] == 1))
                return 10; // Jack-high straight
            if (((((rankedHand[4] == 1) && (rankedHand[5] == 1)) && (rankedHand[6] == 1)) && (rankedHand[7] == 1)) && (rankedHand[8] == 1))
                return 9; // Ten-high straight
            if (((((rankedHand[5] == 1) && (rankedHand[6] == 1)) && (rankedHand[7] == 1)) && (rankedHand[8] == 1)) && (rankedHand[9] == 1))
                return 8; // 9-high straight
            if (((((rankedHand[6] == 1) && (rankedHand[7] == 1)) && (rankedHand[8] == 1)) && (rankedHand[9] == 1)) && (rankedHand[10] == 1))
                return 7; // 8-high straight
            if (((((rankedHand[7] == 1) && (rankedHand[8] == 1)) && (rankedHand[9] == 1)) && (rankedHand[10] == 1)) && (rankedHand[11] == 1))
                return 6; // 7-high straight
            if (((((rankedHand[8] == 1) && (rankedHand[9] == 1)) && (rankedHand[10] == 1)) && (rankedHand[11] == 1)) && (rankedHand[12] == 1))
                return 5; // 6-high straight

            return 0; // Not a straight
        }

        public int ComputeHandCombination(string hand, int[] rankedHand)
        {
            bool flush = IsFlush(hand);
            int straight = IsStraight(rankedHand);

            int[] sortedCardQuantities = new int[13];
            Array.Copy(rankedHand, sortedCardQuantities, 13);
            Array.Sort(sortedCardQuantities);


            // {0,0,0,0,0,0,0,0,0,0,0,1,4} = four of a kind
            // {0,0,0,0,0,0,0,0,0,0,0,2,3} = full house
            // {0,0,0,0,0,0,0,0,0,0,1,1,3} = three of a kind
            // {0,0,0,0,0,0,0,0,0,0,1,2,2} = two pair
            // {0,0,0,0,0,0,0,0,0,1,1,1,2} = one pair
            // {0,0,0,0,0,0,0,0,1,1,1,1,1} = something else, check if it is flush and/or straight

            int[] array4kind = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4 };
            int[] arrayFullHouse = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3 };
            int[] array3kind = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 3 };
            int[] array2pair = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2 };
            int[] array1pair = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 2 };

            if ((flush) && (straight > 0)) return 1000 + straight;
            else if (Enumerable.SequenceEqual(sortedCardQuantities, array4kind)) return 900;
            else if (Enumerable.SequenceEqual(sortedCardQuantities, arrayFullHouse)) return 800;
            else if (flush) return 700;
            else if (straight > 0) return 600 + straight;
            else if (Enumerable.SequenceEqual(sortedCardQuantities, array3kind)) return 500;
            else if (Enumerable.SequenceEqual(sortedCardQuantities, array2pair)) return 400;
            else if (Enumerable.SequenceEqual(sortedCardQuantities, array1pair)) return 300;
            else return 200;
        }

        public Result Compare4OfAKind()
        {
            int a = Array.IndexOf(CardRanksInHand1, 4);
            int b = Array.IndexOf(CardRanksInHand2, 4);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            a = Array.IndexOf(CardRanksInHand1, 1);
            b = Array.IndexOf(CardRanksInHand2, 1);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            return Result.Tie;
        }

        public Result CompareFullHouse()
        {
            int a = Array.IndexOf(CardRanksInHand1, 3);
            int b = Array.IndexOf(CardRanksInHand2, 3);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            a = Array.IndexOf(CardRanksInHand1, 2);
            b = Array.IndexOf(CardRanksInHand2, 2);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            return Result.Tie;
        }

        public Result Compare3OfAKind()
        {
            int a = Array.IndexOf(CardRanksInHand1, 3);
            int b = Array.IndexOf(CardRanksInHand2, 3);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            a = Array.IndexOf(CardRanksInHand1, 1);
            b = Array.IndexOf(CardRanksInHand2, 1);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            CardRanksInHand1[a] = 0;
            CardRanksInHand2[b] = 0;

            a = Array.IndexOf(CardRanksInHand1, 1);
            b = Array.IndexOf(CardRanksInHand2, 1);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            return Result.Tie;
        }

        public Result Compare2Pairs()
        {
            int a = Array.IndexOf(CardRanksInHand1, 2);
            int b = Array.IndexOf(CardRanksInHand2, 2);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            CardRanksInHand1[a] = 0;
            CardRanksInHand2[b] = 0;

            a = Array.IndexOf(CardRanksInHand1, 2);
            b = Array.IndexOf(CardRanksInHand2, 2);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            a = Array.IndexOf(CardRanksInHand1, 1);
            b = Array.IndexOf(CardRanksInHand2, 1);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            return Result.Tie;
        }

        public Result Compare1Pair()
        {
            int a = Array.IndexOf(CardRanksInHand1, 2);
            int b = Array.IndexOf(CardRanksInHand2, 2);

            if (a < b) return Result.Win;
            if (a > b) return Result.Loss;

            for (int i = 0; i < 3; i++)
            {
                a = Array.IndexOf(CardRanksInHand1, 1);
                b = Array.IndexOf(CardRanksInHand2, 1);

                if (a < b) return Result.Win;
                if (a > b) return Result.Loss;

                CardRanksInHand1[a] = 0;
                CardRanksInHand2[b] = 0;
            }
            return Result.Tie;
        }

        public Result CompareNothing()
        {
            int a;
            int b;
            for (int i = 0; i < 5; i++)
            {
                a = Array.IndexOf(CardRanksInHand1, 1);
                b = Array.IndexOf(CardRanksInHand2, 1);

                Console.WriteLine("CompareNothing: a=" + a + ",b=" + b);

                if (a < b) return Result.Win;
                if (a > b) return Result.Loss;

                CardRanksInHand1[a] = 0;
                CardRanksInHand2[b] = 0;
            }
            return Result.Tie;
        }

        public Result CompareWith(PokerHand hand)
        {
            Hand2 = hand.hand;

            CardRanksInHand1 = DetermineCardRanksOfHand(Hand1);
            CardRanksInHand2 = DetermineCardRanksOfHand(Hand2);

            int hand1Value = ComputeHandCombination(Hand1, CardRanksInHand1);
            int hand2Value = ComputeHandCombination(Hand2, CardRanksInHand2);

            if (hand1Value > hand2Value) return Result.Win;
            else if (hand1Value < hand2Value) return Result.Loss;
            else
            {
                // Both players have the same combination type, extra comparison is needed
                switch (hand1Value)
                {
                    case 900: // both players have a 4 of a kind
                        return Compare4OfAKind();
                    case 800: // both players have a full house
                        return CompareFullHouse();
                    case 700: // both players have a non-straight flush, compare card height
                        return CompareNothing();
                    case 500: // both players have a 3 of a kind
                        return Compare3OfAKind();
                    case 400: // both players have two pairs
                        return Compare2Pairs();
                    case 300: // both players have an one pair
                        return Compare1Pair();
                    case 200: // both players have nothing, compare card height
                        return CompareNothing();
                    default:
                        return Result.Tie;
                }
            }
        }
    }
}

