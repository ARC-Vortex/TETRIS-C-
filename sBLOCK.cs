using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class sBLOCK : BLOCK
    {
        private readonly POSITION[][] tiles = new POSITION[][]
        {
            new POSITION[] {new(0,1), new(0,2), new(1,0), new(1,1)},
            new POSITION[] {new(0,1), new(1,1), new(1,2), new(2,2)},
            new POSITION[] {new(1,1), new(1,2), new(2,0), new(2,1)},
            new POSITION[] {new(0,0), new(1,0), new(1,1), new(2,1)}
        };

        public override int ID => 5;
        protected override POSITION START_OFFSET => new POSITION(0, 3);
        protected override POSITION[][] TILES => tiles;
    }
}
