using System.Security.Cryptography;

namespace adventofcode_2023_3_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Advant of code 2023, day 3, part 2");

            string fileName = "input.txt";

            bool debug = false;

            //result 75312571

            var lines = File.ReadLines(fileName).ToList();


            char[][] engSch = new char[lines.Count][]; //engSch = engine schematic

            for (int i = 0; i < lines.Count; i++)
            {
                engSch[i] = new char[140];
                for (int j = 0; j < lines[i].Length; j++)
                {
                    engSch[i][j] = lines[i][j];
                }
            }

            List<char> numbers = new List<char>(new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            List<char> symbols = new List<char>(new char[1] { '*' });

            Dictionary<int, Dictionary<int, EnginePart>> engineParts = new Dictionary<int, Dictionary<int, EnginePart>>();



            for (int i = 0; i < engSch.Length; i++)
            {
                if (debug)
                {
                    PrintLine(lines, i);
                }

                for (int j = 0; j < engSch[i].Length; j++)
                {

                    if (numbers.Contains(engSch[i][j]))
                    {
                        bool symbolFound = false;
                        char? foundedSymbol = null;
                        int symbolXposition = 0;
                        int symbolYposition = 0;
                        string newNumber = "" + engSch[i][j];
                        int numberLength = 1;
                        //how long is the number
                        while (j + numberLength < engSch[i].Length && numbers.Contains(engSch[i][j + numberLength]))
                        {
                            newNumber += engSch[i][j + numberLength];
                            numberLength++;
                        }
                        if (debug)
                        {
                            Console.WriteLine($"number:{newNumber}, length:{numberLength}");
                        }

                        //Search for symbols in previous line
                        for (int k = j - 1; k < j + numberLength + 1; k++)
                        {
                            //if we are in first line, than prevous line is actualy the last line
                            int X = i == 0 ? lines.Count - 1 : i - 1;
                            // k = from j-1 to  j + numberLength + 1
                            int Y = k;

                            //k goes from one char position before ouer number to one char position after our number
                            //if first digit starts on position 0, this means that one char before is actualy the last char in string
                            if (k < 0)
                            {
                                Y = engSch[X].Length - 1;
                            }
                            //if last digit is the last char in string, then k is 0
                            if (k > engSch[X].Length - 1)
                            {
                                Y = 0;
                            }
                            if (debug)
                            {
                                Console.Write(engSch[X][Y]);
                            }

                            if (symbols.Contains(engSch[X][Y]))
                            {
                                symbolXposition = X;
                                symbolYposition = Y;
                                foundedSymbol = engSch[X][Y];
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
                                Y = engSch[X].Length - 1;
                            }

                            if (symbols.Contains(engSch[X][Y]))
                            {
                                symbolXposition = X;
                                symbolYposition = Y;
                                foundedSymbol = engSch[X][Y];
                                symbolFound = true;
                            }

                            //char on right side 
                            if (symbolFound == false)
                            {
                                k = j + numberLength;
                                Y = k;
                                if (k > engSch[X].Length - 1)
                                {
                                    Y = 0;
                                }
                                if (symbols.Contains(engSch[X][Y]))
                                {
                                    symbolXposition = X;
                                    symbolYposition = Y;
                                    foundedSymbol = engSch[X][Y];
                                    symbolFound = true;
                                }
                            }

                        }
                        //line after
                        if (symbolFound == false)
                        {
                            for (int k = j - 1; k < j + numberLength + 1; k++)
                            {
                                //if we are in last line, then next line is first line
                                int X = i == lines.Count - 1 ? 0 : i + 1;
                                // k = from j-1 to  j + numberLength + 1
                                int Y = k;

                                //na začetku vrstice poglej zadnji element
                                if (k < 0)
                                {
                                    Y = engSch[X].Length - 1;
                                }
                                //na koncu vrstice poglej prvi element
                                if (k > engSch[X].Length - 1)
                                {
                                    Y = 0;
                                }
                                if (debug)
                                    Console.Write(engSch[X][Y]);

                                if (symbols.Contains(engSch[X][Y]))
                                {
                                    symbolXposition = X;
                                    symbolYposition = Y;
                                    foundedSymbol = engSch[X][Y];
                                    symbolFound = true;
                                    break;
                                }

                            }
                        }
                        if (debug)
                            Console.WriteLine("");
                        if (symbolFound)
                        {
                            if (!engineParts.ContainsKey(symbolXposition))
                            {
                                EnginePart ep = new EnginePart() { PartSymbol = foundedSymbol.Value, XPoz = symbolXposition, YPoz = symbolYposition };
                                ep.ConnectedNumbers.Add(Convert.ToInt32(newNumber));

                                Dictionary<int, EnginePart> enginePartLine = new Dictionary<int, EnginePart>
                                {
                                    { symbolYposition, ep }
                                };

                                engineParts.Add(symbolXposition, enginePartLine);
                            }
                            else if (!engineParts[symbolXposition].ContainsKey(symbolYposition))
                            {
                                EnginePart ep = new EnginePart()
                                {
                                    PartSymbol = foundedSymbol.Value,
                                    XPoz = symbolXposition,
                                    YPoz = symbolYposition
                                };
                                ep.ConnectedNumbers.Add(Convert.ToInt32(newNumber));

                                engineParts[symbolXposition].Add(symbolYposition, ep);

                            }
                            else
                            {
                                engineParts[symbolXposition][symbolYposition].ConnectedNumbers.Add(Convert.ToInt32(newNumber)); ;
                            }   
                        }

                        j += numberLength;

                    }
                }
            }

            int result = 0;
            foreach (var item1 in engineParts)
            {
                foreach (var item2 in item1.Value)
                {
                    EnginePart part = item2.Value;

                    if (part.ConnectedNumbers.Count == 1)
                        continue;

                    result += part.ConnectedNumbers.Aggregate((a, x) => a * x); ;
                    if (debug)
                        Console.WriteLine("("+part.XPoz+","+ part.YPoz+") \t"+part.PartSymbol+ " (" +string.Join(',', part.ConnectedNumbers) + ")");
                }

            }

            Console.WriteLine($"Result: {result}");

        }
        static void PrintLine(List<string> lines, int lineIndex)
        {

            if (lineIndex == 0)
            {
                Console.WriteLine(lines[lines.Count - 1]);
                Console.WriteLine(lines[lineIndex]);
                Console.WriteLine(lines[lineIndex + 1]);
                return;
            }

            if (lineIndex == lines.Count - 1)
            {
                Console.WriteLine(lines[lineIndex - 1]);
                Console.WriteLine(lines[lineIndex]);
                Console.WriteLine(lines[0]);
                return;
            }

            Console.WriteLine(lines[lineIndex - 1]);
            Console.WriteLine(lines[lineIndex]);
            Console.WriteLine(lines[lineIndex + 1]);
        }
    }
}