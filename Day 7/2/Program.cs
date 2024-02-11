using Microsoft.VisualBasic;
using System;
using System.Collections.Immutable;

Console.WriteLine("Advant of code 2023, day 7, part 2");
string fileName = "input.txt";

//result 248750699

var lines = File.ReadLines(fileName);

char[] buffer = new char[13] { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };

List<HandSet> FiveOfAKindList = new List<HandSet>();
List<HandSet> FourOfAKindList = new List<HandSet>();
List<HandSet> FullHouseList = new List<HandSet>();
List<HandSet> ThreeOfAKindList = new List<HandSet>();
List<HandSet> TwoPairsList = new List<HandSet>();
List<HandSet> OnePairList = new List<HandSet>();
List<HandSet> HightCardList = new List<HandSet>();


foreach (var lineOriginal in lines)
{
    var game =  lineOriginal.Split(' ');
    var hand = new string(game[0].ToArray());
    var copy = new string(game[0].ToArray());
    var inputX = game[0];

    var bid = Convert.ToInt64(game[1]);

    HandSet T = new HandSet(hand, bid);
    bool found = false;


    

    if (CheckUnique(hand))
    {
        if (hand.Contains('J'))
        {
            char strongestCard = FindStrongestCard(hand);
            hand = ReplaceJokers(hand, strongestCard);
            copy = new string(hand);
        }
        else
        {
            //WE HAVE High card
            HightCardList.Add(T);
            continue;
        }
    }

    foreach (var el in buffer)
    {
        hand = ReplaceJokers(new string(game[0].ToArray()), el);
        if (hand.Count(c => c == el) == 5)
        {
            //WE HAVE FIVE OF A KIND
            FiveOfAKindList.Add(T);
            found = true;
            break;
        }
    }

    if (found)
        continue;

    foreach (var el in buffer)
    {
        hand = ReplaceJokers(new string(game[0].ToArray()), el);
        if (hand.Count(c => c == el) == 4)
        {
            //WE HAVE FOUR OF A KIND
            FourOfAKindList.Add(T);
            found = true;
            break;
        }
    }
    if (found)
        continue;

    foreach (var el in buffer)
    {
        hand = ReplaceJokers(new string(game[0].ToArray()), el);
        if (hand.Count(c => c == el) == 3) {

            hand = hand.Replace("" + el, "");
            if (hand[0] == hand[1])
            {
                //WE HAVE FULL HOUSE
                FullHouseList.Add(T);
                found = true;
                break;
            }
            else
            {
                //WE HAVE THREE OF A KIND
                ThreeOfAKindList.Add(T);
                found = true;
                break;

            }
        }
    }
    if (found)
        continue;


    foreach (var el in buffer)
    {
        hand = ReplaceJokers(new string(copy), el);
        bool foundDouble = false;
        if (hand.Count(c => c == el) == 2)
        {
            hand = hand.Replace("" + el, "");
            foreach (var el2 in buffer)
            {
                if (el2 == el)
                {
                    continue;
                }

                if (hand.Count(c => c == el2) == 2)
                {
                    //WE HAVE TWO PAIR
                    TwoPairsList.Add(T);
                    foundDouble = true;
                    found = true;
                    break;
                }
            }
            if (!foundDouble)
            {
                //WE HAVE ONE PAIR
                OnePairList.Add(T);
                found = true;
                break;
            }
            else
            {
                break;
            }


        }    
    }
    if (found)
        continue;

    throw new Exception("Unexpected");

}

FiveOfAKindList.Sort();
FourOfAKindList.Sort();
FullHouseList.Sort();
ThreeOfAKindList.Sort();
TwoPairsList.Sort();
OnePairList.Sort();
HightCardList.Sort();

bool debug = false;
if (debug)
{
    System.Console.WriteLine("FiveOfAKindList");
    foreach (var item in FiveOfAKindList)
        System.Console.Write(item + ", ");
    System.Console.WriteLine(" ");

    System.Console.WriteLine("FourOfAKindList");
    foreach (var item in FourOfAKindList)
        System.Console.Write(item + ", ");
    System.Console.WriteLine(" ");

    System.Console.WriteLine("FullHouseList");
    foreach (var item in FullHouseList)
        System.Console.Write(item + ", ");
    System.Console.WriteLine(" ");

    System.Console.WriteLine("ThreeOfAKindList");
    foreach (var item in ThreeOfAKindList)
        System.Console.Write(item + ", ");
    System.Console.WriteLine(" ");

    System.Console.WriteLine("TwoPairsList");
    foreach (var item in TwoPairsList)
        System.Console.Write(item + ", ");
    System.Console.WriteLine(" ");

    System.Console.WriteLine("OnePairList");
    foreach (var item in OnePairList)
        System.Console.Write(item + ", ");
    System.Console.WriteLine(" ");

    System.Console.WriteLine("HightCardList");
    foreach (var item in HightCardList)
        System.Console.Write(item + ", ");
    System.Console.WriteLine(" ");
}


long result = 0;
int index = 1;

foreach (var item in HightCardList)
{

    item.Rang = index;
    item.Sum = item.Rang * item.Item2;
    result += item.Sum;
    index++;
    if (debug)
        System.Console.WriteLine($"{item} {item.Item2}x{item.Rang}={item.Sum}");
}
if (debug)
    System.Console.WriteLine(" ");
foreach (var item in OnePairList)
{

    item.Rang = index;
    item.Sum = item.Rang * item.Item2;
    result += item.Sum;
    index++;
    if (debug)
        System.Console.WriteLine($"{item} {item.Item2}x{item.Rang}={item.Sum}");
}
if (debug)
    System.Console.WriteLine(" ");
foreach (var item in TwoPairsList)
{

    item.Rang = index;
    item.Sum = item.Rang * item.Item2;
    result += item.Sum;
    index++;
    if (debug)
        System.Console.WriteLine($"{item} {item.Item2}x{item.Rang}={item.Sum}");

}
if (debug)
    System.Console.WriteLine(" ");
foreach (var item in ThreeOfAKindList)
{
    item.Rang = index;
    item.Sum = item.Rang * item.Item2;
    result += item.Sum;
    index++;
    if (debug)
        System.Console.WriteLine($"{item} {item.Item2}x{item.Rang}={item.Sum}");

}
if (debug)
    System.Console.WriteLine(" ");
foreach (var item in FullHouseList)
{
    item.Rang = index;
    item.Sum = item.Rang * item.Item2;
    result += item.Sum;
    index++;
    if (debug)
        System.Console.WriteLine($"{item} {item.Item2}x{item.Rang}={item.Sum}");

}
if (debug)
    System.Console.WriteLine(" ");
foreach (var item in FourOfAKindList)
{

    item.Rang = index;
    item.Sum = item.Rang * item.Item2;
    result += item.Sum;
    index++;
    if (debug)
        System.Console.WriteLine($"{item} {item.Item2}x{item.Rang}={item.Sum}");

}
if (debug)
    System.Console.WriteLine(" ");

foreach (var item in FiveOfAKindList)
{

    item.Rang = index;
    item.Sum = item.Rang * item.Item2;
    result += item.Sum;
    index++;
    if (debug)
        System.Console.WriteLine($"{item} {item.Item2}x{item.Rang}={item.Sum}");

}
if (debug)
    System.Console.WriteLine(" ");
System.Console.WriteLine(" ");
System.Console.WriteLine($"RESULT 1: {result}");


bool CheckUnique(string str)
{
    string one = "";
    string two = "";
    for (int i = 0; i < str.Length; i++)
    {
        one = str.Substring(i, 1);
        for (int j = 0; j < str.Length; j++)
        {
            two = str.Substring(j, 1);
            if ((one == two) && (i != j))
                return false;
        }
    }
    return true;
}

string ReplaceJokers(string hand, char el)
{
    return hand.Replace('J', el);
}

char FindStrongestCard(string hand)
{

    foreach (var item in buffer)
    {
        if (hand.Contains(item))
        {
            return item;
        }
    }

    return hand[0];
}

public class HandSet : Tuple<string, long>, IComparable<HandSet>
{
    public string I1 { get; set; }
    public long I2 { get; set; }
    public long Rang  { get; set; }
    public long Sum  { get; set; }
    public HandSet(string item1, long item2) : base(item1, item2) 
    {
        I1 = item1;
        I2 = item2;
    }

    public int CompareTo(HandSet? other)
    {
        char[] cards = new char[13] { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };
        for (int x = 0; x < I1.Length; x++)
        {
            var item1 = I1[x];
            var item2 = other?.I1[x];

            if (item2.HasValue && item1 == item2.Value)
            {
                //same card, look at next card in set
                continue;
            }
            else
            {
                //SORT ASC => if first card is higher it will return negative number
                return Array.IndexOf(cards, item2) - Array.IndexOf(cards, item1);
            }

        }

        return 0;
    }
}