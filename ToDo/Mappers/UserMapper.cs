using ToDo.Models;
using ToDo.ViewModels;

namespace ToDo.Mappers
{
    public class UserMapper
    {
        public static User FromRegisterVM(RegisterVM vm)
        {
            return new User
            {
                Identifiant = vm.Identifiant,
                MotDePasse = vm.MotDePasse
            };
        }
    }
}
