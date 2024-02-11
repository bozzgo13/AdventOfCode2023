using Microsoft.VisualBasic;
using System;
using System.Collections.Immutable;

Console.WriteLine("Advant of code 2023, day 8, part 1");
string fileName = "input.txt";
//string fileName = "test.txt";

//result 13019

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

}


int counter = 0;

string startingFrom = "AAA";
for (int x = 0; x < instructions.Length; x++)
{
    counter++;

    char newInstruction = instructions[x];

    if (newInstruction == 'L')
    {
        //Console.WriteLine("'" + startingFrom + "'" + ": L : '" + map[startingFrom].Item1 + "'");
        startingFrom = map[startingFrom].Item1;
    }
    else {
        //Console.WriteLine("'"+startingFrom+"'" + ": R : '" + map[startingFrom].Item2+"'");
        startingFrom = map[startingFrom].Item2; 
    }

    if (startingFrom=="ZZZ")
    {
        break;
    }


    if (x == instructions.Length - 1)
    {
        x = -1;
    }

}

Console.WriteLine($"Result: {counter}");

