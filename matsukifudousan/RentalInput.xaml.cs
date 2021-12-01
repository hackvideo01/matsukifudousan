using matsukifudousan.Model;
using matsukifudousan.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace matsukifudousan
{
    /// <summary>
    /// RentalInput.xaml の相互作用ロジック
    /// </summary>
    public partial class RentalInput : UserControl
    {
        public RentalInput()
        {
            InitializeComponent();
        }
            private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void txbHousePost_LostFocus(object sender, RoutedEventArgs e)
        {
            string zipcode = txbHousePost.Text;
            //URL
            string url = "https://zipcloud.ibsnet.co.jp/api/search?zipcode=" + zipcode;
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    // エンコーディングをUTF-8にしておく（取得してからEncoding変えてもパースできなかった）
                    webClient.Encoding = System.Text.Encoding.UTF8;

                    // JSONのテキストを取得
                    string jsonStr = webClient.DownloadString(url);

                    JObject jsonObj = JObject.Parse(jsonStr);

                    var jsonData = jsonObj["results"].First;
                    //var jsonData1 = jsonObj["results"];
                    //var jsonData2 = jsonObj["results"].FirstOrDefault();

                    var address1 = jsonData["address1"];
                    var address2 = jsonData["address2"];
                    var address3 = jsonData["address3"];

                    //var jsonPollution = jsonCurrent["pollution"];
                    //var json_aqius = jsonPollution["aqius"];
                    //var json_aqicn = jsonPollution["aqicn"];
                    // Dictionaryをシリアライズします。
                    //var jsonstr = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    //MessageBox.Show(address1.ToString() + address2.ToString() + address3.ToString());

                    txbHouseAddress.Text = address1.ToString() + address2.ToString() + address3.ToString();
                    txbHouseAddress.SelectionStart = txbHouseAddress.Text.Length;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("郵便局番号は恐らく間違っています。もう一度ご確認お願い致します。", "確認", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txbHouseNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            //foreach (var ch in e.Text)
            //{
            //    if (!(Char.IsDigit(ch) || ch.Equals(':')))
            //    {
            //        e.Handled = true;
            //        break;
            //    }
            //}
        }

        private void txbHouseNo_KeyUp(object sender, KeyEventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if (ke.Key == Key.Space)
            {
                ke.Handled = true;

                MessageBox.Show("物件番号はスペースバーを入力したいでください！", "確認", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        private void txbHouseNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbHouseNo.Text != "" && IsNumber(txbHouseNo.Text))
            {
                int houseno = Int32.Parse(txbHouseNo.Text);
                var checkHouse = DataProvider.Ins.DB.RentalManagementDB.Where(ck => ck.HouseNo == houseno);
                int checkhousenoCount = checkHouse.Count();
                if (checkhousenoCount != 0)
                {
                    MessageBox.Show("その物件番号は使われています。", "物件番号を再入力", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("物件番号（数字のみ）を入力してください。", "物件番号を再入力", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
