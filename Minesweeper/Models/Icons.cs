using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Models
{
    public class Icons
    {
        private List<List<PictureBox>> icons;
        private int size;
        private GameController game;
        private Form gameArea;
        public Icons(int size, Form gameArea, GameController game)
        {
            this.size = size;
            this.gameArea = gameArea;
            this.game = game;
            render(gameArea);
        }


        public void revealEnd(int xCor, int yCor)
        {
            var icon = icons[yCor][xCor];
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Resources");
            icons[yCor][xCor].Load(filePath + "\\other.jpg");
        }

        public void reveal(int xCor, int yCor, int num)
        {
            var icon = icons[yCor][xCor];
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Resources");
            icon.Load(filePath + "\\num" + num + ".jpg");
        }

        public void toggleFlag(int xCor, int yCor)
        {
            var icon = icons[yCor][xCor];
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Resources");
            icon.Load(filePath + "\\flag.jpg");
        }

        public void unFlag(int xCor, int yCor)
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Resources");
            var icon = icons[yCor][xCor];
            icon.Load(filePath + "\\testing.jpg");
        }

        private void render(Form gameArea)
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Resources");
            icons = new List<List<PictureBox>>();
            for (int i = 0; i < size; i++)
            {
                icons.Add(new List<PictureBox>());
                for (int j = 0; j < size; j++)
                {

                    var icon = new PictureBox
                    {
                        Name = "untouched",
                        Size = new Size(20, 20),
                        Location = new Point(j * 20, i * 20),
                        Image = Image.FromFile(filePath + "\\testing.jpg"),
                    };
                    icon.SizeMode = PictureBoxSizeMode.StretchImage;
                    gameArea.Controls.Add(icon);
                    icon.MouseClick += new MouseEventHandler(onClick);
                    icons[icons.Count - 1].Add(icon);
                }
            }
        }


        private void onClick(object sender, MouseEventArgs e)
        {
            PictureBox icon = (PictureBox)sender;
            Point p = icon.Location;
            if (e.Button == MouseButtons.Left)
            {
                game.click(p.X / 20, p.Y / 20);
            } else
            {
                game.flag(p.X / 20, p.Y / 20);
            }
            
        }

    }
}
