using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game
{
    internal static class ConsoleGame
    {
        static readonly (int left, int top) START_POINT = (50, 10);
        static readonly int MAX_DIG_COUNT = 8;
        static readonly int PADDING_LINES_COUNT = 1;
        static readonly int CUBE_HEIGHT = PADDING_LINES_COUNT * 2 + 1;
        private static Game? game;
        private static void DisplayMessage(string message)
        {
            Console.SetCursorPosition(START_POINT.left,  START_POINT.top + CUBE_HEIGHT * (int)GameBoard.SIZE + 3);
            
            Console.Write(message);

            Console.Write("                                         ");

        }

        private static void ReWriteCube(uint number)
        {
            (int left, int top) cursorPos = Console.GetCursorPosition();
            for (int i = 0; i < MAX_DIG_COUNT; i++)
                Console.Write(" ");
            Console.SetCursorPosition(cursorPos.left, cursorPos.top);
            Console.Write(number);
        }

        private static void DisplayBoard() 
        {
            Console.CursorLeft = START_POINT.left;
            Console.CursorTop = START_POINT.top;
            for (int i = 0; i < GameBoard.SIZE; i++)
            {
                for (int j = 0; j < GameBoard.SIZE; j++) 
                {
                    Console.CursorTop += PADDING_LINES_COUNT;
                    ReWriteCube(game!.Board.Data[i, j]);
                    Console.CursorLeft -= game!.Board.Data[i, j].ToString().Length;
                    Console.CursorTop -= PADDING_LINES_COUNT;
                    Console.CursorLeft += MAX_DIG_COUNT;
                }
                Console.CursorLeft = START_POINT.left;
                Console.CursorTop += CUBE_HEIGHT;
            }
        }

        private static void MakeTurn(Direction direction)
        {
            game!.Move(direction); 
            DisplayBoard();
        }


        public static void Play()
        {
            Console.CursorVisible = false;
            ConsoleKey inputKey;
            game = new Game();
            DisplayBoard();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    inputKey = Console.ReadKey(intercept: true).Key;
                    if (inputKey == ConsoleKey.LeftArrow) MakeTurn(Direction.LEFT);
                    else if (inputKey == ConsoleKey.RightArrow) MakeTurn(Direction.RIGHT);
                    else if (inputKey == ConsoleKey.UpArrow) MakeTurn(Direction.UP);
                    else if (inputKey == ConsoleKey.DownArrow) MakeTurn(Direction.DOWN);
                    else if (inputKey == ConsoleKey.Q)
                    {
                        DisplayMessage("quitting game...");
                        break;
                    }
                    else DisplayMessage("in order to move the cubes use the arrows.");
                }

                if (game.Status == GameStatus.LOSE)
                {
                    DisplayMessage("Game over, you lost :(");
                    break;
                }
                else if (game.Status == GameStatus.WIN) DisplayMessage("Game won! You can keep playing ;)");

            }
        }



    }
}
