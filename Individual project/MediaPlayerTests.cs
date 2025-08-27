using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Individual_project.Tests
{
    [TestClass]
    public class MediaPlayerTests
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
        public void MediaPlayerAdapter_ThrowsArgumentNullException_WhenLegacyPlayerIsNull()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() => new MediaPlayerAdapter(null!));
        }

        [TestMethod]
        public void MediaPlayerAdapter_Play_CallsLegacyPlayFile()
        {
            TestLegacyMediaPlayer legacyPlayer = new TestLegacyMediaPlayer();
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

            Assert.ThrowsExactly<ArgumentNullException>(() => adapter.Play(null!));
        }

        [TestMethod]
        public void MediaPlayerAdapter_Play_ThrowsArgumentException_WhenFileNameIsEmpty()
        {
            LegacyMediaPlayer legacyPlayer = new LegacyMediaPlayer();
            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);

            Assert.ThrowsExactly<ArgumentException>(() => adapter.Play(""));
        }

        [TestMethod]
        public void MediaPlayerAdapter_Play_ThrowsArgumentException_WhenFileNameIsWhitespace()
        {
            LegacyMediaPlayer legacyPlayer = new LegacyMediaPlayer();
            MediaPlayerAdapter adapter = new MediaPlayerAdapter(legacyPlayer);

            Assert.ThrowsExactly<ArgumentException>(() => adapter.Play("   "));
        }
    }

    internal class TestLegacyMediaPlayer : LegacyMediaPlayer
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
