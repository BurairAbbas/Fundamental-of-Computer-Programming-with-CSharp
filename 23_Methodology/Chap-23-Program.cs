using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap23MethodolologyProblemSolving
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Excercise.MainEx();

            //DeckCards();

            // Test
            //TestShuffle52Cards();
            //TestShuffleOneCard();
            //TestShuffleTwoCards();
            //TestShuffleEmptyCardDeck();
            //TestShuffle52000Cards();

            //NumberSort();
            
            // Test
            //Test1000Number();
            //Test1number();
            //TestEmptyNumber();
            //Test100000Number();

        }

        static void NumberSort()
        {
            Console.WriteLine("Initial numbers: ");
            List<int> numbers = new List<int>() { 4, 5, 9, 10, 12, 15, 4, 2 };
            //numbers = new List<int>() { 1, 4, 5, 9, 10, 12, 15, 4, 2 };
            //numbers = new List<int>() { 4, 5, 9, 10, 1, 12, 15, 4, 2 };
            //numbers = new List<int>() { 4, 5, 9, 10, 12, 15, 4 };
            //PrintNumber(numbers);

            Console.WriteLine("After Method: ");
            SortNumber(numbers);
            //PrintNumber(numbers);

            //PrintDeleteLowestNumber(numbers);
            //PrintDeleteLowestNumber(numbers);
            //PrintNumber(numbers);
        }

        static void Test1000Number()
        {
            List<int> numbers = new List<int>();
            for (int i = 1000; i > 0; i--)
            {
                numbers.Add(i);
            }
            DateTime startTime = DateTime.Now;
            SortNumber(numbers);
            Console.WriteLine("Execute time: {0}", DateTime.Now - startTime);
        }
        static void Test1number()
        {
            List<int> numbers = new List<int>() { 1 };
            SortNumber(numbers);
        }
        static void TestEmptyNumber()
        {
            List<int> numbers = new List<int>();
            SortNumber(numbers);
        }
        static void Test100000Number()
        {
            List<int> numbers = new List<int>();
            for (int i = 10000; i > 0; i--)
            {
                numbers.Add(i);
            }
            DateTime startTime = DateTime.Now;
            SortNumber(numbers);
            Console.WriteLine("Execute time: {0}", DateTime.Now - startTime);

            int[] numbers2 = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                numbers2[i] = rnd.Next(2 * numbers2.Length);
            }

            DateTime startTime2 = DateTime.Now;
            SelectionSort(numbers2);
            PrintNumber(numbers2);
            Console.WriteLine("Execute time: {0}", DateTime.Now - startTime2);
        }

        static void PrintNumber(int[] numbers)
        {
            //foreach (int number in numbers)
            //{
            //    Console.Write(number + " ");
            //}
            //Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }

        static int FindLowestNumber(List<int> numbers)
        {
            int lowestNumber = numbers.Min();
            return lowestNumber;
        }

        static void PrintDeleteLowestNumber(List<int> numbers)
        {
            int lowestNumber = FindLowestNumber(numbers);
            Console.Write(lowestNumber + " ");
            numbers.Remove(lowestNumber);
        }

        static void SortNumber(List<int> numbers)
        {
            int count = numbers.Count;
            for (int i = 0; i < count; i++)
            {
                PrintDeleteLowestNumber(numbers);
            }
            Console.WriteLine();
        }

        static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int minIndex = i;
                for (int j =  i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int oldNumber = numbers[i];
                numbers[i] = numbers[minIndex];
                numbers[minIndex] = oldNumber;
            }
        }




        static void DeckCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card() { Face = "2", Suit = Suit.CLUB });
            cards.Add(new Card() { Face = "6", Suit = Suit.DIAMOND });
            cards.Add(new Card() { Face = "7", Suit = Suit.HEART });
            cards.Add(new Card() { Face = "A", Suit = Suit.SPADE });
            cards.Add(new Card() { Face = "J", Suit = Suit.CLUB });
            cards.Add(new Card() { Face = "10", Suit = Suit.DIAMOND });

            Console.WriteLine("Initial deck:");
            PrintCards(cards);

            ShuffleCards(cards);
            Console.WriteLine("After Shufle: ");
            PrintCards(cards);
        }

        static void TestShuffle52Cards()
        {
            List<Card> cards = new List<Card>();
            string[] allFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Suit[] allSuits = new Suit[] { Suit.DIAMOND, Suit.CLUB, Suit.HEART, Suit.HEART };

            foreach (string face in allFaces)
            {
                foreach (Suit suit in allSuits)
                {
                    Card card = new Card() { Face = face, Suit = suit };
                    cards.Add(card);
                }
            }
            PrintCards(cards);

            ShuffleCards(cards);
            PrintCards(cards);

        }
        static void TestShuffleOneCard()
        {
            List<Card> cards = new List<Card>();
            cards.Add( new Card() { Face = "A", Suit = Suit.CLUB });
            ShuffleCards(cards);
            PrintCards(cards);            
        }
        static void TestShuffleTwoCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add( new Card { Face = "A", Suit = Suit.CLUB });
            cards.Add(new Card { Face = "3", Suit = Suit.DIAMOND });
            
            ShuffleCards(cards);
            PrintCards(cards);
        }
        static void TestShuffleEmptyCardDeck()
        {
            List<Card> cards = new List<Card>();
            ShuffleCards(cards);
            PrintCards(cards);
        }
        static void TestShuffle52000Cards()
        {
            List<Card> cards = new List<Card>();
            string[] allFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Suit[] allSuits = new Suit[] { Suit.DIAMOND, Suit.CLUB, Suit.HEART, Suit.HEART };

            for (int i = 0; i < 52000; i++)
            {
                cards.Add(new Card() { Face = allFaces[rnd.Next(0, allFaces.Length)], Suit = allSuits[rnd.Next(0, allSuits.Length)] });
            }

            DateTime startTime = DateTime.Now;
            ShuffleCards(cards);
            Console.WriteLine("Execution time: {0}", DateTime.Now - startTime);
            //PrintCards(cards);
        }

        static void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.Write(card);
            }
            Console.WriteLine();
        }

        static void SingleSwap(List<Card> cards, int index)
        {
            int randomIndex = rnd.Next(0, cards.Count);
            Card firstCard = cards[index];
            Card randomCard = cards[randomIndex];
            cards[index] = randomCard;
            cards[randomIndex] = firstCard;
        }

        static void ShuffleCards(List<Card> cards)
        {
            if (cards.Count > 1)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    SingleSwap(cards, i);
                }
            }
        }
    }

    class Card
    {
        public string Face { get; set; }
        public Suit Suit { get; set; }

        public override string ToString()
        {
            string card = "(" + this.Face + " " + this.Suit + ")";
            return card;
        }
    }

    enum Suit
    {
        CLUB, DIAMOND, HEART, SPADE
    }
}
