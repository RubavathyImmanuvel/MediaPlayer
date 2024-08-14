# Media Player
A simple media player application built using WPF and C# .NET. This application allows you to open, play, pause, stop, and seek through media files. The UI includes a media control panel, a progress slider, and a time display.

## Features
- Open media files (e.g., .mp4, .mp3, .avi, .mkv, .wav, .wmv, .mov).
- Play, pause, and stop media playback.
- Seek through media using a progress slider.
- Display current and total media playback time.

## Getting Started

### Prerequisites
- **Visual Studio**: Ensure you have Visual Studio installed on your system.
- **.NET Framework**: This application targets the .NET Framework. Make sure the .NET Framework is installed on your machine.

### Running the Application
1. Clone the repository: git clone https://github.com/RubavathyImmanuvel/MediaPlayer.git
2. Open the solution file (`MediaPlayer.sln`) in Visual Studio.
3. Build the solution to restore the necessary packages.
4. Run the application.

### Usage
1. **Open Media File**:
	- Click the **Open** button to browse and select a media file.
2. **Control Playback**:
	- Click **Play** to start playback.
    - Click **Pause** to pause playback.
    - Click **Stop** to stop playback and reset the progress slider.
3. **Seek Through Media**:
	- Use the progress slider to move to different points in the media. The media position updates as you drag the slider.
4. **Display Information**:   
	- **StatusTextBlock** shows the current status of the media player (e.g., "Playing...", "Paused").
    - **CurrentTimeTextBlock** displays the current playback time.
    - **TotalTimeTextBlock** displays the total duration of the media.

## Contributions
If you want to contribute to this project, please fork the repository and submit a pull request with your changes.
