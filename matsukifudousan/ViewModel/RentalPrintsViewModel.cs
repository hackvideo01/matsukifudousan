using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ExcelWorksheet = GemBox.Spreadsheet.ExcelWorksheet;
using System.Windows.Controls;
using System.Windows.Forms;
using PrintDialog = System.Windows.Forms.PrintDialog;
using System.Threading;
using System.Drawing.Printing;
using DocumentFormat.OpenXml.Wordprocessing;
using GleamTech.FileSystems.AmazonS3;
using System.Drawing;
using Spire.Pdf;
using Spire.Xls;
using matsukifudousan.Model;
using System.Collections.ObjectModel;
using MessageBox = System.Windows.MessageBox;

namespace matsukifudousan.ViewModel
{
    public class RentalPrintsViewModel : BaseViewModel
    {
        private ObservableCollection<RentalManagementDB> _List;
        public ObservableCollection<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _Combox = new ObservableCollection<Object>();
        public ObservableCollection<Object> Combox { get => _Combox; set { _Combox = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private string _HouseNo;
        public string HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }
        
        private string _SelectedPrints;
        public string SelectedPrints { get => _SelectedPrints; set { _SelectedPrints = value; OnPropertyChanged(); } }

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

        public ICommand PDFButton { get; set; }

        public ICommand EXCELButton { get; set; }

        public ICommand EXCELButton2 { get; set; }

        public ICommand SearchButton { get; set; }

        private bool isNewXlsFile = false;
        private Microsoft.Office.Interop.Excel.Application xls = null;
        private Microsoft.Office.Interop.Excel.Workbook book = null;
        private Microsoft.Office.Interop.Excel.Worksheet sheet = null;

        private void printPreview_PrintClick(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            string path = "C:/Users/user/source/repos/matsukifudousan-git-backup/matsukifudousan/files/test.pdf";
            doc.LoadFromFile(path);

            PrintDialog dialogPrint = new PrintDialog();
            dialogPrint.AllowPrintToFile = true;
            dialogPrint.AllowSomePages = true;
            dialogPrint.PrinterSettings.MinimumPage = 1;
            dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
            dialogPrint.PrinterSettings.FromPage = 1;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

            PageSetupDialog setupDlg = new PageSetupDialog();
            PrintDocument printDoc = doc.PrintDocument;
            setupDlg.AllowMargins = false;
            setupDlg.AllowOrientation = false;
            setupDlg.AllowPaper = false;
            setupDlg.AllowPrinter = false;

            if (dialogPrint.ShowDialog() == DialogResult.OK)
            {
                doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;
                try
                {
                    //printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A3", 1169, 1654);
                    printDoc.PrinterSettings =
                        dialogPrint.PrinterSettings;
                    printDoc.Print();
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("プリンターがないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        public RentalPrintsViewModel()
        {
            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string savePathFile = string.Format(@"{0}\files", projectDirectory);
            // Create specific path image
            string savePathImage = string.Format(@"{0}\images", projectDirectory);

            PDFButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                RentalPrints prs = new RentalPrints();
                string path = savePathFile + "/test.pdf";
                PdfDocument doc = new PdfDocument();
                try
                {
                    doc.LoadFromFile(path);
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("パスが正しくないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                PrintDialog dialogPrint = new PrintDialog();

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.ClientSize =
                    new System.Drawing.Size(400, 300);
                previewDialog.Location =
                    new System.Drawing.Point(29, 29);
                previewDialog.Name = "PrintPreviewDialog1";
                PrintDocument printDoc = doc.PrintDocument;
                previewDialog.Document = printDoc;

                ToolStripButton b = new ToolStripButton();
                b.Image = Bitmap.FromFile(savePathImage + "/printer.png");
                b.DisplayStyle = ToolStripItemDisplayStyle.Image;
                b.Click += printPreview_PrintClick;
                ((ToolStrip)(previewDialog.Controls[1])).Items.RemoveAt(0);
                ((ToolStrip)(previewDialog.Controls[1])).Items.Insert(0, b);

                previewDialog.ShowDialog();
            });

            string Result = null;
            List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
            #region SearchButton
            //int loadedRecord = 0;
            //int pageNumber = 1;
            //int numberRecord = 10;

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Result = Search;
                //List = LoadRecord(loadedRecord, numberRecord);

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
            Combox.Add("物件賃貸契約書");
            EXCELButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                RentalPrints select = new RentalPrints();
                
                if(SelectedPrints == "物件賃貸契約書")
                {
                    this.xls = new Microsoft.Office.Interop.Excel.Application();
                    ExcelVisibleToggle(xls, false);
                    if (this.isNewXlsFile)
                    {
                        this.book = xls.Workbooks.Add();
                    }
                    else
                    {
                        // Open a File
                        this.book = xls.Workbooks.Open(savePathFile + "/建物賃貸借契約書.xlsx");

                        this.xls.Cells[30, "C"] = "ok1";
                    }
                    //this.sheet =
                    //(Microsoft.Office.Interop.Excel.Worksheet)this.book.Sheets[sheetName];
                    ExcelVisibleToggle(xls, true);
                }
                else
                {
                    MessageBox.Show(SelectedPrints);
                }

                //RentalPrints prs = new RentalPrints();

                //string path = savePathFile + "/test.xls";

                //Workbook workbook = new Workbook();
                //try
                //{
                //    workbook.LoadFromFile(path);
                //}
                //catch (Exception)
                //{

                //    System.Windows.MessageBox.Show("パスが正しくないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}

                //PrintDialog dialog = new PrintDialog();

                //dialog.AllowPrintToFile = true;
                //dialog.AllowCurrentPage = true;
                //dialog.AllowSomePages = true;
                //dialog.AllowSelection = true;
                //dialog.UseEXDialog = true;
                //dialog.PrinterSettings.Duplex = Duplex.Simplex;
                //dialog.PrinterSettings.FromPage = 0;
                //dialog.PrinterSettings.ToPage = 8;
                //dialog.PrinterSettings.PrintRange = PrintRange.SomePages;

                //if (dialog.ShowDialog() == DialogResult.OK)
                //{
                //    try
                //    {
                //        workbook.PrintDialog = dialog;
                //        PrintDocument pd = workbook.PrintDocument;
                //        pd.Print();
                //    }
                //    catch (Exception)
                //    {

                //        System.Windows.MessageBox.Show("プリンターがないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                //        return;
                //    }
                //}
            });
            EXCELButton2 = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                RentalPrints prs = new RentalPrints();
                string path = savePathFile + "/test.xls";
                Workbook workbook = new Workbook();
                try
                {
                    workbook.LoadFromFile(path);
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("パスが正しくないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                PrintDialog dialog = new PrintDialog();
                dialog.AllowPrintToFile = true;
                dialog.AllowCurrentPage = true;
                dialog.AllowSomePages = true;
                dialog.AllowSelection = true;
                dialog.UseEXDialog = true;
                dialog.PrinterSettings.Duplex = Duplex.Simplex;
                dialog.PrinterSettings.FromPage = 0;
                dialog.PrinterSettings.ToPage = 8;
                dialog.PrinterSettings.PrintRange = PrintRange.SomePages;
               
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        workbook.PrintDialog = dialog;
                        PrintDocument pd = workbook.PrintDocument;
                        pd.Print();
                    }
                    catch (Exception)
                    {
                        System.Windows.MessageBox.Show("プリンターがないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            });
        }
        public void ExcelVisibleToggle(Microsoft.Office.Interop.Excel.Application xls, bool setting)
        {
            if (xls.Visible == !setting)
            {
                xls.Visible = setting;
            }
        }
    }
}
