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

## Screenshots
- Opening the app<br>
  <img width="1074" height="119" alt="Screenshot 2025-11-22 032955" src="https://github.com/user-attachments/assets/d679dc84-b7dc-4a36-99a3-e573f25a6823" /><br>
- App Menu<br>
  <img width="1053" height="404" alt="Screenshot 2025-11-22 033019" src="https://github.com/user-attachments/assets/0513800a-b499-4947-bb45-eca1c9160489" /><br>
### Actions<br>
- Adding Task<br>
 <img width="854" height="563" alt="Screenshot 2025-11-22 033355" src="https://github.com/user-attachments/assets/1fce2f90-8c7b-42b6-ba36-bdcd89dd4968" /><br>
- Viewing Tasks<br>
  <img width="896" height="470" alt="Screenshot 2025-11-22 033438" src="https://github.com/user-attachments/assets/79801000-92af-4730-9a1d-eef5739fe111" /><br>
- Marking Task as Completed<br>
  <img width="871" height="433" alt="Screenshot 2025-11-22 033520" src="https://github.com/user-attachments/assets/b4fd3327-4f3e-413f-9a9c-8ee60622d23b" /><br>
- Deleting Task<br>
  <img width="863" height="826" alt="Screenshot 2025-11-22 034001" src="https://github.com/user-attachments/assets/d9c78cb2-681e-4e48-99e7-3a84ace85a01" /><br>
- Saving Task<br>
 <img width="848" height="283" alt="Screenshot 2025-11-22 033832" src="https://github.com/user-attachments/assets/a565d904-f356-40ae-9cb3-b67dc08f5601" /><br>
- Loading Tasks<br>
 <img width="866" height="461" alt="Screenshot 2025-11-22 033711" src="https://github.com/user-attachments/assets/34723006-a666-4bb8-9ec4-f7be80806831" /><br>
- Exiting Task<br>
 <img width="901" height="406" alt="Screenshot 2025-11-22 034039" src="https://github.com/user-attachments/assets/66c40c58-67b1-48fe-9aa9-ec0d21d739a8" /><br>


  
  



 
