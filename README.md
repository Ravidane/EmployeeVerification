# .NET Backend with Angular Frontend using SQLite & EF Core
A simple application featuring .NET Core Web API backend, 
paired with an Angular frontend for verifying employee data, 
which is pre-populated in an SQLite in-memory database using EF Core data provider and repositor pattern.

## Prerequisites
Before you begin, ensure you have the following installed:

- Node.js v16
- .NET 8
- Visual Studio 2022

## How to Run
Follow these steps to get the project up and running:

1. Clone the repository using the following command:
   ```bash
   git clone [repo-url]
   ```

 2. Open the solution file EmployeeVerification.sln in Visual Studio 2022.
 3. Set the default startup project to "https" (EmployeeVerification.Server).
 4. Install and accept the suggested SSL certificates for HTTPS SSL Socks Transport, or alternatively, use the http startup profile.
 5. Wait for the .NET backend to start up, and for npm to install, build, and run the necessary scripts.
 6. Navigate to https://localhost:62721 to access the Angular frontend UI.
 7. Enter valid inputs in the form to evaluate the server and data from the SQLite in-memory database.
    ```yaml
    EmployeeID: 1
    CompanyName: Apple
    ValidationCode: ABC123
    ```

## Configuration
- The application uses an SQLite in-memory database. Pre-populated data is inserted during application startup through the EnsureCreated and OnModelCreating methods in the DatabaseContexts.
- The backend server runs on port 7000 and is enabled with Swagger for API documentation and testing.

## Features
- Data Providers: The application includes modular data provider implementation using repository patterns & EF Core to interact with the database.
- Domain Models: Well-defined domain models to represent the data structure.
- Exception Handling: Exception handling to manage errors gracefully.
- Logging: Integrated logging to track application behavior and issues.
