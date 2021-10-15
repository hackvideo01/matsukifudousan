using ApiAccess.Glassdoor.V1.DataTypes;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace matsukifudousan
{
    /// <summary>
    /// ImageSearch.xaml の相互作用ロジック
    /// </summary>
    public partial class ImageSearch : UserControl
    {
        public ImageSearch()
        {
            InitializeComponent();

            string zipcode = "4110842";

            //URL
            string url = "https://zipcloud.ibsnet.co.jp/api/search?zipcode=" + zipcode;

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
                MessageBox.Show(address1.ToString() + address2.ToString() + address3.ToString());

            }
        }
    }
}
