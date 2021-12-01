using matsukifudousan.Model;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace matsukifudousan.ViewModel
{
    public class RentalContractSearchViewModel : BaseViewModel
    {
        private ObservableCollection<object> _List;
        public ObservableCollection<object> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand RentalPaymentInputWD { get; set; }

        public ICommand RentalContractFix { get; set; }

        public ICommand RentalContractView { get; set; }

        public ICommand RentalContractPrints { get; set; }

        public ICommand RentalContractDelete { get; set; }

        public RentalContractSearchViewModel()
        {
            var querySearch = from s in DataProvider.Ins.DB.RentalManagementDB
                              join sa in DataProvider.Ins.DB.RentalContactDB on s.HouseNo equals sa.HouseNo
                              where sa.HouseNo.ToString().Contains(Search) || sa.RentName.Contains(Search) || sa.RenterName.Contains(Search)
                              select new
                              { s.HouseNo, s.HouseName, s.Rent, sa.RentName };

            List = new ObservableCollection<object>(querySearch.ToList());

            RentalPaymentInputWD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (HouseNo != 0)
                {
                    RentalPaymentInput openWindowDetails = new RentalPaymentInput(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            RentalContractFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (HouseNo != 0 && HouseNo != null)
                {
                    RentalContractFix openWindowDetails = new RentalContractFix(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            RentalContractView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (HouseNo != 0 && HouseNo != null)
                {
                    RentalContractView openWindowDetails = new RentalContractView(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalContractSearch rentalContractSearch = new RentalContractSearch();
                string Result = null;
                Result = Search;
                rentalContractSearch.House.Text = null;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    //var querySearch = from s in DataProvider.Ins.DB.RentalManagementDB
                    //                  join sa in DataProvider.Ins.DB.RentalContactDB on s.HouseNo equals sa.HouseNo
                    //                  where sa.HouseNo.ToString() == Search || sa.RentName == Search || sa.RenterName == Search
                    //                  select new
                    //                  { s.HouseNo, s.HouseName, s.Rent, sa.RentName };

                    List = new ObservableCollection<object>(querySearch.ToList());

                    if (List.Count == 0)
                    {
                        MessageBox.Show("検索の結果がなかったです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    
                }
                    
            });

            RentalContractPrints = new RelayCommand<object>((p) => { return true; }, (p) => { printsButton(); });

            RentalContractDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalContractSearch selectRentalNo = new RentalContractSearch();

                if (selectRentalNo.House.Text != "")
                {
                    //int isExsit = DataProvider.Ins.DB.RentalPaymentDB.Where(e => e.HouseNo == HouseNo).Count();
                    //if (isExsit != 0)
                    //{
                    //    MessageBox.Show("削除が出来なかったです。まず入金（番号："+ HouseNo + "）を削除してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //}
                    //else
                    //{
                        
                    //}
                    rentalContractDelete();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
        }
        private void printsButton()
        {
            if (List.Count != 0) // if List.Count = 0 then Search Result not had 
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string filePath = "";
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

                if (dialog.ShowDialog() == true)
                {
                    filePath = dialog.FileName;
                }

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("回線（パス）には正しくないです。", "回線とパス", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    using (ExcelPackage pa = new ExcelPackage())
                    {
                        pa.Workbook.Properties.Author = "マツキ不動産賃貸管理";
                        pa.Workbook.Properties.Title = "賃貸物件詳細";
                        ExcelWorksheet ws = pa.Workbook.Worksheets.Add("賃貸一覧");
                        ws.Name = "賃貸物件詳細";
                        ws.Cells.Style.Font.Size = 11;
                        ws.Cells.Style.Font.Name = "Calibri";

                        string[] arrColumnHeader = {
                                                        "物件番号",
                                                        "物件名",
                                                        "所在地"
                                                        };
                        var countColHeader = arrColumnHeader.Count();

                        ws.Cells[1, 1].Value = "賃貸管理の一覧表示";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            var border = cell.Style.Border;
                            border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;

                            cell.Value = item;
                            colIndex++;
                        }
                        foreach (var item in List)
                        {
                            colIndex = 1;
                            rowIndex++;
                            //ws.Cells[rowIndex, colIndex++].Value = item[1];
                            //ws.Cells[rowIndex, colIndex++].Value = item[2];
                            //ws.Cells[rowIndex, colIndex++].Value = item[3];
                        }

                        Byte[] bin = pa.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("一覧表示からリスト印刷出来ました❣", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception EE)
                {
                    MessageBox.Show("ファイルが開いているために閉じて保存してください！　"+EE, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("一覧表示がなかったです。検索のは検索してください❕", "検索しなかった", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
        private void rentalContractDelete()
        {
            RentalContractSearch rentalSearch = new RentalContractSearch();
            var rentalHouseDelete = Int32.Parse(rentalSearch.House.Text);
            var resultButtonDeleteHouse = MessageBox.Show("この物件（物件番号：" + rentalHouseDelete + "）を削除しますか？", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.OK)
            {
                string Result = null;
                Result = Search;

                var HouseDeleteDB = DataProvider.Ins.DB.RentalContactDB.Where(houseDelete => houseDelete.HouseNo == rentalHouseDelete);
                DataProvider.Ins.DB.RentalContactDB.RemoveRange(HouseDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！", "削除", MessageBoxButton.OK, MessageBoxImage.Information);
                List = new ObservableCollection<object>(DataProvider.Ins.DB.RentalContactDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.RenterName.Contains(Result) || t.RentName.Contains(Result)));
            }
            else
            {
                MessageBox.Show("削除しなかったです！", "削除しない", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
