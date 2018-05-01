using System;

namespace JitWorldGraphDemo
{
    // Assumptions: there won't be more than 10,000 rooms (including rooms 0 to 9,999)
    public struct RoomNumber:IEquatable<RoomNumber>
    {
        // zero means "not a room" or "there is no room in this direction"
        public int ID { get; private set; }

        public RoomNumber(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("id", "RoomNumber may not be negative.");
            this.ID = id;
        }

        public override string ToString() => ID.ToString().PadLeft(4);

        public bool Equals(RoomNumber other) => this.ID == other.ID;
}