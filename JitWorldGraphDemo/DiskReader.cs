using System;
using System.Windows.Media;

namespace JitWorldGraphDemo
{
    internal class DiskReader
    {
        public DiskReader()
        {
        }

        internal Color GetColor(RoomNumber roomNumber)
        {
            RefreshRoomLocal(roomNumber);
            // now actually read the file
            throw new NotImplementedException();
        }
        // there's only one property stored in the files now.  But as soon as we add a second or further,
        // we'll have to figure out how to load all the data in the file into memory and then each Get*()
        // function will return the appropriate data.

        private void RefreshRoomLocal(RoomNumber roomNumber)
        {
            string roomFileName = GetFileName(roomNumber);
            string localPath = GetLocalDataPath();
            // check for existence locally
            // check timestamps if exists locally
            // recopy locally if necessary
        }

        private string GetFileName(RoomNumber roomNumber) => $"Room{roomNumber}.txt";

        private string GetLocalDataPath()
        {
            throw new NotImplementedException();
        }
    }
}