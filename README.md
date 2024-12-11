
# .NET 8.0 API with PostgreSQL

## Project Description

This is a Book Management System built with .NET 8.0 Web API. The system manages books and their relationships with publishers and authors.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- IDE (Visual Studio 2022, VS Code, Jetbrains Rider, or similar)

## Getting Started

1. Clone the repository

    `git clone <repository-url>` </br>
    `cd <project-directory>`


2. Update Database Connection
   1. [x] Open `appsettings.json`
   2. [x] Modify the connection string to match your PostgreSQL settings:

           "ConnectionStrings": {
               "DefaultConnection": "Host=localhost;Database=yourdbname;Username=yourusername;Password=yourpassword"
           }


3. Apply Database Migrations

    `dotnet ef database update`


4. Run the Application

    `dotnet run`

The API will start running at _https://localhost:7187_ and _http://localhost:5070_ or </br>
you can access the Swagger UI at _https://localhost:7187/swagger/index.html_ and _http://localhost:5070/swagger/index.html_

## Login Information
   1. [x] Username: admin
   2. [x] Password: Admin123/ </br> 
   Or
   3. [x] Username: admin2
   4. [x] Password: Admin123/

## Deployment Information

1. [x] If you want to use this project directly, you can visit this link (Include with API Documentation): https://book-management-api.fadhlih.com/swagger/index.html
2.[x] The project without API Documentation: https://book-management-api.fadhlih.com/




