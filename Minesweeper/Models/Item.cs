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
        public abstract int getNumber();

        public abstract void setNumber(int number);
        protected bool isRevealed;
        protected int num;
    }
}
