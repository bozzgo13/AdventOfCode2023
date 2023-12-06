
string fileName = "input.txt";

//result 54985

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
    string[] numbers = new string[9] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    char[] digits = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };


    for (int i = 0; i < line.Length; i++)
    {
       
        for (int j = 0; j < digits.Length; j++)
        {
            if (line.Substring(i).StartsWith( (revert) ? string.Concat(numbers[j].Reverse()) : numbers[j]))
            {
                return digits[j];
            }
        }
        
        if (Char.IsDigit(line[i]))
        {
            return line[i];
        }

    }
    throw new Exception("No number");
}