using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game
{
    internal class Game
    {
        protected uint _points;
        protected GameStatus _status;
        protected GameBoard _board;

        public Game()
        {
            _points = 0;
            _status = GameStatus.IDLE;
            _board = new GameBoard();
        }


        private void UpdateState()
        {
            if (IsWon()) _status = GameStatus.WIN; 
            else if (IsLose()) _status = GameStatus.LOSE; 
        }

        private bool IsWon()
        {
            for (int i = 0; i < GameBoard.SIZE; i++) 
                for (int j = 0; j < GameBoard.SIZE; j++)
                    if (_board.Data[i, j] == 2048)
                        return true;
            return false;
        }

        private bool IsLose()
        {
            for (int i = 0; i < GameBoard.SIZE; i++)
                for (int j = 0; j < GameBoard.SIZE; j++)
                {
                    if (_board.Data[i, j] == 0) return false;
                    if (i < GameBoard.SIZE - 1 && _board.Data[i + 1, j] == _board.Data[i, j])
                        return false;
                    if (j < GameBoard.SIZE - 1 && _board.Data[i, j + 1] == _board.Data[i, j])
                        return false;
                }
            return true;
        }

        public uint Points
        {
            get => _points;
            protected set => _points = value;
        }

        public GameStatus Status => _status;


        public void Move(Direction direction)
        {
            if (_status != GameStatus.LOSE)
            {
                _points += _board.Move(direction);
                UpdateState();
            }
        }

    }
}
