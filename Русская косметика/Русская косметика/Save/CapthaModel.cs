using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;

namespace MVVM_learn.Models
{
    public class CapthaModel : INotifyPropertyChanged
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                propertyChanged(nameof(Text));
            }
        }

        private ImageSource image;
        public ImageSource Image
        {
            get { return image; }
            set
            {
                image = value;
                propertyChanged(nameof(Image));
            }
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private ImageSource generateCapthaImage(string text)
        {
            using (var bitmap = new Bitmap(120, 50))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(System.Drawing.Color.White);

                using (var brush = new SolidBrush(System.Drawing.Color.Black))
                {
                    graphics.DrawString(text, new Font("Arial", 20), brush, new PointF(10, 10));
                }

                AddNoise(bitmap);

                using(var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    stream.Position = 0;
                    var imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = stream;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();
                    return imageSource;
                }
            }
        }

        private void AddNoise(Bitmap image)
        {
            Random rand = new Random();
            int density = 2;

            for(int i = 0; i < image.Width; i++)
            {
                for(int j = 0; j<image.Height; j++)
                {
                    if(rand.Next(density) == 0)
                    {
                        System.Drawing.Color c = image.GetPixel(i, j);
                        int r = (c.R + rand.Next(0, 256)) % 256;
                        int g = (c.G + rand.Next(0, 256)) % 256;
                        int b = (c.B + rand.Next(0, 256)) % 256;
                        image.SetPixel(i,j, System.Drawing.Color.FromArgb(r, g, b));
                    }
                }
            }
        }

        public void GenerateCaptha()
        {
            Text = GenerateRandomText(5);
            Image = generateCapthaImage(Text);
        }

        public bool IsEqual(string UserInput)
        {
            if(UserInput == Text)
            {
                return true;
            }
            else
            {
                GenerateCaptha();
                return false;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
