using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;

namespace GameOfLife
{
    public class Grid
    {
        public bool[,] CreateGrid(int x, int y)
        {
            return new bool[x, y];
        }

        //google gebruikt voor het checken van de lengte van X / Y van grid 

        public bool[,] CalculateNextGeneration(bool[,] currentGrid)
        {
            var xUpperBound = currentGrid.GetUpperBound(0);
            var yUpperBound = currentGrid.GetUpperBound(1);
            var newGrid = this.CreateGrid(xUpperBound, yUpperBound);


            for (var y = 0; y < yUpperBound; y++)
            {
                for (var x = 0; x < xUpperBound; x++)
                {
                    var neighborsAlive = CalculateAliveNeighbors(currentGrid, x, y);
                    if (currentGrid[x, y]) // if cell is alive in current generation
                    {
                        if (neighborsAlive > 3 || neighborsAlive < 2)
                        {
                            newGrid[x, y] = false;
                        }
                        else
                        {
                            newGrid[x, y] = true;
                        }
                    }
                    else //if cell is dead in current generation
                    {
                        if (neighborsAlive == 3)
                        {
                            newGrid[x, y] = true;
                        }
                    }
                }
            }
            return newGrid;
        }

        public int CalculateAliveNeighbors(bool[,] currentGrid, int x, int y)
        {
            var neighbors = 0;

            if (CalculateIfAlive(currentGrid, x - 1, y - 1))
            {
                neighbors++;
            }

            if (CalculateIfAlive(currentGrid, x - 1, y))
            {
                neighbors++;
            }

            if (CalculateIfAlive(currentGrid, x - 1, y + 1))
            {
                neighbors++;
            }

            if (CalculateIfAlive(currentGrid, x, y - 1))
            {
                neighbors++;
            }

            if (CalculateIfAlive(currentGrid, x, y + 1))
            {
                neighbors++;
            }

            if (CalculateIfAlive(currentGrid, x + 1, y - 1))
            {
                neighbors++;
            }
            
            if (CalculateIfAlive(currentGrid, x + 1, y))
            {
                neighbors++;
            }

            if (CalculateIfAlive(currentGrid, x + 1, y + 1))
            {
                neighbors++;
            }

            return neighbors;
        }

        private static bool CalculateIfAlive(bool[,] currentGrid, int x, int y)
        {
            if (x <= currentGrid.GetUpperBound(0) && x >= currentGrid.GetLowerBound(0))
            {
                if (y <= currentGrid.GetUpperBound(1) && y >= currentGrid.GetLowerBound(1))
                {
                    return currentGrid[x,y];
                }
            }
            return false;
        }
        
        //does make sure that its within bounds
        //public int CalculateAliveNeighbors2(bool[,] currentGrid, int x, int y)
        //{
        //    var arrayOfNeighbors = GetAllNeighbors2(currentGrid, x, y);
        //    return arrayOfNeighbors.Count(neighbor => neighbor == true);
        //}

        //public IEnumerable<bool> GetAllNeighbors2(bool[,] currentGrid, int x, int y)
        //{
        //    var arrayOfNeighbors = new[]
        //    {
        //        currentGrid[x - 1, y - 1],
        //        currentGrid[x - 1, y],
        //        currentGrid[x - 1, y + 1],
        //        currentGrid[x, y - 1],
        //        currentGrid[x, y + 1],
        //        currentGrid[x + 1, y - 1],
        //        currentGrid[x + 1, y],
        //        currentGrid[x + 1, y + 1],
        //    };
        //    return arrayOfNeighbors;
        //}

    }
}
