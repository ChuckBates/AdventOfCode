using NUnit.Framework;

namespace Day10.Specs
{
    [TestFixture]
    public class KnotHashSpecs
    {
        KnotHash ClassUnderTest;

        [TestFixtureSetUp]
        public void Setup()
        {
            ClassUnderTest = new KnotHash();
            ClassUnderTest.KeyList = ClassUnderTest.GenerateList();
        }

        [Test]
        public void when_hashing_a_knot_and_the_lengths_are_null_empty()
        {
            var result = ClassUnderTest.Hash(null);
            Assert.AreEqual(0, result);

            result = ClassUnderTest.Hash(new int[] { });
            Assert.AreEqual(0, result);
        }

        [Test]
        public void when_hashing_a_knot_and_there_is_one_length_of_one()
        {
            var lengths = new[] { 1 };
            var result = ClassUnderTest.Hash(lengths);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void when_hashing_a_knot_and_there_is_one_length_greater_than_256()
        {
            var lengths = new[] { 1000 };
            var result = ClassUnderTest.Hash(lengths);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void when_hashing_a_knot_with_test_marks_example()
        {
            ClassUnderTest.KeyList = GenerateList();

            var lengths = new[] { 3, 4, 1, 5 };
            var result = ClassUnderTest.Hash(lengths);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void when_hashing_a_knot_with_puzzle_input()
        {
            var lengths = new[] { 157, 222, 1, 2, 177, 254, 0, 228, 159, 140, 249, 187, 255, 51, 76, 30 };
            var result = ClassUnderTest.Hash(lengths);
            Assert.AreEqual(62238, result);
        }

        private int[] GenerateList()
        {
            var list = new int[5];
            for (int i = 0; i < 5; i++)
            {
                list[i] = i;
            }

            return list;
        }
    }
}
