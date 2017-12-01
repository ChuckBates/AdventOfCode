using System.Collections.Generic;

namespace Day1
{
    public class InverseCaptcha
    {
        public int GetSum(string puzzle)
        {
            var sum = 0;
            if (!string.IsNullOrEmpty(puzzle) && puzzle.Length >= 2)
            {
                var digits = puzzle.ToCharArray();
                for (int i = 0; i < digits.Length; i++)
                {
                    int next = i + 1 < digits.Length ? digits[i + 1] : digits[0];
                    var current = digits[i];
                    if (current == next)
                    {
                        sum += (int) char.GetNumericValue(current);
                    }
                }
            }
            return sum;
        }

        public int GetHalfwaySum(string puzzle)
        {
            var sum = 0;
            var half = puzzle.Length / 2;
            if (!string.IsNullOrEmpty(puzzle) && puzzle.Length >= 2)
            {
                var digits = puzzle.ToCharArray();
                for (int i = 0; i < digits.Length; i++)
                {
                    int next = GetNextHalfway(i, half, digits);
                    var current = digits[i];
                    if (current == next)
                    {
                        sum += (int)char.GetNumericValue(current);
                    }
                }
            }
            return sum;
        }

        private char GetNextHalfway(int index, int half, char[] digits)
        {
            char next;
            if (index + half >= digits.Length)
            {
                next = digits[index + half - digits.Length];
            }
            else
            {
                next = digits[index + half];
            }

            return next;
        }
    }
}
