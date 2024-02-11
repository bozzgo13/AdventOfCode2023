// See https://aka.ms/new-console-template for more information
using System;
using System.Numerics;

Console.WriteLine("Advent of code 2023, Day 5, part 1 and part 2");

string fileName = "input.txt";

//Answer 1 836040384
//Answer 2 10834440

var lines = File.ReadLines(fileName).ToList();

long[] seeds = lines[0].Split(": ")[1].Split(" ").Select(x=> Convert.ToInt64(x)).ToArray();

bool seedsToSoil = false;
bool soilToFertilizer = false;
bool fertilizerToWater = false;
bool waterToLight = false;
bool lightToTemperature = false;
bool temperatureToHumidity = false;
bool humidityToLocation = false;

RangeMap seedsToSoilMap = new RangeMap();
RangeMap soilToFertilizerMap = new RangeMap();
RangeMap fertilizerToWaterMap = new RangeMap();
RangeMap waterToLightMap = new RangeMap();
RangeMap lightToTemperatureMap = new RangeMap();
RangeMap temperatureToHumidityMap = new RangeMap();
RangeMap humidityToLocationMap = new RangeMap();



for (int i = 1; i < lines.Count; i++) { 

    string line = lines[i];

    if (line == string.Empty)
    {
        continue;
    }

    if (line == "seed-to-soil map:")
    {
        seedsToSoil = true;
        soilToFertilizer =
        fertilizerToWater =
        waterToLight =
        lightToTemperature =
        temperatureToHumidity =
        humidityToLocation = false;
        continue;
    }
    if (line == "soil-to-fertilizer map:")
    {
        soilToFertilizer = true;
        seedsToSoil = 
        fertilizerToWater = 
        waterToLight = 
        lightToTemperature = 
        temperatureToHumidity = 
        humidityToLocation = false;

        continue;
    }
    if (line == "fertilizer-to-water map:")
    {
        fertilizerToWater = true;
        seedsToSoil = 
        soilToFertilizer = 
        waterToLight = 
        lightToTemperature = 
        temperatureToHumidity = 
        humidityToLocation = false;

        continue;
    }
    if (line == "water-to-light map:")
    {
        waterToLight = true;
        seedsToSoil = 
        soilToFertilizer = 
        fertilizerToWater = 
        lightToTemperature = 
        temperatureToHumidity = 
        humidityToLocation = false;

        continue;
    }
    if (line == "light-to-temperature map:")
    {
        lightToTemperature = true;
        seedsToSoil = 
        soilToFertilizer = 
        fertilizerToWater =
        waterToLight = 
        temperatureToHumidity = 
        humidityToLocation = false;

        continue;
    }
    if (line == "temperature-to-humidity map:")
    {
        temperatureToHumidity = true;
        seedsToSoil = 
        soilToFertilizer = 
        fertilizerToWater = 
        waterToLight = 
        lightToTemperature = 
        humidityToLocation = false;

        continue;
    }
    if (line == "humidity-to-location map:")
    {
        humidityToLocation = true;
        seedsToSoil = 
        soilToFertilizer =
        fertilizerToWater =
        waterToLight = 
        lightToTemperature = 
        temperatureToHumidity = false;
        
        continue;
    }
    long[] numbers = line.Split(' ').Select(x => Convert.ToInt64(x)).ToArray();

    long destinationRangeStart = numbers[0]; 
    long sourceRangeStart = numbers[1];
    long rangeLength = numbers[2];

    if (seedsToSoil) 
    {
        seedsToSoilMap.AddRangeDefinition(destinationRangeStart, sourceRangeStart, rangeLength);
    }
    if (soilToFertilizer)
    {
        soilToFertilizerMap.AddRangeDefinition(destinationRangeStart, sourceRangeStart, rangeLength);
    }
    if (fertilizerToWater)
    {
        fertilizerToWaterMap.AddRangeDefinition(destinationRangeStart, sourceRangeStart, rangeLength);
    }
    if (waterToLight)
    {
        waterToLightMap.AddRangeDefinition(destinationRangeStart, sourceRangeStart, rangeLength);
    }
    if (lightToTemperature)
    {
        lightToTemperatureMap.AddRangeDefinition(destinationRangeStart, sourceRangeStart, rangeLength);
    }
    if (temperatureToHumidity)
    {
        temperatureToHumidityMap.AddRangeDefinition(destinationRangeStart, sourceRangeStart, rangeLength);
    }
    if (humidityToLocation)
    {
        humidityToLocationMap.AddRangeDefinition(destinationRangeStart, sourceRangeStart, rangeLength);
    }
}



long lowestLocationNumber = long.MaxValue;
long lowestLocationNumber2= long.MaxValue;


foreach (var seed in seeds)
{

    long x1 = seedsToSoilMap.Convert(seed);
    long x2 = soilToFertilizerMap.Convert(x1);
    long x3 = fertilizerToWaterMap.Convert(x2);
    long x4 = waterToLightMap.Convert(x3);
    long x5 = lightToTemperatureMap.Convert(x4);
    long x6 = temperatureToHumidityMap.Convert(x5);
    long x7 = humidityToLocationMap.Convert(x6);

    if (x7< lowestLocationNumber)
    {
        lowestLocationNumber = x7;
    }

}

Console.WriteLine($"Answer 1:{lowestLocationNumber}");

Console.WriteLine($"Starting part 2");
Console.WriteLine("This might take a while...");
for (int x = 0; x< seeds.Length; x+=2)
{
    long start = seeds[x];
    long length = seeds[x+1];

    Console.WriteLine($"{(x/2)+1}/{seeds.Length/2}");
    for (long y = start; y < start+length; y++)
    {
        long x1 = seedsToSoilMap.Convert(y);
        long x2 = soilToFertilizerMap.Convert(x1);
        long x3 = fertilizerToWaterMap.Convert(x2);
        long x4 = waterToLightMap.Convert(x3);
        long x5 = lightToTemperatureMap.Convert(x4);
        long x6 = temperatureToHumidityMap.Convert(x5);
        long x7 = humidityToLocationMap.Convert(x6);

        if (x7 < lowestLocationNumber2)
        {
            lowestLocationNumber2 = x7;  
        }
    }
}



Console.WriteLine($"Answer 2:{lowestLocationNumber2}");

public class RangeMap
{

    public List<RangeDefinition> _rDef { get; set; }
    public RangeMap()
    {
        _rDef = new List<RangeDefinition>();
    }

    public void AddRangeDefinition(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        long start = sourceRangeStart;
        long end = sourceRangeStart + rangeLength - 1;
        long diff = destinationRangeStart - sourceRangeStart;

        RangeDefinition el = new RangeDefinition();
        _rDef.Add(new RangeDefinition() { DestinationRangeStart = destinationRangeStart, SourceRangeStart= sourceRangeStart, RangeLength = rangeLength, Start = start, End = end, Diff = diff });
    }



    public long Convert(long inputNumber)
    {

        for (int i = 0; i < _rDef.Count; i++)
        {
            var el = _rDef[i];
            
            if (inputNumber >= el.Start && inputNumber < el.End)
            {
                return inputNumber + el.Diff;

            }
        }
        return inputNumber;
    }

}
public class RangeDefinition
{
    public long DestinationRangeStart { get; set; }
    public long SourceRangeStart { get; set; }
    public long RangeLength { get; set; }


    public long Start { get; set; }
    public long End { get; set; }
    public long Diff { get; set; }
}