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
    public class RentalSearchModel : BaseViewModel
    {
        public static bool AddItem = false; //This must be public and static so that it can be called from your second Window

        private ObservableCollection<RentalManagementDB> _List;
        public ObservableCollection<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        public ICommand RentalDetailsView { get; set; }

        public ICommand RentalFix { get; set; }

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

        public RentalSearchModel()
        {
            string Result = null;
            List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));

            #region SearchButton
            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Result = Search;


                if (Result != "")
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

            #region PrintsButton
            PrintsButton = new RelayCommand<object>((p) => { return true; }, (p) =>
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
                            //ws.Cells[1, 1, 1, countColHeader].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

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
                        MessageBox.Show("エラーがありました❕" + EE, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("一覧表示がなかったです。検索のは検索してください❕", "検索しなかった", MessageBoxButton.OK, MessageBoxImage.Hand);
                }

            });
            #endregion


            RentalDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalDetailsView openWindowDetails = new RentalDetailsView(); openWindowDetails.ShowDialog();
            });

            RentalFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch rentalSearch = new RentalSearch();

                var rentalSearchHouseNo = rentalSearch.House.Text;

                if (rentalSearchHouseNo != "")
                {
                    Window window = new Window
                    {
                        Title = "修正",
                        Width = 835,
                        Height = 450,
                        Content = new RentalFixs(),
                        ResizeMode = ResizeMode.NoResize,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen,
                        WindowStyle = WindowStyle.None
                    };
                    window.ShowDialog();

                }
                else
                {
                    MessageBox.Show("物件を選択下さい！", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }

    }
}
