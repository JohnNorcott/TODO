using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TODO
{
    public class TodoData
    {
        private readonly string _fileName = "todos.txt";
        private readonly string _filePath;
        private readonly string _fullPathToDataFile;

        public TodoData()
        {
            _filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData, System.Environment.SpecialFolderOption.Create);
            _fullPathToDataFile = Path.Combine(_filePath, _fileName);
            if (!File.Exists(_fullPathToDataFile))
            {
                File.Create(_fullPathToDataFile);
            }
        }

        public IEnumerable<TodoModel> GetTodos()
        {
            string storedTodos = File.ReadAllText(_fullPathToDataFile);
            if(string.IsNullOrWhiteSpace(storedTodos))
            {
                return Enumerable.Empty<TodoModel>();
            }
            
            var todos = JsonSerializer.Deserialize<IEnumerable<TodoModel>>(storedTodos);

            return todos;
        }

        public void saveTodos(IEnumerable<TodoModel> todos)
        {
            string serializedTodos = JsonSerializer.Serialize<IEnumerable<TodoModel>>(todos);
            File.WriteAllText(_fullPathToDataFile, serializedTodos);
        }

    }
}