using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class NumberItem : Item
    {

        public NumberItem() : base()
        {
            num = 0;
            // TODO add UI
        }

        public override void setNumber(int number)
        {
            num = number;
        }
        public override int getNumber()
        {
            return num;
        }
    }
}
