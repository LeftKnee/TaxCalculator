# Tax Calculator

Frameworks and Environments

- **Database: SQL Server**
  - ORM for the project: EntityFramework Core
    - Code-first data migrations to create database and table used
    - Setting up by running the InitialDBCreation data migration
  - Adjust appsettings.json for your local environment
    - The connection string to be modified according to your SQL environment:
      - Key: TaxCalculatorConnection
- **REST API**
  - Front-end enabled with Swashbuckle / Swagger
  - The API is used for all CRUD operations
    - Only **insert** and **read** support for this project.
- **User UI**
  - Blazor Web Assembly
  - Making use of the API layer for database operations

Project comments

- The solution has been setup to start up both the API and the user web UI:
  - A swagger web UI for data testing
  - A Blazor WASM UI making use of the API for data operations
- General thoughts and comments have been left in the source code to highlight areas of concern and possible improvement.
  - These are all indicated in the C# comments notation in the format:
    - // Comment: bla bla bla
