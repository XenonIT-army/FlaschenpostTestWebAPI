 ASP.NET RESTful API server
 
Requirements
Visual Studio 2022
.NET 9

Server Structure
🔹 DAL - Contains models and repositories for an in-memory database.

🔹 WebAPI - ASP.NET Core project with controllers for HTTP CRUD operations.
Uses AutoMapper to map database models to project models.
All CRUD operations are implemented via abstractions (interfaces).
To change the connection string, edit the launchSettings.json file.

🔹 xUnit - Contains unit tests for the RESTful API functionality and database services.
