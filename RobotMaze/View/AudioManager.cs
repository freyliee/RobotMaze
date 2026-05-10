using NAudio.Wave;
using System.IO;

namespace RobotMaze.View;

public static class AudioManager
{
    private static IWavePlayer? musicPlayer;
    private static AudioFileReader? musicReader;
    private static LoopStream? loopStream;
    private static readonly object lockObject = new object();

    public static void PlayBackgroundMusic()
    {
        lock (lockObject)
        {
            if (musicPlayer != null && musicPlayer.PlaybackState == PlaybackState.Playing)
            {
                return;
            }

            try
            {
                string musicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Music",
                    "bg_music.mp3");
                if (File.Exists(musicPath))
                {
                    StopBackgroundMusic();

                    musicReader = new AudioFileReader(musicPath);
                    loopStream = new LoopStream(musicReader);
                    musicPlayer = new WaveOutEvent();
                    musicPlayer.Init(loopStream);
                    musicPlayer.Play();
                }
            }
            catch
            {
            }
        }
    }

    public static void StopBackgroundMusic()
    {
        lock (lockObject)
        {
            musicPlayer?.Stop();
            musicPlayer?.Dispose();
            musicPlayer = null;

            musicReader?.Dispose();
            musicReader = null;

            loopStream?.Dispose();
            loopStream = null;
        }
    }
}
