using NUnit.Framework;

namespace Day10.Specs
{
    [TestFixture]
    public class KnotHashSpecs
    {
        KnotHash ClassUnderTest;
        ImportantValues Values;

        [TestFixtureSetUp]
        public void Setup()
        {
            ClassUnderTest = new KnotHash();

            Values = new ImportantValues
            {
                CurrentPosition = 0,
                SkipSize = 0,
                MarkList = ClassUnderTest.GenerateList()
            };
        }

        [Test]
        public void when_hasing_a_knot_example_1()
        {
            var lengths = "AoC 2017";
            var result = ClassUnderTest.Hash2(lengths);
            Assert.AreEqual("33efeb34ea91902bb2f59c9920caa6cd", result);
        }

        [Test]
        public void when_hasing_a_knot_puzzle_input()
        {
            var lengths = "157,222,1,2,177,254,0,228,159,140,249,187,255,51,76,30";
            var result = ClassUnderTest.Hash2(lengths);
            Assert.AreEqual("2b0c9cc0449507a0db3babd57ad9e8d8", result);
        }

        [Test]
        public void when_converting_1_2_3_to_ASCII()
        {
            var lengths = "1,2,3";
            var result = ClassUnderTest.ConvertToASCII(lengths);
            Assert.AreEqual(new[] { 49, 44, 50, 44, 51, 17, 31, 73, 47, 23 }, result);
        }

        [Test]
        public void when_getting_the_dense_hash_exapmle()
        {
            var lengths = new[] { 65, 27, 9, 1, 4, 3, 40, 50, 91, 7, 6, 0, 2, 5, 68, 22 };
            var denseHash = ClassUnderTest.DenseHash(lengths);
            Assert.AreEqual(new[] { 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, denseHash);
        }

        [Test]
        public void when_getting_the_hex_example()
        {
            var lengths = new[] { 64, 7, 255 };
            var hex = ClassUnderTest.ToHex(lengths);
            Assert.AreEqual("4007ff", hex);
        }
    }
}
