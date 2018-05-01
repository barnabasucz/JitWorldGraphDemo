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

        private HashSet<WorldCell> cells; // these are only the parts of the world that are loaded in memory.  Not necessarily the same set as the installed world cells!
        private WorldCell CurrentCell;


        public WorldGraph()
        {
            cells = new HashSet<WorldCell>();
            CurrentCell = Load(new RoomNumber(0), TravelDirection.None);
        }

        // call this to load the starting room
        // call this to load each subsequent room
        private WorldCell Load(RoomNumber roomNumber, TravelDirection fromDirection)
        {
            int centerX = this.BuildX(fromDirection);
            int centerY = this.BuildY(fromDirection);
            TravelDirection direction = TravelDirection.Opposite(fromDirection);
            string roomFileName = RefreshRoomOnDiskFromServer(roomNumber);
            Color color = GetColor(roomFileName);
            throw new NotImplementedException();
        }

        private int BuildX( TravelDirection fromDirection)
        {
            int offset = Director.Offset(fromDirection) * WorldCell.StandardWidth;
            return CurrentCell.CenterX + offset;
        }

        private int BuildY(TravelDirection fromDirection)
        {
            int offset = Director.Offset(fromDirection) * WorldCell.StandardHeight;
            return CurrentCell.CenterY + offset;
        }

        private string RefreshRoomOnDiskFromServer(RoomNumber roomNumber)
        {
            string fileName = GetFileName(roomNumber);
            // check that the file exists locally; if not, copy it from server
            // if file exists locally, check that the timestamp matches server; if not, copy it from server
            return fileName;
        }

        private string GetFileName(RoomNumber roomNumber) => $"Room{roomNumber}.txt";

        public void Travel(TravelDirection direction)
        {
            // throw exception if can't move in that direction (assume the UI disables direction buttons that currently have no connection)

        }
    }
}