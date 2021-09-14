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

namespace matsukifudousan.ViewModel
{
    public class PrintsViewModel : BaseViewModel
    {
        public ICommand PDFButton { get; set; }

        public ICommand EXCELButton { get; set; }

        public ICommand EXCELButton2 { get; set; }

        private void printPreview_PrintClick(object sender, EventArgs e)

        {
            PdfDocument doc = new PdfDocument();
            string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/files/test.pdf";
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
        public PrintsViewModel()
        {
            PDFButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                Prints prs = new Prints();

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/files/test.pdf";

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
                b.Image = Bitmap.FromFile("C:/Users/user/source/repos/matsukifudousan/matsukifudousan/images/printer.png");
                b.DisplayStyle = ToolStripItemDisplayStyle.Image;
                b.Click += printPreview_PrintClick;
                ((ToolStrip)(previewDialog.Controls[1])).Items.RemoveAt(0);
                ((ToolStrip)(previewDialog.Controls[1])).Items.Insert(0, b);

                previewDialog.ShowDialog();

            });

            EXCELButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {

                Prints prs = new Prints();

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/files/test.xls";

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

                string path = "C:/Users/user/source/repos/matsukifudousan/matsukifudousan/files/test.xls";

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
