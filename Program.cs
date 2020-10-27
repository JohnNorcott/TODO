using System;
using System.Collections.Generic;

namespace TODO
{
    class Program
    {
        private static TodoLogic _logic = new TodoLogic();

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            // var splitInput = input.Split('/');
            // foreach (var item in splitInput)
            // {
            //     Console.WriteLine("'" + item.Trim() + "'");
            // }
            while (!string.IsNullOrWhiteSpace(input))
            {
                var splitInput = input.Split('/');
                var commandInput = splitInput[0].Trim();
                switch(commandInput.ToLower())
                {
                    case "add":
                    {
                        AddNewTodo(splitInput);
                        break;
                    }
                    case "read":
                    {
                        var models = ReadToDos();
                        foreach (var item in models)
                        {
                            Console.WriteLine(item.Title);
                        }
                        break;
                    }
                    case "update":
                    {
                        Console.WriteLine(input);
                        break;
                    }
                    case "delete":
                    {
                        Console.WriteLine(input);
                        break;
                    }
                    case "exit":
                    {
                        Console.WriteLine(input);
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
            TodoModel newModel = new TodoModel();
            for (int i=1; i<values.Length; i++)
            {                
                var property = values[i].Split('=');
                switch(property[0].ToLower())
                {
                    case "key":
                    {
                        newModel.Key = int.Parse(property[1]);
                        break;
                    }
                    case "priority":
                    {
                        newModel.Priority = int.Parse(property[1]);
                        break;
                    }
                    case "title":
                    {
                        newModel.Title = property[1].Trim('"');
                        break;
                    }
                    case "details":
                    {
                        newModel.Details = property[1].Trim('"');
                        break;
                    }
                }
            }

            _logic.Add(newModel);
        }

        private static List<TodoModel> ReadToDos()
        {
            return _logic.Read();
        }
    }
}
