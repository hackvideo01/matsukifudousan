using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace matsukifudousan.ViewModel
{
    public class RentalContractSearchViewModel : BaseViewModel
    {
        private ObservableCollection<object> _List;
        public ObservableCollection<object> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public ICommand RentalPaymentInputWD { get; set; }

        public RentalContractSearchViewModel()
        {
            RentalPaymentInputWD = new RelayCommand<object>((p) => { return true; }, (p) => { RentalPaymentInput openWindowDetails = new RentalPaymentInput(); openWindowDetails.ShowDialog(); });

            //var query = from s in DataProvider.Ins.DB.RentalManagementDB
            //            join sa in DataProvider.Ins.DB.RentalContactDB on s.HouseNo equals sa.HouseNo
            //            where sa.HouseNo == "2"
            //            select s;

            var res = DataProvider.Ins.DB.RentalManagementDB.Join(DataProvider.Ins.DB.RentalContactDB,
                 s => s.HouseNo,
                 c => c.HouseNo,
                 (s, c) => new { s, c })
           //.Where(sc => sc.c.HouseNo == "1")
           .Select(sc => sc.s);

            List = new ObservableCollection<object>(res.ToList());


        }
    }
}
