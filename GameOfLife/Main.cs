using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace GameOfLife
{ 
    public class Grid
    {
        public bool[,] CreateGrid(int x, int y)
        {
            return new bool[x, y];
        }

        public bool[,] CalculateNextGeneration(bool[,] currentGrid)
        {
            var newGrid = this.CreateGrid(currentGrid.GetLength(0), currentGrid.GetLength(1));

            var x = 0;
            var y = 0;

            while(x < currentGrid.GetLength(0))
            {
                var neighboursAlive = CalculateAliveNeighbours(currentGrid, x , y);
                if (currentGrid[x,y]) // if cell is alive in current generation
                {
                    
                }
                else //if cell is dead in current generation
                {
                    
                }
                x++;
            }


            return newGrid;
        }

        public int CalculateAliveNeighbours(bool[,] currentGrid, int x, int y)
        {
            var neighbours = 0;
            return neighbours;
        }
    }
}
