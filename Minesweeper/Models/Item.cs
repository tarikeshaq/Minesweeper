using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public abstract class Item
    {
        /*
         * Constructs Item
         */
        public Item()
        {
            isRevealed = false;
            isFlagged = false;
        }


        public void reveal()
        {
            isRevealed = true;
            // stub;
        }

        public bool IsRevealed()
        {
            return isRevealed;
        }
        public bool IsFlagged()
        {
            return isFlagged;
        }

        public void flag()
        {
            isFlagged = !isFlagged;
        }
        public abstract int getNumber();

        public abstract void setNumber(int number);
        protected bool isRevealed;
        protected bool isFlagged;
        protected int num;
    }
}
