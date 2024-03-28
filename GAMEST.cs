using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class GAMEST
    {
        private BLOCK CRT_BLOCK;

        public BLOCK CURRENT_BLOCK
        {
            get => CRT_BLOCK;
            private set
            {
                CURRENT_BLOCK = value;
                CURRENT_BLOCK.RESET();
            }
        }

        public GRID grid { get; }
        public BLOCKQUEUE blockQueue { get; }

        public bool gameOver { get; private set; }

        public GAMEST()
        {
            grid = new GRID(22, 10);
            blockQueue = new BLOCKQUEUE();
            CURRENT_BLOCK = blockQueue.GET_AND_UPD();
        }

        private bool BLOCK_F()
        {
            foreach (POSITION P in CURRENT_BLOCK.TILE_POSITION())
            {
                if (!grid.IS_EMPTY(P.ROW, P.COLUMN))
                {
                    return false;
                }
            }
            return true;
        }

        public void ROT_BLOCK_CW()
        {
            CURRENT_BLOCK.ROT_CW();

            if (!BLOCK_F())
            {
                CURRENT_BLOCK.ROT_CCW();
            }
        }

        public void ROT_BLOCK_CCW()
        {
            CURRENT_BLOCK.ROT_CCW();
            
            if (!BLOCK_F())
            {
                CURRENT_BLOCK.ROT_CW();
            }
        }

        public void MOVE_BLOCK_LF()
        {
            CURRENT_BLOCK.MOVE(0, -1);

            if(!BLOCK_F())
            {
                CURRENT_BLOCK.MOVE(0, 1);
            }
        }

        public void MOVE_BLOCK_RG()
        {
            CURRENT_BLOCK.MOVE(0, 1);

            if (!BLOCK_F())
            {
                CURRENT_BLOCK.MOVE(0, -1);
            }
        }

        private bool IS_GAME_OVER()
        {
            return !(grid.IS_ROW_EMPTY(0) && grid.IS_ROW_EMPTY(1));
        }

        private void PLC_BLOCK()
        {
            foreach (POSITION P in CURRENT_BLOCK.TILE_POSITION())
            {
                grid[P.ROW, P.COLUMN] = CURRENT_BLOCK.ID;
            }

            grid.CLEAR_FULL_ROWS();

            if (IS_GAME_OVER())
            {
                gameOver = true;
            }
            else
            {
                CURRENT_BLOCK = blockQueue.GET_AND_UPD();
            }
        }

        public void MOVE_BLOCK_DW()
        {
            CURRENT_BLOCK.MOVE(1, 0);

            if (!BLOCK_F())
            {
                CURRENT_BLOCK.MOVE(-1, 0);
                PLC_BLOCK();
            }
        }
    }
}
