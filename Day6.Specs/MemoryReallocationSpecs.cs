using NUnit.Framework;

namespace Day6.Specs
{
    [TestFixture]
    public class MemoryReallocationSpecs
    {
        MemoryReallocation ClassUnderTest;

        [TestFixtureSetUp]
        public void Setup()
        {
            ClassUnderTest = new MemoryReallocation();
        }

        [Test]
        public void when_getting_largest_bank_index_and_there_is_one_bank()
        {
            var banks = new[] { 1 };
            var index = ClassUnderTest.GetLargestBankIndex(banks);
            Assert.AreEqual(0, index);
        }

        [Test]
        public void when_getting_largest_bank_index_and_there_are_two_identical_banks()
        {
            var banks = new[] { 3, 3 };
            var index = ClassUnderTest.GetLargestBankIndex(banks);
            Assert.AreEqual(0, index);
        }

        [Test]
        public void when_getting_largest_bank_index_and_there_are_many_varied_banks()
        {
            var banks = new[] { 3, 7, 9, 42 };
            var index = ClassUnderTest.GetLargestBankIndex(banks);
            Assert.AreEqual(3, index);
        }

        [Test]
        public void when_redistributing_memory_and_there_is_one_bank()
        {
            var banks = new[] { 0 };
            var result = ClassUnderTest.RedistributeMemory(banks);
            Assert.AreEqual(banks, result);
        }

        [Test]
        public void when_redistributing_memory_and_there_are_two_non_circular_banks()
        {
            var banks = new[] { 1, 0 };
            var result = ClassUnderTest.RedistributeMemory(banks);
            Assert.AreEqual(new[] { 0, 1 }, result);
        }

        [Test]
        public void when_redistributing_memory_and_there_are_two_circular_banks()
        {
            var banks = new[] { 2, 0 };
            var result = ClassUnderTest.RedistributeMemory(banks);
            Assert.AreEqual(new[] { 1, 1 }, result);
        }

        [Test]
        public void when_redistributing_memory_and_there_are_three_multi_circular_banks()
        {
            var banks = new[] { 2, 0, 7 };
            var result = ClassUnderTest.RedistributeMemory(banks);
            Assert.AreEqual(new[] { 5, 2, 2 }, result);
        }

        [Test]
        public void when_calculating_cycles_of_memory_reallocation_and_there_are_no_banks()
        {
            var banks = new int[] { };
            var cycles = ClassUnderTest.GetRedistributionCycles(banks);
            Assert.AreEqual(0, cycles);
        }

        [Test]
        public void when_calculating_cycles_of_memory_reallocation_and_there_is_one_bank()
        {
            var banks = new[] { 1 };
            var cycles = ClassUnderTest.GetRedistributionCycles(banks);
            Assert.AreEqual(0, cycles);
        }

        [Test]
        public void when_calculating_cycles_of_memory_reallocation_and_there_are_two_identical_banks()
        {
            var banks = new[] { 1, 1 };
            var cycles = ClassUnderTest.GetRedistributionCycles(banks);
            Assert.AreEqual(2, cycles);
        }

        [Test]
        public void when_calculating_cycles_of_memory_reallocation_and_there_are_three_unique_banks()
        {
            var banks = new[] { 1, 0, 1 };
            var cycles = ClassUnderTest.GetRedistributionCycles(banks);
            Assert.AreEqual(5, cycles);
        }

        [Test]
        public void when_calculating_cycles_of_memory_reallocation_for_puzzle_input()
        {
            var banks = new[] { 2, 8, 8, 5, 4, 2, 3, 1, 5, 5, 1, 2, 15, 13, 5, 14 };
            var cycles = ClassUnderTest.GetRedistributionCycles(banks);
            Assert.AreEqual(3156, cycles);
        }
    }
}
