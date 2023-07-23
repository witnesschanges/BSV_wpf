﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BSV_wpf
{
    internal partial class ViewModel : ObservableObject
    {
        public ViewModel() { }

        [ObservableProperty]
        private ImageSource leftImage = new BitmapImage(new System.Uri(@"D:\My Code\BSV_wpf\BSV_wpf\Inputs\1.bmp"));

        [ObservableProperty]
        private ImageSource rightImage = new BitmapImage(new System.Uri(@"D:\My Code\BSV_wpf\BSV_wpf\Inputs\1.bmp"));

        [RelayCommand]
        private void RecognizeCircle(string flag)
        {
            string currentDir = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(currentDir);
            string inputPath = @$"{parentDir?.Parent?.Parent?.FullName}\Inputs\1.bmp";
            string outputPath = ImageProcess.RecognizeCircle(inputPath);
            if (bool.TryParse(flag, out bool iflag))
            {
                if (iflag)
                {
                    LeftImage = new BitmapImage(new System.Uri(outputPath));
                }
                else
                {
                    RightImage = new BitmapImage(new System.Uri(outputPath));
                }
            }
        }

        [RelayCommand]
        private void OpenCamera(string flag)
        {

        }

        [RelayCommand]
        private void Snapshot(string flag)
        {

        }

        [RelayCommand]
        private void SavePicture()
        {

        }

        [RelayCommand]
        private void Calibrate(string flag)
        {

        }

        [RelayCommand]
        private void SetCamera(string flag)
        {

        }

        [RelayCommand]
        private void CaputreVideo(string flag) { }

        [RelayCommand]
        private void StopDetect(string flag) { }

        [RelayCommand]
        private void RecognizeCorner(string flag) { }
    }
}
