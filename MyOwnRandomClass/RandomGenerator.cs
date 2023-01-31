using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnRandomClass
{
    public static class RandomGenerator
    {
        private static int GetSeed()
        {
            return Environment.TickCount;       // MilliSeconds since system started
        }

        // Returns the last digit of an Integer.    This Method is used in an attempt to randomize the seed Quickly without the need/risk for extremely big iterations.
        private static int GetLastDigitOfInteger(int seedInt)
        {
            return (seedInt % 10);

        }
        // Returns the amount of digits in 'number'
        private static int GetDigitsAmountOfInteger(int number, int noDigits)
        {
            if (number == 0)
            {
                return noDigits;
            }
            return GetDigitsAmountOfInteger(number / 10, ++noDigits);
        }

        public static int GetRandom(int low, int high)
        {


            int seedInt = GetSeed();
            for (int i = 0; i < 3; i++)
            {
                seedInt = seedInt * seedInt.ToString().Last() / GetDigitsAmountOfInteger(seedInt, 0);
            }
            String randomSeedStringFull = seedInt.ToString();
            int randomSeedInt = int.Parse(randomSeedStringFull.Substring(randomSeedStringFull.Length - GetDigitsAmountOfInteger(high, 0)));

            int randomInt = low;
            for (int i = 0; i <= randomSeedInt; i++)
            {
                randomInt++;
                if (randomInt > high)
                {
                    randomInt = low;
                }
            }
            Thread.Sleep(1); // Sleep for 1 millisecond to prevent the same Value returned if called quickly
            return randomInt;

        }


        // Prints Number Occurence Data for Analyzing purposes to check large amounts of outputs
        public static void PrintNumberOccurrenceData(List<int> intList, int low, int high)
        {
            int nrCounter;
            List<int> noOccurredInts = new();

            Console.WriteLine($"Total amount of Numbers in list : {intList.Count()}");
            for (int i = low; i <= high; i++)
            {
                if (intList.Contains(i))
                {

                    nrCounter = intList.FindAll(x => x == i).Count();
                    Console.WriteLine($"Number {i} Occurred : {nrCounter} Times");
                }
                else
                {
                    noOccurredInts.Add(i);
                }
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine($"The following numbers did not occur in the list: ");
            if (noOccurredInts.Count < 1)
            {
                Console.Write("No numbers found. All numbers between input parameters occurred.");
            }
            else
            {
                foreach (int i in noOccurredInts)
                {
                    Console.Write($"[{i}], ");
                }
            }
            Console.WriteLine("\r\n----------------------------");
            PrintExtremesData(intList, low, high);
        }

        // Prints The Extremes of the output Data for Analyzing purposes to check for repeating patterns or obvious errors.
        private static void PrintExtremesData(List<int> intList, int low, int high)
        {
            int nrCounter = 0;
            int currentHighestCounter = 0;
            int currentHighestNr = 0;
            for (int i = low; i <= high; i++)
            {
                nrCounter = intList.FindAll(x => x == i).Count();
                if (currentHighestCounter < nrCounter)
                {
                    currentHighestCounter = nrCounter;
                    currentHighestNr = i;
                }
            }
            Console.WriteLine($"The most commonly occured number was {currentHighestNr}, which occured {intList.FindAll(x => x == currentHighestNr).Count} Times.");

        }
    }
}
