﻿using matsukifudousan.Model;
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
    public class DetachedSearchViews : BaseViewModel
    {
        public static bool AddItem = false; //This must be public and static so that it can be called from your second Window

        private ObservableCollection<DetachedDB> _List;
        public ObservableCollection<DetachedDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        public ICommand DetachedDetailsView { get; set; }

        public ICommand DetachedFix { get; set; }

        public ICommand DetachedDelete { get; set; }

        private DetachedDB _SelectedItem;
        public DetachedDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DetachedHouseNo = SelectedItem.DetachedHouseNo;
                }
            }
        }

        private string _DetachedHouseNo;
        public string DetachedHouseNo { get => _DetachedHouseNo; set { _DetachedHouseNo = value; OnPropertyChanged(); } }

        public DetachedSearchViews()
        {
            string Result = null;
            List = new ObservableCollection<DetachedDB>(DataProvider.Ins.DB.DetachedDB.Where(t => t.DetachedHouseNo.Contains(Result) || t.DetachedHouseName.Contains(Result) || t.DetachedAddress.Contains(Result)));

            #region SearchButton
            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Result = Search;


                if (Result != "")
                {

                    List = new ObservableCollection<DetachedDB>(DataProvider.Ins.DB.DetachedDB.Where(t => t.DetachedHouseNo.Contains(Result) || t.DetachedHouseName.Contains(Result) || t.DetachedAddress.Contains(Result)));

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

            DetachedDetailsView = new RelayCommand<object>((p) => { return true; }, (p) => { DetachedDetailsView openWindowDetails = new DetachedDetailsView(); openWindowDetails.ShowDialog(); });

            DetachedFix = new RelayCommand<object>((p) => { return true; }, (p) => { detachedFixOpenWithWindow(); });

            DetachedDelete = new RelayCommand<object>((p) => { return true; }, (p) => { detachedDelete(); });

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

                            ws.Cells[rowIndex, colIndex++].Value = item.DetachedHouseNo;

                            ws.Cells[rowIndex, colIndex++].Value = item.DetachedHouseName;

                            ws.Cells[rowIndex, colIndex++].Value = item.DetachedAddress;

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

        private void detachedFixOpenWithWindow()
        {
            DetachedSearch detachedtalSearch = new DetachedSearch();

            var detachedSearchDetachedHouseNo = detachedtalSearch.House.Text;

            if (detachedSearchDetachedHouseNo != "")
            {
                Window window = new Window
                {
                    Title = "戸建修正",
                    Width = 835,
                    Height = 450,
                    Content = new DetachedFixs(),
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

        private void detachedDelete()
        {
            DetachedSearch detachedtalSearch = new DetachedSearch();
            var detachedDelete = detachedtalSearch.House.Text;

            var resultButtonDeleteHouse = MessageBox.Show("本当にこの物件（物件番号：" + detachedDelete + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultButtonDeleteHouse == MessageBoxResult.OK)
            {
                var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(imgDelete => imgDelete.DetachedHouseNo == detachedDelete);
                DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                var DetachedDeleteDB = DataProvider.Ins.DB.DetachedDB.Where(dtDelete => dtDelete.DetachedHouseNo == detachedDelete);
                DataProvider.Ins.DB.DetachedDB.RemoveRange(DetachedDeleteDB);
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
