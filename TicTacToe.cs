using System;

namespace MobileApplication
{
    public class TicTacToe
    {
        private int[,] grid;
        private int gridSize;

        public TicTacToe(int size)
        {
            gridSize = size;
            grid = new int[size, size];
        }

        public int CheckWin()
        {
            for (int i = 0; i < gridSize; i++)
            {
                if (CheckRow(i)) return grid[i, 0];
                if (CheckColumn(i)) return grid[0, i];
            }

            if (CheckDiagonal()) return grid[0, 0];
            if (CheckAntiDiagonal()) return grid[0, gridSize - 1];

            foreach (var cell in grid)
            {
                if (cell == 0) return 0;  
            }

            return -1; 
        }

        private bool CheckRow(int row)
        {
            for (int i = 1; i < gridSize; i++)
            {
                if (grid[row, i] != grid[row, 0] || grid[row, i] == 0) return false;
            }
            return true;
        }

        private bool CheckColumn(int col)
        {
            for (int i = 1; i < gridSize; i++)
            {
                if (grid[i, col] != grid[0, col] || grid[i, col] == 0) return false;
            }
            return true;
        }

        private bool CheckDiagonal()
        {
            for (int i = 1; i < gridSize; i++)
            {
                if (grid[i, i] != grid[0, 0] || grid[i, i] == 0) return false;
            }
            return true;
        }

        private bool CheckAntiDiagonal()
        {
            for (int i = 1; i < gridSize; i++)
            {
                if (grid[i, gridSize - 1 - i] != grid[0, gridSize - 1] || grid[i, gridSize - 1 - i] == 0) return false;
            }
            return true;
        }

        public bool MakeMove(int row, int col, int player)
        {
            if (grid[row, col] == 0)
            {
                grid[row, col] = player;
                return true;
            }
            return false;
        }
    }
}
