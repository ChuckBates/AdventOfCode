using System.Collections.Generic;
using System.Linq;

namespace Day13
{
    public class PacketScanner
    {
        public int GetTotalSeverity(Dictionary<int, int[]> scanners)
        {
            var iterations = scanners.Keys.Max();
            var totalSeverity = 0;
            for (int i = 0; i <= iterations; i++)
            {
                if (IsPacketCaught(i, scanners))
                {
                    totalSeverity += CaughtSeverity(i, scanners);
                }
                scanners = MoveScannersForward(scanners);
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
