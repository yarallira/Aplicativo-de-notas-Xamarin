using AppNotas.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppNotas
{
    public partial class App : Application
    {
        public static string dbName;
        public static string dbPath;

        public App()
        {
            InitializeComponent();

            MainPage = new PagePrincipal();
        }

        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            App.dbName = dbName;
            App.dbPath = dbPath;
            MainPage = new PagePrincipal();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
