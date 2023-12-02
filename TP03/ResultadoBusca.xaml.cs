using TP03Mobile.ViewModels;

namespace TP03Mobile
{
    //Luiz Gustavo e Rodrigo Rebelo

    public partial class ResultadoBusca : ContentPage
    {
        int count = 0;

        public ResultadoBusca()
        {
            InitializeComponent();
            BindingContext = new PacoteViewModel();
        }
        

        private async void OnBuscarNovoPacoteClick(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}