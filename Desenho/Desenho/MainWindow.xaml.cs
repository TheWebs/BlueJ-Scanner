using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desenho
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();

        private Timer timer1;
        int angulo = 0;
        int centro = 300;
        int raio = 100;

        public MainWindow()
        {
            InitializeComponent();
            AllocConsole();
            Console.Clear();
            InitTimer();

        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*if(i == 5)
            {
                i = 0;
            }
            mudaCores(i);
            i++;*/
            float x = (float)(centro + raio*Math.Cos(toRad(angulo)));
            float y = (float)(centro + raio*Math.Sin(toRad(angulo)));
            desenhaLinha(x, y);
            Console.WriteLine("X: {0}; Y: {1};", x, y);
            angulo++;
        }

        private async void desenhaLinha(float x, float y)
        {
                
                await Task.Run(() =>
                {
                        panel.Dispatcher.BeginInvoke((Action)(() => panel.linhas.Add(new Cordenadas(new Pen(new SolidColorBrush(Colors.Red), 2), new Point(centro, centro), new Point(x, y)))));
                        panel.Dispatcher.BeginInvoke((Action)(() => panel.InvalidateVisual()));
                    
                });
                
            }
            
        

        private async void mudaCores(int i)
        {
            Color[] cores = new Color[] { Colors.Red, Colors.Black, Colors.Blue, Colors.Green, Colors.Yellow, Colors.Violet };
            try
            {
                await Task.Run(() => { panel.Dispatcher.BeginInvoke((Action)(() => panel.color = cores[i]));
                    panel.Dispatcher.BeginInvoke((Action)(() => panel.InvalidateVisual()));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        double toRad(double graus)
        {
            double rad;
            rad = graus * Math.PI / 180;
            return rad;
        }
    }
}
