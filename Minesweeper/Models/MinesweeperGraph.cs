using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Minesweeper.Models;

namespace Minesweeper
{
    class MinesweeperGraph
    {
        private List<List<Item>> graph;
        private const double ratioOfMinesToSize = 0.1;
        private Form gameArea;
        private GameController game;
        private int winningNumberOfReveals;
        private int revealedItems;
        /*
         * Constructs a size*size graph with appropriate mine, empty and number items
         */
        public MinesweeperGraph(int size, Form gameArea, GameController game)
        {
            this.gameArea = gameArea;
            this.game = game;
            initializeGraph(size);
            int numOfMines = (int)(ratioOfMinesToSize * (double)size * (double)size);
            winningNumberOfReveals = size * size - numOfMines;
            placeMines(numOfMines);
            placeNumsAndEmptyItems();
        }


       
        public void click(int xCor, int yCor)
        {
            if (graph[yCor][xCor].IsFlagged() || graph[yCor][xCor].IsRevealed())
                return;
            if (graph[yCor][xCor].GetType().Equals(typeof(Mine)))
            {
                endGame(xCor, yCor);
            }
            else
            {
                revealAllValid(xCor, yCor);
            }
        }
        
        public void flag(int xCor, int yCor)
        {
            if (graph[yCor][xCor].IsRevealed())
                return;
            if (graph[yCor][xCor].IsFlagged())
            {
                game.unFlag(xCor, yCor);
            } else
            {
                game.toggleFlag(xCor, yCor);
                
            }
            graph[yCor][xCor].flag();
        }

        private void initializeGraph(int size)
        {
            graph = new List<List<Item>>();
            for (int i = 0; i < size; i++)
            {
                graph.Add(new List<Item>());
                for (int j = 0; j < size; j++)
                {
                    graph[graph.Count - 1].Add( new EmptyItem());
                }
            }
        }
        private void placeMines(int numOfMines)
        {
            Random rnd = new Random();
            for (int i = 0; i < numOfMines; i++)
            {
                
                int randomLocationX = rnd.Next(0, graph.Count - 1);
                int randomLocationY = rnd.Next(0, graph.Count - 1);
                if (graph[randomLocationY][randomLocationX].GetType().Equals(typeof(Mine)))
                {
                    continue;
                }
                    
                else
                { 
                    graph[randomLocationY][randomLocationX] = new Mine();
                }
                    
            }
        }

        private void placeNumsAndEmptyItems()
        {
            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = 0; j < graph[i].Count; j++)
                {
                    if (graph[i][j].GetType().Equals(typeof(Mine)))
                        continue;
                    int num = getNumOfMinesAround(i, j);
                    if (num == 0)
                    {
                        graph[i][j] = new EmptyItem();
                    } else
                    {
                        Item curr = new NumberItem();
                        curr.setNumber(num);
                        graph[i][j] = curr;
                    }
                }
            }
        }

        private void endGame(int xCor, int yCor)
        {
            game.revealEnd(xCor, yCor);
            game.win();
        }

        private void revealAllValid(int xCor, int yCor)
        {
            Queue<List<int>> q = new Queue<List<int>>();
            List<int> l1 = new List<int>();
            l1.Add(xCor);
            l1.Add(yCor);
            q.Enqueue(l1);
            while (q.Count != 0)
            {
                List<int> curr = q.Dequeue();
                int x = curr[0];
                int y = curr[1];
    
                if (!inBounds(y, x) || isMine(y, x))
                    continue;
                if (graph[y][x].IsRevealed() || graph[y][x].IsFlagged())
                    continue;
                graph[y][x].reveal();
                if (++revealedItems == winningNumberOfReveals)
                    game.win();
                int num = graph[y][x].getNumber();
                game.reveal(x, y, num);

                if (graph[y][x].GetType().Equals(typeof(NumberItem)))
                    continue;
                addAllSurronding(q, x, y);
            }
        }

        
        private void addAllSurronding(Queue<List<int>> q, int xCor, int yCor)
        {
            q.Enqueue(new List<int>() { xCor + 1, yCor + 1 });
            q.Enqueue(new List<int>() { xCor + 1, yCor - 1});
            q.Enqueue(new List<int>() { xCor + 1, yCor });
            q.Enqueue(new List<int>() { xCor - 1, yCor + 1 });
            q.Enqueue(new List<int>() { xCor - 1, yCor });
            q.Enqueue(new List<int>() { xCor - 1, yCor-1 });
            q.Enqueue(new List<int>() { xCor, yCor - 1 });
            q.Enqueue(new List<int>() { xCor, yCor + 1 });
        }

        private int getNumOfMinesAround(int i, int j)
        {
            int numberOfMines = 0;
            if (isMine(i + 1, j))
                numberOfMines++;
            if (isMine(i + 1, j + 1))
                numberOfMines++;
            if (isMine(i + 1, j - 1))
                numberOfMines++;
            if (isMine(i - 1, j))
                numberOfMines++;
            if (isMine(i - 1, j + 1))
                numberOfMines++;
            if (isMine(i - 1, j - 1))
                numberOfMines++;
            if (isMine(i, j + 1))
                numberOfMines++;
            if (isMine(i, j - 1))
                numberOfMines++;
            return numberOfMines;
        }


        private bool isMine(int i, int j)
        {
            return inBounds(i, j) && graph[i][j].GetType().Equals(typeof(Mine));
        }
        private bool inBounds(int i, int j)
        {
            return i >= 0 && i < graph.Count && j >= 0 && j < graph[i].Count;
        }
    }
}
