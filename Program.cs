using System;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace TODO
{    
    class Program
    {
        private static TodoLogic _logic = new TodoLogic();

        [Argument(0)]
        [Required]
        public string Command {get; set;}

        [Option]
        [Required]
        public string Title {get; set;}

        [Option]
        public string Details {get; set;}

        [Option]
        public int? Priority {get; set;}

        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private void OnExecute()
        {
            switch(Command.ToLower())
            {
                case "create":
                {
                    AddNewTodo();
                    ReadToDos();
                    break;
                }
                case "add":
                {
                    AddNewTodo();
                    ReadToDos();
                    break;
                }
                case "read":
                {
                    ReadToDos();
                    break;
                }
                case "update":
                {
                    UpdateTodo();
                    ReadToDos();
                    break;
                }
                case "delete":
                {
                    DeleteTodo();
                    ReadToDos();
                    break;
                }
                default:
                {
                    Console.WriteLine("Options are \"Create\", \"Read\", \"Update\", or \"Delete\"");
                    break;
                }
            }
        }        

        private void AddNewTodo()
        {
            TodoModel newModel = CreateTodo();
            _logic.Add(newModel);
        }

        private void ReadToDos()
        {
            var models = _logic.Read();
            
            foreach (var item in models)
            {
                Console.WriteLine(item.Title + ": " + item.Details + ", Priority " + item.Priority.ToString());
            }
        }

        private void UpdateTodo()
        {
            TodoModel updatedModel = CreateTodo();
            _logic.Update(updatedModel);
        }

        private void DeleteTodo()
        {
            TodoModel modelToDelete = CreateTodo();
            _logic.Delete(modelToDelete);
        }

        private TodoModel CreateTodo()
        {
            TodoModel model = new TodoModel();
            model.Title = Title;
            model.Details = Details;
            model.Priority = Priority ?? 1;

            return model;
        }
    }
}
