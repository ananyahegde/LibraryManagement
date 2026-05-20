# Library Management API — Setup Guide

## 1. Create the Project

```bash
dotnet new webapi --use-controllers -o LibraryManagement
```

## 2. Trust the Dev Certificate

```bash
dotnet dev-certs https --trust
```

## 3. Configure the Database

In `appsettings.json`, add your connection string:

```json
"ConnectionStrings": {
  "Default": "Host=localhost;Port=5432;Database=librarydb;Username=postgres;Password=password"
}
```

## 4. Create the Project Structure

```bash
mkdir Contexts Interfaces Models Repositories Services Exceptions
```

## 5. Install Dependencies

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.11
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.11
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.0.7

dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator --version 8.0.7
```

## 6. Wire Up the App

- Define your **Models** in `Models/`
- Create your **DbContext** in `Contexts/` with `DbSet<T>` properties for each model
- Register the context in `Program.cs`:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
```

## 7. Run Migrations

```bash
dotnet ef migrations add InitialMigration
dotnet ef database update
```

## 8. Run the API

```bash
dotnet run --launch-profile https
```
