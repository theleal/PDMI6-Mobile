using System.Collections.ObjectModel;
using TarefasApp.Models;
using TarefasApp.page;
using System.Linq;

//Luiz Gustavo Leal Cortez - CB3015386 
//Rodrigo Rebelo - CB3016871


namespace TarefasApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Tarefa> Tarefas { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Populando a lista de tarefas como exemplo
            Tarefas = new ObservableCollection<Tarefa>
            {
                new Tarefa { Id = 1, Titulo = "Tarefa 1", Descricao = "Descrição da tarefa 1" },
                new Tarefa { Id = 2, Titulo = "Tarefa 2", Descricao = "Descrição da tarefa 2" }
            };

            // Vinculando a lista à CollectionView
            TarefasListView.ItemsSource = Tarefas;

            TarefasListView.ItemsSource = null;

            TarefasListView.ItemsSource = Tarefas;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            MessagingCenter.Subscribe<EditarTarefaPage, Tarefa>(this, "ExcluirTarefa", (sender, tarefaExcluida) =>
            {
                Tarefas.Remove(tarefaExcluida);
            });


            MessagingCenter.Subscribe<EditarTarefaPage, Tarefa>(this, "AtualizarTarefa", (sender, tarefaAtualizada) =>
            {
                var tarefaNaLista = Tarefas.FirstOrDefault(t => t.Id == tarefaAtualizada.Id);
                if (tarefaNaLista != null)
                {
                    tarefaNaLista.Titulo = tarefaAtualizada.Titulo;
                    tarefaNaLista.Descricao = tarefaAtualizada.Descricao;
                }
            });

            TarefasListView.ItemsSource = null;

            TarefasListView.ItemsSource = Tarefas;
        }

        async void OnAddTarefaClicked(object sender, EventArgs e)
        {
            string titulo = await DisplayPromptAsync("Nova Tarefa", "Informe o título da tarefa:");

            if (string.IsNullOrEmpty(titulo))
            {
                await DisplayAlert("Erro", "O título é obrigatório!", "OK");
                return;
            }

            string descricao = await DisplayPromptAsync("Nova Tarefa", "Informe a descrição da tarefa:");

            var novaTarefa = new Tarefa
            {
                Id = Tarefas.Count + 1,  // Uma forma simples de gerar um ID. Em um cenário real, você pode querer algo mais robusto.
                Titulo = titulo,
                Descricao = descricao
            };

            Tarefas.Add(novaTarefa);
        }

        async void OnTarefaSelected(object sender, SelectionChangedEventArgs e)
        {
            var tarefaSelecionada = (Tarefa)e.CurrentSelection.FirstOrDefault();
            if (tarefaSelecionada != null)
            {
                await Navigation.PushAsync(new EditarTarefaPage(tarefaSelecionada));
            }
            TarefasListView.SelectedItem = null; // Deseleciona o item após navegar
        }
    }
}
