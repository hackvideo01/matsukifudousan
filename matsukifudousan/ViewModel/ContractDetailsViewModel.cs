using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = matsukifudousan.Model.ImageDB;

namespace matsukifudousan.ViewModel
{

    public class ContractDetailsViewModel : BaseViewModel

    {
        #region initi
        private ObservableCollection<Image> _ViewImg;
        public ObservableCollection<Image> ViewImg { get => _ViewImg; set { _ViewImg = value; OnPropertyChanged(); } }

        private string _CurrentDate;
        public string CurrentDate { get => _CurrentDate; set { _CurrentDate = value; OnPropertyChanged(); } }

        //private ObservableCollection<RentalManagementDB> _Rental;
        //public ObservableCollection<RentalManagementDB> Rental { get => _Rental; set { _Rental = value; OnPropertyChanged(); } }

        private string _Rent;
        public string Rent { get => _Rent; set { _Rent = value; OnPropertyChanged(); } }

        private string _Parking;
        public string Parking { get => _Parking; set { _Parking = value; OnPropertyChanged(); } }

        private string _CommonFee;
        public string CommonFee { get => _CommonFee; set { _CommonFee = value; OnPropertyChanged(); } }

        private string _ParkingFee;
        public string ParkingFee { get => _ParkingFee; set { _ParkingFee = value; OnPropertyChanged(); } }

        private string _SecurityDeposit;
        public string SecurityDeposit { get => _SecurityDeposit; set { _SecurityDeposit = value; OnPropertyChanged(); } }

        private string _KeyMoney;
        public string KeyMoney { get => _KeyMoney; set { _KeyMoney = value; OnPropertyChanged(); } }

        private object _Choose;
        public object Choose { get => _Choose; set { _Choose = value; OnPropertyChanged(); } }

        private object _Choose2;
        public object Choose2 { get => _Choose2; set { _Choose2 = value; OnPropertyChanged(); } }
        #endregion

        private string _Electronic;
        public string Electronic { get => _Electronic; set { _Electronic = value; OnPropertyChanged(); } }
        public ContractDetailsViewModel()
        {
            DateTime today = DateTime.Today;

            CurrentDate = DateTime.Now.ToString("yyyy/MM/dd");


            Parking = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().Parking;
            Rent = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().Rent;
            CommonFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().CommonFee;
            ParkingFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().ParkingFee;
            SecurityDeposit = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().SecurityDeposit;
            KeyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().KeyMoney;

            Choose = new ObservableCollection<string>
                {
                    "有",
                    "無"
                };

            Choose2 = new ObservableCollection<string>
                {
                    "不可",
                    "可"
                };

        }

        
    }
}
