using System;
using System.IO;

class ToDoListApp
{
    static string filePath = "tasks.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nTo-Do List Application");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter your task: ");
        string task = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(task);
            }
            Console.WriteLine("Task added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }

    static void ViewTasks()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] tasks = File.ReadAllLines(filePath);
                if (tasks.Length == 0)
                {
                    Console.WriteLine("No tasks found.");
                }
                else
                {
                    Console.WriteLine("\nYour To-Do List:");
                    foreach (string task in tasks)
                    {
                        Console.WriteLine("- " + task);
                    }
                }
            }
            else
            {
                Console.WriteLine("No tasks found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}

