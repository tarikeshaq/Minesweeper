using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Models
{
    public class GameController
    {
        private Icons icons;
        private MinesweeperGraph minesweeper;
        private Form gameArea;
        public GameController(int size, Form gameArea)
        {
            this.gameArea = gameArea;
            icons = new Icons(size, gameArea, this);
            minesweeper = new MinesweeperGraph(size, gameArea, this);
        }

        public void click(int xCor, int yCor)
        {
            minesweeper.click(xCor, yCor);
        }

        public void revealEnd(int xCor, int yCor)
        {
            icons.revealEnd(xCor, yCor);
        }

        public void reveal(int xCor, int yCor, int num)
        {
            icons.reveal(xCor, yCor, num);
        }

        public void flag(int xCor, int yCor)
        {
            minesweeper.flag(xCor, yCor);
        }

        public void toggleFlag(int xCor, int yCor)
        {
            icons.toggleFlag(xCor, yCor);
        }

        public void unFlag(int xCor, int yCor)
        {
            icons.unFlag(xCor, yCor);
        }
        public void win()
        {
            using (Form winPopup = new Form())
            {
                
                winPopup.ShowDialog();
            }
            
        }
    }
}
