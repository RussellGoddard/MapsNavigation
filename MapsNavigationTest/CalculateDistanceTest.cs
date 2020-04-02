using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MapsNavigation;

namespace MapsNavigationTest
{

    [TestFixture]
    class CalculateDistanceTest
    {
        [Test]
        public void test_ValidateDirectionsInput_InputValidString_OutputTrueAndListString()
        {
            string testInput = "L3, R2, N5, S0, E1000, W-10";
            List<String> returnList;

            Assert.IsTrue(CalculateDistance.ValidateDirectionsInput(testInput, out returnList));

            Assert.AreEqual(returnList.Count, 6);
            Assert.AreEqual(returnList[0], "L3");
            Assert.AreEqual(returnList[1], "R2");
            Assert.AreEqual(returnList[2], "N5");
            Assert.AreEqual(returnList[3], "S0");
            Assert.AreEqual(returnList[4], "E1000");
            Assert.AreEqual(returnList[5], "W-10");
        }

        [Test]
        public void test_ValidateDirectionsInput_InputInvalidString_OutputFalseAndNull()
        {
            string testInput = "this will fail";
            List<String> returnList;

            Assert.IsFalse(CalculateDistance.ValidateDirectionsInput(testInput, out returnList));

            Assert.IsNull(returnList);
        }

        [Test]
        public void test_TraverseDirections_InputListStringRelativeDirections_OutputCoordinates()
        {
            List<String> inputList = new List<String> { "L3", "R2", "L5", "R1", "L1", "L2" };

            MapsNavigation.Coordinates returnCoords = CalculateDistance.TraverseDirections(inputList);

            Assert.AreEqual(returnCoords.north, 1);
            Assert.AreEqual(returnCoords.east, -9);
            Assert.AreEqual(returnCoords.TotalDistance(), 10);
            Assert.AreEqual(returnCoords.facing, "South");
        }

        [Test]
        public void test_TraverseDirections_InputListStringCardinalDirections_OutputCoordinates()
        {
            List<String> inputList = new List<String> { "N5", "S0", "E1000", "W-10" };

            MapsNavigation.Coordinates returnCoords = CalculateDistance.TraverseDirections(inputList);

            Assert.AreEqual(returnCoords.north, 5);
            Assert.AreEqual(returnCoords.east, 1010);
            Assert.AreEqual(returnCoords.TotalDistance(), 1015);
            Assert.AreEqual(returnCoords.facing, "West");
        }
    }
}
