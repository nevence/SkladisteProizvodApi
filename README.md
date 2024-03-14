# Warehouse Management System (WMS)

This project is a Warehouse Management System (WMS) developed using ASP.NET Core Web API, providing robust functionalities for managing warehouses, products, and users. The system offers distinct roles for Admin, Manager, and Employee, each tailored with specific privileges and access levels.

## Features

### User Roles
- **Admin**: Responsible for managing user accounts, including adding, modifying, and deleting users. Admins do not have access to warehouse functionalities.
- **Manager**: Manages warehouses by adding, modifying, and deleting them. They can view warehouse details, inventory, and stock levels. Managers can order or deliver products for warehouses and add new products to the database for ordering.
- **Employee**: Similar functionalities as the manager but without the ability to manage warehouses. Employees can view the current inventory of a warehouse, order or deliver products, and view warehouse details. They cannot add, modify, or delete warehouses or products.

## Technologies and Practices
- **.NET Core Web API with .NET 8.0**: Utilized for building the backend services, providing a scalable and efficient solution.
- **Entity Framework**: Used as the Object-Relational Mapping (ORM) tool for interacting with the database, simplifying data access operations.
- **Identity with JWT Bearer Tokens**: Implemented for authentication and authorization, ensuring secure access to the system's resources. JWT Bearer Tokens are employed for token-based authentication, offering a stateless and secure authentication mechanism.
- **Onion Architecture**: Adopted as the software design pattern, facilitating maintainability, testability, and scalability of the application. The architecture emphasizes separation of concerns and modular design.

## Usage
To utilize the Warehouse Management System, follow these steps:
1. Clone the repository to your local machine.
2. Set up the necessary configurations such as database connection strings and authentication settings.
3. Build and run the application.
4. Access the various endpoints provided by the API to manage warehouses, products, and users according to the designated roles.

