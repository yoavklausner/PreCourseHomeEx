using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game
{
    internal class GameBoard
    {
        private static readonly Random random = new();

        internal protected static readonly uint SIZE = 4;

        internal protected uint[,] _data;

        public GameBoard() 
        { 
            _data = new uint[SIZE, SIZE];
            RandSlot();
            RandSlot();
        }

        #region Privates

        private void RandSlot()
        {
            List<(uint, uint)> freeCoords = GetFreeCoords();
            if (freeCoords.Count != 0)
            {
                byte newNumber = (byte)(random.NextSingle() < 0.3f ? 4 : 2);
                (uint row, uint col) newCoords = freeCoords[random.Next(freeCoords.Count)];
                _data[newCoords.row, newCoords.col] = newNumber;
            }
        }

        private List<(uint, uint)> GetFreeCoords()
        {

            List<(uint, uint)> freeCoords = new();
            for (uint i = 0; i < SIZE; i++)
                for (uint j = 0; j < SIZE; j++)
                    if (_data[i, j] == 0)
                        freeCoords.Add((i, j));
            return freeCoords;
        }

        private static (uint row, uint col) GetRealCoor(Direction direction, uint i, uint j)
        {
            if (direction == Direction.RIGHT) return (i, SIZE - 1 - j); 
            if (direction == Direction.LEFT) return (i, j);
            if (direction == Direction.DOWN) return (SIZE - 1 - j, i);
            else return (j, i);
        }

        #endregion

        public uint[,] Data
        {
            get => (uint[,])_data.Clone();
            protected set => _data = value;
        }


        public uint Move(Direction direction)
        {
            uint addedScore = 0;
            for (uint i = 0; i < SIZE; i++)
            {
                uint jDest = 0;
                for (uint j = 0; j < SIZE; j++)
                {
                    (uint row, uint col) dest = GetRealCoor(direction, i, jDest);
                    (uint row, uint col) cur = GetRealCoor(direction, i, j);
                    uint curNumber = _data[cur.row, cur.col];
                    _data[cur.row, cur.col] = 0;
                    if (curNumber != 0)
                    {
                        (uint row, uint col) next = GetRealCoor(direction, i, ++j);
                        while (j < SIZE && _data[next.row, next.col] == 0)
                            next = GetRealCoor(direction, i, ++j);
                        if (j < SIZE && curNumber == _data[next.row, next.col])
                        {
                            curNumber += _data[next.row, next.col];
                            addedScore += curNumber;
                            _data[next.row, next.col] = 0;
                        }
                        else j--;
                        _data[dest.row, dest.col] = curNumber;
                        jDest++;
                    }
                }
            }
            RandSlot();
            return addedScore;
        }
    }
}
