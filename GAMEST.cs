using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class GAMEST
    {
        private BLOCK currentBlock;

        public BLOCK CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.RESET();

                for (int I = 0; I < 2; I++)
                {
                    currentBlock.MOVE(1, 0);
                    if (!BLOCK_F())
                    {
                        currentBlock.MOVE(-1, 0);
                    }
                }
            }
        }

        public GRID gr { get; }
        public BLOCKQUEUE blockQueue { get; }
        public bool gameOver { get; private set; }
        public int Score { get; private set; }

        public GAMEST()
        {
            gr = new GRID(22, 10);
            blockQueue = new BLOCKQUEUE();
            CurrentBlock = blockQueue.GET_AND_UPD();
        }

        private bool BLOCK_F()
        {
            foreach (POSITION P in CurrentBlock.TILE_POSITION())
            {
                if (!gr.IS_EMPTY(P.ROW, P.COLUMN))
                {
                    return false;
                }
            }
            return true;
        }

        public void ROT_BLOCK_CW()
        {
            CurrentBlock.ROT_CW();

            if (!BLOCK_F())
            {
                CurrentBlock.ROT_CCW();
            }
        }

        public void ROT_BLOCK_CCW()
        {
            CurrentBlock.ROT_CCW();

            
            if (!BLOCK_F())
            {
                CurrentBlock.ROT_CW();
            }
        }

        public void MOVE_LEFT()
        {
            CurrentBlock.MOVE(0, -1);

            if(!BLOCK_F())
            {
                CurrentBlock.MOVE(0, 1);
            }
        }

        public void MOVE_RIGHT()
        {
            CurrentBlock.MOVE(0, 1);

            if (!BLOCK_F())
            {
                CurrentBlock.MOVE(0, -1);
            }
        }

        private bool IS_GAME_OVER()
        {
            return !(gr.IS_ROW_EMPTY(0) && gr.IS_ROW_EMPTY(1));
        }

        private void PLC_BLOCK()
        {
            foreach (POSITION P in CurrentBlock.TILE_POSITION())
            {
                gr[P.ROW, P.COLUMN] = CurrentBlock.ID;
            }

            Score += gr.CLEAR_FULL_ROWS();

            if (IS_GAME_OVER())
            {
                gameOver = true;
            }
            else
            {
                CurrentBlock = blockQueue.GET_AND_UPD();
            }
        }

        public void MOVE_BLOCK_DW()
        {
            CurrentBlock.MOVE(1, 0);

            if (!BLOCK_F())
            {
                CurrentBlock.MOVE(-1, 0);
                PLC_BLOCK();
            }
        }

        private int TILE_DROP_DIST(POSITION P)
        {
            int drop = 0;

            while (gr.IS_EMPTY(P.ROW + drop + 1, P.COLUMN))
            {
                drop++;
            }

            return drop;
        }

        public int BLOCK_DROP_DIST()
        {
            int drop = gr.ROWS;

            foreach (POSITION P in CurrentBlock.TILE_POSITION())
            {
                drop = System.Math.Min(drop, TILE_DROP_DIST(P));
            }

            return drop;
        }

        public void DROP()
        {
            CurrentBlock.MOVE(BLOCK_DROP_DIST(), 0);
            PLC_BLOCK();
            
        }
    }
}
