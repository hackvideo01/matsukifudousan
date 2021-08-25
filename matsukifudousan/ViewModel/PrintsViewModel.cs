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
using Spire.Xls;
using Spire.Pdf;

namespace matsukifudousan.ViewModel
{
    public class PrintsViewModel : BaseViewModel
    {
        public ICommand PDFButton { get; set; }

        public ICommand EXCELButton { get; set; }

        public ICommand EXCELButton2 { get; set; }
        public PrintsViewModel()
        {
            PDFButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                //ExcelFile workbook = ExcelFile.Load(path);

                //foreach (ExcelWorksheet worksheet in workbook.Worksheets)
                //{
                //    ExcelPrintOptions sheetPrintOptions = worksheet.PrintOptions;

                //    sheetPrintOptions.Portrait = false;
                //    sheetPrintOptions.HorizontalCentered = true;
                //    sheetPrintOptions.VerticalCentered = true;

                //    sheetPrintOptions.PrintHeadings = true;
                //    sheetPrintOptions.PrintGridlines = true;
                //}

                //PrintOptions printOptions = new PrintOptions();
                //printOptions.SelectionType = SelectionType.EntireFile;

                //string printerName = null;
                //workbook.Print(printerName, printOptions);

                Prints prs = new Prints();

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/images/RentalImage/test.pdf";

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

                //PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                //previewDialog.ClientSize =
                //    new System.Drawing.Size(400, 300);
                //previewDialog.Location =
                //    new System.Drawing.Point(29, 29);
                //previewDialog.Name = "PrintPreviewDialog1";
                //PrintDocument printDoc = doc.PrintDocument;
                //previewDialog.Document = printDoc;
                //previewDialog.ShowDialog();

                dialogPrint.AllowPrintToFile = true;
                dialogPrint.AllowSomePages = true;
                dialogPrint.PrinterSettings.MinimumPage = 1;
                dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
                dialogPrint.PrinterSettings.FromPage = 1;
                dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;
                PageSize pageSize = null;



                if (dialogPrint.ShowDialog() == DialogResult.OK)
            {
                    doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                    doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                    doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;
                    //doc.PageSettings.Size = PdfPageSize.A3;
                    //doc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;


                    PrintDocument printDoc = doc.PrintDocument;

                    PrinterSettings ps = new PrinterSettings();
                    printDoc.PrinterSettings = ps;

                    //printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 297, 420);

                    //printDoc.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A3Rotated;

                    try
                    {
                        printDoc.Print();
                    }
                    catch (Exception)
                    {

                        System.Windows.MessageBox.Show("プリンターがないです。","エラー",MessageBoxButton.OK,MessageBoxImage.Error);
                        return;
                    }
            }

            });

            EXCELButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {

                Prints prs = new Prints();

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/images/RentalImage/tuvung1.xlsx";

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
            EXCELButton2 = new RelayCommand<object>((px) => { return true; }, (px) =>
            {

                Prints prs = new Prints();

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/images/RentalImage/tuvung1.xlsx";

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
    }
}
