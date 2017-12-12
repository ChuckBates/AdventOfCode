using System.Collections.Generic;
using System.Text;

namespace Day10
{
    public class KnotHash
    {
        public ImportantValues Hash(int[] lengths, ImportantValues values)
        {
            if (lengths == null || lengths.Length == 0)
            {
                return null;
            }

            var currentPosition = values.CurrentPosition;
            var skipSize = values.SkipSize;
            var list = values.MarkList;
            foreach (var length in lengths)
            {
                if (length > 256)
                {
                    continue;
                }

                list = SelectAndTwist(list, length, currentPosition);

                currentPosition += length + skipSize;
                if (currentPosition >= list.Length)
                {
                    var newPosition = currentPosition;
                    while (newPosition > 255)
                    {
                        newPosition = newPosition - 256;
                    }
                    currentPosition = newPosition;
                }
                skipSize++;
            }

            return new ImportantValues
            {
                CurrentPosition = currentPosition,
                SkipSize = skipSize,
                MarkList = list
            };
        }

        private int[] SelectAndTwist(int[] list, int length, int currentPosition)
        {
            var selection = new List<int>();
            var index = currentPosition;
            for (int i = 0; i < length; i++)
            {
                if (index >= list.Length)
                {
                    index = 0;
                }
                selection.Add(list[index]);
                index++;
            }

            selection.Reverse();

            index = currentPosition;
            foreach (var mark in selection)
            {
                if (index >= list.Length)
                {
                    index = 0;
                }
                list[index] = mark;
                index++;
            }

            return list;
        }

        public int[] GenerateList()
        {
            var list = new int[256];
            for (int i = 0; i < 256; i++)
            {
                list[i] = i;
            }

            return list;
        }

        public int[] ConvertToASCII(string list)
        {
            var bytes = Encoding.ASCII.GetBytes(list);
            var ints = new List<int>();
            foreach (var b in bytes)
            {
                ints.Add(b);
            }
            ints.Add(17);
            ints.Add(31);
            ints.Add(73);
            ints.Add(47);
            ints.Add(23);

            return ints.ToArray();
        }

        public string Hash2(string lengths)
        {
            var newLengths = ConvertToASCII(lengths);
            var list = GenerateList();
            var currentPosition = 0;
            var skipSize = 0;
            for (int i = 0; i < 64; i++)
            {
                var values = Hash(newLengths, new ImportantValues
                {
                    MarkList = list,
                    CurrentPosition = currentPosition,
                    SkipSize = skipSize
                });

                list = values.MarkList;
                currentPosition = values.CurrentPosition;
                skipSize = values.SkipSize;
            }

            list = DenseHash(list);
            return ToHex(list);
        }

        public string ToHex(int[] list)
        {
            var result = "";
            foreach (var mark in list)
            {
                result += mark.ToString("x2");
            }
            return result;
        }

        public int[] DenseHash(int[] list)
        {
            var newList = new List<int>();
            int xorValue = 0;
            var index = 0;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (index >= list.Length)
                    {
                        break;
                    }
                    xorValue = xorValue ^ list[index];
                    index++;
                }
                newList.Add(xorValue);
                xorValue = 0;
            }

            return newList.ToArray();
        }
    }

    public class ImportantValues
    {
        public int CurrentPosition { get; set; }
        public int SkipSize { get; set; }
        public int[] MarkList { get; set; }
    }
}
