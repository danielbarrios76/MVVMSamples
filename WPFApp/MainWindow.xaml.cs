using System;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnClear.Click += btnClear_Click;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var VM = this.DataContext as ViewModels.ProductData;
            VM.MessageEvent += (s, ev) => MessageBox.Show(ev.Message);
            VM.GetProductByID(Convert.ToInt16(tbSearchProductID.Text));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ViewModels.ProductData();
        }
    }
}
