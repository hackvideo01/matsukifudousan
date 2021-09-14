using matsukifudousan.Model;
using matsukifudousan.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace matsukifudousan
{
    /// <summary>
    /// RentalInput.xaml の相互作用ロジック
    /// </summary>
    public partial class RentalInput : UserControl
    {

        public RentalInput()
        {
            InitializeComponent();

            DataContext = new RentalInputViewModel();
        }

        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    string filePath2 = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/images/RentalImage/桜御影JB.jpg";

        //    var webImage2 = new BitmapImage(new Uri(filePath2));
        //    var imageControl2 = new Image();
        //    imageControl2.Source = webImage2;
        //    ContentRoot.Children.Add(imageControl2);
        //}
    }
}
