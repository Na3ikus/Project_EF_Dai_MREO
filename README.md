# Project_EF_Dai_MREO

A console-based Vehicle Registration System built with . NET 8 and Entity Framework Core (MySQL). Implements a layered architecture, the Repository pattern, Unit of Work pattern, and strict static code analysis.

## Technology Stack

- . NET 8
- Entity Framework Core
- MySQL
- C#
- NUnit (Testing)
- StyleCop Analyzers

## Project Structure

```
Project_EF_Dai_MREO/
│
├── . github/                                    # GitHub workflows and configurations
│
├── Project_EF_Dai_MREO.Main/                  # Main application layer
│   ├── App/                                    # Application UI layer
│   │   ├── Template/                           # Menu templates (Template Method pattern)
│   │   │   ├── IMenu.cs                        # Menu interface
│   │   │   ├── BaseCrudMenu. cs                 # Base CRUD menu template
│   │   │   ├── BrandMenu.cs                    # Brand management menu
│   │   │   ├── CarMenu.cs                      # Car management menu
│   │   │   ├── CountryMenu. cs                  # Country management menu
│   │   │   └── PersonMenu.cs                   # Person management menu
│   │   ├── UI/                                 # UI components and theming
│   │   │   ├── IColorTheme.cs                  # Theme interface
│   │   │   ├── NeonTheme.cs                    # Neon color theme implementation
│   │   │   └── Window.cs                       # Console window drawing utilities
│   │   ├── ConsoleHelper.cs                    # Console input/output helpers
│   │   ├── ConsoleUI.cs                        # Main console UI controller
│   │   └── SystemMenu.cs                       # System menu implementation
│   │
│   ├── Configurator/                           # Configuration layer
│   │   └── DatabaseConfigurator.cs             # Database connection configuration
│   │
│   ├── Data/                                   # Data access layer
│   │   ├── AbstractFactory/                    # Abstract Factory pattern for test data
│   │   └── MreoStorageContext.cs               # EF Core DbContext (25+ entities)
│   │
│   ├── Repository/                             # Repository pattern implementation
│   │   ├── Patern/                             # Repository patterns
│   │   │   ├── IUnitOfWork.cs                  # Unit of Work interface
│   │   │   └── UnitOfWork. cs                   # Unit of Work implementation
│   │   ├── IRepository.cs                      # Generic repository interface
│   │   ├── TemplateRepository.cs               # Base repository with error handling
│   │   ├── BrandRepository.cs                  # Brand repository
│   │   ├── CarRepository.cs                    # Car repository
│   │   ├── CountryRepository.cs                # Country repository
│   │   └── PersonRepository.cs                 # Person repository
│   │
│   ├── Services/                               # Business logic services
│   │   └── ErrorLogger.cs                      # Error logging service
│   │
│   ├── Program.cs                              # Application entry point
│   └── Project_EF_Dai_MREO.csproj             # Project file with NuGet packages
│
├── Project_EF_Dai_MREO.Tests/                 # Unit tests project
│   ├── DatabaseConfiguratorTests.cs            # Database configuration tests
│   ├── ErrorLoggerTests.cs                     # Error logger tests
│   ├── TemplateRepositoryTests.cs              # Repository pattern tests
│   ├── WindowTests.cs                          # UI window tests
│   └── Project_EF_Dai_MREO.Tests. csproj       # Test project file
│
├── . gitignore                                  # Git ignore rules
├── Dai_Mreo.sln                                # Visual Studio solution file
├── code-analysis.ruleset                       # Custom code analysis rules
└── stylecop.json                               # StyleCop analyzer configuration
```

## Description

This is a vehicle registration management system (MREO - Міжрайонний реєстраційно-екзаменаційний відділ) that demonstrates:

### Architecture & Design Patterns
- **Layered Architecture**: Clear separation between UI, Business Logic, and Data Access layers
- **Repository Pattern**:  Abstraction layer for data access operations
- **Unit of Work Pattern**:  Manages transactions across multiple repositories
- **Template Method Pattern**: Base CRUD menu with customizable implementations
- **Abstract Factory Pattern**: Generates test data for database seeding
- **Strategy Pattern**: Interchangeable UI themes

### Key Features
- **25+ Database Entities**: Complete domain model for vehicle registration (Cars, Brands, Persons, Documents, Accidents, etc.)
- **CRUD Operations**: Full Create, Read, Update, Delete functionality for all entities
- **Error Handling**: Centralized error logging service
- **Console UI**: Rich console interface with custom theming and table rendering
- **Database Configuration**: Flexible connection setup with config file support
- **Code Quality**:  Enforced standards using StyleCop and custom analysis rules
- **Unit Tests**: xUnit test coverage for core functionality

### Entity Model Includes
- Vehicle-related:  Car, Brand, CarModel, Factory, Color, VehicleType
- Person-related: Person, Employee, Position, Document, DriverLicense
- Location-related: Country, Region, City, Address, MreoLocation
- Registration: CarOwnersAction, ActionType, Accident
---
**Author:** [Na3ikus](https://github.com/Na3ikus)  
**Repository:** [Project_EF_Dai_MREO](https://github.com/Na3ikus/Project_EF_Dai_MREO)
