using System;

namespace Individual_project
{
    public interface IMediaPlayer
    {
        void Play(string fileName);
    }

    public class LegacyMediaPlayer
    {
        public virtual void PlayFile(string filePath)
        {
            Console.WriteLine($"Playing (legacy): {filePath}");
        }
    }

    public class MediaPlayerAdapter : IMediaPlayer
    {
        private readonly LegacyMediaPlayer _legacyPlayer;

        public MediaPlayerAdapter(LegacyMediaPlayer legacyPlayer)
        {
            _legacyPlayer = legacyPlayer ?? throw new ArgumentNullException(nameof(legacyPlayer));
        }

        public void Play(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be empty or whitespace.", nameof(fileName));
            }

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
                var legacyPlayer = new LegacyMediaPlayer();
                IMediaPlayer adaptedPlayer = new MediaPlayerAdapter(legacyPlayer);

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
