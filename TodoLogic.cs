using System.Collections.Generic;

namespace TODO
{
    public class TodoLogic
    {
        private Dictionary<int, TodoModel> _cache = new Dictionary<int, TodoModel>();
        
        public void Add(TodoModel newTodo)
        {
            _cache.Add(newTodo.Key, newTodo);
        }

        public void Update(TodoModel updatedTodo)
        {

        }

        public List<TodoModel> Read()
        {
            var allToDos = new List<TodoModel>();
            var keys = _cache.Keys;
            foreach (var key in keys)
            {
                allToDos.Add(_cache[key]);
            }
            
            return allToDos;
        }

        public void Delete(TodoModel noLongerNeededTodo)
        {
            
        }
    }
}