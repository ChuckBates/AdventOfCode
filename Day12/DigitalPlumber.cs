using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    public class DigitalPlumber
    {
        Dictionary<int, int[]> pipes = new Dictionary<int, int[]>();

        public Dictionary<int, int[]> ParsePipes(string pipesPrimitve)
        {
            var pipes = new Dictionary<int, int[]>();
            if (!string.IsNullOrEmpty(pipesPrimitve))
            {
                foreach (var pipe in pipesPrimitve.Split('\n'))
                {
                    var pipePieces = pipe.Split(' ');
                    pipes.Add(int.Parse(pipePieces[0]), ParsePieces(pipePieces[2]));
                }
            }
            return pipes;
        }

        public int[] ParsePieces(string connectedPipes)
        {
            var pipes = connectedPipes.Split(',');
            var pieces = new int[pipes.Length];
            for (var i = 0; i < pipes.Length; i++)
            {
                pieces[i] = int.Parse(pipes[i].Trim());
            }

            return pieces;
        }

        public int PipesConnectedToProgram(string pipeList)
        {
            pipes = ParsePipes(pipeList);
            var connectedPrograms = new List<int>();
            connectedPrograms.Add(0);
            AddConnectedPrograms(connectedPrograms, pipes[0]);

            return connectedPrograms.Count;
        }

        public int CountProgramGroups(string pipeList)
        {
            pipes = ParsePipes(pipeList);
            var programGroups = 0;
            var connectedPrograms = new List<int>();
            foreach (var program in pipes)
            {
                if (!connectedPrograms.Contains(program.Key))
                {
                    AddConnectedPrograms(connectedPrograms, program.Value);
                    programGroups++;
                }
            }

            return programGroups;
        }

        public void AddConnectedPrograms(List<int> connectedPrograms, int[] programs)
        {
            foreach (var program in programs)
            {
                if (!connectedPrograms.Contains(program))
                {
                    connectedPrograms.Add(program);
                    AddConnectedPrograms(connectedPrograms, pipes[program]);
                }
            }
        }
    }
}
