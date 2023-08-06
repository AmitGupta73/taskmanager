using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
}

class TaskManager
{
    private List<Task> tasks;
    private string filename = "tasks.json";

    public TaskManager()
    {
        tasks = LoadTasks();
    }

    private List<Task> LoadTasks()
    {
        try
        {
            if (File.Exists(filename))
            {
                string jsonData = File.ReadAllText(filename);
                return JsonConvert.DeserializeObject<List<Task>>(jsonData);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading tasks: " + ex.Message);
        }
        return new List<Task>();
    }

    private void SaveTasks()
    {
        try
        {
            string jsonData = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filename, jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving tasks: " + ex.Message);
        }
    }

    public void AddTask()
    {
        Console.Write("Enter task name: ");
        string name = Console.ReadLine();

        Console.Write("Enter task description: ");
        string description = Console.ReadLine();

        Console.Write("Enter task due date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            tasks.Add(new Task { Name = name, Description = description, DueDate = dueDate, Status = "To Do" });
            SaveTasks();
            Console.WriteLine("Task added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid date format. Task not added.");
        }
    }

    public void ViewTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            Task task = tasks[i];
            Console.WriteLine($"{i + 1}. Name: {task.Name}");
            Console.WriteLine($"   Description: {task.Description}");
            Console.WriteLine($"   Due Date: {task.DueDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"   Status: {task.Status}");
            Console.WriteLine();
        }
    }

    public void MarkTaskAsDone()
    {
        Console.Write("Enter the task number to mark as done: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].Status = "Done";
            SaveTasks();
            Console.WriteLine("Task marled as cpmpleted !");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    public void RemoveTask()
    {
        Console.Write("Enter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            SaveTasks();
            Console.WriteLine("Task delete successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n-----------Task Manager------------");
            Console.WriteLine("1. Add a Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Save and Exit");

            Console.Write("Enter your choice: ");
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
                    MarkTaskAsDone();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    SaveTasks();
                    Console.WriteLine("Tasks saved. Exiting.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}


