using System.Collections.Generic;

namespace Day6
{
    public class MemoryReallocation
    {
        public int[] GetRedistributionCycles(int[] banks)
        {
            var cycles = 0;
            var counter = 0;
            var states = new Dictionary<string, int>();
            states.Add(string.Join(", ", banks), counter++);

            if (banks.Length > 1)
            {
                while (true)
                {
                    banks = RedistributeMemory(banks);
                    cycles++;

                    if (states.ContainsKey(string.Join(", ", banks)))
                    {
                        break;
                    }

                    states.Add(string.Join(", ", banks), counter++);
                }
            }

            return new[] { cycles, cycles - states[string.Join(", ", banks)] };
        }

        public int[] RedistributeMemory(int[] banks)
        {
            var index = GetLargestBankIndex(banks);
            var bankValue = banks[index];
            banks[index] = 0;
            if (bankValue > 0)
            {
                for (int i = index + 1; i <= banks.Length; i++)
                {
                    if (bankValue <= 0)
                    {
                        break;
                    }

                    if (i >= banks.Length)
                    {
                        i = 0;
                    }

                    banks[i] = banks[i] + 1;
                    bankValue--;
                }
            }

            return banks;
        }

        public int GetLargestBankIndex(int[] banks)
        {
            var highestBank = 0;
            var highestBankIndex = 0;
            if (banks.Length > 1)
            {
                for (int i = 0; i < banks.Length; i++)
                {
                    if (banks[i] > highestBank)
                    {
                        highestBank = banks[i];
                        highestBankIndex = i;
                    }
                }
            }

            return highestBankIndex;
        }
    }
}
