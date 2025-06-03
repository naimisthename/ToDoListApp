using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoListApp
{
    class Program
    {
        static List<string> tasks = new List<string>();
        const string fileName = "tasks.txt";

        static void Main(string[] args)
        {
            LoadTasks();

            while (true)
            {
                Console.WriteLine("\n=== To-Do List App ===");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Save and Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        SaveTasks();
                        Console.WriteLine("Tasks saved. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ViewTasks()
        {
            Console.WriteLine("\n--- Tasks ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to show.");
                return;
            }
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        static void AddTask()
        {
            Console.Write("Enter a new task: ");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }
        }

        static void RemoveTask()
        {
            ViewTasks();
            if (tasks.Count == 0) return;

            Console.Write("Enter the number of the task to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) &&
                index >= 1 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task removed!");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }

        static void SaveTasks()
        {
            File.WriteAllLines(fileName, tasks);
        }

        static void LoadTasks()
        {
            if (File.Exists(fileName))
            {
                tasks = new List<string>(File.ReadAllLines(fileName));
            }
        }
    }
}
