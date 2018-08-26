using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class EmptyItem : Item
    {
        public EmptyItem() : base()
        {
            num = 0;
            // TODO add icon
        }
        public override void setNumber(int number)
        {
            throw new NotImplementedException();
        }

        public override int getNumber()
        {
            return 0;
        }
    }
}
