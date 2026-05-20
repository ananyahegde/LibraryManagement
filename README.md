```
dotnet new webapi --use-controllers -o LibraryManagement
```

```
dotnet dev-certs https --trust
```

```
dotnet run --launch-profile https
```

In appsettins.json
```
"ConnectionStrings": {
    "Default": "Host=localhost;Port=5432;Database=bankingapidb;Username=postgres;Password=password"
},
```

```
mkdir Contexts Interfaces Models Repositories Services Exceptions
```


```
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.11
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.11
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.0.7
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator --version 8.0.7
```

Get Contexts, Models set up. Wire the ConnectionString in Program.cs. Then do migrations.

```
dotnet ef migrations add InitialMigration
dotnet ef database update
```


