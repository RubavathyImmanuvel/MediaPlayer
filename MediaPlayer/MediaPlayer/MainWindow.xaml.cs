using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MediaPlayer
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (MediaElement.Source != null && MediaElement.NaturalDuration.HasTimeSpan)
            {
                ProgressSlider.Minimum = 0;
                ProgressSlider.Maximum = MediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                ProgressSlider.Value = MediaElement.Position.TotalSeconds;

                CurrentTimeTextBlock.Text = MediaElement.Position.ToString(@"hh\:mm\:ss");
                TotalTimeTextBlock.Text = MediaElement.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Media files|*.mp4;*.mp3;*.avi;*.mkv;*.wav;*.wmv;*.mov"
            };
            StatusTextBlock.Text = "Loading media...";
            if (openFileDialog.ShowDialog() == true)
            {
                MediaElement.Source = new Uri(openFileDialog.FileName);
                MediaElement.LoadedBehavior = MediaState.Manual;
                MediaElement.UnloadedBehavior = MediaState.Manual;
                PlayButton.IsEnabled = true;
                StopButton.IsEnabled = true;
                StatusTextBlock.Text = "Ready to Play";
                timer.Start();
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement.Play();
            StatusTextBlock.Text = "Playing...";
            timer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement.Pause();
            StatusTextBlock.Text = "Paused";
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement.Stop();
            StatusTextBlock.Text = "Stopped";
            ProgressSlider.Value = 0; // Reset the progress slider to 0
            CurrentTimeTextBlock.Text = "00:00:00"; // Reset current time display
            timer.Stop();
        }

        private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaElement.Source != null)
            {
                MediaElement.Position = TimeSpan.FromSeconds(ProgressSlider.Value);
            }
        }

        private void ProgressSlider_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MediaElement.Position = TimeSpan.FromSeconds(ProgressSlider.Value);
        }
    }
}
