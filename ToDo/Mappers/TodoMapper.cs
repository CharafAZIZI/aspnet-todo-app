using ToDo.Models;
using ToDo.ViewModels;

namespace ToDo.Mappers
{
    public class TodoMapper
    {
        public static Todo GetToFodoFromTodoAddVM(TodoAddVM vm)
        {
            return new Todo
            {
                Libelle = vm.Libelle,
                Description = vm.Description,
                DateLimite = vm.DateLimite,
                Statut = vm.Statut
            };
        }

        public static TodoListVM GetTodoListVM(Todo vm)
        {
            return new TodoListVM 
            {
                Id = vm.Id,
                Libelle = vm.Libelle,
                Description = vm.Description,
                DateLimite = vm.DateLimite,
                Statut = vm.Statut
            };
        }

        public static TodoEditVM ToEditVm(Todo todo)
        {
            return new TodoEditVM
            {
                Id = todo.Id,
                Libelle = todo.Libelle,
                Description = todo.Description,
                DateLimite = todo.DateLimite,
                Statut = todo.Statut
            };
        }

        public static void UpdateTodoFromVm(Todo todo, TodoEditVM vm)
        {
            todo.Libelle = vm.Libelle;
            todo.Description = vm.Description;
            todo.DateLimite = vm.DateLimite;
            todo.Statut = vm.Statut;
        }


    }
}
