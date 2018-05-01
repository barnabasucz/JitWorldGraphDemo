namespace JitWorldGraphDemo
{
    internal static class Director
    {
        public static int Offset(TravelDirection travelDirection)
        {
            int offset = 0;
            if (travelDirection == TravelDirection.North || travelDirection == TravelDirection.West)
                offset = -1;
            else if (travelDirection == TravelDirection.South || travelDirection == TravelDirection.East)
                offset = 1;
            return offset;
        }
    }
}