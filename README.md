# EFCore Migrations And SQL Script
Reference guide for migrations and SQL script commands in Microsoft EntityFramework Core.


## Requirements

**.NET Core Framework**

https://dotnet.microsoft.com/download

**Visual Studio Code**

https://code.visualstudio.com/


## VS Code Extensions

**C# for Visual Studio Code (powered by OmniSharp)**

https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp

**C# Extensions**

https://marketplace.visualstudio.com/items?itemName=kreativ-software.csharpextensions

**C# Snippets**

https://marketplace.visualstudio.com/items?itemName=jorgeserrano.vscode-csharp-snippets

**C# Full namespace autocompletion**

https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.namespace

**SQLite Database Viewer**

https://marketplace.visualstudio.com/items?itemName=qwtel.sqlite-viewer


## Documentation

**Microsoft EntityFramework Core**

https://docs.microsoft.com/en-us/ef/core/

**Migrations**

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli


## Project Creation Scripts

**Create new solution**

    dotnet new sln -n EFCoreMigrationsAndSQLScript

**Create new console project**

    dotnet new console -n EFCoreMigrationsAndSQLScript -o EFCoreMigrationsAndSQLScript -f netcoreapp3.1

**Add project to solution**

    dotnet sln EFCoreMigrationsAndSQLScript.sln add EFCoreMigrationsAndSQLScript/EFCoreMigrationsAndSQLScript.csproj


## Project packages

**EntityFrameworkCore**

    dotnet add package Microsoft.EntityFrameworkCore --version 5.0.10

**EntityFrameworkCore Design**

    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.10

**SQLite**

    dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.3



## Migrations basic commands

**Create migration**

    dotnet ef migrations add MigrationName

**Apply migration**

    dotnet ef database update

**Remove last migration**

    dotnet ef migrations remove

**List migrations**
    
    dotnet ef migrations list

**DbContext Scaffold**
    
    dotnet ef dbcontext scaffold "ConnectionString" Microsoft.EntityFrameworkCore.Sqlite -o Model

**Script migrations**
    
    dotnet ef migrations script -o FileName.sql

**Additional information**

https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx
