using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Day2
{
    public class CorruptionChecksum
    {
        public int GetChecksum(string spreadsheet)
        {
            int checksum = 0;
            if (!string.IsNullOrEmpty(spreadsheet))
            {
                var lineDifferences = new List<int>();
                string[] lines = spreadsheet.Split('\n');
                foreach (var line in lines)
                {
                    lineDifferences.Add(GetLineDifference(line.Trim()));
                }

                checksum = lineDifferences.Sum();
            }
            
            return checksum;
        }

        private int GetLineDifference(string line)
        {
            string[] values = line.Split(' ', '\t');
            int low = -1;
            int high = -1;
            foreach (var value in values)
            {
                var intValue = int.Parse(value.Trim());
                if (low < 0 || intValue < low)
                {
                    low = intValue;
                }

                if (high < 0 || intValue > high)
                {
                    high = intValue;
                }
            }
            return high - low;
        }

        public int GetLineDivisorsResultSum(string spreadsheet)
        {
            var lineDivisorsResultSums = new List<int>();
            string[] lines = spreadsheet.Split('\n');
            foreach (var line in lines)
            {
                lineDivisorsResultSums.Add(GetLineDivisorsResult(line.Trim()));
            }
            return lineDivisorsResultSums.Sum();
        }

        public int GetLineDivisorsResult(string line)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(line))
            {
                string[] values = line.Split(' ', '\t');
                foreach (var value in values)
                {
                    foreach (var innerValue in values)
                    {
                        if (value.Equals(innerValue))
                        {
                            continue;
                        }
                        if (int.Parse(value.Trim()) % int.Parse(innerValue.Trim()) == 0)
                        {
                            return int.Parse(value.Trim()) / int.Parse(innerValue.Trim());
                        }
                    }
                }
            }

            return result;
        }
    }
}
