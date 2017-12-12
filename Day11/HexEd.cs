using System;

namespace Day11
{
    public class HexEd
    {
        public int FewestSteps(string childPath)
        {
            if (string.IsNullOrEmpty(childPath))
            {
                return 0;
            }

            var coordinates = new[] {0, 0, 0};
            foreach (var step in childPath.Split(','))
            {
                coordinates = Move(coordinates, step);
            }

            return (Math.Abs(coordinates[0] - 0) + Math.Abs(coordinates[1] - 0) + Math.Abs(coordinates[2] - 0)) / 2;
        }
        public int FurthestSteps(string childPath)
        {
            if (string.IsNullOrEmpty(childPath))
            {
                return 0;
            }

            var coordinates = new[] {0, 0, 0};
            var furthestSteps = 0;
            foreach (var step in childPath.Split(','))
            {
                coordinates = Move(coordinates, step);
                var currentStepsAway = (Math.Abs(coordinates[0] - 0) + Math.Abs(coordinates[1] - 0) + Math.Abs(coordinates[2] - 0)) / 2;
                if (currentStepsAway > furthestSteps)
                {
                    furthestSteps = currentStepsAway;
                }
            }

            return furthestSteps;
        }

        public int[] Move(int[] currentCoordinates, string direction)
        {
            switch (direction)
            {
                case "n":
                    return new[] {currentCoordinates[0], currentCoordinates[1] + 1, currentCoordinates[2] - 1};
                case "ne":
                    return new[] {currentCoordinates[0] + 1, currentCoordinates[1], currentCoordinates[2] - 1};
                case "se":
                    return new[] {currentCoordinates[0] + 1, currentCoordinates[1] - 1, currentCoordinates[2]};
                case "s":
                    return new[] {currentCoordinates[0], currentCoordinates[1] - 1, currentCoordinates[2] + 1};
                case "sw":
                    return new[] {currentCoordinates[0] - 1, currentCoordinates[1], currentCoordinates[2] + 1};
                case "nw":
                    return new[] {currentCoordinates[0] - 1, currentCoordinates[1] + 1, currentCoordinates[2]};
                default:
                    return currentCoordinates;
            }
        }
    }
}
