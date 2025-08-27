using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Individual_project
{
    // Main classes for the adapter pattern
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
}

namespace Individual_project.Tests
{
    [TestClass]
    public class MediaPlayerMSTests
    {
        [TestMethod]
        public void MediaPlayerAdapter_ImplementsIMediaPlayer()
        {
            LegacyMediaPlayer legacyPlayer = new LegacyMediaPlayer();
            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);

            Assert.IsTrue(adapter is IMediaPlayer);
        }

        [TestMethod]
        public void MediaPlayerAdapter_RequiresLegacyPlayer()
        {
            LegacyMediaPlayer legacyPlayer = new LegacyMediaPlayer();

            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);
            Assert.IsNotNull(adapter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MediaPlayerAdapter_ThrowsArgumentNullException_WhenLegacyPlayerIsNull()
        {
            // ReSharper disable once ExpressionIsAlwaysNull
            _ = new MediaPlayerAdapter(null!);
        }

        [TestMethod]
        public void MediaPlayerAdapter_Play_CallsLegacyPlayFile()
        {
            TestLegacyMediaPlayerMS legacyPlayer = new TestLegacyMediaPlayerMS();
            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);
            string fileName = "test.mp3";

            adapter.Play(fileName);

            Assert.IsTrue(legacyPlayer.PlayFileCalled);
            Assert.AreEqual(fileName, legacyPlayer.LastFileName);
        }

        [TestMethod]
        public void MediaPlayerAdapter_Play_ThrowsArgumentNullException_WhenFileNameIsNull()
        {
            LegacyMediaPlayer legacyPlayer = new LegacyMediaPlayer();
            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);

            Assert.ThrowsException<ArgumentNullException>(() => adapter.Play(null!));
        }

        [TestMethod]
        public void MediaPlayerAdapter_Play_ThrowsArgumentException_WhenFileNameIsEmpty()
        {
            LegacyMediaPlayer legacyPlayer = new LegacyMediaPlayer();
            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);

            Assert.ThrowsException<ArgumentException>(() => adapter.Play(""));
        }

        [TestMethod]
        public void MediaPlayerAdapter_Play_ThrowsArgumentException_WhenFileNameIsWhitespace()
        {
            LegacyMediaPlayer legacyPlayer = new LegacyMediaPlayer();
            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);

            Assert.ThrowsException<ArgumentException>(() => adapter.Play("   "));
        }

        [TestMethod]
        public void LegacyMediaPlayer_PlayFile_AcceptsFileName()
        {
            TestLegacyMediaPlayerMS legacyPlayer = new TestLegacyMediaPlayerMS();
            string fileName = "video.avi";

            legacyPlayer.PlayFile(fileName);

            Assert.IsTrue(legacyPlayer.PlayFileCalled);
            Assert.AreEqual(fileName, legacyPlayer.LastFileName);
        }
    }

    internal class TestLegacyMediaPlayerMS : LegacyMediaPlayer
    {
        public bool PlayFileCalled { get; private set; }
        public string? LastFileName { get; private set; }

        public override void PlayFile(string filePath)
        {
            PlayFileCalled = true;
            LastFileName = filePath;
            base.PlayFile(filePath);
        }
    }
}
