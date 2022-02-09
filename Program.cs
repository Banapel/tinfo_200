//////////////////////////////////////////////////////////////////
// Jasper Jung
// TINFO-200C
// L5life - Game of Life Assignment
// This program shows a simulation of populations using a top 
// down approach. This will be done using 2 dimensional arrays 
// and nested for loops. The requirements include that a cell is born 
// if it has exactly three  neighbors and survives if there are two or 
// three living neighbors or else it dies. 
/////////////////////////////////////////////////////////////////
// Change History
// Date     Developer       Description of Change
// 1/30/2022  Jasper Jung   Added description of the program and started creating each file 
// 2/2/2022  Jasper Jung    filled in each method and started testing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5Life
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // game object is created to start simulation
            Game game = new Game();
            game.StartGame();
        }
    }
}
