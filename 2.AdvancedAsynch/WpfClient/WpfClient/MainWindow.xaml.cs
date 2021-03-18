using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WeatherService service;
        private CancellationTokenSource tokenSource;
        public MainWindow()
        {
            InitializeComponent();
            service = new WeatherService();
            tokenSource = new CancellationTokenSource();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            btn_get.IsEnabled = false;
            gd_results.Items.Clear();
            var town = tb_villes.Text;
            progress.IsIndeterminate = true;
            progress.Visibility = Visibility.Visible;

            var result = await service.GetWeather(town);
            gd_results.Items.Add(new ResultRow
            {
                Town = town,
                JPlus1 = result[0].TemperatureC.ToString(),
                JPlus2 = result[1].TemperatureC.ToString(),
                JPlus3 = result[2].TemperatureC.ToString(),
                JPlus4 = result[3].TemperatureC.ToString(),
                JPlus5 = result[4].TemperatureC.ToString()
            });

            progress.IsIndeterminate = false;
            progress.Visibility = Visibility.Hidden;
            btn_get.IsEnabled = true;
        }
    }
}
