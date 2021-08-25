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

namespace matsukifudousan
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl usc = null;
        public MainWindow()
        {
            InitializeComponent();

            usc = new UserControlMain();
            GridMain.Children.Add(usc);
        }

        private void ListViewMenu_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          
            //GridMain.Children.Clear();
            
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {

                case "UserControlMain":
                    usc = new UserControlMain();
                    GridMain.Children.Add(usc);
                    break;
                case "RentalManagement":
                    usc = new RentalManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "DetachedHouse":
                    usc = new DetachedHouse();
                    GridMain.Children.Add(usc);
                    break;

                default:
                    break;
            }
        }

    }
}
