

//input file in Day1 folder (exe in net6.0 folder. Go backward - Day 1\1\adventofcode_2023_1\bin\Debug\net6.0)
string fileName = "..\\..\\..\\..\\..\\input.txt";

//result 55130

int endResult = 0;
IEnumerable<string> lines = null;

try
{
  lines = File.ReadLines(fileName);
  foreach (var lineOriginal in lines)
  {
    var line = lineOriginal.ToLower();
    var lineReverse = string.Concat(line.Reverse());

    char[] chars = { ' ', ' ' };
    string numberAsString = string.Empty;


    chars[0] = GetFirstDigit(line);
    chars[1] = GetFirstDigit(lineReverse);

    numberAsString = new string(chars);

    int result = System.Convert.ToInt32(numberAsString);
    endResult += result;

  }
}
catch (System.IO.FileNotFoundException fnfE)
{
  Console.WriteLine($"File not found : {fnfE.Message}");
  return;
}



Console.WriteLine($"result : {endResult}");


char GetFirstDigit(string line)
{
   
    for (int i = 0; i < line.Length; i++)
    {
        
        if (Char.IsDigit(line[i]))
        {
            return line[i];
        }

    }
    throw new Exception("No number");
}