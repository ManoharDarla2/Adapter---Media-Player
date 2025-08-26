using System;

namespace Individual_project
{
    /// <summary>
    /// Defines the standard media player interface.
    /// </summary>
    public interface IMediaPlayer
    {
        /// <summary>
        /// Plays the specified media file.
        /// </summary>
        /// <param name="fileName">The name of the file to play.</param>
        void Play(string fileName);
    }

    /// <summary>
    /// Represents a legacy media player with a different interface.
    /// </summary>
    public class LegacyMediaPlayer
    {
        /// <summary>
        /// Plays a media file using the legacy method.
        /// </summary>
        /// <param name="filePath">The path of the file to play.</param>
        public virtual void PlayFile(string filePath)
        {
            Console.WriteLine($"Playing (legacy): {filePath}");
        }
    }

    /// <summary>
    /// Adapter to allow LegacyMediaPlayer to be used as an IMediaPlayer.
    /// Implements the Adapter design pattern to bridge incompatible interfaces.
    /// </summary>
    public class MediaPlayerAdapter : IMediaPlayer
    {
        private readonly LegacyMediaPlayer _legacyPlayer;

        /// <summary>
        /// Initializes a new instance of the MediaPlayerAdapter class.
        /// </summary>
        /// <param name="legacyPlayer">The legacy media player to adapt.</param>
        /// <exception cref="ArgumentNullException">Thrown when legacyPlayer is null.</exception>
        public MediaPlayerAdapter(LegacyMediaPlayer legacyPlayer)
        {
            _legacyPlayer = legacyPlayer ?? throw new ArgumentNullException(nameof(legacyPlayer));
        }

        /// <summary>
        /// Plays the specified media file by delegating to the legacy player.
        /// </summary>
        /// <param name="fileName">The name of the file to play.</param>
        /// <exception cref="ArgumentNullException">Thrown when fileName is null.</exception>
        /// <exception cref="ArgumentException">Thrown when fileName is empty or whitespace.</exception>
        public void Play(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be empty or whitespace.", nameof(fileName));

            _legacyPlayer.PlayFile(fileName);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Media Player Adapter Pattern Demo");
            Console.WriteLine("==================================");
            
            try
            {
                // Create a legacy media player
                var legacyPlayer = new LegacyMediaPlayer();
                
                // Adapt it to work with the new interface
                IMediaPlayer adaptedPlayer = new MediaPlayerAdapter(legacyPlayer);
                
                // Use the adapted player through the standard interface
                Console.WriteLine("\nUsing adapted legacy player:");
                adaptedPlayer.Play("song.mp3");
                adaptedPlayer.Play("movie.mp4");
                
                Console.WriteLine("\nDirect legacy player usage:");
                legacyPlayer.PlayFile("oldformat.wav");
                
                Console.WriteLine("\nDemo completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
