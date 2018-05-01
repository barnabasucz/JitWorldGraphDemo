using System.Collections.Generic;
using static JitWorldGraphDemo.WorldGraph;

namespace JitWorldGraphDemo
{
    internal class DirectionMapping
    {
        public Dictionary<TravelDirections, RoomNumber> Mapping;

        public DirectionMapping()
        {
            Mapping = new Dictionary<TravelDirections, RoomNumber>();
        }

        public override bool Equals(object obj)
        {
            var mapping = obj as DirectionMapping;
            return mapping != null &&
                   EqualityComparer<Dictionary<TravelDirections, RoomNumber>>.Default.Equals(Mapping, mapping.Mapping);
        }

        public override int GetHashCode()
        {
            return 1416879085 + EqualityComparer<Dictionary<TravelDirections, RoomNumber>>.Default.GetHashCode(Mapping);
        }
    }
}