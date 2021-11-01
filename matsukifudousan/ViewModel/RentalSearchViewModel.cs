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
    public class RentalSearchViewModel : BaseViewModel
    {
        public static bool AddItem = false; //This must be public and static so that it can be called from your second Window

        //private List<RentalManagementDB> _List;
        //public List<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<RentalManagementDB> _List;
        public ObservableCollection<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _IsSelectedValue;
        public string IsSelectedValue { get => _IsSelectedValue; set { _IsSelectedValue = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        public ICommand RentalDetailsView { get; set; }

        public ICommand RentalFix { get; set; }

        public ICommand RentalDelete { get; set; }

        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand RentalContract { get; set; }

        private RentalManagementDB _SelectedItem;
        public RentalManagementDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    HouseNo = SelectedItem.HouseNo;
                }
            }
        }

        private string _HouseNo;
        public string HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        List<RentalManagementDB> LoadRecord(int page,int recordNum)
        {
            List<RentalManagementDB> result = new List<RentalManagementDB>();
            string Result = null;
            Result = Search;
            result = DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)).OrderBy(a=>a.HouseNo).Skip(page).Take(recordNum).ToList();
            return result;
        }
        public RentalSearchViewModel()
        {
            string Result = null;
            List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
            #region SearchButton
            //int loadedRecord = 0;
            //int pageNumber = 1;
            //int numberRecord = 10;

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //List = LoadRecord(loadedRecord, numberRecord);
                Result = Search;
                if (Result != "" && Result != null)
                {
                    List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));

                    if (List.Count == 0)
                    {
                        MessageBox.Show("検索の結果がなかったです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("まだ入力しないです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            #endregion

            PrintsButton = new RelayCommand<object>((p) => { return true; }, (p) => { printsButton(); });
            RentalDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();

                if (selectRentalNo.House.Text != "")
                {
                    RentalDetailsView openWindowDetails = new RentalDetailsView(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            RentalFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();

                if (selectRentalNo.House.Text != "")
                {
                    rentalFixOpenWithWindow();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            RentalDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();

                if (selectRentalNo.House.Text != "")
                {
                    rentalDelete();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });

            ContractDetailsCommandWD = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                RentalSearch selectRentalNo = new RentalSearch();
                var selectRentalSearch = selectRentalNo.House.Text;

                if (selectRentalSearch != "")
                {
                    if (DataProvider.Ins.DB.ContractDetailsDB.Where(h=>h.HouseNo == selectRentalSearch).Count() == 0)
                    {
                        ContractDetails wd = new ContractDetails(); wd.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("物件は詳細入力がありました。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                    }
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            RentalContract = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                RentalSearch selectRentalNo = new RentalSearch();
                var selectRentalSearch = selectRentalNo.House.Text;
                var displayList = DataProvider.Ins.DB.RentalContactDB.Where(x => x.HouseNo == selectRentalSearch);
                int a = displayList.Count();

                if (selectRentalSearch != "" && selectRentalSearch != null && displayList.Count() == 0)
                {
                    RentalContractInput openWindowRentalContractInput = new RentalContractInput(); openWindowRentalContractInput.ShowDialog();
                }
                else if (displayList.Count() != 0)
                {
                    MessageBox.Show("物件（物件No：" + selectRentalSearch + "）がありました。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
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
                            ws.Cells[rowIndex, colIndex++].Value = item.HouseNo;
                            ws.Cells[rowIndex, colIndex++].Value = item.HouseName;
                            ws.Cells[rowIndex, colIndex++].Value = item.HouseAddress;
                        }

                        Byte[] bin = pa.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("一覧表示からリスト印刷出来ました❣", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception EE)
                {
                    MessageBox.Show("ファイルが開いているために閉じて保存してください！　", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("一覧表示がなかったです。検索のは検索してください❕", "検索しなかった", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void rentalFixOpenWithWindow()
        {
            RentalSearch rentalSearch = new RentalSearch();
            var rentalSearchHouseNo = rentalSearch.House.Text;

            if (rentalSearchHouseNo != "")
            {
                string Result = null;
                Result = Search;
                Window window = new Window
                {
                    Title = "賃貸修正",
                    Width = 835,
                    Height = 450,
                    Content = new RentalFixs(),
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    WindowStyle = WindowStyle.None
                };
                window.ShowDialog();
                List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
            }
            else
            {
                MessageBox.Show("物件を選択下さい！", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void rentalDelete()
        {
            RentalSearch rentalSearch = new RentalSearch();
            var rentalHouseDelete = rentalSearch.House.Text;
            var resultButtonDeleteHouse = MessageBox.Show("本当にこの物件（物件番号：" + rentalHouseDelete + "）を削除したいでしょうか？","警告",MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.OK)
            {
                string Result = null;
                Result = Search;
                var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(imgDelete => imgDelete.HouseNo == rentalHouseDelete);
                DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                var HouseDeleteDB = DataProvider.Ins.DB.RentalManagementDB.Where(houseDelete => houseDelete.HouseNo == rentalHouseDelete);
                DataProvider.Ins.DB.RentalManagementDB.RemoveRange(HouseDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！");
                List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
            }
            else
            {
                MessageBox.Show("削除しなかったです。");
            }
        }
    }
}
