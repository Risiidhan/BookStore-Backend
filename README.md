
# BookStore Backend System

This System is a simple software designed to latest .NET design patterns, tools and architecture. Built with a clean architecture approach, the system is organized into distinct layers: API layer, Domain layer, and Infrastructure layer and SQL Server. 

- _Follows CQRS approach with Mediatr_
- _Repository patterns_
- _AutoMapper_
- _Fluent Validation_
- _JWT authentication_
- _role based access control_
- _global exception_


## Folder Structure
![image](https://github.com/Risiidhan/BookStore-Backend/assets/95620628/3ebbbe29-62d5-4fae-9d5e-75fbc8719bb0)


## API Layer:

 - Where the web API is located and consists of controllers and middleware for global exception handling

## Core Layer:
### Domain Layer:

 - The Domain Layer contains data models of the application. It includes database models representing entities such as category, books, user and author

### Application Layer:

 - consists of DTOs, interface to follow repository pattern and generic interface to follow inheritance for CRUD actions. Automaper to map models and dtos. Follows the CQRS (Command Query Responsibility Segregation) pattern along with MediatR for command and query processing. Additionally, it includes common response classes for standardized return types.

## Infrastruture Layer:

### Infrastruture Layer
Here the DB context file is stored, migrations from enity framework and repository for DB calls of category, books and author are located with Dependency Injection service

### Identity Layer
Here the Identity user authentication with JWT token service implementation with role based access control and for login and user register are called, and with Dependency Injection service



## Run Migration

**Change connection string in appSetting.json to your appropriate DB server**

```bash
 "ConnectionStrings": {
    "DefaultConnection": "Server=ServerName;Database=DBName;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False",
    "AuthDBDefaultConnection": "Server=ServerName;Database=DBName;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False"
  },
```
**Initial Migration** -
move to BookStore-Backend\BookStore>
```bash
  dotnet ef migrations add InitialMigration --startup-project API\BookStore.API --project Infrastructure\BookStore.identity --context AuthApplicationDbContext
```

**Update Database**
```bash
    dotnet ef database update --startup-project API\BookStore.API --project Infrastructure\BookStore.identity --context AuthApplicationDbContext
```
## Build Project
```bash
    dotnet build
```

## Run Project
Move to BookStore-Backend\BookStore\src\API>
```bash
    dotnet watch run
```


## Run Migration

**Change connection string in appSetting.json to your appropriate DB server**

```bash
 "ConnectionStrings": {
    "DefaultConnection": "Server=ServerName;Database=DBName;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False",
    "AuthDBDefaultConnection": "Server=ServerName;Database=DBName;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False"
  },
```
**Initial Migration** -
move to BookStore-Backend\BookStore>
```bash
  dotnet ef migrations add InitialMigration --startup-project API\BookStore.API --project Infrastructure\BookStore.identity --context AuthApplicationDbContext
```

**Update Database**
```bash
    dotnet ef database update --startup-project API\BookStore.API --project Infrastructure\BookStore.identity --context AuthApplicationDbContext
```
## Build Project
```bash
    dotnet build
```

## Run Project
Move to BookStore-Backend\BookStore\src\API>
```bash
    dotnet watch run
```

