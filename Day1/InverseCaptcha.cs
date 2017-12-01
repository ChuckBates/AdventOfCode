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
    }
}
