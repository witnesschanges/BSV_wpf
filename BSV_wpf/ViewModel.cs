using CommunityToolkit.Mvvm.Input;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BSV_wpf
{
    internal partial class ViewModel
    {
        public ViewModel() { }

        //public ImageSource LeftImage { get; set; }

        //public ImageSource RightImage { get; set; }

        [RelayCommand]
        private void RecognizeCircle()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(currentDir);
            string inputPath = @$"{parentDir?.Parent?.Parent?.FullName}\Inputs\1.bmp";
            ImageProcess.RecognizeCircle(inputPath);
        }
    }
}
