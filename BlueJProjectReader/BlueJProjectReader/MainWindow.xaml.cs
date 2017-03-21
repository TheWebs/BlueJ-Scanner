using System;
using System.Collections.Generic;
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
using Ookii.Dialogs.Wpf;
using System.IO;

namespace BlueJProjectReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            scan();
        }

        public void scan()
        {
            int i = 0;
            int a = 0;
            VistaFolderBrowserDialog ze = new VistaFolderBrowserDialog();
            ze.ShowDialog();
            string caminho = ze.SelectedPath;
            foreach (string file in Directory.GetFiles(caminho))
            {
                FileInfo info = new FileInfo(file);
                if (info.Extension == ".ctxt")
                {
                    foreach (string line in File.ReadLines(info.FullName))
                    {
                        if (line.Contains("target"))
                        {
                            string important = line.Split('=')[1].Replace("\\", "").Replace("java.util.", "").Replace("java.lang.", "");
                            if (important.Split(' ').Length == 1)
                            {
                                listBox1.Items.Add(important);
                                a++;
                            }
                            else
                            {
                                listBox.Items.Add(important);
                                i++;
                            }
                        }
                    }

                }
            }
            label1.Content = i;
            label3.Content = a;
            label3.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
        }
    }
}
