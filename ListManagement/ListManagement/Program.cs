
using ListManagement.models;
using System2 = System;

namespace ListManagement // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            var todos = new List<ToDo>();
            Console.WriteLine("Welcome to the List Management App");

            var nextTodo = new ToDo();
            PrintMenu();

            int input = -1;
            if(int.TryParse(Console.ReadLine(),out input)) {
                while (input != 3) //==
                {
                    nextTodo = new ToDo();
                    if (input == 1)
                    {
                        //C - Create
                        //ask for property values
                        Console.WriteLine("Give me a Name");
                        nextTodo.Name = Console.ReadLine();


                        //todos.Add(nextTodo);

                        //nextTodo.Deadline = DateTime.TryParse(Console.ReadLine());
                    }
                    else if (input == 2)
                    {
                        //D - Delete/Remove
                        //Console.WriteLine("Which string should I delete?");
                        //var strIndex = int.Parse(Console.ReadLine());
                        //stringList.RemoveAt(strIndex - 1);
                    } 
                    else if (input == 3)
                    {
                        //U - Update/Edit
                    }
                    else if (input == 4)
                    {
                        //Complete Task
                    }
                    else if(input ==5)
                    {
                        //R - Read / List uncompleted tasks

                    } else if (input ==6)
                    {
                        //R - Read / List all tasks
                        foreach(var todo in todos)
                        {
                            Console.WriteLine(todo.ToString());
                        }
                    } else if (input == 7)
                    {

                    }
                    else
                    {
                        Console.WriteLine("I don't know what you mean");
                    }

                    PrintMenu();
                    input = int.Parse(Console.ReadLine());
                }
            }
           else
            {
                Console.WriteLine("User did not specify a valid int!");
            }
            

            foreach(var item in stringList)
            {
                Console.WriteLine(item);
            }
           
            Console.ReadLine();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Delete Item");
            Console.WriteLine("3. Exit");
        }

        public static void AddString(List<string> strList, string str)
        {
            strList.Add(str);
        }
    }
}