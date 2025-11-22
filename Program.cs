using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

class TodoApp
{
    private List<TaskItem> tasks;
    private readonly string dataFile = "tasks.json";
    private int nextId;
    private bool isRunning; // Added missing field

    public TodoApp()
    {
        tasks = new List<TaskItem>();
        nextId = 1;
        isRunning = true; // Initialize the field
        LoadTasks();
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("=====================");
        Console.WriteLine("      TO-DO LIST");
        Console.WriteLine("=====================");

        while (isRunning) // Changed to use isRunning
        {
            ShowMenu();
            string choice = GetUserInput("Choose an option (1-7): ");

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    MarkTaskCompleted();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    SaveTasks();
                    Console.WriteLine("Goodbye! Your Tasks Have Been Saved");
                    return;
                case "6":
                    LoadTasks();
                    break;
                case "7":
                    Exit();
                    break; // Removed the invalid option message from here
                default: // Added default case for invalid options
                    Console.WriteLine("Invalid Option! Please Choose a Number 1 - 7.");
                    WaitForUser();
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\n" + new string('=', 30));
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Mark Task as Completed");
        Console.WriteLine("4. Delete Task");
        Console.WriteLine("5. Save Tasks");
        Console.WriteLine("6. Load Tasks");
        Console.WriteLine("7. Exit");
        Console.WriteLine(new string('=', 30));
    }

    //Add task function
    private void AddTask()
    {
        Console.WriteLine("\n--- Add New Task ---");
        string taskDescription = GetUserInput("Enter task description: ");

        if (string.IsNullOrWhiteSpace(taskDescription))
        {
            Console.WriteLine("Task description cannot be empty.");
            WaitForUser();
            return;
        }

        TaskItem newTask = new TaskItem(nextId++, taskDescription);
        tasks.Add(newTask);
        SaveTasks();

        Console.WriteLine($"Task '{taskDescription}' added successfully!");
        WaitForUser();
    }

    //View tasks function
    private void ViewTasks()
    {
        Console.WriteLine("\n--- Your Tasks ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available. Add a new task to get started!");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task.ToString());
            }

            int completedCount = tasks.Count(t => t.Completed);
            Console.WriteLine($"\nTotal Tasks: {tasks.Count}, Completed: {completedCount}");
        }

        WaitForUser();
    }

    //Mark task as completed function - FIXED
    private void MarkTaskCompleted()
    {
        Console.WriteLine("\n--- Mark Task as Completed ---");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to mark as completed.");
            WaitForUser();
            return;
        }

        if (int.TryParse(GetUserInput("Enter task ID to mark as completed: "), out int taskId))
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null) // Fixed: changed from "if (task == null)" to "if (task != null)"
            {
                if (!task.Completed)
                {
                    task.Completed = true;
                    SaveTasks();
                    Console.WriteLine($"Task '{task.Task}' marked as completed!");
                }
                else
                {
                    Console.WriteLine($"Task ID {taskId} is already completed.");
                }
            }
            else
            {
                Console.WriteLine($"Task ID {taskId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid task ID. Please enter a valid number.");
        }
        WaitForUser(); // Added missing WaitForUser
    }

    //Delete task function
    private void DeleteTask()
    {
        Console.WriteLine("\n--- Delete Task ---");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to delete.");
            WaitForUser();
            return;
        }

        ViewTasks();

        if (int.TryParse(GetUserInput("\nEnter Task ID to Delete: "), out int taskId))
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);

            if (task != null)
            {
                Console.WriteLine($"Are you sure you want to delete the task: '{task.Task}'?");
                string confirm = GetUserInput("Type 'yes' to confirm: ");

                if (confirm.ToLower() == "yes")
                {
                    tasks.Remove(task);
                    SaveTasks();
                    Console.WriteLine($"Task ID {taskId} deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Task deletion cancelled.");
                }
            }
            else
            {
                Console.WriteLine($"Task ID {taskId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid task ID. Please enter a valid number.");
        }

        WaitForUser();
    }

    //Save tasks function
    private void SaveTasks()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(dataFile, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks: {ex.Message}");
        }
    }

    //Load tasks function - FIXED
    private void LoadTasks()
    {
        try
        {
            if (File.Exists(dataFile)) // Fixed: changed from dataFile.Exists(dataFile) to File.Exists(dataFile)
            {
                string json = File.ReadAllText(dataFile); // Fixed: changed from dataFile.ReadAllText(dataFile) to File.ReadAllText(dataFile)
                var loadedTasks = JsonSerializer.Deserialize<List<TaskItem>>(json);
                if (loadedTasks != null && loadedTasks.Count > 0)
                {
                    tasks = loadedTasks;
                    nextId = tasks.Max(t => t.Id) + 1;
                    Console.WriteLine($"Loaded {tasks.Count} tasks from file.");
                }
            }
            else
            {
                Console.WriteLine("No Existing task file found. Starting with empty list.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks: {ex.Message}");
            Console.WriteLine("Starting with empty list");
            tasks = new List<TaskItem>();
        }
        WaitForUser(); // Added missing WaitForUser
    }

    //Exit function
    private void Exit()
    {
        Console.WriteLine("\nSaving tasks...");
        SaveTasks();
        Console.WriteLine("Tasks saved. Thank you for using the To-Do List CLI App. Goodbye!");
        isRunning = false;
    }

    // ADD MISSING HELPER METHODS
    private string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim() ?? "";
    }

    private void WaitForUser()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}

//Main Program Entry - MOVED OUTSIDE TodoApp class
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "To-Do List CLI App";
        TodoApp app = new TodoApp();
        app.Run();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}