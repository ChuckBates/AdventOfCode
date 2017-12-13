using System.Collections.Generic;
using NUnit.Framework;

namespace Day13.Specs
{
    [TestFixture]
    public class PacketScannerSpecs
    {
        PacketScanner ClassUnderTest;

        [TestFixtureSetUp]
        public void Setup()
        {
            ClassUnderTest = new PacketScanner();
        }

        [Test]
        public void when_moving_a_scanner_forward_and_the_scanner_is_empty()
        {
            var scannerPreMove = new int[0];
            var scannerPostMove = ClassUnderTest.MoveScannerForward(scannerPreMove);
            Assert.AreEqual(scannerPreMove, scannerPostMove);
        }

        [Test]
        public void when_moving_a_scanner_forward_and_the_scanner_has_position_zero_and_range_one_and_was_traveling_down()
        {
            var scannerPreMove = new[] { 0, 1, -1 };
            var scannerPostMove = ClassUnderTest.MoveScannerForward(scannerPreMove);
            Assert.AreEqual(new[] { 0, 1, -1 }, scannerPostMove);
        }

        [Test]
        public void when_moving_a_scanner_forward_and_the_scanner_has_position_zero_and_range_one_and_was_traveling_up()
        {
            var scannerPreMove = new[] { 0, 1, 1 };
            var scannerPostMove = ClassUnderTest.MoveScannerForward(scannerPreMove);
            Assert.AreEqual(new[] { 0, 1, 1 }, scannerPostMove);
        }

        [Test]
        public void when_moving_a_scanner_forward_and_the_scanner_has_position_one_and_range_two_and_was_traveling_down()
        {
            var scannerPreMove = new[] { 1, 2, -1 };
            var scannerPostMove = ClassUnderTest.MoveScannerForward(scannerPreMove);
            Assert.AreEqual(new[] { 0, 2, 1 }, scannerPostMove);
        }

        [Test]
        public void when_moving_a_scanner_forward_and_the_scanner_has_position_one_and_range_two_and_was_traveling_up()
        {
            var scannerPreMove = new[] { 1, 2, 1 };
            var scannerPostMove = ClassUnderTest.MoveScannerForward(scannerPreMove);
            Assert.AreEqual(new[] { 0, 2, 1 }, scannerPostMove);
        }

        [Test]
        public void when_moving_a_scanner_forward_and_the_scanner_has_position_two_and_range_three_and_was_traveling_up()
        {
            var scannerPreMove = new[] { 2, 3, 1 };
            var scannerPostMove = ClassUnderTest.MoveScannerForward(scannerPreMove);
            Assert.AreEqual(new[] { 1, 3, 1 }, scannerPostMove);
        }

        [Test]
        public void when_moving_a_scanner_forward_and_the_scanner_has_position_two_and_range_three_and_was_traveling_down()
        {
            var scannerPreMove = new[] { 2, 3, -1 };
            var scannerPostMove = ClassUnderTest.MoveScannerForward(scannerPreMove);
            Assert.AreEqual(new[] { 1, 3, 1 }, scannerPostMove);
        }

        [Test]
        public void when_moving_multiple_scanners_forward_example_1()
        {
            var scannersPreMove = new Dictionary<int, int[]>
            {
                { 0, new [] { 0, 3, -1 } },
                { 1, new [] { 0, 2, -1 } },
                { 4, new [] { 0, 4, -1 } },
                { 6, new [] { 0, 4, -1 } }
            };
            var scannersPostMove = ClassUnderTest.MoveScannersForward(scannersPreMove);
            var expectedScanners = new Dictionary<int, int[]>
            {
                { 0, new [] { 1, 3, -1 } },
                { 1, new [] { 1, 2, -1 } },
                { 4, new [] { 1, 4, -1 } },
                { 6, new [] { 1, 4, -1 } }
            };
            Assert.AreEqual(expectedScanners, scannersPostMove);
        }

        [Test]
        public void when_moving_multiple_scanners_forward_example_2()
        {
            var scannersPreMove = new Dictionary<int, int[]>
            {
                { 0, new [] { 2, 3, 1 } },
                { 1, new [] { 0, 2, -1 } },
                { 4, new [] { 2, 4, -1 } },
                { 6, new [] { 2, 4, -1 } }
            };
            var scannersPostMove = ClassUnderTest.MoveScannersForward(scannersPreMove);
            var expectedScanners = new Dictionary<int, int[]>
            {
                { 0, new [] { 1, 3, 1 } },
                { 1, new [] { 1, 2, -1 } },
                { 4, new [] { 3, 4, -1 } },
                { 6, new [] { 3, 4, -1 } }
            };
            Assert.AreEqual(expectedScanners, scannersPostMove);
        }

        [Test]
        public void when_checking_is_packet_caught_true()
        {
            var packetPosition = 0;
            var scanners = new Dictionary<int, int[]>
            {
                { 0, new [] { 0, 3, -1 } },
                { 1, new [] { 0, 2, -1 } },
                { 4, new [] { 0, 4, -1 } },
                { 6, new [] { 0, 4, -1 } }
            };
            var result = ClassUnderTest.IsPacketCaught(packetPosition, scanners);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void when_checking_is_packet_caught_false()
        {
            var packetPosition = 3;
            var scanners = new Dictionary<int, int[]>
            {
                { 0, new [] { 0, 3, -1 } },
                { 1, new [] { 0, 2, -1 } },
                { 4, new [] { 0, 4, -1 } },
                { 6, new [] { 0, 4, -1 } }
            };
            var result = ClassUnderTest.IsPacketCaught(packetPosition, scanners);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void when_getting_caught_severity_example_1()
        {
            var packetPosition = 0;
            var scanners = new Dictionary<int, int[]>
            {
                { 0, new [] { 0, 3, -1 } },
                { 1, new [] { 0, 2, -1 } },
                { 4, new [] { 0, 4, -1 } },
                { 6, new [] { 0, 4, -1 } }
            };
            var result = ClassUnderTest.CaughtSeverity(packetPosition, scanners);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void when_getting_caught_severity_example_2()
        {
            var packetPosition = 6;
            var scanners = new Dictionary<int, int[]>
            {
                { 0, new [] { 2, 3, -1 } },
                { 1, new [] { 0, 2, -1 } },
                { 4, new [] { 0, 4, -1 } },
                { 6, new [] { 0, 4, -1 } }
            };
            var result = ClassUnderTest.CaughtSeverity(packetPosition, scanners);
            Assert.AreEqual(24, result);
        }

        [Test]
        public void when_getting_total_caught_severity_example()
        {
            var scanners = new Dictionary<int, int[]>
            {
                { 0, new [] { 0, 3, -1 } },
                { 1, new [] { 0, 2, -1 } },
                { 4, new [] { 0, 4, -1 } },
                { 6, new [] { 0, 4, -1 } }
            };
            var totalSeverity = ClassUnderTest.GetTotalSeverity(scanners);
            Assert.AreEqual(24, totalSeverity);
        }

        [Test]
        public void when_getting_total_caught_severity_puzzle_input()
        {
            var scanners = new Dictionary<int, int[]>
            {
                { 0, new[] { 0, 3, -1 } },
                { 1, new[] { 0, 2, -1 } },
                { 2, new[] { 0, 4, -1 } },
                { 4, new[] { 0, 8, -1 } },
                { 6, new[] { 0, 5, -1 } },
                { 8, new[] { 0, 6, -1 } },
                { 10, new[] { 0, 6, -1 } },
                { 12, new[] { 0, 4, -1 } },
                { 14, new[] { 0, 6, -1 } },
                { 16, new[] { 0, 6, -1 } },
                { 18, new[] { 0, 9, -1 } },
                { 20, new[] { 0, 8, -1 } },
                { 22, new[] { 0, 8, -1 } },
                { 24, new[] { 0, 8, -1 } },
                { 26, new[] { 0, 8, -1 } },
                { 28, new[] { 0, 10, -1 } },
                { 30, new[] { 0, 8, -1 } },
                { 32, new[] { 0, 12, -1 } },
                { 34, new[] { 0, 10, -1 } },
                { 36, new[] { 0, 14, -1 } },
                { 38, new[] { 0, 12, -1 } },
                { 40, new[] { 0, 12, -1 } },
                { 42, new[] { 0, 12, -1 } },
                { 44, new[] { 0, 12, -1 } },
                { 46, new[] { 0, 12, -1 } },
                { 48, new[] { 0, 12, -1 } },
                { 50, new[] { 0, 14, -1 } },
                { 52, new[] { 0, 12, -1 } },
                { 54, new[] { 0, 14, -1 } },
                { 56, new[] { 0, 12, -1 } },
                { 58, new[] { 0, 12, -1 } },
                { 60, new[] { 0, 14, -1 } },
                { 62, new[] { 0, 18, -1 } },
                { 64, new[] { 0, 14, -1 } },
                { 68, new[] { 0, 14, -1 } },
                { 70, new[] { 0, 14, -1 } },
                { 72, new[] { 0, 14, -1 } },
                { 74, new[] { 0, 14, -1 } },
                { 78, new[] { 0, 14, -1 } },
                { 80, new[] { 0, 20, -1 } },
                { 82, new[] { 0, 14, -1 } },
                { 84, new[] { 0, 14, -1 } },
                { 90, new[] { 0, 17, -1 } }
            };
            var totalSeverity = ClassUnderTest.GetTotalSeverity(scanners);
            Assert.AreEqual(1728, totalSeverity);
        }
    }
}
