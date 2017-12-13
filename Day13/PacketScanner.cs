using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day13
{
    public class PacketScanner
    {
        public int GetSmallestDelay(Dictionary<int, int[]> scanners)
        {
            var start = Stopwatch.StartNew();
            var delay = 0;
            while(true)
            {
                var caught = false;
                foreach (var scanner in scanners)
                {
                    var time = scanner.Key + delay;
                    var range = scanner.Value[1];
                    if (time % ((range - 1) * 2) == 0)
                    {
                        caught = true;
                        break;
                    }
                }
                if (!caught)
                {
                    Console.Out.WriteLine(start.ElapsedMilliseconds);
                    return delay;
                }
                delay++;
            }
        }

        public int GetScannerCycle(int time, int range)
        {
            return time % ((range - 1) * 2);
        }

        public int GetTotalSeverity(int delay, Dictionary<int, int[]> scanners)
        {
            var firewallScanners = new Dictionary<int, int[]>();
            foreach (var scanner in scanners)
            {
                var copy = new int[scanner.Value.Length];
                scanner.Value.CopyTo(copy, 0);
                firewallScanners.Add(scanner.Key, copy);
            }

            var iterations = firewallScanners.Keys.Max();
            var totalSeverity = 0;
            for (int i = delay * -1; i <= iterations; i++)
            {
                if (IsPacketCaught(i, firewallScanners))
                {
                    totalSeverity += CaughtSeverity(i, firewallScanners);
                }
                firewallScanners = MoveScannersForward(firewallScanners);
            }

            return totalSeverity;
        }

        public int CaughtSeverity(int packetPostition, Dictionary<int, int[]> scanners)
        {
            if (!scanners.ContainsKey(packetPostition))
            {
                return 0;
            }

            return scanners[packetPostition][1] * packetPostition;
        }

        public bool IsPacketCaught(int packetPosition, Dictionary<int, int[]> scanners)
        {
            if (!scanners.ContainsKey(packetPosition))
            {
                return false;
            }
            return scanners[packetPosition][0] == 0;
        }

        public Dictionary<int, int[]> MoveScannersForward(Dictionary<int, int[]> scanners)
        {
            var newScanners = new Dictionary<int, int[]>();
            foreach (var scanner in scanners)
            {
                newScanners.Add(scanner.Key, MoveScannerForward(scanner.Value));
            }

            return newScanners;
        }

        public int[] MoveScannerForward(int[] scannerPreMove)
        {
            if (scannerPreMove.Length == 0 || scannerPreMove[1] <= 1)
            {
                return scannerPreMove;
            }

            if (scannerPreMove[0] == scannerPreMove[1] - 1 && scannerPreMove[2] == -1)
            {
                scannerPreMove[0]--;
                scannerPreMove[2] *= -1;
            }
            else if (scannerPreMove[0] == 0 && scannerPreMove[2] == 1)
            {
                scannerPreMove[0]++;
                scannerPreMove[2] *= -1;
            }
            else
            {
                if (scannerPreMove[2] == -1)
                {
                    scannerPreMove[0]++;
                }
                else
                {
                    scannerPreMove[0]--;
                }
            }

            return scannerPreMove;
        }
    }
}
