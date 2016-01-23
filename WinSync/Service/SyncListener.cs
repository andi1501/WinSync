﻿namespace WinSync.Service
{
    public interface ISyncListener
    {
        /// <summary>
        /// is called when a detect task of a file started
        /// </summary>
        /// <param name="path">relative file path</param>
        void OnDetectingFileStarted(string path);
        
        /// <summary>
        /// is called when a detect task of a file finished and a change has been detected
        /// </summary>
        /// <param name="sfi">detected file information</param>
        void OnFileChangeDetected(SyncFileInfo sfi);
        
        /// <summary>
        /// is called when a file has been copied or deleted
        /// </summary>
        /// <param name="sfi">synced file information</param>
        void OnFileSynced(SyncFileInfo sfi);

        /// <summary>
        /// is called when a directory has been created or removed
        /// </summary>
        /// <param name="sdi">synced directory information</param>
        void OnDirSynced(SyncDirInfo sdi);

        /// <summary>
        /// is called when a file conflict occurred
        /// </summary>
        /// <param name="sfi">conflicted file information</param>
        void OnFileConflicted(SyncFileInfo sfi);

        /// <summary>
        /// is called when a directory conflict occurred
        /// </summary>
        /// <param name="sdi">conflicted directory information</param>
        void OnDirConflicted(SyncDirInfo sdi);

        /// <summary>
        /// is called when a log message has been received
        /// </summary>
        /// <param name="message"></param>
        void OnLog(LogMessage message);
    }
}
