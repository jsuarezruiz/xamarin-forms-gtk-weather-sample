using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace WeatherApp.GTK
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            Gtk.Application.Init();
            Forms.Init();
            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("WeatherApp");
            window.Show();
            Gtk.Application.Run();
        }
    }
}