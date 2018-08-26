using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Mine : Item
    {
        public Mine() : base()
        {
            num = -1;
            // TODO add UI and looks
        }

        public override void setNumber(int number)
        {
            throw new NotImplementedException();
        }

        public override int getNumber()
        {
            return -1;
        }
    }
}
