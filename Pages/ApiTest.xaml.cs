using System;
using System.Collections.Generic;
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
using my.race.connect;
using System.Windows.Threading;
using System.Data;
using Newtonsoft.Json;

namespace MyRaceWPF.Pages
{
    /// <summary>
    /// ApiTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ApiTest : Page
    {
        public ApiTest()
        {
            InitializeComponent();
        }

        private async void buttonTest_Click(object sender, RoutedEventArgs e)
        {

            var connect = new my.race.connect.DataBases();

            var result = await connect.SelectApiInformation("RaceResult").ConfigureAwait(false);
            

            gridResult.ItemsSource = null;            

            MessageBox.Show(result.UrlAddress);
        }

        private async void buttonCall_Click(object sender, RoutedEventArgs e)
        {

            var _databases = new my.race.connect.DataBases();
            var _configuration = new my.race.connect.Configurations();
            var _dataapi = new my.race.connect.DataAPI();

            var parameters = new List<string>()
            {
                "20221113",
                "20221114"
            };

            var apiInformation = await _databases.SelectApiInformation("RaceResult").ConfigureAwait(false);

            gridResult.ItemsSource = null;

            if (apiInformation != null)
            {
                var _parameters = apiInformation.MakeParameters(parameters);
                var apiResult = await _dataapi.GetFromAPI<object>(apiInformation.UrlAddress, _parameters).ConfigureAwait(false);
                var resultJson = JsonConvert.SerializeObject(apiResult);


                var resultTable = new DataTable();

                resultTable  = JsonConvert.DeserializeObject<DataTable>(resultJson) ;

                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                {
                    gridResult.ItemsSource = apiResult;
                }));
            }           

        }
        
    }
}
