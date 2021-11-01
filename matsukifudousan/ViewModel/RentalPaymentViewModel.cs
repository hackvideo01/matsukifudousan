using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace matsukifudousan.ViewModel
{
    public class RentalPaymentViewModel : BaseViewModel
    {
        private string _HouseNo;
        public string HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _ContractDate;
        public string ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        private string _RenterName;
        public string RenterName { get => _RenterName; set { _RenterName = value; OnPropertyChanged(); } }

        public ICommand RentalPaymentButton { get; set; }

        public int Comfirm = 0;

        public RentalPaymentViewModel()
        {
            RentalPaymentButton = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(HouseNo))
                //    return false;

                //var displayList = DataProvider.Ins.DB.RentalContactDB.Where(x => x.HouseNo == HouseNo);
                //if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                //    return false;

                return true;
            }, (p) =>
            {
                MessageBox.Show("入金されていました。");
                //if (Comfirm == 0)
                //{
                //    var AddRentalPayment = new RentalContactDB()
                //    {
                //        HouseNo = HouseNo,

                //    };
                //    DataProvider.Ins.DB.RentalContactDB.Add(AddRentalPayment);
                //    DataProvider.Ins.DB.SaveChanges();
                //    Comfirm = 1;
                //    MessageBox.Show("入金されていました。");
                //}

            });
        }
    }
}
