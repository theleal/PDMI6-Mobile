using TarefasApp.Models;

namespace TarefasApp.page;

//Luiz Gustavo Leal Cortez - CB3015386 
//Rodrigo Rebelo - CB3016871


public partial class EditarTarefaPage : ContentPage
{
    public Tarefa TarefaAtual { get; set; }

    public EditarTarefaPage(Tarefa tarefa)
    {
        InitializeComponent();

        TarefaAtual = tarefa;

        // Preenche as labels com as informações da tarefa
        TituloEntry.Text = TarefaAtual.Titulo;
        DescricaoEditor.Text = TarefaAtual.Descricao;
        List<Prioridade> prioridade = new List<Prioridade>{ Prioridade.Baixa, Prioridade.Media, Prioridade.Alta };
        PrioridadePicker.ItemsSource = prioridade;
        PrioridadePicker.SelectedItem = TarefaAtual.Prioridade;

    }

    async void OnSalvarClicked(object sender, EventArgs e)
    {
        TarefaAtual.Titulo = TituloEntry.Text;
        TarefaAtual.Descricao = DescricaoEditor.Text;
        TarefaAtual.Prioridade = (Prioridade)PrioridadePicker.SelectedItem;  // Adicionado para salvar a prioridade
        MessagingCenter.Send(this, "AtualizarTarefa", TarefaAtual);
        await Navigation.PopAsync(); // Retorna à página anterior
    }

    async void OnExcluirClicked(object sender, EventArgs e)
    {
        bool isConfirmed = await DisplayAlert("Excluir Tarefa", "Tem certeza que deseja excluir esta tarefa?", "Sim", "Não");

        if (isConfirmed)
        {
            MessagingCenter.Send(this, "ExcluirTarefa", TarefaAtual);
            await Navigation.PopAsync(); // Retorna à página anterior após exclusão
        }
    }
}
