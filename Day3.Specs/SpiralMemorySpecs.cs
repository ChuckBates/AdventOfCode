using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Day3.Specs
{
    [TestFixture]
    public class SpiralMemorySpecs
    {
        SpiralMemory ClassUnderTest;
        [TestFixtureSetUp]
        public void Setup()
        {
            ClassUnderTest = new SpiralMemory();
        }

        [Test]
        public void when_getting_steps_and_at_sqare_2()
        {
            var square = 2;
            var steps = ClassUnderTest.GetSteps(square);
            Assert.AreEqual(1, steps);
        }

        [Test]
        public void when_getting_3x3_grid()
        {
            var square = 9;
            var grid = ClassUnderTest.GetGrid(square);
            var expected = new Dictionary<int, int[]>
            {
                {9, new []{1,-1}},
                {8, new []{0,-1}},
                {7, new []{-1,-1}},
                {6, new []{-1,0}},
                {5, new []{-1,1}},
                {4, new []{0,1}},
                {3, new []{1,1}},
                {2, new []{1,0}}
            };
            Assert.AreEqual(expected, grid);
        }

        [Test]
        public void when_getting_steps_and_at_sqare_277678()
        {
            var square = 277678;
            var steps = ClassUnderTest.GetSteps(square);
            Assert.AreEqual(475, steps);
        }
    }
}
