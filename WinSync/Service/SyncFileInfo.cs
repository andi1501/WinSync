﻿using System;

namespace WinSync.Service
{
    public class SyncFileInfo
    {
        public SyncInfo SyncInfo { get; set; }

        public MyFileInfo FileInfo { get; set; }

        /// <summary>
        /// create SyncFileInfo
        /// </summary>
        /// <param name="syncInfo">owner</param>
        /// <param name="path">relative file path</param>
        /// <param name="size">file size in byte</param>
        public SyncFileInfo(SyncInfo syncInfo, MyFileInfo fileInfo)
        {
            SyncInfo = syncInfo;
            FileInfo = fileInfo;
        }

        /// <summary>
        /// create SyncFileInfo
        /// </summary>
        /// <param name="syncInfo">owner</param>
        /// <param name="path">relative file path</param>
        /// <param name="size">file size in byte</param>
        /// <param name="dir">synchronisation direction</param>
        /// <param name="remove">if destination file should be removed</param>
        public SyncFileInfo(SyncInfo syncInfo, MyFileInfo fileInfo, SyncDirection dir, bool remove) : this(syncInfo, fileInfo)
        {
            Direction = dir;
            Remove = remove;
        }

        /// <summary>
        /// synchronisation direction
        /// </summary>
        public SyncDirection Direction { get; set; }

        /// <summary>
        /// if destination file should be removed
        /// </summary>
        public bool Remove { get; set; }

        /// <summary>
        /// set synchronisation start time of file to now
        /// </summary>
        public void StartedNow()
        {
            SyncStart = DateTime.Now;
        }

        /// <summary>
        /// set synchronisation end time of file to now
        /// </summary>
        public void EndedNow()
        {
            SyncEnd = DateTime.Now;
        }

        /// <summary>
        /// synchronisation start time
        /// </summary>
        public DateTime SyncStart { get; private set; }

        /// <summary>
        /// synchronisation end time
        /// </summary>
        public DateTime? SyncEnd { get; private set; }

        /// <summary>
        /// in milliseconds
        /// </summary>
        public TimeSpan SyncDuration  => Synced ? (SyncEnd - SyncStart).Value : TimeSpan.Zero;

        /// <summary>
        /// in Megabits/second
        /// </summary>
        public double Speed => (FileInfo.Size * 8.0 / (1024.0 * 1024.0)) / (SyncDuration.TotalSeconds);

        /// <summary>
        /// if synchronisation has finished
        /// </summary>
        public bool Synced => SyncEnd != null;

        /// <summary>
        /// set conflict to file info
        /// </summary>
        /// <param name="ci">conflict info</param>
        public void FileConflicted(FileConflictInfo ci)
        {
            ConflictInfo = ci;
        }
        
        /// <summary>
        /// conflict info: null if no conflict
        /// </summary>
        public FileConflictInfo ConflictInfo { get; private set; }

        /// <summary>
        /// check if conflict appeared while file synchronisation
        /// </summary>
        public bool Conflicted => ConflictInfo != null;
    }
}
