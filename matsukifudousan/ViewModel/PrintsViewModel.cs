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
using Spire.Pdf;
using Spire.Xls;

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

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/bin/Debug/RentalImage/2.pdf";

                PdfDocument doc = new PdfDocument();
                try
                {
                    doc.LoadFromFile(path);
                }
                catch (Exception e)
                {

                    System.Windows.MessageBox.Show("パスが正しくないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            PrintDialog dialogPrint = new PrintDialog();
            dialogPrint.AllowPrintToFile = true;
            dialogPrint.AllowSomePages = true;
            dialogPrint.PrinterSettings.MinimumPage = 1;
            dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
            dialogPrint.PrinterSettings.FromPage = 1;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

            if (dialogPrint.ShowDialog() == DialogResult.OK)
            {
                    doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                    doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                    doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;

                    PrintDocument printDoc = doc.PrintDocument;
                    try
                    {
                        printDoc.Print();
                    }
                    catch (Exception e)
                    {

                        System.Windows.MessageBox.Show("プリンターがないです。","エラー",MessageBoxButton.OK,MessageBoxImage.Error);
                        return;
                    }
            }

            });

            EXCELButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {

                Prints prs = new Prints();

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/bin/Debug/RentalImage/tuvung1.xlsx";

                Workbook workbook = new Workbook();
                try
                {
                    workbook.LoadFromFile(path);
                }
                catch (Exception e)
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
                    catch (Exception e)
                    {

                        System.Windows.MessageBox.Show("プリンターがないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

            });
            EXCELButton2 = new RelayCommand<object>((px) => { return true; }, (px) =>
            {

                Prints prs = new Prints();

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/bin/Debug/RentalImage/2.xlsx";

                Workbook workbook = new Workbook();
                try
                {
                    workbook.LoadFromFile(path);
                }
                catch (Exception e)
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
                    catch (Exception e)
                    {

                        System.Windows.MessageBox.Show("プリンターがないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

            });
        }
    }
}
