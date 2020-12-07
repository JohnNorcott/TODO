using System.Collections.Generic;
using System.Linq;

namespace TODO
{
    public class TodoLogic
    {
        private Dictionary<string, TodoModel> _cache = new Dictionary<string, TodoModel>();
        private readonly TodoData _data = new TodoData();

        public TodoLogic()
        {
            var existingTodos = _data.GetTodos();
            foreach (var todo in existingTodos)
            {
                _cache.Add(todo.Title, todo);
            }
        }
        
        public void Add(TodoModel newTodo)
        {
            _cache.Add(newTodo.Title, newTodo);
            _data.saveTodos(_cache.Select(t => t.Value));
        }

        public void Update(TodoModel updatedTodo)
        {
            var existingToDo = _cache[updatedTodo.Title];
            existingToDo.Priority = updatedTodo.Priority;
            existingToDo.Details = updatedTodo.Details;
            _data.saveTodos(_cache.Select(t => t.Value));
        }

        public List<TodoModel> Read()
        {
            return _data.GetTodos().ToList();
        }

        public void Delete(TodoModel noLongerNeededTodo)
        {
            _cache.Remove(noLongerNeededTodo.Title);
            _data.saveTodos(_cache.Select(t => t.Value));
        }
    }
}