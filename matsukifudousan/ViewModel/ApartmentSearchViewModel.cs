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
using MaterialDesignThemes.Wpf;

namespace matsukifudousan.ViewModel
{
    public class ApartmentSearchViewModel : BaseViewModel
    {
        public static bool AddItem = false; //This must be public and static so that it can be called from your second Window

        private ObservableCollection<ApartmentDB> _List;
        public ObservableCollection<ApartmentDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        public ICommand ApartmentDetailsView { get; set; }

        public ICommand ApartmentFix { get; set; }

        public ICommand ApartmentDelete { get; set; }

        private ApartmentDB _SelectedItem;
        public ApartmentDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    ApartmentHouseNo = SelectedItem.ApartmentHouseNo;
                }
            }
        }

        private string _ApartmentHouseNo;
        public string ApartmentHouseNo { get => _ApartmentHouseNo; set { _ApartmentHouseNo = value; OnPropertyChanged(); } }

        public ApartmentSearchViewModel()
        {
            string Result = null;
            List = new ObservableCollection<ApartmentDB>(DataProvider.Ins.DB.ApartmentDB.Where(t => t.ApartmentHouseNo.Contains(Result) || t.ApartmentHouseName.Contains(Result) || t.ApartmentAddress.Contains(Result)));

            #region SearchButton
            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Result = Search;


                if (Result != "")
                {

                    List = new ObservableCollection<ApartmentDB>(DataProvider.Ins.DB.ApartmentDB.Where(t => t.ApartmentHouseNo.Contains(Result) || t.ApartmentHouseName.Contains(Result) || t.ApartmentAddress.Contains(Result)));

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

            ApartmentDetailsView = new RelayCommand<object>((p) => { return true; }, (p) => { ApartmentDetailsView openWindowDetails = new ApartmentDetailsView(); openWindowDetails.ShowDialog(); });

            ApartmentFix = new RelayCommand<object>((p) => { return true; }, (p) => { apartmentFixOpenWithWindow(); });

            ApartmentDelete = new RelayCommand<object>((p) => { return true; }, (p) => { apartmentDelete(); });

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

                            ws.Cells[rowIndex, colIndex++].Value = item.ApartmentHouseNo;

                            ws.Cells[rowIndex, colIndex++].Value = item.ApartmentHouseName;

                            ws.Cells[rowIndex, colIndex++].Value = item.ApartmentAddress;

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
        }

        private void apartmentFixOpenWithWindow()
        {
            ApartmentSearch apartmentSearch = new ApartmentSearch();

            var apartmentSearchHouseNo = apartmentSearch.House.Text;

            if (apartmentSearchHouseNo != "")
            {
                Window window = new Window
                {
                    Title = "戸建修正",
                    Width = 835,
                    Height = 450,
                    Content = new ApartmentFix(),
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
        }

        private void apartmentDelete()
        {
            ApartmentSearch apartmentSearch = new ApartmentSearch();

            var apartmentDeleteHouseNo = apartmentSearch.House.Text;

            var resultButtonDeleteHouse = MessageBox.Show("本当にこの物件（物件番号：" + apartmentDeleteHouseNo + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultButtonDeleteHouse == MessageBoxResult.OK)
            {
                var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(imgDelete => imgDelete.DetachedHouseNo == apartmentDeleteHouseNo);
                DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                var apartmnetDeleteDB = DataProvider.Ins.DB.ApartmentDB.Where(dtDelete => dtDelete.ApartmentHouseNo == apartmentDeleteHouseNo);
                DataProvider.Ins.DB.ApartmentDB.RemoveRange(apartmnetDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！");

            }
            else
            {
                MessageBox.Show("削除しなかったです。");
            }

        }

    }
}
