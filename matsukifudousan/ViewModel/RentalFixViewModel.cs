using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.IO;
using System.Diagnostics;
using System.Threading;
using GleamTech.Reflection;
using ImageProcessor.Common.Extensions;
using UserControl = System.Windows.Controls.UserControl;

namespace matsukifudousan.ViewModel
{
    public class RentalFixViewModel : BaseViewModel, System.ComponentModel.INotifyPropertyChanged
    {
        

        #region Rental Item Input
        private string _HouseNo;
        public string HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _HouseName;
        public string HouseName { get => _HouseName; set { _HouseName = value; OnPropertyChanged(); } }

        private string _HousePost;
        public string HousePost { get => _HousePost; set { _HousePost = value; OnPropertyChanged(); } }

        private string _HouseAddress;
        public string HouseAddress { get => _HouseAddress; set { _HouseAddress = value; OnPropertyChanged(); } }

        private string _NearestSation;
        public string NearestSation { get => _NearestSation; set { _NearestSation = value; OnPropertyChanged(); } }

        private string _HouseType;
        public string HouseType { get => _HouseType; set { _HouseType = value; OnPropertyChanged(); } }

        private string _Construction;
        public string Construction { get => _Construction; set { _Construction = value; OnPropertyChanged(); } }

        private string _YearConstruction;
        public string YearConstruction { get => _YearConstruction; set { _YearConstruction = value; OnPropertyChanged(); } }

        private string _Decorate;
        public string Decorate { get => _Decorate; set { _Decorate = value; OnPropertyChanged(); } }

        private string _TotalArea;
        public string TotalArea { get => _TotalArea; set { _TotalArea = value; OnPropertyChanged(); } }

        private string _Parking;
        public string Parking { get => _Parking; set { _Parking = value; OnPropertyChanged(); } }

        private string _Pets;
        public string Pets { get => _Pets; set { _Pets = value; OnPropertyChanged(); } }

        private string _OtherEquipment;
        public string OtherEquipment { get => _OtherEquipment; set { _OtherEquipment = value; OnPropertyChanged(); } }

        private string _HouseRemarks;
        public string HouseRemarks { get => _HouseRemarks; set { _HouseRemarks = value; OnPropertyChanged(); } }

        private string _SecurityDeposit;
        public string SecurityDeposit { get => _SecurityDeposit; set { _SecurityDeposit = value; OnPropertyChanged(); } }

        private string _KeyMoney;
        public string KeyMoney { get => _KeyMoney; set { _KeyMoney = value; OnPropertyChanged(); } }

        private string _CommonFee;
        public string CommonFee { get => _CommonFee; set { _CommonFee = value; OnPropertyChanged(); } }

        private string _ManagementFee;
        public string ManagementFee { get => _ManagementFee; set { _ManagementFee = value; OnPropertyChanged(); } }

        private string _Rent;
        public string Rent { get => _Rent; set { _Rent = value; OnPropertyChanged(); } }

        private string _ParkingFee;
        public string ParkingFee { get => _ParkingFee; set { _ParkingFee = value; OnPropertyChanged(); } }

        private string _OtherFee;
        public string OtherFee { get => _OtherFee; set { _OtherFee = value; OnPropertyChanged(); } }

        private string _MNGMTCOName;
        public string MNGMTCOName { get => _MNGMTCOName; set { _MNGMTCOName = value; OnPropertyChanged(); } }

        private string _CompanyAddress;
        public string CompanyAddress { get => _CompanyAddress; set { _CompanyAddress = value; OnPropertyChanged(); } }

        private string _COPhone;
        public string COPhone { get => _COPhone; set { _COPhone = value; OnPropertyChanged(); } }

        private string _COFax;
        public string COFax { get => _COFax; set { _COFax = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Fax;
        public string Fax { get => _Fax; set { _Fax = value; OnPropertyChanged(); } }

        private string _MNGMTForm;
        public string MNGMTForm { get => _MNGMTForm; set { _MNGMTForm = value; OnPropertyChanged(); } }

        private string _Remarks;
        public string Remarks { get => _Remarks; set { _Remarks = value; OnPropertyChanged(); } }

        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }

        #endregion

        #region
        private string _ImagePath;
        public string ImagePath { get => _ImagePath; set { _ImagePath = value; OnPropertyChanged(); } }

        private string _ImageFullPath;
        public string ImageFullPath { get => _ImageFullPath; set { _ImageFullPath = value; OnPropertyChanged(); } }

        private string _rentalSearchHouseNo;
        public string rentalSearchHouseNo { get => _rentalSearchHouseNo; set { _rentalSearchHouseNo = value; OnPropertyChanged(); } }
        #endregion
        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand AddRentalCommand { get; set; }

        public ICommand AddImageCommand { get; set; }

        public ICommand deleteAction { get; set; }

        public string[] ImageObject;

        public string[] ImageNameObject;

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged("NameIMG"); } }

        private ObservableCollection<Object> _ImageListPath = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath { get => _ImageListPath; set { _ImageListPath = value; OnPropertyChanged(); } }

        private ObservableCollection<RentalManagementDB> _RentalDetailsView;
        public ObservableCollection<RentalManagementDB> RentalDetailsView { get => _RentalDetailsView; set { _RentalDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _rentalImageView;
        public ObservableCollection<ImageDB> rentalImageView { get => _rentalImageView; set { _rentalImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGDeleteList = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGDeleteList { get => _NameIMGDeleteList; set { _NameIMGDeleteList = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageData = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageData { get => _ImageData; set { _ImageData = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";

        string conbineCharatarAfter = "] ";

        public int Comfirm = 0;

        public RentalFixViewModel()
        {
            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;

            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            // Create specific path file
            string SavePath = string.Format(@"{0}\images\RentalImage", projectDirectory);

            string[] a = ImageObject;

            RentalSearch rentalSearch = new RentalSearch();

            rentalSearchHouseNo = rentalSearch.House.Text;

            reload();

            AddImageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                try
                {

                duplicateImage:

                    OpenFileDialog openDialog = new OpenFileDialog();

                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

                    openDialog.Multiselect = true;

                    if (openDialog.ShowDialog() == true)
                    {

                        string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);



                        //string appdirect = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                        //string appdirect1 = AppDomain.CurrentDomain.BaseDirectory;

                        //string appdirect2 = System.IO.Directory.GetCurrentDirectory();

                        //string appdirect3 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                        foreach (String item in openDialog.FileNames)
                        {
                            //var displayListImage = DataProvider.Ins.DB.ImageDB.Where(x => x.ImageName == item);

                            //if (displayListImage == null || displayListImage.Count() != 0)
                            //{

                            //    var result = MessageBox.Show("がありました。この写真を保存しますか？", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Error);
                            //    if (result == MessageBoxResult.No)
                            //    {
                            //        goto duplicateImage;
                            //    }
                            //}

                            string fileNameRandom = item;
                            int count = 0;
                            string filePathWithoutName = Path.GetDirectoryName(fileNameRandom);
                            string fileName = Path.GetFileName(fileNameRandom);
                            string filenamewithoutextension = Path.GetFileNameWithoutExtension(fileNameRandom);
                            string extension = Path.GetExtension(fileNameRandom);

                            if (File.Exists(SavePath + "\\" + fileName))
                            {

                                var result = MessageBox.Show("【" + fileName + "】 " + "がありました。\nもう一度写真を選択或いはアップデートしたい写真の名前を変更ください！", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                                if (result == MessageBoxResult.OK)
                                {
                                    goto duplicateImage;
                                }
                            }

                            //while (File.Exists(SavePath + "\\" + fileName))
                            //{
                            //    MessageBox.Show("ありました!");

                            //    fileName = filenamewithoutextension + count + extension;
                            //}

                            //ImageObject.Add(filePathWithoutName + "\\" + fileName);
                            //File.Copy(fileNameRandom, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(fileNameRandom)), true);
                            //string curDir = Path.GetDirectoryName(fileNameRandom);
                            //File.Move(fileNameRandom, Path.Combine(curDir, "NewNameForFile.txt"));
                        }

                        int i = 1;
                        foreach (var imageLink in openDialog.FileNames)
                        {
                            string imagePath = imageLink;

                            var drawImageBitmap = new BitmapImage(new Uri(imagePath));
                            var imageControl = new Image();
                            imageControl.Width = 100;  //set image of width 100 , guest of request
                            imageControl.Height = 100; //set image of height 100 , quest of request
                            imageControl.Source = drawImageBitmap;

                            Button deleteButton = new Button();
                            deleteButton.Content = "X";
                            deleteButton.Name = "Delete";
                            deleteButton.Command = deleteAction;
                            deleteButton.Background = Brushes.Red;
                            deleteButton.Click += new RoutedEventHandler(home_read_click);

                            //StackPanel stackPnl = new StackPanel();
                            //stackPnl.Orientation = Orientation.Vertical;
                            //stackPnl.Height = 150;
                            //stackPnl.Width = 150;
                            //stackPnl.Children.Add(imageControl);
                            //stackPnl.Children.Add(deleteButton);

                            NameIMG.Add(imageControl);
                            NameIMG.Add(deleteButton);

                            //NameIMG.Add(stackPnl);


                            i += 2;
                        }

                        ImageObject = openDialog.FileNames;
                        ImageNameObject = openDialog.SafeFileNames;

                        foreach (String saveImageName in ImageNameObject)
                        {
                            ImageListPath.Add(saveImageName);
                        }

                        ImagePath = "";

                        foreach (var saveImageName in ImageListPath)
                        {
                            ImagePath += conbineCharatarBefore + saveImageName + conbineCharatarAfter;

                        }

                        foreach (String SaveImageItem in ImageObject)
                        {
                            File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Fix!" + e, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            });

            AddRentalCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(HouseNo))
                //    return false;

                //var displayList = DataProvider.Ins.DB.RentalManagementDB.Where(x => x.HouseNo == HouseNo);
                //if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                //    return false;

                return true;
            }, (p) =>

            {
                #region Value Form RentalMangement

                var AddRental = DataProvider.Ins.DB.RentalManagementDB.Where(hno => hno.HouseNo == rentalSearchHouseNo).SingleOrDefault();

                //HouseNo = HouseNo,
                AddRental.HouseName = HouseName;
                AddRental.HousePost = HousePost;
                AddRental.HouseAddress = HouseAddress;
                AddRental.NearestSation = NearestSation;
                AddRental.HouseType = HouseType;
                AddRental.Construction = Construction;
                AddRental.YearConstruction = YearConstruction;
                AddRental.Decorate = Decorate;
                AddRental.TotalArea = TotalArea;
                AddRental.Parking = Parking;
                AddRental.Pets = Pets;
                AddRental.OtherEquipment = OtherEquipment;
                AddRental.HouseRemarks = HouseRemarks;
                AddRental.SecurityDeposit = SecurityDeposit;
                AddRental.KeyMoney = KeyMoney;
                AddRental.CommonFee = CommonFee;
                AddRental.ManagementFee = ManagementFee;
                AddRental.Rent = Rent;
                AddRental.ParkingFee = ParkingFee;
                AddRental.OtherFee = OtherFee;
                AddRental.MNGMTCOName = MNGMTCOName;
                AddRental.CompanyAddress = CompanyAddress;
                AddRental.COPhone = COPhone;
                AddRental.COFax = COFax;
                AddRental.Name = Name;
                AddRental.Address = Address;
                AddRental.Phone = Phone;
                AddRental.Fax = Fax;
                AddRental.MNGMTForm = MNGMTForm;
                AddRental.Remarks = Remarks;
                AddRental.Image = Image;

                DataProvider.Ins.DB.SaveChanges();
                string appDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                int nameImageCount = 0;

                rentalImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.HouseNo == rentalSearchHouseNo));
                DataProvider.Ins.DB.ImageDB.RemoveRange(rentalImageView);
                DataProvider.Ins.DB.SaveChanges();
                foreach (string saveImageDB in ImageListPath)
                {
                    var AddImage = new ImageDB()
                    {
                        ImageName = saveImageDB,
                        ImagePath = SavePath + "\\" + saveImageDB,
                        HouseNo = HouseNo
                    };
                    DataProvider.Ins.DB.ImageDB.Add(AddImage);
                    DataProvider.Ins.DB.SaveChanges();

                    nameImageCount++;
                }
                Comfirm = 1;

                if (Comfirm == 1)
                {

                    //foreach (string VARIABLE in NameIMGDeleteList)
                    //{
                    //    DeleteImage(VARIABLE);
                    //}

                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

                    MessageBox.Show("データを修正されました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);

                    Comfirm = 0;
                }

                //if (Comfirm == 1)
                //{
                //    for (int i = nameImageCount * 2 - 1; i >= 0; i--)
                //    {
                //        NameIMG.RemoveAt(i);
                //        ImagePath = "";
                //    }
                //}

                #endregion
            });

        }

        private void home_read_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((Button)sender);

            int comfirmDeleteImage = Comfirm;

            var button = sender as Button;

            //string n = ((Button) sender).Content.ToString();

            //int index = Int32.Parse(n);

            var indexBtn = NameIMG.IndexOf(button);

            var indexImg = indexBtn - 1;

            if (indexImg == 0)
            {
                string nameImage = ImageListPath.ElementAt(0).ToString();
                ImageListPath.RemoveAt(0);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);

                if (comfirmDeleteImage == 0)
                {
                    //NameIMGDeleteList.Add(nameImage);
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);
                        
                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.HouseNo == rentalSearchHouseNo && d.ImageName == nameImage);
                        DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }

            }
            else
            {
                string nameImage = ImageListPath.ElementAt(indexImg / 2).ToString();
                ImageListPath.RemoveAt(indexImg / 2);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);

                if (comfirmDeleteImage == 0)
                {
                    //NameIMGDeleteList.Add(nameImage);
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);

                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.HouseNo == rentalSearchHouseNo && d.ImageName == nameImage);
                        DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }

            }

            ImagePath = "";

            foreach (var saveImageName in ImageListPath)
            {
                ImagePath += conbineCharatarBefore + saveImageName + conbineCharatarAfter;

            }
        }

        private void reload()
        {
            if (rentalSearchHouseNo != "")
            {
                #region Display Column of value

                RentalDetailsView = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo));

                HouseNo = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().HouseNo;
                HouseName = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().HouseName;
                HousePost = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().HousePost;
                HouseAddress = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().HouseAddress;
                NearestSation = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().NearestSation;
                HouseType = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().HouseType;
                Construction = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Construction;
                YearConstruction = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().YearConstruction;
                Decorate = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Decorate;
                TotalArea = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().TotalArea;
                Parking = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Parking;
                Pets = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Pets;
                OtherEquipment = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().OtherEquipment;
                HouseRemarks = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().HouseRemarks;
                SecurityDeposit = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().SecurityDeposit;
                KeyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().KeyMoney;
                CommonFee = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().CommonFee;
                ManagementFee = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().ManagementFee;
                Rent = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Rent;
                ParkingFee = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().ParkingFee;
                OtherFee = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().OtherFee;
                MNGMTCOName = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().MNGMTCOName;
                CompanyAddress = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().CompanyAddress;
                COPhone = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().COPhone;
                COFax = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().COFax;
                Name = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Name;
                Address = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Address;
                Phone = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Phone;
                Fax = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Fax;
                MNGMTForm = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().MNGMTForm;
                Remarks = DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == rentalSearchHouseNo).First().Remarks;

                #endregion


                rentalImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.HouseNo == rentalSearchHouseNo));


                foreach (var imagePathDB in rentalImageView)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    ImageFullPath = imagePath;

                    //var drawImageBitmap = new BitmapImage(new Uri(imagePath));
                    //drawImageBitmap.CacheOption = BitmapCacheOption.OnLoad;
                    //var imageControl = new Image();
                    //imageControl.Width = 100;  //set image of width 100 , guest of request
                    //imageControl.Height = 100; //set image of height 100 , quest of request
                    //imageControl.Source = drawImageBitmap;

                    var bitmap = new BitmapImage();
                    var stream = File.OpenRead(imagePath);
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    stream.Close();
                    stream.Dispose();
                    bitmap.Freeze();
                    var imageControl = new Image();
                    imageControl.Width = 100;  //set image of width 100 , guest of request
                    imageControl.Height = 100; //set image of height 100 , quest of request
                    imageControl.Source = bitmap;

                    Button deleteButton = new Button();
                    deleteButton.Content = "X";
                    deleteButton.Name = "Delete";
                    //deleteButton.Command = deleteAction;
                    deleteButton.Background = Brushes.Red;
                    deleteButton.Click += new RoutedEventHandler(home_read_click);

                    NameIMG.Add(imageControl);
                    NameIMG.Add(deleteButton);
                    ImagePath += conbineCharatarBefore + imageName + conbineCharatarAfter;
                    ImageListPath.Add(imageName);

                }
            }
        }
        private void DeleteImage(string nameImage)

        {
            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;

            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            // Create specific path file
            string SavePath = string.Format(@"{0}\images\RentalImage\", projectDirectory);

            string path = SavePath + nameImage;
            try
            {
                if (File.Exists(path))
                {

                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    GC.Collect();
                    System.IO.File.Delete(path);

                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("" + ex);
            }

        }

    }

}
