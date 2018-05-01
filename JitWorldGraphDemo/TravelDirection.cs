using System;
using System.Collections.Generic;

namespace JitWorldGraphDemo
{
    public class TravelDirection : IEquatable<TravelDirection>
    {
        private TravelDirections Direction { get; set; }

        public static TravelDirection None => new TravelDirection { Direction = TravelDirections.None };
        public static TravelDirection North => new TravelDirection { Direction = TravelDirections.North };
        public static TravelDirection South => new TravelDirection { Direction = TravelDirections.South };
        public static TravelDirection West => new TravelDirection { Direction = TravelDirections.West };
        public static TravelDirection East => new TravelDirection { Direction = TravelDirections.East };

        private enum TravelDirections
        {
            North,
            South,
            East,
            West,
            None
        }

        private static Dictionary<TravelDirection, TravelDirection> opposites =
            new Dictionary<TravelDirection, TravelDirection> {
                {TravelDirection.North, TravelDirection.South },
                {TravelDirection.South, TravelDirection.North },
                {TravelDirection.East, TravelDirection.West },
                {TravelDirection.West, TravelDirection.East }
            };

        public static TravelDirection Opposite(TravelDirection fromDirection) => opposites[fromDirection];

        public override bool Equals(object obj)
        {
            return Equals(obj as TravelDirection);
        }

        public bool Equals(TravelDirection other)
        {
            return other != null &&
                   Direction == other.Direction;
        }

        public override int GetHashCode()
        {
            return 2094509978 + Direction.GetHashCode();
        }
    }
}