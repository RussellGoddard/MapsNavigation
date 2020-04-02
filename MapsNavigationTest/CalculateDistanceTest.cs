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
        public void test_ValidateDirectionsInput_InputLowerCaseString_OutputTrueAndListStringAllUpperCase()
        {
            string testInput = "l3, r2, n5, s0, e1000, w-10";
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

        [Test]
        public void test_TraverseDirections_InputListStringExample1_OutputCoordinates()
        {
            List<String> inputList = new List<String> { "R2", "L3" };

            MapsNavigation.Coordinates returnCoords = CalculateDistance.TraverseDirections(inputList);

            Assert.AreEqual(returnCoords.north, 3);
            Assert.AreEqual(returnCoords.east, 2);
            Assert.AreEqual(returnCoords.TotalDistance(), 5);
            Assert.AreEqual(returnCoords.facing, "North");
        }

        [Test]
        public void test_TraverseDirections_InputListStringExample2_OutputCoordinates()
        {
            List<String> inputList = new List<String> { "R2", "R2", "R2" };

            MapsNavigation.Coordinates returnCoords = CalculateDistance.TraverseDirections(inputList);

            Assert.AreEqual(returnCoords.north, -2);
            Assert.AreEqual(returnCoords.east, 0);
            Assert.AreEqual(returnCoords.TotalDistance(), 2);
            Assert.AreEqual(returnCoords.facing, "West");
        }

        [Test]
        public void test_TraverseDirections_InputListStringExample3_OutputCoordinates()
        {
            List<String> inputList = new List<String> { "R5", "L5", "R5", "R3" };

            MapsNavigation.Coordinates returnCoords = CalculateDistance.TraverseDirections(inputList);

            Assert.AreEqual(returnCoords.north, 2);
            Assert.AreEqual(returnCoords.east, 10);
            Assert.AreEqual(returnCoords.TotalDistance(), 12);
            Assert.AreEqual(returnCoords.facing, "South");
        }

        [Test]
        public void test_TraverseDirections_InputListStringExample4_OutputCoordinates()
        {
            List<String> inputList = new List<String> { "L3", "R2", "L5", "R1", "L1", "L2", "L2", "R1", "R5", "R1", "L1", "L2", "R2", "R4", "L4", "L3", "L3", "R5", "L1", "R3", "L5", "L2", "R4", "L5", "R4", "R2", "L2", "L1", "R1", "L3", "L3", "R2", "R1", "L4", "L1", "L1", "R4", "R5", "R1", "L2", "L1", "R188", "R4", "L3", "R54", "L4", "R4", "R74", "R2", "L4", "R185", "R1", "R3", "R5", "L2", "L3", "R1", "L1", "L3", "R3", "R2", "L3", "L4", "R1", "L3", "L5", "L2", "R2", "L1", "R2", "R1", "L4", "R5", "R4", "L5", "L5", "L4", "R5", "R4", "L5", "L3", "R4", "R1", "L5", "L4", "L3", "R5", "L5", "L2", "L4", "R4", "R4", "R2", "L1", "L3", "L2", "R5", "R4", "L5", "R1", "R2", "R5", "L2", "R4", "R5", "L2", "L3", "R3", "L4", "R3", "L2", "R1", "R4", "L5", "R1", "L5", "L3", "R4", "L2", "L2", "L5", "L5", "R5", "R2", "L5", "R1", "L3", "L2", "L2", "R3", "L3", "L4", "R2", "R3", "L1", "R2", "L5", "L3", "R4", "L4", "R4", "R3", "L3", "R1", "L3", "R5", "L5", "R1", "R5", "R3", "L1" };

            MapsNavigation.Coordinates returnCoords = CalculateDistance.TraverseDirections(inputList);

            Assert.AreEqual(returnCoords.north, 78);
            Assert.AreEqual(returnCoords.east, -131);
            Assert.AreEqual(returnCoords.TotalDistance(), 209);
            Assert.AreEqual(returnCoords.facing, "West");
        }
    }
}
