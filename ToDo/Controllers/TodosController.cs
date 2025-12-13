using Microsoft.AspNetCore.Mvc;
using ToDo.Mappers;
using ToDo.Models;
using ToDo.Services;
using ToDo.ViewModels;
using ToDo.Filters;

namespace ToDo.Controllers
{
    [AuthFilter]
    public class TodosController : Controller
    {
        private readonly ISessionManagerService session;

        public TodosController(ISessionManagerService session)
        {
            this.session = session;
        }


        public IActionResult Index()
        {
            List<Todo> list = session.Get<List<Todo>>("todos", HttpContext);
            List<TodoListVM> vm = list.Select(TodoMapper.GetTodoListVM).ToList();
            ViewBag.count = vm.Count;
            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TodoAddVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            List<Todo> list = session.Get<List<Todo>>("todos", HttpContext);

            Todo todo = TodoMapper.GetToFodoFromTodoAddVM(vm);

            // Auto-incrémentation de l'ID
            todo.Id = list.Count == 0 ? 1 : list.Max(t => t.Id) + 1;

            list.Add(todo);
            session.Add("todos", list, HttpContext);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            List<Todo> list = session.Get<List<Todo>>("todos", HttpContext);
            Todo todo = list.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            TodoEditVM vm = TodoMapper.ToEditVm(todo);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(TodoEditVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            List<Todo> list = session.Get<List<Todo>>("todos", HttpContext);
            Todo todo = list.FirstOrDefault(t => t.Id == vm.Id);
            if (todo == null) return NotFound();


            TodoMapper.UpdateTodoFromVm(todo, vm);
            session.Add("todos", list, HttpContext);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            List<Todo> list = session.Get<List<Todo>>("todos", HttpContext);
            Todo todo = list.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            list.Remove(todo);
            session.Add("todos", list, HttpContext);

            return RedirectToAction(nameof(Index));
        }
    }
}
