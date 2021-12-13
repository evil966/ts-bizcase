[![.NET](https://github.com/evil966/ts-bizcase/actions/workflows/ts-bizcase-server.yml/badge.svg)](https://github.com/evil966/ts-bizcase/actions/workflows/ts-bizcase-server.yml)
# Introduction 
Develop a web application to manage the Tender details within the organization. The application should have the ability to
• Create a tender
• Edit a tender
• Delete a tender
• View a Tender
• Show the tender list.

Technical template or scope for the application.
Tools
• Visual Studio 2019/Visual studio code
• Microsoft SQL server.
• Upload your project to GitHub and send us the link.

Architecture
• Preferable using Clean Architecture, but any N-Tier architecture will do.
• Architecture should consider having a separation of concern.
• Dependency injection
• Repository pattern for the persistent layer.

Database
• Microsoft SQL server
• If you are using SQL
o Write stored procedures for CRUD operations. (If possible or at least 1 stored procedure)
o Write table creation in SQL
o You can user EF core 2/ Dapper/ ADO.net to execute stored procedure.

Back end Language:
• Asp.net Core Web API using .NET 3.1/5
• Use Attribute routing

Front End Client App
• Angular 10/11
• Reactive forms.
• User Observable to call API
• Bootstrap 4/5 

These are the components; we will be looking at when we are evaluating the project. You don’t need to implement everything. Showcase your talent. Implement those in bold.
Web API dotnet core
• Middleware
• Filters
• RESTful API
Angular
• Routing
• Pipes
• Modularizing angular components
o Lazy loading/Eager Loading
• Child Routes
• Services
• Uses of Ng-bootstrap components (Models)
• NgRx
• Any other fancy libraries
o Toaster notification
o Overlay loading

Testing
• For Unit/ Integration Test XUnit, Moq


# Getting Started
1. Clone this repo
2. Load in VS2019
3. Restore the Nuget Packages
4. Perform initial build
5. "update-database" from the Package Management Console to create the DB (SqlServer)
6. F5 to run
