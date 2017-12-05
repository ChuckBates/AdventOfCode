using System.Collections.Generic;

namespace Day5
{
    public class JumpMaze
    {
        public string[] Offsets;

        public int GetStepsToEscape(string maze)
        {
            if (string.IsNullOrEmpty(maze))
            {
                return 0;
            }

            Offsets = maze.Split(' ');
            if (int.Parse(Offsets[0]) >= maze.Length)
            {
                return 1;
            }

            var steps = 0;
            var position = 0;
            while (true)
            {
                steps++;
                var currentOffset = int.Parse(Offsets[position]);
                if (currentOffset >= Offsets.Length - position)
                {
                    return steps;
                }
                Offsets[position] = (currentOffset >= 3 ? currentOffset - 1 : currentOffset + 1).ToString();
                position = position + currentOffset;
            }
        }
    }
}
