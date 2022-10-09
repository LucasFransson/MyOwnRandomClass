
MyRandom random = new();
List<int> intList = new List<int>();

for (int i = 0; i < 1000; i++)
{
    int test = random.Next(1, 100);
    intList.Add(test);
    Console.WriteLine(test);

}


random.PrintNumberOccurrenceData(intList, 1, 100);

class MyRandom
{
    public int GetSeed()
    {
        {
            return Environment.TickCount;
        }
    }

    public int Next(int low, int high)
    {
        int seedInt = GetSeed(); 
        for (int i = 0; i < 3; i++)
        {
            seedInt = seedInt* seedInt.ToString().Last() / NumberOfDigits(seedInt,0);
        }
        String randomSeedStringFull = seedInt.ToString(); 
        int randomSeedInt = int.Parse(randomSeedStringFull.Substring(randomSeedStringFull.Length-NumberOfDigits(high,0)));

        int randomInt = low;  
        for (int i = 0; i <= randomSeedInt; i++)
        {
            randomInt++; 
            if (randomInt == high) 
            {
                randomInt = low; 
            }
        }
        Thread.Sleep(1); // byt ut till en timer 
        return randomInt; 
    }

    public void PrintNumberOccurrenceData(List<int> intList, int low, int high)
    {
        int nrCounter;
        List<int> noOccurredInts = new();

        Console.WriteLine($"Total amount of Numbers in list : {intList.Count()}");
        for (int i = low; i < high; i++)
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
    }

    public int NumberOfDigits(int number, int noDigits)
    {
        if (number == 0)
        {
            return noDigits;
        }
        return NumberOfDigits(number / 10, ++noDigits);
    }
}