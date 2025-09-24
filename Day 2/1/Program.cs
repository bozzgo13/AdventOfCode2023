
Console.WriteLine("Advant of code 2023, day 2 part 1");
//input file in Day2 folder (exe in net7.0 folder. Go backward - Day 2\1\bin\Debug\net7.0)
string fileName = "..\\..\\..\\..\\input.txt";

//result 2377

IEnumerable<string>? lines = null;

try 
{
  lines = File.ReadLines(fileName);
}
catch (System.IO.FileNotFoundException fnfE)
{
  Console.WriteLine($"File not found : {fnfE.Message}");
  return;
}

int maxRed = 12, maxGreen = 13, maxBlue = 14;
int result = 0;

foreach (var lineOriginal in lines)
{

  //example of lineOriginal = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
  //example of ine = "1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
  var line = lineOriginal.Substring(5);

  int redCount= 0, greenCount = 0, blueCount = 0;
  //Examle of gameIndexAndResults = ["1", " 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"] 
  var gameIndexAndResults = line.Split(": ");
  //Examle of ID = 1
  int ID = System.Convert.ToInt32(gameIndexAndResults[0]);
  //Example of sets =
  //[
  //  " 3 blue, 4 red",
  //  " 1 red, 2 green, 6 blue",
  //  " 2 green"
  //]
  var sets = gameIndexAndResults[1].Split("; ");
    bool isOk = true;


    foreach (var singleSet in sets) {

    //example = [" 3 blue", " 4 red"]
    var colorGroup = singleSet.Split(",");

        foreach (var counterAndColor in colorGroup)
        {
      //example = ["3", "blue"]
      var w = counterAndColor.Trim().Split(" ");


      switch (w[1].ToLower())
            {
                case "green":
                    greenCount = System.Convert.ToInt32(w[0]);

                    if (greenCount > maxGreen)
                    {
                        isOk = false;
                    }
                    break;
                case "blue":
                    blueCount = System.Convert.ToInt32(w[0]);

                    if (blueCount > maxBlue)
                    {
                        isOk = false;
                    }
                    break;
                case "red":
                    redCount = System.Convert.ToInt32(w[0]);

                    if (redCount > maxRed)
                    {
                        isOk = false;
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
        result += ID;
    }
}

Console.WriteLine($"Result: {result}");