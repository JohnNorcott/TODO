using System;
using System.Collections.Generic;

namespace TODO
{    
    class Program
    {
        private static TodoLogic _logic = new TodoLogic();
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var splitInput = input.Split('/');
                var commandInput = splitInput[0].Trim();
                
                switch(commandInput.ToLower())
                {
                    case "create":
                    {
                        AddNewTodo(splitInput);
                        ReadToDos();
                        break;
                    }
                    case "add":
                    {
                        AddNewTodo(splitInput);
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
                        UpdateTodo(splitInput);
                        ReadToDos();
                        break;
                    }
                    case "delete":
                    {
                        DeleteTodo(splitInput);
                        ReadToDos();
                        break;
                    }
                    case "exit":
                    {
                        Console.WriteLine("Thank you for using the Todo app.");
                        return;
                    }
                    default:
                    {
                        Console.WriteLine("Options are \"Create\", \"Read\", \"Update\", \"Delete\", or \"Exit\"");
                        break;
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void AddNewTodo(string[] values)
        {
            TodoModel newModel = ParseValues(values);
            _logic.Add(newModel);
        }

        private static void ReadToDos()
        {
            var models = _logic.Read();
            
            foreach (var item in models)
            {
                Console.WriteLine(item.Title + ": " + item.Details + ", Priority " + item.Priority.ToString());
            }
        }

        private static void UpdateTodo(string[] values)
        {
            TodoModel updatedModel = ParseValues(values);
            _logic.Update(updatedModel);
        }

        private static void DeleteTodo(string[] values)
        {
            TodoModel modelToDelete = ParseValues(values);
            _logic.Delete(modelToDelete);
        }

        private static TodoModel ParseValues(string[] values)
        {
            TodoModel model = new TodoModel();
            for (int i=1; i<values.Length; i++)
            {                
                var property = values[i].Split('=');
                switch(property[0].ToLower())
                {
                    case "key":
                    {
                        model.Key = int.Parse(property[1]);
                        break;
                    }
                    case "priority":
                    {
                        model.Priority = int.Parse(property[1]);
                        break;
                    }
                    case "title":
                    {
                        model.Title = property[1].Trim().Trim('"');
                        break;
                    }
                    case "details":
                    {
                        model.Details = property[1].Trim().Trim('"');
                        break;
                    }
                }
            }

            return model;
        }
    }
}
