using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace JitWorldGraphDemo
{
    public class WorldGraph
    {
        // The graph will check whether it needs to load more rooms whenever 
        // a room is traversed.  Assume that the current room always has its connecting 
        // rooms loaded.
        // Whenever it is time to load, the client checks the server for the latest and greatest 
        // version of the room specification file.  This way, the client always shows the latest
        // that is on the server when moving between rooms, without needing to close the application or
        // click some sort of refresh button on the UI.
        // Note: this is a proof of concept.  In a production use, we wouldn't necessarily wait until the 
        // last second to check for adjacent areas needing to be loaded; rather, we'd use an intelligent
        // "graph crawl" to do a load in the background, intelligent enough that the data will be ready by the
        // time the player reaches the content in question.

        private HashSet<WorldCell> cells; // these are only the parts of the world that are loaded in memory.  Not necessarily the same set as the installed world cells!
        private WorldCell CurrentCell;

        private DiskReader diskReader { get; set; }

        public WorldGraph()
        {
            cells = new HashSet<WorldCell>();
            var roomNumberZero = new RoomNumber(0);
            CurrentCell = Load(roomNumberZero, TravelDirection.None, roomNumberZero);
            diskReader = new DiskReader(); // might pass in the local data path and network paths here, 
                                            // or let the diskreader handle or delegate it as appropriate
        }

        // call this to load the starting room
        // call this to load each subsequent room
        // Using a naive algorithm since this is the first try:
        // Whenever it is time to load another room for any reason, check the server
        // version, download if necessary, etc.  There may be a better way to do this, down the road.
        // First things first, though!
        private WorldCell Load(RoomNumber roomNumber, TravelDirection fromDirection, RoomNumber parentRoomNumber)
        {
            int centerX = this.BuildX(fromDirection);
            int centerY = this.BuildY(fromDirection);
            Color backgroundColor = diskReader.GetColor(roomNumber);
            TravelDirection directionToParent = TravelDirection.Opposite(fromDirection);
            return new WorldCell(centerX, centerY, roomNumber, backgroundColor, directionToParent, parentRoomNumber);
        }

        private int BuildX( TravelDirection fromDirection)
        {
            int xOffset = Director.Offset(fromDirection) * WorldCell.StandardWidth;
            return CurrentCell.CenterX + xOffset;
        }

        private int BuildY(TravelDirection fromDirection)
        {
            int yOffset = Director.Offset(fromDirection) * WorldCell.StandardHeight;
            return CurrentCell.CenterY + yOffset;
        }

        public void Travel(TravelDirection direction)
        {
            // throw exception if can't move in that direction (assume the UI disables direction buttons that currently have no connection)
            // figure out which room number is in the indicated direction
            // check this.cells for indicated roomNumber (if found, assign it to CurrentCell)
            // Load(indicated roomNumber, indicated direction) if not found in cells
            // ...and assign result of load to CurrentCell
            // In either case, CurrentCell will be the travelled-to cell.
            // This might be the only place that should/can call Load(RoomNumber, TravelDirection).
        }
    }
}