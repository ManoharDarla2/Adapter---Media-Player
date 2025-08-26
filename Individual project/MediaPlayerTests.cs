using System;
using Xunit;

namespace Individual_project
{
    public class MediaPlayerTests
    {
        [Fact]
        public void MediaPlayerAdapter_ImplementsIMediaPlayer()
        {
            // Arrange
            var legacyPlayer = new LegacyMediaPlayer();
            var adapter = new MediaPlayerAdapter(legacyPlayer);
            
            // Assert
            Assert.IsAssignableFrom<IMediaPlayer>(adapter);
        }

        [Fact]
        public void MediaPlayerAdapter_RequiresLegacyPlayer()
        {
            // Arrange
            var legacyPlayer = new LegacyMediaPlayer();
            
            // Act & Assert
            var adapter = new MediaPlayerAdapter(legacyPlayer);
            Assert.NotNull(adapter);
        }

        [Fact]
        public void MediaPlayerAdapter_ThrowsArgumentNullException_WhenLegacyPlayerIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new MediaPlayerAdapter(null!));
        }

        [Fact]
        public void MediaPlayerAdapter_Play_CallsLegacyPlayFile()
        {
            // Arrange
            var legacyPlayer = new TestLegacyMediaPlayer();
            var adapter = new MediaPlayerAdapter(legacyPlayer);
            var fileName = "test.mp3";
            
            // Act
            adapter.Play(fileName);
            
            // Assert
            Assert.True(legacyPlayer.PlayFileCalled);
            Assert.Equal(fileName, legacyPlayer.LastFileName);
        }

        [Fact]
        public void MediaPlayerAdapter_Play_ThrowsArgumentNullException_WhenFileNameIsNull()
        {
            // Arrange
            var legacyPlayer = new LegacyMediaPlayer();
            var adapter = new MediaPlayerAdapter(legacyPlayer);
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => adapter.Play(null!));
        }

        [Fact]
        public void MediaPlayerAdapter_Play_ThrowsArgumentException_WhenFileNameIsEmpty()
        {
            // Arrange
            var legacyPlayer = new LegacyMediaPlayer();
            var adapter = new MediaPlayerAdapter(legacyPlayer);
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => adapter.Play(""));
            Assert.Throws<ArgumentException>(() => adapter.Play("   "));
        }

        [Fact]
        public void LegacyMediaPlayer_PlayFile_AcceptsFileName()
        {
            // Arrange
            var legacyPlayer = new TestLegacyMediaPlayer();
            var fileName = "video.avi";
            
            // Act
            legacyPlayer.PlayFile(fileName);
            
            // Assert
            Assert.True(legacyPlayer.PlayFileCalled);
            Assert.Equal(fileName, legacyPlayer.LastFileName);
        }
    }

    /// <summary>
    /// Test version of LegacyMediaPlayer that tracks method calls for verification.
    /// </summary>
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
