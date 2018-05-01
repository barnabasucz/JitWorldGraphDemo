using System;
using System.Collections.Generic;
using System.Windows.Media;
using static JitWorldGraphDemo.WorldGraph;

namespace JitWorldGraphDemo
{
    internal struct WorldCell
    {
        public const int StandardWidth = 10;
        public const int StandardHeight = 10;
        public RoomNumber RoomNumber { get; private set; }
        public Color BackColor { get; private set; }
        private Dictionary<TravelDirection, RoomNumber> connections;
        public int CenterX { get; private set; }
        public int CenterY { get; private set; }

        // Assume the builder or whatever to pass in proper values.
        // Assume this cell wouldn't be constructed in memory until after the client ensures that the relevant content file is installed.
        // If this is the starting cell, there won't be any parent direction or parent room number, which is expected.
        public WorldCell(int centerX, int centerY, RoomNumber roomNumber, 
            Color backColor, TravelDirection directionToParent, RoomNumber parentRoomNumber)
        {
            this.CenterX = centerX;
            this.CenterY = centerY;
            this.RoomNumber = roomNumber;
            this.BackColor = backColor;
            connections = new Dictionary<TravelDirection, RoomNumber>();
            Connect(directionToParent, parentRoomNumber);
        }

        // Assume: the constructor of RoomNumber ensures that the room number is valid.
        public void Connect(TravelDirection direction, RoomNumber toRoomNumber)
        {
            connections[direction] = toRoomNumber;
        }
    }
}