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
// 2/4/2022  Jasper Jung    created getNeighbor method and getNeighborCount
// 2/4/2022 Jasper Jung     Added a UI to tell the user what the program does
//////////////////////////////////////////////////////////////////
/// References
/// Followed Charles Costarella's lecture and to write the 
/// majority of the code
//////////////////////////////////////////////////////////////////
using System;

namespace L5Life
{
    internal class Game
    {
        // sets the array for the gameboard and buffboard
        private char[,] gameBoard;
        private char[,] buffBoard;

        // char constants for the empty, alive and dead 
        public const char SPACE = ' ';
        public const char LIVE = '@';
        public const char DEAD = '-';

        // sets the array column and rows values (hardcoded)
        public readonly int ROW_SIZE = 50;
        public readonly int COL_SIZE = 80;
        public Game()
        {
            // major objects 
            gameBoard = new char[ROW_SIZE, COL_SIZE];
            buffBoard = new char[ROW_SIZE, COL_SIZE];
        
            // gameboard initalize
            InitalizeGameBoard();

            // insert a startup pattern 
            InsertStartupPattern(24, 20);
        }

        // this method inserts a live startup pattern from which the program will take
        private void InsertStartupPattern(int r, int c)
        {
            //insert 8 live cells after 1 dead
            gameBoard[r, c + 1] = LIVE;
            gameBoard[r, c + 2] = LIVE;
            gameBoard[r, c + 3] = LIVE;
            gameBoard[r, c + 4] = LIVE;
            gameBoard[r, c + 5] = LIVE;
            gameBoard[r, c + 6] = LIVE;
            gameBoard[r, c + 7] = LIVE;
            gameBoard[r, c + 8] = LIVE;
            //1 dead
            gameBoard[r, c + 10] = LIVE;
            gameBoard[r, c + 11] = LIVE;
            gameBoard[r, c + 12] = LIVE;
            gameBoard[r, c + 13] = LIVE;
            gameBoard[r, c + 14] = LIVE;
            // leave 3 dead with 3 live
            gameBoard[r, c + 18] = LIVE;
            gameBoard[r, c + 19] = LIVE;
            gameBoard[r, c + 20] = LIVE;
            // 7 live cells
            gameBoard[r, c + 27] = LIVE;
            gameBoard[r, c + 28] = LIVE;
            gameBoard[r, c + 29] = LIVE;
            gameBoard[r, c + 30] = LIVE;
            gameBoard[r, c + 31] = LIVE;
            gameBoard[r, c + 32] = LIVE;
            gameBoard[r, c + 33] = LIVE;
            // 5 live cells 
            gameBoard[r, c + 35] = LIVE;
            gameBoard[r, c + 36] = LIVE;
            gameBoard[r, c + 37] = LIVE;
            gameBoard[r, c + 38] = LIVE;
            gameBoard[r, c + 39] = LIVE;

        }
        // starts the gameboard with all cells as dead
        private void InitalizeGameBoard()
        {
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    // gameboard all cells are dead
                    gameBoard[r, c] = DEAD;
                    // buffboard all cells are dead
                    buffBoard[r, c] = DEAD;
                }   
            }
        }
        internal void StartGame()
        {
            Console.WriteLine(@"
    ---------------------------------------------------------------------------------------------------------
    * This program will stimulate the famous Game of Life by John Horton Conway. The initial parameters are *
    * already set by the program, meaning this is also a zero-player game. No further input is required by  *
    * the user except for how many generations that you want to be displayed. Whether a cell lives or die   *
    * is determined by these set of rules:                                                                  *
    * 1. A cell is born if it has exactly three neighbors                                                   *
    * 2. A cell survives if it has two or three living neighbors and lives on the next generation           *
    * 3. A cell with three or more does by overpopulation                                                   *
    * 4. A cell with less than two neighbors dies by underpopulation                                        *
    ---------------------------------------------------------------------------------------------------------
    * This program is created using 2 dimensional arrays and nested for loops                               *
    *                                                                                                       *
    * The Game of Life will now begin...                                                                    *
    ---------------------------------------------------------------------------------------------------------");
            
            // tell the user to input a number to initalize the number of generations
            Console.Write("     Enter the number of generations that you want to be displayed (eg. 10,12, 20): ");
            int generateNumber = int.Parse(Console.ReadLine()); 

            //for (int i = 0; i < generateNumber; i++)

            // starts at one to include user input 
            for (int generation = 1; generation <= generateNumber; generation++)

            {

                // Game board is displayed
                DisplayGameBoardCurr(generation);


                // Game board is processed and prepared for new generation
                ProcessGameBoard();

                // the game board is swapped
                SwapGameBoard();
            }
    
        }

        // a simple algo to swap between the gameboard and the buffboard
        private void SwapGameBoard()
        {
            //  set a temp array to hold gameboard
            char[,] temp = gameBoard;
            // set the gameboard to the buffboard
            gameBoard = buffBoard;
            // set the boardboard to temp, now buffBoard is gameBoard
            buffBoard = temp;
        }

        private void ProcessGameBoard()
        {
            //ititerate throught the whole array
            for  (int r = 0;r < ROW_SIZE;r++)
                for (int c=0;c < COL_SIZE;c++)
                {
                    // recall the ifDeadorAliveMethod
                    buffBoard[r, c] = IfDeadOrAlive(r, c); 

                }

        }
        
        // method to implement the rules of the game
        private char IfDeadOrAlive(int r, int c)
        {
            // count the live neightbor within the array
            int count = GetNeighborCount(r, c);

            // this begins the "rules of the game" 

            // if the live cell has fewer than 2 and they are alive, they will die (underpopulation)
            if (gameBoard[r, c] == LIVE && count < 2) return DEAD;
            // if the live cell has two or three cells that are alive, they will move on to the next generation
            if (gameBoard[r, c] == LIVE && (count == 2 || count == 3)) return LIVE;
            // if the live cell has more than 3 cells that are alive, they will die (overpopulation)
            if (gameBoard[r, c] == LIVE && count > 3) return DEAD;
            // if there are exactly three live with a dead cell, it will live (reproduction)
            if (gameBoard[r, c] == DEAD && count == 3) return LIVE;
            // all others will return dead regardless
            else return DEAD; 
        }

        // this method tracks whether there is a neighbor and counters it
        private int GetNeighborCount(int r, int c)
        {
            // init var
            int neighborCount = 0;

            if (r == 0 && c == 0)
            {
                // check top left corner
                if (gameBoard[r, c + 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborCount++;
            }
            else if (r == 0 && c == COL_SIZE - 1)
            {
                if (gameBoard[r, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c] == LIVE) neighborCount++;
                // check top right corner
            }
            else if (r == ROW_SIZE - 1 && c == COL_SIZE - 1)
            {
                //check bottom right corner
                if (gameBoard[r - 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c] == LIVE) neighborCount++; ;
                if (gameBoard[r, c - 1] == LIVE) neighborCount++;

            }
            else if (r == ROW_SIZE - 1 && c == 0)
            {
                // check bottom left corner
                if (gameBoard[r - 1, c + 1] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c] == LIVE) neighborCount++;
                if (gameBoard[r, c + 1] == LIVE) neighborCount++;
            }
            else if (r == 0) // cannot do r -1
            {
                // check top edge
                if (gameBoard[r, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r, c + 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborCount++;
            }
            else if (c == COL_SIZE - 1) // cannot do c+1
            {
                // check right edge
                if (gameBoard[r - 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c] == LIVE) neighborCount++;
                if (gameBoard[r, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c] == LIVE) neighborCount++;
            }
            else if (r == ROW_SIZE - 1) // cannot do r+1
            {
                if (gameBoard[r - 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighborCount++;
                if (gameBoard[r, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r, c + 1] == LIVE) neighborCount++;
            }
            else if (c == 0) // cannot do c-1
            {
                // check left edge
                if (gameBoard[r - 1, c] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighborCount++;
                if (gameBoard[r, c + 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborCount++;
            }
            else
            {
                // nominal cell in the gameboard (doesnt check corner or edge)
                // first three rows
                if (gameBoard[r - 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c] == LIVE) neighborCount++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighborCount++;
                // middle two rows
                if (gameBoard[r, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r, c + 1] == LIVE) neighborCount++;
                // last three rows 
                if (gameBoard[r + 1, c - 1] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c] == LIVE) neighborCount++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighborCount++;

            }
            return neighborCount;
        }

        // displays the current gameboard that is up to date
        private void DisplayGameBoardCurr(int gen)
        {
            // gen keeps track of what number the current gameboard is at
            Console.WriteLine($"Displaying generation #{gen}");
            // iterate throught the array 
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    Console.Write($"{SPACE}{gameBoard[r,c]}");
                }
                Console.WriteLine();
            }
        }
    }
}