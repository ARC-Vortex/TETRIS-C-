using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class GRID
    {
        private readonly int[,] grid;
        public int ROWS { get;  }
        public int COLUMNS { get; }

        public int this[int R, int C]
        {
            get => grid[R, C];
            set => grid[R, C] = value;
        }

        public GRID(int ROW, int COLUMN)
        {
            ROWS = ROW;
            COLUMNS = COLUMN;
            grid = new int[ROW, COLUMN];
        }

        public bool IS_INSIDE(int R, int C)
        {
            return R >= 0 && R < ROWS && C >= 0 && C < COLUMNS;
        }

        public bool IS_EMPTY(int R, int C)
        {
            return IS_INSIDE(R, C) && grid[R, C] == 0;
        }

        public bool IS_ROW_FULL(int R)
        {
            for (int C = 0; C < COLUMNS; C++)
            {
                if (grid[R, C] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IS_ROW_EMPTY(int R)
        {
            for (int C = 0; C < COLUMNS; C++)
            {
                if (grid[R, C] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void CLEAR_ROW(int R)
        {
            for (int C = 0; C < COLUMNS; C++)
            {
                grid[R, C] = 0;
            }
        }

        private void MOVE_ROW_DOWN(int R, int NUMROWS)
        {
            for (int C = 0; C < COLUMNS; C++)
            {
                grid[R + NUMROWS, C] = grid[R, C];
                grid[R, C] = 0;
            }
        }

        public int CLEAR_FULL_ROWS()
        {
            int cleared = 0;
            for (int R = ROWS-1; R >= 0; R--)
            {
                if (IS_ROW_FULL(R))
                {
                    CLEAR_ROW(R);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MOVE_ROW_DOWN(R, cleared);
                }
            }
            return cleared;
        }
    }
}
