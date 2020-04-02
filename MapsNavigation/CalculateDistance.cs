using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MapsNavigation
{
    public struct Coordinates
    {
        public int north;
        public int east;
        public string facing;

        public int TotalDistance()
        {
            return Math.Abs(north) + Math.Abs(east);
        }
    }


    public static class CalculateDistance
    {
        /// <summary>
        /// Validates user input for directions
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outputList"></param>
        /// <returns>Bool indicating pass/fail and an output List<String> of the split input</returns>
        public static bool ValidateDirectionsInput(string input, out List<String> outputList)
        {
            outputList = null;
            List<String> splitString = input.Split(',').Select(input => input.ToUpper().Trim()).ToList();

            foreach (string x in splitString)
            {
                //check to see if first character is (L, R, N, E, S, W) then see if remaining string is all digits with an optional negative symbol
                Regex validCharacters = new Regex(@"^[LRNESW]-?\d+$");
                if (!validCharacters.IsMatch(x))
                {
                    return false;
                }
            }

            outputList = splitString;
            return true;
        }

        /// <summary>
        /// Traverses directions passed in, validation must be done prior to this method
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Coordinates struct with how many blocks north and east the directions traveled as well as final facing</returns>
        public static Coordinates TraverseDirections(List<String> input)
        {
            //input already validated
            int north = 0;
            int east = 0;
            int currentFacing = 0;

            foreach(string x in input)
            {
                //get first character
                char direction = x[0];
                currentFacing = newFacing(currentFacing, direction);
                //get the rest assume it can be turned into int
                int distanceInt = Int32.Parse(x.Substring(1));

                switch (currentFacing)
                {
                    case 0: //north
                        north += distanceInt;
                        break;
                    case 1: //east
                        east += distanceInt;
                        break;
                    case 2: //south
                        north -= distanceInt;
                        break;
                    case 3: //west
                        east -= distanceInt;
                        break;
                    default:
                        break;
                }
            }

            Coordinates finalLocation = new Coordinates();
            finalLocation.north = north;
            finalLocation.east = east;
            finalLocation.facing = cardinalDirections[currentFacing];

            return finalLocation;
        }

        private static readonly IList<String> cardinalDirections = new ReadOnlyCollection<string>(new List<String>{"North", "East", "South", "West" });
        
        private static int newFacing(int currentFacing, char newDirection)
        {
            switch (newDirection)
            {
                case 'L':
                    --currentFacing;
                    break;
                case 'R':
                    ++currentFacing;
                    break;
                case 'N':
                    currentFacing = 0;
                    break;
                case 'E':
                    currentFacing = 1;
                    break;
                case 'S':
                    currentFacing = 2;
                    break;
                case 'W':
                    currentFacing = 3;
                    break;
                default:
                    break;
            }

            if (currentFacing < 0)
            {
                //turned left while facing north
                currentFacing = 3;
            }
            else if (currentFacing > 3)
            {
                //turned right while facing west
                currentFacing = 0;
            }

            return currentFacing;
        }
    }
}
