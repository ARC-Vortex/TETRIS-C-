using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public abstract class BLOCK
    {
        protected abstract POSITION[][] TILES { get; }
        protected abstract POSITION START_OFFSET { get; }

        public abstract int ID { get; }

        private int ROT_STATE;
        private POSITION OFFSET;

        public BLOCK()
        {
            OFFSET = new POSITION(START_OFFSET.ROW, START_OFFSET.COLUMN);
        }

        public IEnumerable<POSITION> TILE_POSITION()
        {
            foreach (POSITION P in TILES[ROT_STATE])
            {
                yield return new POSITION(P.ROW + OFFSET.ROW, P.COLUMN + OFFSET.COLUMN);
            }
        }

        public void ROT_CW()
        {
            ROT_STATE = (ROT_STATE + 1) % TILES.Length;
        }

        public void ROT_CCW()
        {
            if (ROT_STATE == 0)
            {
                ROT_STATE = TILES.Length - 1;
            }
            else
            {
                ROT_STATE--;
            }
        }

        public void MOVE(int ROWS, int COLUMNS)
        {
            OFFSET.ROW += ROWS;
            OFFSET.COLUMN += COLUMNS;
        }

        public void RESET()
        {
            ROT_STATE = 0;
            OFFSET.ROW = START_OFFSET.ROW;
            OFFSET.COLUMN = START_OFFSET.COLUMN;
        }
    }
}
