Console.WriteLine("Advant of code 2023, day 4, part 1 and 2");
string fileName = "input.txt";


//part 1 result 25010
//part 2 result 9924412


var lines = File.ReadLines(fileName);
long result = 0;

List<int> numberOfCards = new List<int>();


for (int x = 0; x< lines.Count(); x++)
{
    numberOfCards.Add(1);
}

int index = 0;

foreach (var lineOriginal in lines)
{

    var first = lineOriginal.Split(':');
    var second = first[1].Split('|');

    var left = second[0].Replace("  ", " ").Trim();
    var right = second[1].Replace("  ", " ").Trim();
    var winningNumbers = left.Split(' ');

    var myNumbers = right.Split(' ');
    int lineResult = 0;
    var count = 0;
    foreach (var my in myNumbers)
    {
        if (winningNumbers.Contains(my))
        {
            if (lineResult==0)
            {
                lineResult = 1;

            }
            else  
            {
                lineResult *= 2;
            }


            count++;
        }
    }

    Console.WriteLine(first[0] + $" number of cards => {numberOfCards[index]}" + $" winning numbers count => {count}");

    while (count > 0)
    {
        if(numberOfCards.Count > index + count)
        {
            numberOfCards[index + count] += numberOfCards[index];
        }

        count--;
    }


    result += lineResult;

    index++;
}
Console.WriteLine($"Answer 1: {result}");
Console.WriteLine($"Answer 2: {numberOfCards.Sum(x => x)}");