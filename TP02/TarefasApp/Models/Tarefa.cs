using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp.Models
{
    public class Tarefa
    {
        public int Id { get; set; } // Se decidir usar o ID
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
