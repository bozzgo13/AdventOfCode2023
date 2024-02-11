using System.Security.Cryptography;

Console.WriteLine("Advant of code 2023, day 3, part 1");

string fileName = "input.txt";

bool debug = false;

//result 535078

var lines = File.ReadLines(fileName).ToList();


char[][] myTable = new char[lines.Count][];

for (int i = 0; i < lines.Count; i++)
{
    myTable[i] = new char[140];
    for (int j = 0; j < lines[i].Length; j++)
    {
        myTable[i][j] = lines[i][j];
    }
}

List<char> numbers = new List<char>(new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'});
List<char> symbols = new List<char>(new char[10] { '*', '=', '+', '%', '@', '#', '-', '/', '&', '$' });

int result = 0;

for (int i = 0; i < myTable.Length; i++)
{
    if (debug)
    {
        if (i == 0)
        {
            Console.WriteLine(lines[lines.Count - 1]);
            Console.WriteLine(lines[i]);
            Console.WriteLine(lines[i + 1]);
        }
        else if (i == myTable.Length - 1)
        {
            Console.WriteLine(lines[i - 1]);
            Console.WriteLine(lines[i]);
            Console.WriteLine(lines[0]);
        }
        else
        {
            Console.WriteLine(lines[i - 1]);
            Console.WriteLine(lines[i]);
            Console.WriteLine(lines[i + 1]);
        }
    }


    for (int j = 0; j < myTable[i].Length; j++)
    {

        if (numbers.Contains(myTable[i][j]))
        {
            bool symbolFound = false;
            string newNumber = "" + myTable[i][j];
            int numberLength = 1;
            //how long is the number
            while ((j + numberLength) < myTable[i].Length && numbers.Contains(myTable[i][j+ numberLength]))
            {
                newNumber += myTable[i][j + numberLength];
                numberLength++;
            }
            if (debug)
            {
                System.Console.WriteLine($"number:{newNumber}, length:{numberLength}");
            }

            //Search for symbols in previous line
            for (int k = j-1; k < j+ numberLength + 1; k++)
            {
                //if we are in first line, than prevous line is actualy the last line
                int X = (i == 0) ? lines.Count - 1 : i-1;
                // k = from j-1 to  j + numberLength + 1
                int Y = k;

                //k goes from one char position before ouer number to one char position after our number
                //if first digit starts on position 0, this means that one char before is actualy the last char in string
                if (k < 0)
                {
                    Y = myTable[X].Length - 1;
                }
                //if last digit is the last char in string, then k is 0
                if (k > myTable[X].Length - 1)
                {
                    Y = 0;
                }
                if (debug)
                {
                    Console.Write(myTable[X][Y]);
                }

                if (symbols.Contains(myTable[X][Y]))
                {
                    symbolFound = true;
                    break;
                }

            }
            if (debug)
                Console.WriteLine("");
            //Search for symbols in current line
            if (symbolFound == false)
            {
                //only needs to check one char before and one char after
                //but can appear that first digit is on begining of the line or last digit is on the end of the line

                //char on left side 
                int k = j - 1;
                int X = i;
                int Y = k;
                if (k < 0)
                {
                    Y = myTable[X].Length - 1;
                }

                if (symbols.Contains(myTable[X][Y]))
                {
                    symbolFound = true;
                }

                //char on right side 
                if (symbolFound == false)
                {
                    k = j + numberLength;
                    Y = k;
                    if (k > myTable[X].Length - 1)
                    {
                        Y = 0;
                    }
                    if (symbols.Contains(myTable[X][Y]))
                    {
                        symbolFound = true;
                    }
                }

            }
            //line after
            if (symbolFound == false)
            {
                for (int k = j - 1; k < j + numberLength + 1; k++)
                {
                    //če je zadnja vrstica potem naslednja vrstica je 0 vrstica
                    int X = (i==lines.Count - 1) ? 0 : i+1;
                    // k = from j-1 to  j + numberLength + 1
                    int Y = k;

                    //na začetku vrstice poglej zadnji element
                    if (k < 0)
                    {
                        Y = myTable[X].Length - 1;
                    }
                    //na koncu vrstice poglej prvi element
                    if (k > myTable[X].Length - 1)
                    {
                        Y = 0;
                    }
                    if (debug)
                        Console.Write(myTable[X][Y]);

                    if (symbols.Contains(myTable[X][Y]))
                    {
                        symbolFound = true;
                        break;
                    }

                }
            }
            if (debug)
                Console.WriteLine("");
            if (symbolFound)
            {

                result += System.Convert.ToInt32(newNumber);
            }

            j += numberLength;

        }
    }
}

Console.WriteLine($"Result: {result}");