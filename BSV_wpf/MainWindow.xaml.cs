using System.Windows;
using System.IO;

namespace BSV_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currentDir = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(currentDir);
            string inputPath = @$"{parentDir?.Parent?.Parent?.FullName}\Inputs\1.bmp";
            ImageProcess.RecognizeCircle(inputPath);
        }
    }
}
