﻿using matsukifudousan.Model;
using matsukifudousan.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace matsukifudousan
{
    /// <summary>
    /// ApartmentInput.xaml の相互作用ロジック
    /// </summary>
    public partial class ApartmentInput : UserControl
    {
        public ApartmentInput()
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

        private void txbApartmentPost_LostFocus(object sender, RoutedEventArgs e)
        {
            string zipcode = txbApartmentPost.Text;
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

                    txbApartmentAddress.Text = address1.ToString() + address2.ToString() + address3.ToString();
                    txbApartmentAddress.SelectionStart = txbApartmentAddress.Text.Length;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("郵便局番号は恐らく間違っています。もう一度ご確認お願い致します。", "確認", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txbApartmentHouseNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        private void txbApartmentHouseNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbApartmentHouseNo.Text != "" && IsNumber(txbApartmentHouseNo.Text))
            {
                int houseno = Int32.Parse(txbApartmentHouseNo.Text);
                var checkHouse = DataProvider.Ins.DB.ApartmentDB.Where(ck => ck.ApartmentHouseNo == houseno);
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
