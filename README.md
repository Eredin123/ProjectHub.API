# ProjectHub.API

A RESTful Task Management API built with ASP.NET Core 8, demonstrating clean architecture, Entity Framework Core, and best practices in .NET backend development.

## Tech Stack

- **ASP.NET Core 8** – Web API framework
- **Entity Framework Core** – ORM for database access
- **SQLite** – Lightweight relational database
- **Swagger / OpenAPI** – API documentation and testing

## Architecture

The solution follows a 3-layer architecture:

```
ProjectHub.API            → Controllers, Middleware, Program.cs
ProjectHub.Core           → Entities, Interfaces, DTOs
ProjectHub.Infrastructure → DbContext, Repositories
```

Dependencies flow inward: `API → Core ← Infrastructure`

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

### Run Locally

```bash
# Clone the repository
git clone https://github.com/YOUR_USERNAME/ProjectHub.API.git
cd ProjectHub.API

# Apply database migrations
dotnet ef database update --project ProjectHub.Infrastructure --startup-project ProjectHub.API

# Run the API
dotnet run --project ProjectHub.API
```

Swagger UI is available at: `https://localhost:{PORT}/swagger`

## API Endpoints

### Projects

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/projects` | Get all projects |
| GET | `/api/projects/{id}` | Get project by ID |
| POST | `/api/projects` | Create a new project |
| PUT | `/api/projects/{id}` | Update a project |
| DELETE | `/api/projects/{id}` | Delete a project |

### Tasks

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/projects/{projectId}/tasks` | Get all tasks for a project |
| GET | `/api/projects/{projectId}/tasks/{taskId}` | Get task by ID |
| POST | `/api/projects/{projectId}/tasks` | Create a new task |
| PUT | `/api/projects/{projectId}/tasks/{taskId}` | Update a task |
| DELETE | `/api/projects/{projectId}/tasks/{taskId}` | Delete a task |

## Example Requests

### Create a Project

```json
POST /api/projects
{
  "name": "My Project",
  "description": "Project description"
}
```

### Create a Task

```json
POST /api/projects/1/tasks
{
  "title": "Implement login",
  "description": "Add JWT authentication",
  "isCompleted": false
}
```

## License

This project is open source and available under the [MIT License](LICENSE).