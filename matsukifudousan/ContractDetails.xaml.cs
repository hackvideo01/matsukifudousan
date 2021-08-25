using matsukifudousan.Model;
using matsukifudousan.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace matsukifudousan
{
    /// <summary>
    /// ContractDetails.xaml の相互作用ロジック
    /// </summary>
    public partial class ContractDetails : Window
    {
        public ContractDetails()
        {
            InitializeComponent();
            ParkingChoose.IsEnabled = false;
            gaschoose.IsEnabled = false;
            WaterServiceChoose.IsEnabled = false;
            ToiletChoose.IsEnabled = false;
            WaterTankChoose.IsEnabled = false;
        }

        private void ContractVM_Loaded(object sender, RoutedEventArgs e)
        {
            Parking.SelectionChanged += Electronic_SelectionChanged;
            gas.SelectionChanged += Gas_SelectionChanged;
            WaterService.SelectionChanged += WaterService_SelectionChanged;
            Toilet.SelectionChanged += Toilet_SelectionChanged;
            WaterTank.SelectionChanged += WaterTank_SelectionChanged;
        }
        private void WaterTank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterTank.SelectedValue == "有")
            {
                WaterTankChoose.IsEnabled = true;
            }
            else
            {
                WaterTankChoose.IsEnabled = false;
                WaterTankChoose.SelectedValue = null;
            }
        }

        private void Toilet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Toilet.SelectedValue == "有")
            {
                ToiletChoose.IsEnabled = true;
            }
            else
            {
                ToiletChoose.IsEnabled = false;
                ToiletChoose.SelectedValue = null;
            }
        }

        private void WaterService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterService.SelectedValue == "有")
            {
                WaterServiceChoose.IsEnabled = true;
            }
            else
            {
                WaterServiceChoose.IsEnabled = false;
                WaterServiceChoose.SelectedValue = null;
            }
        }

        private void Gas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gas.SelectedValue == "有")
            {
                gaschoose.IsEnabled = true;
            }
            else
            {
                gaschoose.IsEnabled = false;
                gaschoose.SelectedValue = null;
            }
        }

        private void Electronic_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Parking.SelectedValue == "有")
            {
                ParkingChoose.IsEnabled = true;
            }
            else
            {
                ParkingChoose.IsEnabled = false;
                ParkingChoose.SelectedValue = null;
            }

        }
    }
}
