﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using matsukifudousan.ViewModel;

namespace matsukifudousan
{
    /// <summary>
    /// RentalFixs.xaml の相互作用ロジック
    /// </summary>
    public partial class RentalFixs : UserControl
    {
        public RentalFixs()
        {
            InitializeComponent();

            DataContext = new RentalFixViewModel();

        }
       
    }
}
