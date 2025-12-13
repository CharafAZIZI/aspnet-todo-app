using System.ComponentModel.DataAnnotations;
using ToDo.Enums;

namespace ToDo.ViewModels
{
    public class TodoAddVM
    {
        [Required(ErrorMessage= "Le libelle est obligatoire")]
        public string Libelle { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La date limite est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }

        [Required(ErrorMessage = "La statut est obligatoire")]
        public State Statut { get; set; }
    }
}
