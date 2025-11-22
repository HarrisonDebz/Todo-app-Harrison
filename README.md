# To-Do List Application

A simple command-line To-Do List application built with C# that persists data using JSON files.

## Features

- Add new tasks
- View all tasks with completion status
- Mark tasks as completed
- Delete tasks with confirmation
- Automatic save/load functionality
- Error handling for invalid inputs

## How to Run

### Prerequisite

- .NET 6.0 or later
- Any code editor (VS Code, Visual Studio, etc.)

### Steps

1. Clone or download the project files
2. Ensure all files are in the same directory:
   - `Program.cs`
   - `TaskItem.cs`
   - `tasks.json` (will be created automatically if missing)
3. Open terminal/command prompt in the project directory
4. Run the application: ```bash
   dotnet run

## What I Learned

- **File Handling:** Using System.Text.Json for serialization/deserialization.

- **Data Persistence:** Saving application state between sessions.

- **Error Management:** Handling invalid user inputs and file operations.

- **Object-Oriented Design:** Creating clean, maintainable class structures.

- **LINQ Operations:** Using LINQ for data querying and manipulation.

## Challenges I Faced

- Handling JSON serialization with proper error recovery.

- Managing task IDs and ensuring uniqueness.

- Creating a user-friendly CLI interface with proper input validation.

- Implementing proper error handling for file operations.

## Future Improvements

- Add due dates and reminders.

- Add search and filter functionality.

- Create a GUI version.

- Add export to CSV/PDF feature.
