using TarefasApp.Models;

namespace TarefasApp.page;

//Luiz Gustavo Leal Cortez - CB3015386 
//Rodrigo Rebelo - CB3016871


public partial class AdicionarTarefaPage : ContentPage
{
    public AdicionarTarefaPage()
    {
        InitializeComponent();
    }

    async void OnSalvarClicked(object sender, EventArgs e)
    {
        // Aqui, você pode pegar os valores dos campos e criar uma nova tarefa.
        // Depois, você pode usar o MessagingCenter para enviar essa tarefa para a MainPage.

        // Exemplo:
        var novaTarefa = new Tarefa
        {
            Titulo = TituloEntry.Text,
            Descricao = DescricaoEditor.Text,
            Prioridade = (Prioridade)Enum.Parse(typeof(Prioridade), PrioridadePicker.SelectedItem.ToString())
        };

        MessagingCenter.Send(this, "AdicionarTarefa", novaTarefa);

        await Navigation.PopModalAsync(); // Fecha o pop-up
    }

    async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(); // Fecha o pop-up sem salvar
    }
}
