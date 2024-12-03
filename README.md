eCommerce Solution - Clean Architecture (.NET)

This project is mockup built with .NET and follows the principles of Clean Architecture. It demonstrates a scalable, maintainable, and testable approach to software design, ideal for modern web applications.

Key Features
Layered Architecture: Follows Clean Architecture principles, separating concerns between application layers (Domain, Application, Infrastructure, and Presentation).
Domain-Driven Design (DDD): Encapsulates core business logic within the domain layer, ensuring the application remains adaptable and resilient.
Test-Driven Development (TDD): Includes unit and integration tests, following TDD best practices to ensure a robust codebase.
Modular Design: Enables flexible deployment and easy feature extension.
Cloud-Ready: Configured for deployment in cloud environments, with a focus on scalability and reliability.

Technology Stack
.NET Core: Backend API with RESTful services.
Entity Framework Core: For database interactions, with migrations for easy schema management.
PostgreSQL / SQL Server: Recommended databases, adaptable to other SQL/NoSQL databases.
Automapper: Simplifies data mapping between layers.
Dependency Injection: Ensures modularity and testability.
Docker: Containerization support for easy deployment.

----------------------------------------------------
Requirements

Should be Docker installed

For running redis you should open command console on root folder and run:
> docker-compose up -d
This is going to set up redis on your machine by executing the .yml config file.
