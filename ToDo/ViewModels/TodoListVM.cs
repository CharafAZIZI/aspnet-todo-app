using System.ComponentModel.DataAnnotations;
using ToDo.Enums;

namespace ToDo.ViewModels
{
    public class TodoListVM
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }

        public State Statut { get; set; }
    }

}
