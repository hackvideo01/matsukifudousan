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

            var options = new JsonSerializerOptions
            {
                //日本語の場合の文字化け防止
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                //インデント整形
                WriteIndented = true,
            };

            string zipcode = "4110842";

            string url = "https://zipcloud.ibsnet.co.jp/api/search?zipcode=" + zipcode;
            using (var webClient = new System.Net.WebClient())
            {
                //string jsonStr = webClient.DownloadString(url);
                string jsonStr = webClient.DownloadString(url);

                //バイト配列に変換
                byte[] bytesUTF8 = System.Text.Encoding.Default.GetBytes(jsonStr);

                //バイト配列をUTF8の文字コードとしてStringに変換
                string stringSJIS = System.Text.Encoding.UTF8.GetString(bytesUTF8);

                // Serialize
                var json = System.Text.Json.JsonSerializer.Serialize(stringSJIS, options);

                // Deserialize
                var obj = System.Text.Json.JsonSerializer.Deserialize<string>(json);

                //foreach (var item in json)
                //{

                //}

                //string address = "静岡県";
                //string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(address), YOUR_API_KEY);

                //WebRequest request = WebRequest.Create(requestUri);
                //WebResponse response = request.GetResponse();
                //XDocument xdoc = XDocument.Load(response.GetResponseStream());

                //XElement result = xdoc.Element("GeocodeResponse").Element("result");
                //XElement locationElement = result.Element("geometry").Element("location");
                //XElement lat = locationElement.Element("lat");
                //XElement lng = locationElement.Element("lng");
            }
        }
    }
}
