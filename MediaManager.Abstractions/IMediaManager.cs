using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;

namespace Plugin.MediaManager.Abstractions
{
    /// <summary>
    /// The main purpose of this class is to be a controlling unit for all the single MediaItem implementations, who
    /// in themselve can play their media, but need a central controling unit, surrounding them
    /// </summary>
    public interface IMediaManager : IPlaybackManager
    {
        /// <summary>
        /// Player responsible for audio playback
        /// </summary>
        IAudioPlayer AudioPlayer { get; set; }

        /// <summary>
        /// Player responsible for video playback
        /// </summary>
        IVideoPlayer VideoPlayer { get; set; }

        IPlaybackManager CurrentPlaybackManager { get; }

        /// <summary>
        /// Queue to play media in sequences
        /// </summary>
        IMediaQueue MediaQueue { get; set; }

        /// <summary>
        /// Extracts media information to put it into an IMediaItem
        /// </summary>
        IMediaExtractor MediaExtractor { get; set; }

        /// <summary>
        /// Manages notifications to the native system
        /// </summary>
        INotificationManager NotificationManager { get; set; }

        /// <summary>
        /// Used to manage the volume
        /// </summary>
        IVolumeManager VolumeManager { get; set; }

        /// <summary>
        /// Used in various views to control the playback
        /// </summary>
        IPlaybackController PlaybackController { get; set; }

        Task Play();
        Task Play(string url, MediaItemType type);

        Task Play(IEnumerable<IMediaItem> items);

        //TODO: NetStandard
        //Task Play(Stream stream, MediaItemType type);
        //Task Play(FileInfo file, MediaItemType type);

        /// <summary>
        /// Plays the next MediaFile in the Queue
        /// </summary>
        Task PlayNext();

        /// <summary>
        /// Plays the previous MediaFile in the Queue
        /// </summary>
        Task PlayPrevious();

        /// <summary>
        /// Plays a MediaFile by its position in the Queue
        /// </summary>
        Task PlayByPosition(int index);

        /// <summary>
        /// Sets a function which gets called before the MediaFile is played
        /// </summary>
        /// <param name="beforePlay">The before play.</param>
        void SetOnBeforePlay(Func<IMediaItem, Task> beforePlay);

    }
}
