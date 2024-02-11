
using System;
using System.Numerics;

Console.WriteLine("Advent of code 2023, Day 6 part 1 and part 2");
{
    int[] times = new int[] { 46, 80, 78, 66 };
    int[] minDistances = new int[] { 214, 1177, 1402, 1024 };

    int[] results = new int[4];


    for (int j = 0;j < times.Length; j++)
    {

        int counter = 0;
        for (int i = 1; i < times[j]; i++)
        {
            int speed = i;
            int distance = speed * (times[j] - i);

            if (distance > minDistances[j])
                counter++;

        }

        results[j] = counter;

    }

    int endResult = 1;

    for (int j = 0; j < times.Length; j++)
    {
        endResult *= results[j];
    }

    Console.WriteLine($"Answer 1: {endResult}");
}
{
    long time = 46807866;
    long minDistance = 214117714021024;

    long counter = 0;
    for (long i = 1; i < time; i++)
    {
        long speed = i;
        long distance = speed * (time - i);

        if (distance > minDistance)
            counter++;
    }

    Console.WriteLine($"Answer 2: {counter}");
}