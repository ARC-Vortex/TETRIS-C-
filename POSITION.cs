using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class POSITION
    {
        public int ROW { get; set; } = 0;
        public int COLUMN { get; set; } = 0;

        public POSITION(int row, int column)
        {
            ROW = row;
            COLUMN = column;
        }
    }
}
