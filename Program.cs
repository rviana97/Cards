using System;

namespace Cards
{
    class Program
    {
        const int cardCount = 5;

        static void Main(string[] args)
        {
            int[] cards = ReadConsoleInput();
            Console.WriteLine(CalculatePoints(cards));
        }

        private static int[] ReadConsoleInput()
        {
            int[] ret = new int[cardCount];
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.WriteLine("Please input " + cardCount + " space-separated integers");
                string input = Console.ReadLine();
                string[] cardStrings = input.Split(" ");

                if (cardStrings.Length == cardCount)
                {
                    isInputValid = true;
                    for (int i = 0; i < cardCount; i++)
                    {
                        if (!int.TryParse(cardStrings[i], out ret[i]))
                        {
                            isInputValid = false;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        private static int CalculatePoints(int[] cards)
        {
            return CountIdenticalValuePairs(cards) + CountGroupsThatSum(cards, 15);
        }

        private static int CountIdenticalValuePairs(int[] cards)
        {
            int pairCount = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                int currentFirstCard = cards[i];
                for (int j = i + 1; j < cards.Length; j++)
                {
                    int currentSecondCard = cards[j];
                    if (currentFirstCard == currentSecondCard)
                    {
                        pairCount++;
                    }
                }
            }
            return pairCount;
        }

        private static int CountGroupsThatSum(int[] cards, int sum)
        {
            int ret = 0;

            bool[] usedCards = new bool[cardCount];

            CountGroupsThatSumRecursive(cards, sum, 0, 0, usedCards, ref ret);

            return ret;
        }

        // Backtracking algorithm
        private static void CountGroupsThatSumRecursive(int[] cards, int targetSum, int currentSum, int currentPosition, bool[] usedCards, ref int groupCount)
        {
            for (int i = currentPosition; i < cards.Length; i++)
            {
                currentPosition = i;
                if (!usedCards[i] && currentSum < targetSum)
                {
                    currentSum = currentSum + cards[currentPosition];
                    usedCards[currentPosition] = true;

                    if (currentSum == targetSum)
                    {
                        groupCount++;
                    }
                    else
                    {
                        CountGroupsThatSumRecursive(cards, targetSum, currentSum, currentPosition + 1, usedCards, ref groupCount);
                    }

                    currentSum = currentSum - cards[currentPosition];
                    usedCards[currentPosition] = false;
                }
            }
        }
    }
}
