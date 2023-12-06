
string fileName = "input.txt";

//result 55130

int endResult = 0;
var lines = File.ReadLines(fileName);
foreach (var lineOriginal in lines)
{
    var line = lineOriginal.ToLower();
    var lineReverse = string.Concat(line.Reverse());

    char[] chars = { ' ', ' ' };
    string numberAsString = string.Empty;


    chars[0] = GetDigit(line, false);
    chars[1] = GetDigit(lineReverse, true);

    numberAsString = new string(chars);

    int result = System.Convert.ToInt32(numberAsString);
    endResult += result;

}


Console.WriteLine($"result : {endResult}");


char GetDigit(string line, bool revert)
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