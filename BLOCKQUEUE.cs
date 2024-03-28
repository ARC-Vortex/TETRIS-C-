using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class BLOCKQUEUE
    {
        private readonly BLOCK[] BLOCKS = new BLOCK[]
        {
            new iBLOCK(),
            new jBLOCK(),
            new lBlock(),
            new oBLOCK(),
            new sBLOCK(),
            new tBLOCK(),
            new zBLOCK()
        };

        private readonly Random RND = new Random();
        public BLOCK NXT_BLOCK { get; private set; }

        public BLOCKQUEUE()
        {
            NXT_BLOCK = RND_BLOCK();
        }

        private BLOCK RND_BLOCK()
        {
            return BLOCKS[RND.Next(BLOCKS.Length)];
        }

        public BLOCK GET_AND_UPD()
        {
            BLOCK BLOCK = NXT_BLOCK;
            do
            {
                NXT_BLOCK = RND_BLOCK();
            }
            while (BLOCK.ID == NXT_BLOCK.ID);
            return BLOCK;
        }
    }
}
