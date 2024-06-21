using System.IO;
using NAudio.Wave;


namespace ElsClockStrikes.Core
{
    public class AudioPlayer
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private WaveStream waveStream;
        public UnmanagedMemoryStream unmanagedMemoryStream;
        public string filePath { get; set; }

        public AudioPlayer(UnmanagedMemoryStream unmanagedMemoryStream)
        {
            this.unmanagedMemoryStream = unmanagedMemoryStream;
        }

        public AudioPlayer(string filePath)
        {
            this.filePath = filePath;
        }

        public void Play()
        {
            waveOutDevice = new WaveOutEvent();
            if (unmanagedMemoryStream == null)
            {
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice.Init(audioFileReader);
            } else
            {
                waveStream = new WaveFileReader(unmanagedMemoryStream);
                waveOutDevice.Init(waveStream);
            }
            waveOutDevice.Play();
            waveOutDevice.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            waveOutDevice.Dispose();
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
            }
            else if (waveStream != null)
            {
                unmanagedMemoryStream.Position = 0;
                waveStream.Dispose();
            }
        }

        public void Stop()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
            }
        }
    }
}
