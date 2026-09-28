# School project (Backend)

This web app gives users an overview of their subscriptions. This is the backend. The frontend is in a separate repository: [SubscriptionOverviewFrontend](https://github.com/Vic-Linden/SubscriptionOverviewFrontend).

## About the project

This was an individual assignment in my **fullstack .NET education**. The goal was to build and deploy a complete web application, with a backend API, a database and a frontend.

**What the assignment required:**

- A **REST API** with full CRUD, built with **ASP.NET Core** and **Entity Framework Core**.
- Authentication and authorization with **JWT** and roles.
- Validation and central error handling.
- A database index created through a migration.
- CORS configured for the frontend.
- Deployment to **Azure**, with secrets kept out of the code.
  
## Tech stack

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server (Docker locally, Azure SQL in production)
- ASP.NET Core Identity
- JWT authentication
- Scalar for API documentation
- Hosted on Azure

## Features

- Register and log in, returning a JWT
- CRUD for categories, subscriptions and payments
- Each user only sees their own subscriptions and payments
- Role-based authorization, with an Admin endpoint for listing all users
- Input validation with data annotations
- Central exception handling middleware
- Database index on the subscription's user id

## Run locally

1. Clone the repo
2. Start SQL Server in Docker:
   `docker start sqlserver`
3. Set your secrets with User Secrets (never commit these):
   - `ConnectionStrings:DefaultConnection`
   - `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience`
   - `AdminSeed:Email`
4. Apply the migrations:
   `dotnet ef database update`
5. Run the API:
   `dotnet run`
