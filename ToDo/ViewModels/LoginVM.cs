using System.ComponentModel.DataAnnotations;

namespace ToDo.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "L'identifiant est obligatoire")]
        public string Identifiant { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        public string MotDePasse { get; set; }
    }
}
