# Task Tracker CLI Application

**https://roadmap.sh/projects/task-tracker**

A simple Command Line Interface (CLI) application to manage tasks, add/update/delete tasks, and track their statuses (e.g., `todo`, `in-progress`, `done`). This application is built using C# and .NET 9.0, and it saves task data to a JSON file.

## Features

- **Add a task**: Add new tasks to your list.
- **Update a task**: Update the task description.
- **Delete a task**: Remove a task from the list.
- **Mark task as in-progress**: Update the status of a task to `in-progress`.
- **Mark task as done**: Mark a task as `done`.
- **List tasks**: View all tasks, or filter by their status (`todo`, `in-progress`, or `done`).

## Requirements

- .NET 9.0 SDK or later
- A terminal or command prompt
- Visual Studio or any C# IDE (optional)

## Setting Up

### 1. Clone the Repository

First, clone this repository to your local machine:

```bash
git clone https://github.com/yourusername/task-tracker-cli.git
cd task-tracker-cli
```
2. Restore Dependencies
Make sure you have .NET 9.0 installed on your machine. Run the following command to restore the project dependencies:

```bash
dotnet restore
```
3. Build the Application
Build the application to compile the code:
```bash
dotnet build
```
4. Run the Application
You can run the application using the following command:
```bash
dotnet run
```
This will start the application, and you can interact with the CLI.

Usage
Adding a Task
To add a new task, use the add command:

```bash
task-cli add "Buy groceries"
```
This will add a task with the description "Buy groceries" and generate an ID for it.

Updating a Task
To update the description of a task:

```bash
task-cli update <task-id> "New Task Description"
```
Replace <task-id> with the ID of the task you want to update.

Deleting a Task
To delete a task, use the delete command:

```bash
task-cli delete <task-id>
```
Replace <task-id> with the ID of the task you want to delete.

Marking a Task as In Progress
To mark a task as in-progress:

```bash
task-cli mark-in-progress <task-id>
```
Marking a Task as Done
To mark a task as done:

```bash
task-cli mark-done <task-id>
```
Listing All Tasks
To list all tasks:

```bash
task-cli list
```
Listing Tasks by Status
You can also filter tasks by their status:

List tasks that are done:

```bash
task-cli list done
```
List tasks that are todo:

```bash
task-cli list todo
```
List tasks that are in-progress:

```bash
task-cli list in-progress
```
Configuration
You can configure the file path for storing tasks (by default, it's "Tasks.json") in the TaskManager constructor. To change this, modify the filePath parameter in the constructor or extend it to load from a configuration file such as appsettings.json.

Task Model
The application uses the following properties for each task:

- Id: Unique identifier for the task.

- Description: Short description of the task.

- Status: Current status of the task (todo, in-progress, or done).

- CreatedAt: Timestamp when the task was created.

- UpdatedAt: Timestamp when the task was last updated.

Testing
-To test the application, you can:

- Add tasks using the add command.

- List all tasks or tasks with specific statuses using the list command.

- Update, delete, or mark tasks as done or in-progress.

- Verify that the tasks are saved correctly in the Tasks.json file.

Contributing
If you'd like to contribute to this project, feel free to fork the repository, make your changes, and create a pull request. Ensure that your code adheres to the project's coding style and passes any tests (if applicable).
