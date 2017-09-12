using System;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModels.ProductData VM; //esto nomme gusta como quedo

        public MainWindow()
        {
            InitializeComponent();
            btnClear.Click += btnClear_Click;

            VM = this.DataContext as ViewModels.ProductData;
            VM.MessageEvent += (s, ev) => MessageBox.Show(ev.Message); //y aca se suscribe a ese evento
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {          
            VM.GetProductByID(Convert.ToInt16(tbSearchProductID.Text));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ViewModels.ProductData();
        }
    }
}
