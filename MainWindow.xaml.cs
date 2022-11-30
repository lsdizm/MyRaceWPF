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

namespace MyRaceWPF
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainTabControl.Items.Clear();
            AddPage(new Pages.ApiTest(), "ApiTest");            
            mainTabControl.SelectedIndex = 0;
        }

        private void AddPage(Page page, string title)
        {
            var newFrame = new Frame();
            newFrame.Content = page;

            var newPage = new TabItem();
            newPage.Header = title.PadRight(10, ' ');
            newPage.Content = newFrame;

            mainTabControl.Items.Add(newPage);
        }
    }
}
