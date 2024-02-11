using Microsoft.VisualBasic;
using System;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Reflection;

Console.WriteLine("Advant of code 2023, day 8, part 2");
string fileName = "input.txt";
//string fileName = "test.txt";

//result 13524038372771

List<string> startingFromAll = new List<string>();


var lines = File.ReadLines(fileName).ToArray();

string instructions = lines[0];
Dictionary<string, Tuple<string, string>> map = new Dictionary<string, Tuple<string, string>>(); 

for (int x =2; x< lines.Length; x++)
{

    var lineOriginal = lines[x];
    var inst = lineOriginal.Split('=');

    string currentPos = inst[0].TrimEnd(' ');
    string[] newPos = inst[1].Split(", ");
    string left = newPos[0].TrimStart(' ').TrimStart('(');
    string right = newPos[1].TrimEnd(')'); ;

    map.Add(currentPos, Tuple.Create(left, right));

    if (currentPos.EndsWith('A'))
    {
        startingFromAll.Add(currentPos);
    }

}

List<long> counters = new List<long>();

for (int Q = 0; Q < startingFromAll.Count; Q++)
{
    string startingFrom = startingFromAll[Q];
    int counter = 0;

    for (int x = 0; x < instructions.Length; x++)
    {

        counter++;

        char newInstruction = instructions[x];

        if (newInstruction == 'L')
        {
            startingFrom = map[startingFrom].Item1;
        }
        else
        {
            startingFrom = map[startingFrom].Item2;
        }

        if (startingFrom.EndsWith('Z'))
        {
            counters.Insert(Q, counter);
            break;
        }

        if (x == instructions.Length - 1)
        {
            x = -1;
        }
    }
}

foreach (var item in counters)
{
    Console.WriteLine($"Partial results: {item}");
}

Console.WriteLine($"Result 2: {LCM(counters)}");



// compute lcm from list of numbers
long LCM(List<long> numbers)
{
    return numbers.Aggregate(lcm);
}

// compute lcm from two numbers
 static long lcm(long a, long b)
{
    return Math.Abs(a * b) / GCD(a, b);
}

// compute gcd from two numbers
 static long GCD(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}
