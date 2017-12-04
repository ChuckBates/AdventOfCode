using System;
using System.Collections.Generic;

namespace Day3
{
    public class SpiralMemory
    {
        public int GetSteps(int square)
        {
            var squareCoordinates = GetGrid(square)[square];
            return GetManhattanDistance(0, 0, squareCoordinates[0], squareCoordinates[1]);
        }

        public Dictionary<int, int[]> GetGrid(int square)
        {
            var grid = new Dictionary<int, int[]>();
            var gridSize = GetGridSize(square);
            BuildGrid(gridSize, grid);
            return grid;
        }

        private void BuildGrid(int gridSize, Dictionary<int, int[]> grid)
        {
            var median = (gridSize + 1) / 2;
            var right = median - 1;
            var bottom = -(median - 1);
            var top = median - 1;
            var left = -(median - 1);
            var startKey = gridSize * gridSize;
            grid.Add(startKey, new []{right, bottom});
            //bottom side
            for (int i = 1; i <= median; i++)
            {
                grid.Add(startKey - 1, new[] { right - i, bottom });
                startKey--;
            }
            //Left side
            for (int i = 1; i <= median; i++)
            {
                grid.Add(startKey - 1, new[] { left, bottom + i });
                startKey--;
            }
            //Top side
            for (int i = 1; i <= median; i++)
            {
                grid.Add(startKey - 1, new[] { left + i, top });
                startKey--;
            }
            //Right side
            for (int i = 1; i < median; i++)
            {
                grid.Add(startKey - 1, new []{right, top - i});
                startKey--;
            }
        }

        private int GetManhattanDistance(int a, int b, int c, int d)
        {
            return Math.Abs(a - c) + Math.Abs(b - d);
        }

        private int GetGridSize(int square)
        {
            for (int i = 3; i < 599; i += 2)
            {
                if (square / i <= i)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
