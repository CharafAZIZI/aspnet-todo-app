using System.ComponentModel.DataAnnotations;
using ToDo.Enums;
using ToDo.ViewModels;

namespace ToDo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State Statut { get; set; }

    }
}
