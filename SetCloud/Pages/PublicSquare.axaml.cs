using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SetCloud;

public partial class PublicSquare : UserControl
{
    public PublicSquare()
    {
        InitializeComponent();
        BackgroundImage();
    }

    async void BackgroundImage()
    {
        try
        {
            HttpClient http = new HttpClient();
            using var result = new MemoryStream(await http.GetByteArrayAsync("https://mod.3dmgame.com/static/upload/mod/allimg/341_161116182911_1.jpg")) { Position = 0 };//https://bing.shangzhenyang.com/api/1080p
            var cache = new Bitmap(result);
            ImageX.Source = cache;
            //await Task.Delay(1500);
            ProgressBarX.Opacity = 0;
            BorderX.Opacity = 1;
        }
        catch
        {

        }
    }
}