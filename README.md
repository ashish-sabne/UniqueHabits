# UniqueHabits

**UniqueHabits is a full-stack Progressive Web Application (PWA) for building and tracking habits.** It combines evidence-based habit-building concepts with software development practices to help users create habits, track progress, and continuously improve their routines.

This is a personal project that I designed and developed end-to-end, including the application architecture, API, database, business logic, UI, and automated tests.

> **Note:** The application is currently a development project and is not publicly hosted. The repository is provided to demonstrate the architecture, implementation, and engineering practices behind the application.

## Key Features

* Create and manage personal habits
* Track habit progress over time
* Organize and view habits through a responsive web interface
* User-specific data and authorization
* Server-side business logic and validation
* Persistent data storage using SQL Server
* Progressive Web App capabilities

## Architecture

The application is structured as a multi-project .NET solution with clear separation between the presentation, API, domain, data-access, and shared-contract layers.

```text
┌─────────────────────────────┐
│       Blazor WebAssembly    │
│          Client             │
└──────────────┬──────────────┘
               │ HTTP / API
               ▼
┌─────────────────────────────┐
│       ASP.NET Core API      │
│     Application Services    │
└──────────────┬──────────────┘
               │
        ┌──────┴───────┐
        ▼              ▼
┌──────────────┐ ┌──────────────┐
│    Domain    │ │     Data     │
│   Business   │ │ EF Core /    │
│    Rules     │ │ SQL Server   │
└──────────────┘ └──────────────┘
```

The solution is separated into:

* **UniqueHabits.Client** – Blazor WebAssembly client application
* **UniqueHabits.Api** – ASP.NET Core Web API
* **UniqueHabits.Domain** – domain models and business concepts
* **UniqueHabits.Data** – Entity Framework Core and data access
* **UniqueHabits.Contracts** – API contracts and shared DTOs
* **UniqueHabits.Shared** – shared application components

## Technology Stack

### Frontend

* Blazor WebAssembly
* HTML / CSS / JavaScript
* Responsive UI
* Progressive Web App capabilities

### Backend

* C#
* ASP.NET Core Web API
* Entity Framework Core
* RESTful APIs

### Data

* SQL Server
* Entity Framework Core

### Testing

* NUnit
* FluentAssertions

## Engineering Approach

I built this project with a focus on maintainability and separation of concerns rather than putting all application logic into the UI or API controllers.

Some of the areas explored in the project include:

* Domain-driven organization of business logic
* Separation of API contracts from domain models
* Entity Framework Core data access
* User-specific data filtering
* Automated unit testing
* Query optimization and projection
* API/client separation
* Progressive Web App architecture

## Why I Built It

I wanted to build a project that combined two interests: habit formation and software engineering.

Rather than building a simple CRUD application, I used the project as an opportunity to explore how I would structure and evolve a real-world business application from the ground up.

The application has also evolved over time as I've experimented with different approaches and learned from implementing them.

## Running Locally

### Prerequisites

* .NET SDK
* SQL Server or SQL Server Express
* Visual Studio 2022 or another compatible .NET development environment

### Getting Started

1. Clone the repository:

```bash
git clone https://github.com/ashish-sabne/UniqueHabits.git
```

2. Open `UniqueHabits.sln`.

3. Configure the application's database connection string.

4. Apply the Entity Framework Core migrations.

5. Start the API and Blazor WebAssembly client.

> The exact configuration may change as the project continues to evolve.

## Future Improvements

Some areas I would consider improving as the application evolves include:

* Production cloud deployment
* CI/CD pipeline
* Additional automated integration tests
* Improved observability and application telemetry
* Further performance optimization
* Additional PWA/offline capabilities

## About

UniqueHabits is a personal project by **Ashish Sabne**, a Senior Full-Stack Developer with experience building enterprise and business applications using .NET, Angular, Azure, SQL Server, and related technologies.

[View the source code on GitHub](https://github.com/ashish-sabne/UniqueHabits)
