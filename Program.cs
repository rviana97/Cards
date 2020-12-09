using System;

namespace Cards
{
    class Program
    {
        const int cardCount = 5;

        static void Main(string[] args)
        {
            int[] cards = ReadConsoleInput();
        }

        private static int[] ReadConsoleInput()
        {
            int[] ret = new int[cardCount];
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.WriteLine("Please input 5 space-separated integers");
                string input = Console.ReadLine();
                string[] cardStrings = input.Split(" ");

                if (cardStrings.Length == 5)
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
    }
}
