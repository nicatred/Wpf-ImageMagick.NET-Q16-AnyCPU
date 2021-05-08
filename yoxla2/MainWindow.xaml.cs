using ImageMagick;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace yoxla2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            origin.Width = 300;
            origin.Height = 300;
            custom.Width = 300;
            custom.Height = 300;

            WPF_WINDOW.MouseWheel += WPF_WINDOW_MouseWheel;
            custom.MouseLeftButtonDown += custom_MouseLeftButtonDown;
            custom.MouseLeftButtonUp += custom_MouseLeftButtonUp;
            custom.MouseMove += custom_MouseMove;
        }

        bool zoomMode = false;
        private System.Windows.Point origin_point;  
        private System.Windows.Point start;   
        private void monocrome_Click(object sender, RoutedEventArgs e)
        {

            GrayScale();
            
        }

        private void origin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (zoomMode == false)
            {
                OpenPicture();
            }
            if (zoomMode == true && origin.Width < 501)
            {

                origin.Width += 50;
                origin.Height += 50;

            }

          
        }
      

      
        private void mirror_Click(object sender, RoutedEventArgs e)
        {
          
            Mirror();

        }

       

        private void custom_MouseMove(object sender, MouseEventArgs e)
        {
            if (!custom.IsMouseCaptured) return;
            System.Windows.Point p = e.MouseDevice.GetPosition(border);

            Matrix m = custom.RenderTransform.Value;
           
                m.OffsetX = origin_point.X + (p.X - start.X);
                m.OffsetY = origin_point.Y + (p.Y - start.Y);
            
            custom.RenderTransform = new MatrixTransform(m);
        }

        private void custom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (zoomMode == true && custom.Width < 501)
            {

                custom.Width += 50;
                custom.Height += 50;

            }

            if (custom.IsMouseCaptured) return;
            custom.CaptureMouse();

            start = e.GetPosition(border);
            
                origin_point.X = custom.RenderTransform.Value.OffsetX;
                origin_point.Y = custom.RenderTransform.Value.OffsetY;
            
            
        }

      

        private void custom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            custom.ReleaseMouseCapture();
        }

        private void WPF_WINDOW_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            System.Windows.Point p = e.MouseDevice.GetPosition(custom);

            Matrix m = custom.RenderTransform.Value;
            if (e.Delta > 0)
                m.ScaleAtPrepend(1.1, 1.1, p.X, p.Y);
            else
                m.ScaleAtPrepend(1 / 1.1, 1 / 1.1, p.X, p.Y);

            custom.RenderTransform = new MatrixTransform(m);
        }

        #region methods
        void OpenPicture()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse image Files",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|Bitmap Image|*.bmp|Tiff Files (*.tiff)|*.tiff",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == true)
            {
                origin.Source = new BitmapImage(new Uri(openFileDialog1.FileName));

                custom.Source = origin.Source;

            }
        }


        private BitmapImage byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                stream.Write(byteArrayIn, 0, byteArrayIn.Length);
                stream.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                BitmapImage returnImage = new BitmapImage();
                returnImage.BeginInit();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                returnImage.StreamSource = ms;
                returnImage.EndInit();

                return returnImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }


        public static byte[] ConvertBitmapSourceToByteArray(ImageSource imageSource)
        {
            var image = imageSource as BitmapSource;
            
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }


        void Mirror()
        {

            byte[] byteImage = ConvertBitmapSourceToByteArray(custom.Source);

            MagickImage image = new MagickImage(byteImage);
            

            image.Flop();

            BitmapImage result = byteArrayToImage(image.ToByteArray());

            custom.Source = result;



        }
        void GrayScale()
        {
            byte[] byteImage = ConvertBitmapSourceToByteArray(custom.Source);

            MagickImage image = new MagickImage(byteImage);

            
            image.ColorSpace = ColorSpace.Gray;

            BitmapImage result = byteArrayToImage(image.ToByteArray());

            custom.Source = result;
        }


        

        private System.Drawing.Image ImagetoDraw(System.Windows.Media.ImageSource image)
        {
            MemoryStream ms = new MemoryStream();
            var encoder = new System.Windows.Media.Imaging.BmpBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(image as System.Windows.Media.Imaging.BitmapSource));
            encoder.Save(ms);
            ms.Flush();
            return System.Drawing.Image.FromStream(ms);
        }

        void Save_as()
        {

            System.Drawing.Image last_result = ImagetoDraw(custom.Source);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Tiff Image|*.tiff";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();



            if (saveFileDialog1.FileName != "")
            {

                FileStream fs =
                    (FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        last_result.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        last_result.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        last_result.Save(fs, ImageFormat.Tiff);
                        break;
                }
            }
        }
        #endregion

        private void zoom_Click(object sender, RoutedEventArgs e)
        {
            if (zoomMode == false)
            {
                zoomMode = true;
                zoom.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                zoomMode = false;
                zoom.BorderBrush = System.Windows.Media.Brushes.Transparent;
            }
        }

        private void origin_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (zoomMode == false)
            {
                OpenPicture();
            }
            if (zoomMode == true && origin.Width > 199)
            {

                origin.Width -= 50;
                origin.Height -= 50;

            }         
        }

        private void custom_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (zoomMode == true && custom.Width > 199)
            {

                custom.Width -= 50;
                custom.Height -= 50;

            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenPicture();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

      

        private void save_as_Click(object sender, RoutedEventArgs e)
        {
            Save_as();
        }



        private void WPF_WINDOW_MouseMove(object sender, MouseEventArgs e)
        {
            status.Content = Mouse.GetPosition(this).ToString();
        }
    }
}
