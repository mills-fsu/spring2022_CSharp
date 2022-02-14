using Library.ListManagement.helpers;
using ListManagement.models;
using ListManagement.services;
using Newtonsoft.Json;
using System2 = System;

namespace ListManagement // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            var persistencePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\SaveData.json";
            var itemService = ItemService.Current;
            //var listNavigator = new ListNavigator<Item>(itemService.Items, 2);
            Console.WriteLine("Welcome to the List Management App");

            PrintMenu();

            int input;
            if(int.TryParse(Console.ReadLine(),out input)) {
                while (input != 7) //==
                {
                    ToDo nextTodo = new ToDo();
                    if (input == 1)
                    {
                        //C - Create
                        //ask for property values
                        FillProperties(nextTodo);

                        itemService.Add(nextTodo);

                    }
                    else if (input == 2)
                    {
                        //D - Delete/Remove
                        Console.WriteLine("Which item should I delete?");

                        if(int.TryParse(Console.ReadLine(), out int selection))
                        {
                            var selectedItem = itemService.Items.FirstOrDefault(i => i.Id == selection);
                            if(selectedItem != null)
                            {
                                itemService.Remove(selectedItem);
                            }

                        } else
                        {
                            Console.WriteLine("Sorry, I can't find that item!");
                        }
                    } 
                    else if (input == 3)
                    {
                        //U - Update/Edit
                        Console.WriteLine("Which item should I edit?");
                        if (int.TryParse(Console.ReadLine(), out int selection))
                        {
                            var selectedItem = itemService.Items[selection - 1] as ToDo;

                            if(selectedItem != null)
                            {
                                FillProperties(selectedItem);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, I can't find that item!");
                        }
                    }
                    else if (input == 4)
                    {
                        //Complete Task
                        Console.WriteLine("Which item should I complete?");
                        if (int.TryParse(Console.ReadLine(), out int selection))
                        {
                            var selectedItem = itemService.Items[selection-1] as ToDo;
                            
                            if(selectedItem != null)
                            {
                                selectedItem.IsCompleted = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, I can't find that item!");
                        }
                    }
                    else if(input ==5)
                    {
                        //R - Read / List uncompleted tasks

                        //use LINQ
                        itemService.ShowComplete = false;
                        var userSelection = string.Empty;
                        while (userSelection != "E")
                        {
                            foreach (var item in itemService.GetPage())
                            {
                                Console.WriteLine(item);
                            }
                            userSelection = Console.ReadLine();

                            if (userSelection == "N")
                            {
                                itemService.NextPage();
                            }
                            else if (userSelection == "P")
                            {
                                itemService.PreviousPage();
                            }
                        }

                    } else if (input ==6)
                    {
                        //R - Read / List all tasks
                        //itemService.Items.ForEach(Console.WriteLine);
                        itemService.ShowComplete = true;
                        var userSelection = string.Empty;
                        while(userSelection != "E")
                        {
                            foreach (var item in itemService.GetPage())
                            {
                                Console.WriteLine(item);
                            }
                            userSelection = Console.ReadLine();

                            if (userSelection == "N")
                            {
                                itemService.NextPage();
                            }
                            else if (userSelection == "P")
                            {
                                itemService.PreviousPage();
                            }
                        }
                        

                    } else if (input ==7)
                    {
                        itemService.Save();
                    } else if (input == 8)
                    {

                    }
                    else
                    {
                        Console.WriteLine("I don't know what you mean");
                    }

                    PrintMenu();
                    if(!int.TryParse(Console.ReadLine(), out input))
                    {
                        Console.WriteLine("Sorry, I don't understand.");
                    }
                }
            }
           else
            {
                Console.WriteLine("User did not specify a valid int!");
            }
           
            Console.ReadLine();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Delete Item");
            Console.WriteLine("3. Edit Item");
            Console.WriteLine("4. Complete Item");
            Console.WriteLine("5. List Outstanding");
            Console.WriteLine("6. List All");
            Console.WriteLine("7. Save");
            Console.WriteLine("8. Exit");
        }

        public static void FillProperties(ToDo todo)
        {
            Console.WriteLine("Give me a Name");
            todo.Name = Console.ReadLine();
            Console.WriteLine("Give me a Description");
            todo.Description = Console.ReadLine()?.Trim();
        }

        public static void AddString(List<string> strList, string str)
        {
            strList.Add(str);
        }
    }
}