# Tax Calculator

Frameworks and Environments

- **Database: SQL Server**
  - ORM for the project: EntityFramework Core
    - Code-first data migrations to create database and table used
  - Adjust appsettings.json for your local environment
    - The connection string to be modify according to your SQL environment:
      - Key: TaxCalculatorConnection
- **REST API**
  - Front-end enabled with Swashbuckle / Swagger
  - The API is used for all CRUD operations
    - ONLINE insert and read support for this project.
- **User UI**
  - Blazor Web Assembly
