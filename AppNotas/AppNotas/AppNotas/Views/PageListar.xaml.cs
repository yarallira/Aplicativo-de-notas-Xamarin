using AppNotas.Models;
using AppNotas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNotas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageListar : ContentPage
	{
		public PageListar ()
		{
		    InitializeComponent ();
            AtualizaLista();
        }
       
        public void AtualizaLista()
        {
            ServicesDBNotas dbNotas = new ServicesDBNotas(App.dbPath);
            ListaNotas.ItemsSource = dbNotas.Listar();
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelNotas nota = (ModelNotas)ListaNotas.SelectedItem;
            // Chamada da pageCadastar
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar(nota));
        }
    }
}