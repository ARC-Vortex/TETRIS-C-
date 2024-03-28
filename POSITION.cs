using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class POSITION
    {
        public int ROW { get; set; }
        public int COLUMN { get; set; }

        public POSITION(int row, int column)
        {
            ROW = row;
            COLUMN = column;
        }
    }
}
