﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game
{
    internal class BoardTester  //this tester for 4x4
    {
        private static void PrintBoard(GameBoard board)
        {
            string rowStr = "";
            for (int i = 0; i < 4; i++)
            {
                rowStr = "";
                for (int j = 0; j < 4; j++) rowStr += board.Data[i, j] + ", ";
                Console.WriteLine(rowStr);
            }
        }

        private static void TestMove(uint[,] boardState, Direction direction, uint correctOutput)
        {
            GameBoard board = new GameBoard();
            uint score;
            board._data = boardState;

            PrintBoard(board);

            score = board.Move(direction);
            if (score == correctOutput) Console.WriteLine("\nscore check succeed!\n");
            else Console.WriteLine("\nscore check failed!\n");

            PrintBoard(board);
        }
        
        internal static void TestMove1() 
        {
            Console.WriteLine("\n     Test move 1\n");
            TestMove(
                new uint[4, 4]
                    {
                        { 2, 2, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 16, 4 },
                        { 0, 4, 2, 4 }
                    },
                Direction.LEFT,
                4
            );

        }

        internal static void TestMove2()
        {
            Console.WriteLine("\n     Test move 2\n");
            TestMove(
                new uint[4, 4]
                    {
                        { 0, 8, 0, 8 },
                        { 0, 0, 0, 0 },
                        { 0, 2, 0, 0 },
                        { 0, 0, 0, 0 }
                    },
                Direction.DOWN,
                0
            );
        }

        internal static void TestMove3()
        {
            Console.WriteLine("\n     Test move 3\n");
            TestMove(
                new uint[4, 4]
                    {
                        { 32, 0, 0, 32 },
                        { 0, 0, 0, 0 },
                        { 4, 0, 4, 0 },
                        { 0, 0, 0, 0 }
                    },
                Direction.RIGHT,
                72
            );
        }

        internal static void TestMove4()
        {
            Console.WriteLine("\n     Test move 4\n");
            TestMove(
                new uint[4, 4]
                    {
                        { 2, 0, 0, 0 },
                        { 2, 0, 4, 0 },
                        { 2, 0, 4, 0 },
                        { 2, 0, 4, 0 }
                    },
                Direction.UP,
                16
            );
        }


        internal static void TestMove5()
        {
            Console.WriteLine("\n     Test move 5\n");
            TestMove(
                new uint[4, 4]
                    {
                        { 1024, 256, 256, 512 },
                        { 2, 4, 0, 2 },
                        { 2, 2, 2, 2 },
                        { 14336, 0, 14336, 2048 }
                    },
                Direction.RIGHT,
                29192
            );
        }

        internal static void TestMove6()
        {
            Console.WriteLine("\n     Test move 6\n");
            TestMove(
                new uint[4, 4]
                    {
                        { 1024, 512, 256, 512 },
                        { 2, 4, 8, 2 },
                        { 128, 16, 32, 64 },
                        { 2048, 2, 1024, 2048 }
                    },
                Direction.DOWN,
                0
            );
        }

        internal static void TestMove7()
        {
            Console.WriteLine("\n     Test move 7\n");
            TestMove(
                new uint[4, 4]
                    {
                        { 1024, 512, 0, 0 },
                        { 2, 0, 0, 0 },
                        { 128, 16, 32, 64 },
                        { 2048, 2, 1024, 0 }
                    },
                Direction.LEFT,
                0
            );


        }

    }
}
