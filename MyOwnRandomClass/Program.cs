
using System.Diagnostics;



MyRandom random = new();
List<int> intList = new List<int>();


for (int i = 0; i < 100; i++)
{
    int test = random.Next(1, 100);
    intList.Add(test);
    Console.WriteLine(test);
}
random.PrintNumberOccurrenceData(intList, 1, 100);




class MyRandom
{
    private int GetSeed()
    {
        return Environment.TickCount;
    }
    private int GetLastDigitOfInteger(int seedInt)
    {
        return (seedInt % 10);
        //string tempSeedString = seedInt.ToString();    // Parse the int to a string
        //char lastChar = tempSeedString.LastOrDefault();    //Set char lastChar to the last char of the string .Iow Set "lastNumber" to the last "number" of the "Integer"
        //return int.Parse(tempSeedString);    // Parse the string back to an int and return it's value

    }

    public int Next(int low, int high)
    {


        int seedInt = GetSeed();
        for (int i = 0; i < 3; i++)
        {
            seedInt = seedInt * seedInt.ToString().Last() / NumberOfDigits(seedInt, 0);
        }
        String randomSeedStringFull = seedInt.ToString();
        int randomSeedInt = int.Parse(randomSeedStringFull.Substring(randomSeedStringFull.Length - NumberOfDigits(high, 0)));

        int randomInt = low;
        for (int i = 0; i <= randomSeedInt; i++)
        {
            randomInt++;
            if (randomInt > high)
            {
                randomInt = low;
            }
        }
        Thread.Sleep(1); // Change to StopWatch or use Async to free up thread 
        return randomInt;


    }

    public void PrintNumberOccurrenceData(List<int> intList, int low, int high)
    {
        int nrCounter;
        List<int> noOccurredInts = new();

        Console.WriteLine($"Total amount of Numbers in list : {intList.Count()}");
        for (int i = low; i <=high; i++)
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

    private void PrintExtremesData(List<int> intList, int low, int high)
    {
        int nrCounter=0; 
        int currentHighestCounter=0;
        int currentHighestNr = 0;
        for (int i = low;i<=high;i++)
        {
            nrCounter = intList.FindAll(x => x == i).Count();
            if (currentHighestCounter < nrCounter)
            {
                currentHighestCounter = nrCounter;
                currentHighestNr = i;
            }
        }
        Console.WriteLine($"The most commonly occured number was {currentHighestNr}, which occured {intList.FindAll(x=>x==currentHighestNr).Count} Times.");

    }

    private int NumberOfDigits(int number, int noDigits)
    {
        if (number == 0)
        {
            return noDigits;
        }
        return NumberOfDigits(number / 10, ++noDigits);
    }
}