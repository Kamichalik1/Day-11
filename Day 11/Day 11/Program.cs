using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Constructor
            string[] lines = System.IO.File.ReadAllLines(@"E:\Advent Code\Day 11\Data.txt");

            string[,] SeatPlan = new string[lines[0].Length, lines.Length];
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    SeatPlan[x, y] = lines[y].Substring(x, 1);
                }
            }


            //Main
            int PreviousOccupiedSeats = 0;
            bool Stable = false;

            while (Stable == false)
            {
                //New Generator
                string[,] NewSeatPlan = new string[lines[0].Length, lines.Length];
                for (int y = 0; y < SeatPlan.GetLength(1); y++)
                {
                    for (int x = 0; x < SeatPlan.GetLength(0); x++)
                    {
                        int OccupiedAdjecentSeats = 0;

                        //Top Left
                        if (x > 0 && y > 0)
                        {
                            if (SeatPlan[x - 1, y - 1] == "#") OccupiedAdjecentSeats++;
                        }
                        //Left
                        if (x > 0)
                        {
                            if (SeatPlan[x - 1, y] == "#") OccupiedAdjecentSeats++;
                        }
                        //Bottom Left
                        if (x > 0 && y + 1 < SeatPlan.GetLength(1))
                        {
                            if (SeatPlan[x - 1, y + 1] == "#") OccupiedAdjecentSeats++;
                        }

                        //Up
                        if (y > 0)
                        {
                            if (SeatPlan[x, y - 1] == "#") OccupiedAdjecentSeats++;
                        }
                        //Down
                        if (y + 1 < SeatPlan.GetLength(1))
                        {
                            if (SeatPlan[x, y + 1] == "#") OccupiedAdjecentSeats++;
                        }

                        //Top Right
                        if (x + 1 < SeatPlan.GetLength(0) && y > 0)
                        {
                            if (SeatPlan[x + 1, y - 1] == "#") OccupiedAdjecentSeats++;
                        }
                        //Right
                        if (x + 1 < SeatPlan.GetLength(0))
                        {
                            if (SeatPlan[x + 1, y] == "#") OccupiedAdjecentSeats++;
                        }
                        //Bottom Right
                        if (x + 1 < SeatPlan.GetLength(0) && y + 1 < SeatPlan.GetLength(1))
                        {
                            if (SeatPlan[x + 1, y + 1] == "#") OccupiedAdjecentSeats++;
                        }


                        if (SeatPlan[x, y] == "L" && OccupiedAdjecentSeats == 0)
                        {
                            NewSeatPlan[x, y] = "#";
                        }
                        else if (SeatPlan[x, y] == "#" && OccupiedAdjecentSeats >= 4)
                        {
                            NewSeatPlan[x, y] = "L";
                        }
                        else
                        {
                            NewSeatPlan[x, y] = SeatPlan[x, y];
                        }

                    }
                }

                //New Occipued Counter
                int OccupiedSeats = 0;
                for (int y = 0; y < SeatPlan.GetLength(1); y++)
                {
                    for (int x = 0; x < SeatPlan.GetLength(0); x++)
                    {
                        if (NewSeatPlan[x, y] == "#") OccupiedSeats++;
                    }
                }

                //Cloner/Completer
                if (OccupiedSeats == PreviousOccupiedSeats)
                {
                    Stable = true;
                    PreviousOccupiedSeats = OccupiedSeats;
                }
                else
                {
                    PreviousOccupiedSeats = OccupiedSeats;

                    for (int y = 0; y < SeatPlan.GetLength(1); y++)
                    {
                        for (int x = 0; x < SeatPlan.GetLength(0); x++)
                        {
                            SeatPlan[x, y] = NewSeatPlan[x, y];
                        }
                    }
                }

            }


            Console.WriteLine(PreviousOccupiedSeats);
                                                            
        }
    }
}
