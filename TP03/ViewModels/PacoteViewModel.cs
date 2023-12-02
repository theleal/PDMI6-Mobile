using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP03Mobile.ViewModels
{

    //Luiz Gustavo e Rodrigo Rebelo

    public class PacoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Pacote> _listaPacotes;
        private Pacote _pacote;

        public List<Pacote> Pacotes
        {
            get { return _listaPacotes; }
            set
            {
                _listaPacotes = value;
                OnPropertyChanged();
            }
        }

        public Pacote Pacote
        {
            get { return _pacote; }
            set
            {
                _pacote = value;
                OnPropertyChanged();
            }
        }

        public PacoteViewModel()
        {
            _listaPacotes = new List<Pacote>
            {
                new Pacote
                {
                    PacoteId = "CDE1234567",
                    Status = "Em trânsito",
                    DataEnvio = DateTime.Now.AddDays(-10),
                    DataPrevistaEntrega = DateTime.Now.AddDays(3),
                    HistoricoEventos = new List<string>
                    {
                        "Pacote recebido no centro de distribuição.",
                        "Pacote em trânsito para o destino.",
                        "Pacote pronto para entrega."
                    }
                },
                new Pacote
                {
                    PacoteId = "ABC123456",
                    Status = "Enviado ao centro de distribuição",
                    DataEnvio = DateTime.Now.AddDays(-32),
                    DataPrevistaEntrega = DateTime.Now.AddDays(5),
                    HistoricoEventos = new List<string>
                    {
                        "Pacote recebido no centro de distribuição.",
                    }
                },
            };
        }

        public async Task BuscarPacoteAsync(string codigoRastreamento)
        {
            var pacoteEncontrado = _listaPacotes.FirstOrDefault(p => p.PacoteId == codigoRastreamento);

            if (pacoteEncontrado != null)
            {
                Pacote = pacoteEncontrado;
            }
            else
            {
                Pacote = null;
                await Application.Current.MainPage.DisplayAlert("Pacote não encontrado", "Tente novamente.", "Ok");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
