using MyOwnRandomClass;







List<int> intList = new List<int>();     // Create an empty list to store the result from the RandomGenerator

for (int i = 0; i < 100; i++)
{
    int test = RandomGenerator.GetRandom(1, 100);
    intList.Add(test);
    Console.WriteLine(test);
}

RandomGenerator.PrintNumberOccurrenceData(intList, 1, 100);
Console.ReadKey();

intList.Clear();

for (int i = 0; i < 100; i++)
{
    int test = RandomGenerator.GetRandom(1, 1000);
    intList.Add(test);
    Console.WriteLine(test);
}

RandomGenerator.PrintNumberOccurrenceData(intList, 1, 1000);
Console.ReadKey();

intList.Clear();  

for (int i = 0; i <1000; i++)
{
    int test = RandomGenerator.GetRandom(1, 100000);
    intList.Add(test);
    Console.WriteLine(test);
}

RandomGenerator.PrintNumberOccurrenceData(intList, 1, 100000);