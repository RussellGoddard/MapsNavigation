using System;
using System.Collections.Generic;
using System.Text;

namespace MapsNavigation
{
    public static class MessageText
    {
        public static string inputPlaceholder = "Input directions as comma seperated values\nThe first character should be one of (L, R, N, E, S, W)\nWhich indicate either cardinal direction or the direction to turn\nThe remaining characters should be an integer indicating distance\n\nInitial facing is north\nTo change it simply put cardinal direction and 0 at the beginning ex: S0\n\nL3, R2, L5, R1, L1, L2";
        public static string errorMessage = "Invalid direction encountered while validating input";
        public static string blocksNorth = "Blocks North:";
        public static string blocksSouth = "Blocks South:";
        public static string blocksEast = "Blocks East:";
        public static string blocksWest = "Blocks West:";
    }
}
