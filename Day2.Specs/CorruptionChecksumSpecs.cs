using NUnit.Framework;

namespace Day2.Specs
{
    [TestFixture]
    public class CorruptionChecksumSpecs
    {
        CorruptionChecksum ClassUnderTest;
        [TestFixtureSetUp]
        public void Setup()
        {
            ClassUnderTest = new CorruptionChecksum();
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_is_null()
        {
            var checksum = ClassUnderTest.GetChecksum(null);
            Assert.AreEqual(0, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_is_empty()
        {
            var spreadsheet = string.Empty;
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(0, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_has_one_line()
        {
            var spreadsheet = "1 2 3";
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(2, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_has_one_line_with_duplicate_values()
        {
            var spreadsheet = "1 2 1";
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(1, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_has_one_line_with_highest_value_first()
        {
            var spreadsheet = "3 2 1";
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(2, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_has_one_line_with_tab_separators()
        {
            var spreadsheet = "3\t2\t1";
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(2, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_has_two_lines()
        {
            var spreadsheet = "1 2 3\n4 5 6";
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(4, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_has_two_lines_with_extra_spaces()
        {
            var spreadsheet = " 1 2 3 \n 4 5 6 ";
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(4, checksum);
        }

        [Test]
        public void when_calculating_checksum_and_the_spreadsheet_has_three_lines()
        {
            var spreadsheet = " 1 2 3 \n 4 5 6 \n 7 8 9";
            var checksum = ClassUnderTest.GetChecksum(spreadsheet);
            Assert.AreEqual(6, checksum);
        }

        [Test]
        [TestCase("5 1 9 5 \n 7 5 3 \n 2 4 6 8", 18)]
        [TestCase("52 17 96 15 \n 157 59 513 \n 542 445 5416 8254", 8344)]
        [TestCase("798 1976	1866 1862 559 1797 1129	747	85 1108	104	2000 248 131 87	95 \n" +
            "201 419 336 65 208 57 74 433 68 360 390 412 355 209 330 135 \n" +
            "967 84 492 1425 1502 1324 1268 1113 1259 81 310 1360 773 69 68 290 \n" + 
            "169 264 107 298 38 149 56 126 276 45 305 403 89 179 394 172 \n" +
            "3069 387 2914 2748 1294 1143 3099 152 2867 3082 113 145 2827 2545 134 469 \n" +
            "3885 1098 2638 5806 4655 4787 186 4024 2286 5585 5590 215 5336 2738 218 266 \n" +
            "661 789 393 159 172 355 820 891 196 831 345 784 65 971 396 234 \n" +
            "4095 191 4333 161 3184 193 4830 4153 2070 3759 1207 3222 185 176 2914 4152 \n" +
            "131 298 279 304 118 135 300 74 269 96 366 341 139 159 17 149 \n" +
            "1155 5131 373 136 103 5168 3424 5126 122 5046 4315 126 236 4668 4595 4959 \n" +
            "664 635 588 673 354 656 70 86 211 139 95 40 84 413 618 31 \n" +
            "2163 127 957 2500 2370 2344 2224 1432 125 1984 2392 379 2292 98 456 154 \n" +
            "271 4026 2960 6444 2896 228 819 676 6612 6987 265 2231 2565 6603 207 6236 \n" +
            "91 683 1736 1998 1960 1727 84 1992 1072 1588 1768 74 58 1956 1627 893 \n" +
            "3591 1843 3448 1775 3564 2632 1002 3065 77 3579 78 99 1668 98 2963 3553 \n" +
            "2155 225 2856 3061 105 204 1269 171 2505 2852 977 1377 181 1856 2952 2262", 41919)]
        public void when_calculating_checksum(string spreadsheet, int checksum)
        {
            Assert.AreEqual(checksum, ClassUnderTest.GetChecksum(spreadsheet));
        }

        [Test]
        public void when_calculating_divisors_result_and_the_line_is_null()
        {
            Assert.AreEqual(0, ClassUnderTest.GetLineDivisorsResult(null));
        }

        [Test]
        public void when_calculating_divisors_result_and_the_line_is_empty()
        {
            Assert.AreEqual(0, ClassUnderTest.GetLineDivisorsResult(string.Empty));
        }

        [Test]
        public void when_calculating_divisors_result_and_the_line_has_one_value()
        {
            Assert.AreEqual(0, ClassUnderTest.GetLineDivisorsResult("1"));
        }

        [Test]
        public void when_calculating_divisors_result_and_the_line_has_two_values_that_are_identical()
        {
            var line = "4 4";
            var result = ClassUnderTest.GetLineDivisorsResult(line);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void when_calculating_divisors_result_and_the_line_has_two_values_that_do_NOT_divide_evenly()
        {
            var line = "4 3";
            var result = ClassUnderTest.GetLineDivisorsResult(line);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void when_calculating_divisors_result_and_the_line_has_two_values_that_do_divide_evenly()
        {
            var line = "4 2";
            var result = ClassUnderTest.GetLineDivisorsResult(line);
            Assert.AreEqual(2, result);
        }

        [Test]
        [TestCase("5 9 2 8 \n 9 4 7 3 \n 3 8 6 5", 9)]
        [TestCase("798 1976	1866 1862 559 1797 1129	747	85 1108	104	2000 248 131 87	95 \n" +
                  "201 419 336 65 208 57 74 433 68 360 390 412 355 209 330 135 \n" +
                  "967 84 492 1425 1502 1324 1268 1113 1259 81 310 1360 773 69 68 290 \n" +
                  "169 264 107 298 38 149 56 126 276 45 305 403 89 179 394 172 \n" +
                  "3069 387 2914 2748 1294 1143 3099 152 2867 3082 113 145 2827 2545 134 469 \n" +
                  "3885 1098 2638 5806 4655 4787 186 4024 2286 5585 5590 215 5336 2738 218 266 \n" +
                  "661 789 393 159 172 355 820 891 196 831 345 784 65 971 396 234 \n" +
                  "4095 191 4333 161 3184 193 4830 4153 2070 3759 1207 3222 185 176 2914 4152 \n" +
                  "131 298 279 304 118 135 300 74 269 96 366 341 139 159 17 149 \n" +
                  "1155 5131 373 136 103 5168 3424 5126 122 5046 4315 126 236 4668 4595 4959 \n" +
                  "664 635 588 673 354 656 70 86 211 139 95 40 84 413 618 31 \n" +
                  "2163 127 957 2500 2370 2344 2224 1432 125 1984 2392 379 2292 98 456 154 \n" +
                  "271 4026 2960 6444 2896 228 819 676 6612 6987 265 2231 2565 6603 207 6236 \n" +
                  "91 683 1736 1998 1960 1727 84 1992 1072 1588 1768 74 58 1956 1627 893 \n" +
                  "3591 1843 3448 1775 3564 2632 1002 3065 77 3579 78 99 1668 98 2963 3553 \n" +
                  "2155 225 2856 3061 105 204 1269 171 2505 2852 977 1377 181 1856 2952 2262", 303)]
        public void when_calculating_divisors_result_sum(string spreadsheet, int sum)
        {
            Assert.AreEqual(sum, ClassUnderTest.GetLineDivisorsResultSum(spreadsheet));
        }
    }
}
