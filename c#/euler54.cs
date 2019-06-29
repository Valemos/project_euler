using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Windows.Forms;

//task
/*

In the card game poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:

    High Card: Highest value card.
    One Pair: Two cards of the same value.
    Two Pairs: Two different pairs.
    Three of a Kind: Three cards of the same value.
    Straight: All cards are consecutive values.
    Flush: All cards of the same suit.
    Full House: Three of a kind and a pair.
    Four of a Kind: Four cards of the same value.
    Straight Flush: All cards are consecutive values of same suit.
    Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.

The cards are valued in the order:
2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.

If two players have the same ranked hands then the rank made up of 
the highest value wins; for example, a pair of eights beats a pair of fives 
(see example 1 below). But if two ranks tie, for example, both players have
a pair of queens, then highest cards in each hand are compared (see example 4 below);
if the highest cards tie then the next highest cards are compared, and so on.

The file, poker.txt, contains one-thousand random hands dealt to two players. 
Each line of the file contains ten cards (separated by a single space): the first five 
are Player 1's cards and the last five are Player 2's cards. You can assume that all 
hands are valid (no invalid characters or repeated cards), each player's hand is in 
no specific order, and in each hand there is a clear winner.

How many hands does Player 1 win?
*/


namespace eu54_poker
{
    class Program
    {
        static string pokerPath = "poker.txt";
        
        static int compare(string el1,string el2)
        {
            int value = 0;
            foreach(char el in el1)
            {
                if (el == '2') { value += 1; continue; }
                if (el == '3') { value += 2; continue; }
                if (el == '4') { value += 3; continue; }
                if (el == '5') { value += 4; continue; }
                if (el == '6') { value += 5; continue; }
                if (el == '7') { value += 6; continue; }
                if (el == '8') { value += 7; continue; }
                if (el == '9') { value += 8; continue; }
                if (el == 'T') { value += 9; continue; }
                if (el == 'J') { value += 10; continue; }
                if (el == 'Q') { value += 11; continue; }
                if (el == 'K') { value += 12; continue; }
                if (el == 'A') { value += 13; continue; }

            }

            foreach(char el in el2)
            {
                if (el == '2') { value -= 1; continue; }
                if (el == '3') { value -= 2; continue; }
                if (el == '4') { value -= 3; continue; }
                if (el == '5') { value -= 4; continue; }
                if (el == '6') { value -= 5; continue; }
                if (el == '7') { value -= 6; continue; }
                if (el == '8') { value -= 7; continue; }
                if (el == '9') { value -= 8; continue; }
                if (el == 'T') { value -= 9; continue; }
                if (el == 'J') { value -= 10; continue; }
                if (el == 'Q') { value -= 11; continue; }
                if (el == 'K') { value -= 12; continue; }
                if (el == 'A') { value -= 13; continue; }

            }
            return value;
        }

        static int getValue(char ch)
        {
            int value = 0;
            if (ch == '2') value = 1;
            if (ch == '3') value = 2;
            if (ch == '4') value = 3;
            if (ch == '5') value = 4;
            if (ch == '6') value = 5;
            if (ch == '7') value = 6;
            if (ch == '8') value = 7;
            if (ch == '9') value = 8;
            if (ch == 'T') value = 9;
            if (ch == 'J') value = 10;
            if (ch == 'Q') value = 11;
            if (ch == 'K') value = 12;
            if (ch == 'A') value = 13;
            return value;
        }
        
        [STAThread]
        static void Main(string[] args)
        {
            int P1Wins = 0;

            FileStream fstrm = new FileStream(pokerPath,FileMode.Open);
            StreamReader sr = new StreamReader(fstrm);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] P1 = new string[5];
                string[] P2 = new string[5];
                string[] bothHands = line.Split();

                for(int l = 0;l<10;l++)
                {
                    if (l < 5)
                    {
                        P1[l] = bothHands[l];
                    }
                    else
                    {
                        P2[l - 5] = bothHands[l];
                    }
                }

                //sort Player 1 hand
                int sort = 0;
                while (sort <= 4)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        if (compare(P1[l], P1[l + 1]) < 0)
                        {
                            string prevP1 = P1[l];

                            P1[l] = P1[l + 1];
                            P1[l + 1] = prevP1;
                        }
                    }
                    sort++;
                }

                //sort Player 2 hand
                sort = 0;
                while (sort <= 4)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        if (compare(P2[l],P2[l + 1]) < 0)
                        {
                            string prevP2 = P2[l];

                            P2[l] = P2[l + 1];
                            P2[l + 1] = prevP2;
                        }
                    }
                    sort++;
                }


/*
    1-High Card: Highest value card.
    2-One Pair: Two cards of the same value.
    3-Two Pairs: Two different pairs.
    ---4-Three of a Kind: Three cards of the same value.
    ---5-Straight: All cards are consecutive values.
    ---6-Flush: All cards of the same suit.
    ---7-Full House: Three of a kind and a pair.
    8-Four of a Kind: Four cards of the same value.
    ---9-Straight Flush: All cards are consecutive values of same suit.
    ---10-Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.

The cards are valued in the order:
2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.

23456789TJQKA
*/
                //check for Royal Flush and Straight flush
                int value1 = 0;
                int value2 = 0;

                string h1 = "";
                string h2 = "";
                //separate combinations without suits
                for (int i = 0; i < 5; i++)
                {
                    h1 += P1[i].Substring(0, 1);
                    h2 += P2[i].Substring(0, 1);
                }
                //check for suit match
                int matchSuit = 0;
                for (int i = 0;i<3; i++)
                {
                    // AS KS QS JS TS (Royal Flush)
                    if (P1[i].Substring(1,1)== P1[i+1].Substring(1, 1)) matchSuit++;
                }
                //AKQJT98765432
                string[] consequent = { "AKQJT", "KQJT9", "QJT98", "JT987", "T9876", "98765", "87654", "76543", "65432" };
                for (int i = 0;i<consequent.Length;i++)
                {
                    if(h1 == consequent[i] && h1[0]=='A' && matchSuit == 4)
                    {
                        value1 = 1000 + getValue(h1[0]);
                        break;
                    }
                    else if(h1 == consequent[i] && matchSuit == 4)
                    {
                        Console.WriteLine();
                        value1 = 900 + getValue(h1[0]);
                        break;
                    }
                    else if(matchSuit == 4)
                    {
                        value1 = 600 + getValue(h1[0]);
                        break;
                    }
                    else if(h1 == consequent[i])
                    {
                        value1 = 500 + getValue(h1[0]);
                        break;
                    }
                }
                
                    //four of a kind
                if(value1 == 0)
                {
                    for(int i = 0; i < 2; i++)
                    {
                        if (h1[i] == h1[i+1] && h1[i] == h1[i+2] && h1[i] == h1[i+3])
                        {
                            value1 = 800 + getValue(h1[i]);
                            break;
                        }
                    }

                }


                    //full house
                    if ((h1[0] == h1[1] && h1[0] == h1[2] && h1[3] == h1[4]) && value1 == 0)
                    {
                        //AAA99
                        value1 = 700 + getValue(h1[0]);
                    }else
                    if((h1[0] == h1[1] && h1[2] == h1[3] && h1[2] == h1[4]) && value1==0)
                    {
                        //AA999
                        value1 = 700 + getValue(h1[2]);
                    }

                    //three of a kind
                    if (value1 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (h1[i] == h1[i + 1] && h1[i] == h1[i + 2])
                            {
                                value1 = 400 + getValue(h1[i]);
                                break;
                            }
                        }
                    }

                    //pairs QQ4AA
                    if (value1 == 0)
                    {
                        int pairs = 0;
                        char highestPair = '0';
                        for (int i = 0; i < 4; i ++)
                        {
                            if (h1[i] == h1[i + 1])
                            {
                                if (pairs == 0) highestPair = h1[i];
                                pairs++;
                            }
                        }
                        if(pairs == 1)
                        {
                            value1 = 200 + getValue(highestPair); 
                        }else if(pairs == 2)
                        {
                            value1 = 300 + getValue(highestPair);
                        }
                    }

                    //highest card
                    if(value1 == 0)
                    {
                        value1 = 100 + getValue(h1[0]);
                    }

                //player 2
                matchSuit = 0;
                for (int i = 0; i < 3; i++)
                {
                    // AS KS QS JS TS
                    if (P2[i].Substring(1, 1) == P2[i + 1].Substring(1, 1)) matchSuit++;
                }

                for (int i = 0; i < consequent.Length; i++)
                {
                    if (h2 == consequent[i] && h2[0] == 'A' && matchSuit == 4)
                    {
                        value2 = 1000 + getValue(h2[0]);
                        break;
                    }
                    else if (h2 == consequent[i] && matchSuit == 4)
                    {
                        value2 = 900 + getValue(h2[0]);
                        break;
                    }
                    else if (h2 == consequent[i])
                    {
                        value2 = 500 + getValue(h2[0]);
                        break;
                    }
                }
                    if (matchSuit == 4)
                    {
                        value2 = 600 + getValue(h2[0]);
                        break;
                    }
                    

                if (value2 == 0)
                {
                    //four of a kind
                    for (int i = 0; i < 2; i++)
                    {
                        if (h2[i] == h2[i + 1] && h2[i] == h2[i + 2] && h2[i] == h2[i + 3])
                        {
                            value2 = 800 + getValue(h2[0]);
                            break;
                        }
                    }


                    //full house
                    if ((h2[0] == h2[1] && h2[0] == h2[2] && h2[3] == h2[4]) && value2 == 0)
                    {
                        //AAA99
                        value2 = 700 + getValue(h2[0]);
                    }
                    else
                    if ((h2[0] == h2[1] && h2[2] == h2[3] && h2[2] == h2[4]) && value2 == 0)
                    {
                        value2 = 700 + getValue(h2[2]);
                    }

                    //three of a kind
                    if (value2 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (h2[i] == h2[i + 1] && h2[i] == h2[i + 2])
                            {
                                value2 = 400 + getValue(h2[i]);
                                break;
                            }
                        }
                    }

                    //pairs
                    if (value2 == 0)
                    {
                        int pairs = 0;
                        char[] highestPair = new char[2];
                        int g = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (h2[i] == h2[i + 1])
                            {
                                highestPair[g] = h2[i];
                                pairs++;
                                g++;
                            }
                        }
                        if (pairs == 1)
                        {
                            value2 = 200 + getValue(highestPair[0]);
                        }
                        else if (pairs == 2)
                        {
                            value2 = 300 + getValue(highestPair[0]);
                        }
                    }

                    //highest card
                    if (value2 == 0)
                    {
                        value2 = 100 + getValue(h2[0]);
                    }
                }

                if (value1 > value2)
                {
                    P1Wins++;
                }else if(value1 == value2)
                {
                    int high1 = value1 % 100;
                    int high2 = value2 % 100;
                    int newHigh1 = 0;
                    int newHigh2 = 0;

                    for(int i = 0; i < 5; i++)
                    {
                        newHigh1 = getValue(h1[i]);
                        newHigh2 = getValue(h2[i]);

                            if ((newHigh1 > newHigh2) && 
                                (newHigh1 != high1 || newHigh2 != high2))
                            {
                                P1Wins++;
                                break;
                            }
                    }
                }
            }

            SystemSounds.Exclamation.Play();
            Clipboard.SetText(Convert.ToString(P1Wins));
        }
    }
}
