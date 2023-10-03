using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using SetCloud.Pages;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SetCloud
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BackgroundImageX();
            string b = Dns.GetHostName();
            userName.Content = $"[用户] {b}";
            BackgroundImage();
        }

        async void BackgroundImage()
        {
            try
            {
                HttpClient http = new HttpClient();
                using var result = new MemoryStream(await http.GetByteArrayAsync("https://bing.shangzhenyang.com/api/1080p")) { Position = 0 };//https://bing.shangzhenyang.com/api/1080p
                var cache = new Bitmap(result);
                ImageBackgroundControl.Source = cache;

            }
            catch
            {

            }
        }


        private void OpenMenu(object sender, RoutedEventArgs e)
        {
            MenuContentControl.Margin = new Thickness(0, -160, 0, 0);
            StackPanelMenu.Margin = new Thickness(0, 0, 0, 0);
            Menu1.Height = 150;
            MenuOpenWrapPanel.Margin = new Thickness(0, 500, 0, 0);
            ItemsWrapPanel.Margin = new Thickness(0, 10, 0, 0);
        }

        private void CloseMenu(object sender, RoutedEventArgs e)
        {
            MenuContentControl.Margin = new Thickness(0, 0, 0, 0);
            StackPanelMenu.Margin = new Thickness(0, 500, 0, 0);
            Menu1.Height = 50;
            MenuOpenWrapPanel.Margin = new Thickness(0, 0, 0, 0);
            ItemsWrapPanel.Margin = new Thickness(0, 500, 0, 0);
        }

        private void ControlPageButton(object saender, RoutedEventArgs e)
        {
            MenuContentControl.Margin = new Thickness(0, -160, 0, 0);
            MenuContentControl.Content = new ControlPage();
        }
        private void Square(object sender, RoutedEventArgs e)
        {
            MenuContentControl.Margin = new Thickness(0, -160, 0, 0);
            MenuContentControl.Content = new PublicSquare();
        }
        public void BackgroundImageX()
        {
            MenuContentControl.Margin = new Thickness(0, -160, 0, 0);
            MenuContentControl.Content = new ControlPage();
        }
    }
}