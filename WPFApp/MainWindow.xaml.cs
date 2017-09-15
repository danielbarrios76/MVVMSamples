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
            //btnClear.Click += btnClear_Click;

            ViewModels.ProductData VM = this.DataContext as ViewModels.ProductData;
            VM.MessageEvent += (s, ev) =>
            {
               var result = MessageBox.Show(ev.Message, "Titulo", MessageBoxButton.YesNoCancel); 
                ev.Result = (int)result;
            };
        }

        //private void btnSearch_Click(object sender, RoutedEventArgs e)
        //{          
        //    ViewModels.ProductData VM = this.DataContext as ViewModels.ProductData;
        //    VM.GetProductByID(Convert.ToInt16(tbSearchProductID.Text));
        //}

        //private void btnClear_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DataContext = new ViewModels.ProductData();
        //}
    }
}
