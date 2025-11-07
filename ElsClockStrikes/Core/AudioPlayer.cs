using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;


namespace ElsClockStrikes.Core
{
    public class AudioPlayer
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private WaveStream waveStream;
        public UnmanagedMemoryStream unmanagedMemoryStream;
        private VolumeSampleProvider volumeProvider;
        public string filePath { get; set; }
        public float Volume { get; set; } = 1.0f;

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
                volumeProvider = new VolumeSampleProvider(audioFileReader);
            } else
            {
                waveStream = new WaveFileReader(unmanagedMemoryStream);
                volumeProvider = new VolumeSampleProvider(waveStream.ToSampleProvider());
            }
            volumeProvider.Volume = Volume;
            waveOutDevice.Init(volumeProvider);
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
