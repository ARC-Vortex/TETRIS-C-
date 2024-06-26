﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class oBLOCK : BLOCK
    {
        private readonly POSITION[][] tiles = new POSITION[][]
        {
            new POSITION[] {new(0,0), new(0,1), new(1,0), new(1,1)},
        };

        public override int ID => 4;
        protected override POSITION START_OFFSET => new POSITION(0, 4);
        protected override POSITION[][] TILES => tiles;
    }
}
