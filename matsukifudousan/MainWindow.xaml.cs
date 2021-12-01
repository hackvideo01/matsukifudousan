using AutoUpdaterDotNET;
using System;
using System.Deployment.Application;
using System.Windows;
using System.Windows.Controls;

namespace matsukifudousan
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl usc = null;
        public MainWindow()
        {
            InitializeComponent();

            usc = new UserControlMain();
            GridMain.Children.Add(usc);
        }

        private void ListViewMenu_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {

                case "UserControlMain":
                    usc = new UserControlMain();
                    GridMain.Children.Add(usc);
                    break;
                case "RentalManagement":
                    usc = new RentalManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "DetachedHouseManagement":
                    usc = new DetachedHouseManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "ApartmentManagement":
                    usc = new ApartmentManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "LandManagement":
                    usc = new LandManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "RentalPayment":
                    usc = new RentalContractPaymentSearch();
                    GridMain.Children.Add(usc);
                    break;
                case "ImageSearch":
                    usc = new ImageSearch();
                    GridMain.Children.Add(usc);
                    break;
                case "version":
                    version_Click();
                    break;
                default:
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            string version = fvi.FileVersion;
            versionNo.Text = "バージョン： " + version;
            AutoUpdater.DownloadPath = "update";
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 15 * 60 * 1000,
                //SynchronizingObject = (System.ComponentModel.ISynchronizeInvoke)this
            };
            timer.Elapsed += delegate
            {
                AutoUpdater.Start("https://strategic.jp/matsuki-update/update.xml");
            };
            timer.Start();
        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable)
            {

                var dialogResult =
                    MessageBox.Show(
                        $@"Bạn ơi, phần mềm của bạn có phiên bản mới {args.CurrentVersion}. Phiên bản bạn đang sử dụng hiện tại  {args.InstalledVersion}. Bạn có muốn cập nhật phần mềm không?", @"Cập nhật phần mềm",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Information);

                if (dialogResult.Equals(MessageBoxResult.Yes) || dialogResult.Equals(MessageBoxResult.OK))
                {
                    try
                    {
                        if (AutoUpdater.DownloadUpdate(args))
                        {
                            main1.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Phiên bản bạn đang sử dụng đã được cập nhật mới nhất.", @"Cập nhật phần mềm",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void version_Click()
        {
            AutoUpdater.Start("https://strategic.jp/matsuki-update/update.xml");
        }


        private void ListViewMenu_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {

                case "UserControlMain":
                    usc = new UserControlMain();
                    GridMain.Children.Add(usc);
                    break;
                case "RentalManagement":
                    usc = new RentalManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "DetachedHouseManagement":
                    usc = new DetachedHouseManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "ApartmentManagement":
                    usc = new ApartmentManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "LandManagement":
                    usc = new LandManagement();
                    GridMain.Children.Add(usc);
                    break;
                case "version":
                    version_Click();
                    break;
                default:
                    break;
            }
        }
    }
}
