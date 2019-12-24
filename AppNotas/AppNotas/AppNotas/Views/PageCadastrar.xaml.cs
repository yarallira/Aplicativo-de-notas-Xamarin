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
	public partial class PageCadastrar : ContentPage
	{
		public PageCadastrar ()
		{
			InitializeComponent ();
		}

        public PageCadastrar(ModelNotas nota)
        {
            InitializeComponent();
            btSalvar.Text = "Alterar";
            txtCodigo.IsVisible = true;
            btExcluir.IsVisible = true;

            txtCodigo.Text = nota.Id.ToString();
            txtTitulo.Text = nota.Titulo;
            txtDados.Text = nota.Dados;
            swFavorito.IsToggled = nota.Favorito;
        }

        private void BtSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelNotas nota = new ModelNotas();
                nota.Titulo = txtTitulo.Text;
                nota.Dados = txtDados.Text;
                nota.Favorito = swFavorito.IsToggled;
                ServicesDBNotas dbNotas = new ServicesDBNotas(App.dbPath);
                if (btSalvar.Text == "Inserir")
                {
                    dbNotas.Inserir(nota);
                    DisplayAlert("Resultado da operação: ", dbNotas.StatusMessage, "Ok");
                }
                else
                {// alterar
                    nota.Id = Convert.ToInt32(txtCodigo.Text);
                    dbNotas.Alterar(nota);
                    DisplayAlert("Resultado da operação: ", dbNotas.StatusMessage, "Ok");
                }
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro: ", ex.Message, "Ok");
            }
        }

        private void BtCancelar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageHome());
        }

        private async void BtExcluir_Clicked(object sender, EventArgs e)
        {
            var resp =  await DisplayAlert("Excluir Registro?", 
                "Deseja excluir a nota atual ?", "Sim", "Não" );
            if (resp == true)
            {
                ServicesDBNotas dbNotas = new ServicesDBNotas(App.dbPath);
                int id = Convert.ToInt32(txtCodigo.Text);
                dbNotas.Excluir(id);
                DisplayAlert("Resultado da operação: ", dbNotas.StatusMessage, "Ok");
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new PageHome();
            }
        }
    }
}