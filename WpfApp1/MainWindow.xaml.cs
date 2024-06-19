using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Sort();
        }
        async public void Sort()
        {
            int[] mass = new int[10];
            List<Rectangle> rectangles = new List<Rectangle>();
            Random random = new Random();
            for (int i = 0; i < mass.Length; i++)
            {
                Rectangle newRectangle = new Rectangle();
                newRectangle.Width = 50;
                newRectangle.Height = random.Next(0, 200);
                newRectangle.Fill = new SolidColorBrush(Colors.Blue);
                newRectangle.Margin = new Thickness(20, 0, 0, 0);
                newRectangle.VerticalAlignment = VerticalAlignment.Bottom;
                Cont.Children.Add(newRectangle);
                rectangles.Add(newRectangle);
            }
            await Task.Delay(10000);
            double temp;
            for (int i = 0; i < mass.Length; i++)
            {
                rectangles[i].Fill = new SolidColorBrush(Colors.Yellow);
                await Task.Delay(500);
                for (int j = i + 1; j < mass.Length; j++)
                {
                    rectangles[j].Fill = new SolidColorBrush(Colors.Green);
                    await Task.Delay(500);
                    if (rectangles[i].Height > rectangles[j].Height)
                    {
                        rectangles[i].Fill = new SolidColorBrush(Colors.Orange);
                        rectangles[j].Fill = new SolidColorBrush(Colors.Orange);
                        temp = rectangles[i].Height;
                        rectangles[i].Height = rectangles[j].Height;
                        rectangles[j].Height = temp;
                        await Task.Delay(500);
                    }
                    rectangles[i].Fill = new SolidColorBrush(Colors.Yellow);
                    rectangles[j].Fill = new SolidColorBrush(Colors.Blue);
                }
                rectangles[i].Fill = new SolidColorBrush(Colors.Blue);
            }
        }
    }
}
