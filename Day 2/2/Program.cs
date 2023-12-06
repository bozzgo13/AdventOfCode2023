// See https://aka.ms/new-console-template for more information

Console.WriteLine("Advant of code 2023, day 2, part 2");
string fileName = "input.txt";

//result 71220

var lines = File.ReadLines(fileName);

int maxRed = 0, maxGreen = 0, maxBlue = 0;
int result = 0;

foreach (var lineOriginal in lines)
{
    var line = lineOriginal.Substring(5);
    maxRed = 0; 
    maxGreen = 0;
    maxBlue = 0;

    int redCount= 0, greenCount = 0, blueCount = 0;

    var  x = line.Split(": ");
    int ID = System.Convert.ToInt32(x[0]);
    var  y = x[1].Split("; ");
    bool isOk = true;

    foreach (var yy in y) {

        var z = yy.Split(", ");

        foreach (var zz in z)
        {
            var w = zz.Split(" ");


            switch (w[1].ToLower())
            {
                case "green":
                    greenCount = System.Convert.ToInt32(w[0]);

                    if (greenCount > maxGreen)
                    {
                        maxGreen = greenCount;
                    }
                    break;
                case "blue":
                    blueCount = System.Convert.ToInt32(w[0]);

                    if (blueCount > maxBlue)
                    {
                        maxBlue = blueCount;
                    }
                    break;
                case "red":
                    redCount = System.Convert.ToInt32(w[0]);

                    if (redCount > maxRed)
                    {
                        maxRed = redCount;
                    }
                    break;
                default:
                    break;
            }
 
        }

        if (!isOk)
        {
            break;
        }
       
    }
    if (isOk)
    {
        result += maxRed * maxBlue * maxGreen;
    }

}

Console.WriteLine($"Result: {result}");