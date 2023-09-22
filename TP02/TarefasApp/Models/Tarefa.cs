using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public Prioridade Prioridade { get; set; }
    }

    public enum Prioridade
    {
        Baixa = 1,
        Media = 2,
        Alta = 3
    }
}