using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : BindableObject
    {
        private string _location;
        private Weather _weather;
        private ICommand _getWeatherCommand;

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public Weather Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetWeatherCommand =>
            _getWeatherCommand ??
            (_getWeatherCommand = new Command(async () => await GetWeatherAsync()));

        public async Task GetWeatherAsync()
        {
            Weather = await WeatherService.Instance.GetWeatherAsync(Location);
        }
    }
}