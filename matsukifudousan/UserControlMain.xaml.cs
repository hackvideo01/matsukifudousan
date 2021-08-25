﻿using System;
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
    /// UserControlMain.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControlMain : UserControl
    {
        
        UserControl usc = null;
        public UserControlMain()
        {
            InitializeComponent();
            
        }

        private void RentalManagement_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new RentalManagement();
            parentWindow.GridMain.Children.Add(usc);
        }

        private void DetachedHouse_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new DetachedHouse();
            parentWindow.GridMain.Children.Add(usc);
        }
    }
}
