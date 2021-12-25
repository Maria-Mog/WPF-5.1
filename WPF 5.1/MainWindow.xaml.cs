using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_5._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы (*.png)|*.png|Файлы (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "")
            {

                return;
                //inkCanvas.Strokes= File.ReadAllText(openFileDialog.FileName);
            }
            FileStream fileStream = File.Open(openFileDialog.FileName, FileMode.Open);

            StrokeCollection strokeCollection = new StrokeCollection(fileStream);
            inkCanvas.Strokes = strokeCollection;
            fileStream.Close();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы (*.png)|*.png|Файлы (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
            {
                return;
                //File.WriteAllText(saveFileDialog.FileName, );
            }
            FileStream fileStream = File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate);
            inkCanvas.Strokes.Save(fileStream);
            fileStream.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void green_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void blue_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void black_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void red1_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Red);
            inkCanvas.Background = (Brush)solidColorBrush;
        }

        private void green1_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Green);
            inkCanvas.Background = (Brush)solidColorBrush;
        }

        private void blue1_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Blue);
            inkCanvas.Background = (Brush)solidColorBrush;
        }

        private void black1_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Black);
            inkCanvas.Background = (Brush)solidColorBrush;
        }

        private void auto1_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.White);
            inkCanvas.Background = (Brush)solidColorBrush;
        }

        private void wash_Click_1(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            inkCanvas.Cursor = Cursors.Cross;
        }

        private void brush_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            inkCanvas.Cursor = Cursors.Pen;
            inkCanvas.DefaultDrawingAttributes.Width = 2;
            inkCanvas.DefaultDrawingAttributes.Height = 2;
        }
        bool normalLane;
        private void fat_Click(object sender, RoutedEventArgs e)
        {
            normalLane = !normalLane;
            if (normalLane)
            {
                inkCanvas.DefaultDrawingAttributes.Width = 10;
                inkCanvas.DefaultDrawingAttributes.Height = 10;
            }

        }

    }
}
