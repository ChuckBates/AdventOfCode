using System;
using System.Collections.Generic;
using System.Text;

namespace Day10
{
    public class KnotHash
    {
        public int[] KeyList { get; set; }

        public int Hash(int[] lengths)
        {
            if (lengths == null || lengths.Length == 0)
            {
                return 0;
            }

            var currentPosition = 0;
            var skipSize = 0;
            var list = KeyList;
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
                    currentPosition = currentPosition - list.Length;
                }
                skipSize++;
            }

            return list[0] * list[1];
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
    }
}
