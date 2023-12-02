using TP03Mobile.ViewModels;

namespace TP03Mobile
{

    //Luiz Gustavo e Rodrigo Rebelo
    public partial class MainPage : ContentPage
    {
        public PacoteViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new PacoteViewModel();
            BindingContext = ViewModel;
        }
            
        private async void OnButtonClick(object sender, EventArgs e)
        {
            string numeroEntrega = NumeroEntrega.Text;

            await ViewModel.BuscarPacoteAsync(numeroEntrega);

            if (ViewModel.Pacote != null)
            {
                await Navigation.PushAsync(new ResultadoBusca { BindingContext = ViewModel });
            }
            else
            {
                NumeroEntrega.Text = "";
            }
        }
    }
}