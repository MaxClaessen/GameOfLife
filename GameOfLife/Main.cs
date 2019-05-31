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
                    var neighborsAlive = CalculateAliveNeighbours(currentGrid, x, y);
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

        public int CalculateAliveNeighbours(bool[,] currentGrid, int x, int y)
        {
            var neighbours = 0;
            return neighbours;
        }
    }
}
