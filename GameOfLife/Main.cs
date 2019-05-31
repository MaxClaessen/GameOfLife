using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

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
            var newGrid = this.CreateGrid(currentGrid.GetLength(0), currentGrid.GetLength(1));

            var x = 0;
            var y = 0;

            while (y < currentGrid.GetLength(1))
            {
                while (x < currentGrid.GetLength(0))
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

                    x++;
                }

                y++;
            }

            return newGrid;
        }

        public int CalculateAliveNeighbors(bool[,] currentGrid, int x, int y)
        {
            var neighbors = 0;

            if (currentGrid[x - 1, y - 1])
            {
                neighbors++;
            }

            if (currentGrid[x - 1, y])
            {
                neighbors++;
            }

            if (currentGrid[x - 1, y + 1])
            {
                neighbors++;
            }

            if (currentGrid[x, y - 1])
            {
                neighbors++;
            }

            if (currentGrid[x, y + 1])
            {
                neighbors++;
            }

            if (currentGrid[x + 1, y - 1])
            {
                neighbors++;
            }

            if (currentGrid[x + 1, y])
            {
                neighbors++;
            }

            if (currentGrid[x + 1, y + 1])
            {
                neighbors++;
            }

            return neighbors;
        }

        public int CalculateAliveNeighbors2(bool[,] currentGrid, int x, int y)
        {
            var arrayOfNeighbors = GetAllNeighbors(currentGrid, x,y);
            return arrayOfNeighbors.Count(neighbor => neighbor == true);
        }

        public IEnumerable<bool> GetAllNeighbors(bool[,] currentGrid, int x, int y)
        {
            var arrayOfNeighbors = new[]
            {
                currentGrid[x - 1, y -1],
                currentGrid[x - 1, y],
                currentGrid[x - 1, y + 1],
                currentGrid[x, y - 1],
                currentGrid[x, y + 1],
                currentGrid[x + 1, y - 1],
                currentGrid[x + 1, y],
                currentGrid[x + 1, y + 1],
            };
            return arrayOfNeighbors;
        }
    }
}
