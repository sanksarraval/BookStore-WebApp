# Bookstore Web Application

This Bookstore Web Application is a comprehensive solution for managing an online bookstore, featuring inventory management, user authentication, and role-based access control. Developed with **C#**, **.NET Core MVC**, and **MSSQL**, this project focuses on providing a secure, scalable, and user-friendly experience for both administrators and customers.

## Table of Contents

1. [Features](#features)
2. [Tech Stack](#tech-stack)
3. [Setup and Installation](#setup-and-installation)
4. [Usage](#usage)
5. [Database Structure](#database-structure)
6. [Project Structure](#project-structure)
7. [Contributing](#contributing)
8. [Acknowledgments](#acknowledgments)

## Features

- **User Registration and Authentication**: Allows users to create accounts, log in, and manage their profiles securely.
- **Role-Based Access Control (RBAC)**: Admins and customers have different access levels; only admins can manage inventory, view sales reports, and update book details.
- **Book Inventory Management**: Admins can add, update, and delete books, with CRUD functionality for managing book details and categories.
- **Search and Filter**: Users can search and filter books by categories, authors, or price.
- **Cart and Checkout**: Users can add books to a cart, modify quantities, and proceed to checkout with a seamless process.
- **Order Tracking**: Users can view their purchase history and track the status of their orders.
- **Responsive Design**: Ensures accessibility across devices with a mobile-friendly user interface.

## Tech Stack

- **Frontend**: HTML, CSS, JavaScript, and Bootstrap for a responsive and accessible UI.
- **Backend**: C# and .NET Core MVC for server-side logic.
- **Database**: MSSQL for structured data storage and retrieval.
- **Authentication and Authorization**: ASP.NET Identity for secure user authentication and role management.

## Setup and Installation

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 3.1 or later)
- [MSSQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/)

### Installation Steps

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/bookstore-webapp.git
    cd bookstore-webapp
    ```

2. **Configure Database**:
    - Update the connection string in `appsettings.json` with your MSSQL server information.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=your_server_name;Database=BookstoreDB;User Id=your_user;Password=your_password;"
    }
    ```

3. **Database Migration**:
    - Run the following command to apply database migrations:
    ```bash
    dotnet ef database update
    ```

4. **Run the Application**:
    - Start the application with:
    ```bash
    dotnet run
    ```

## Usage

1. **Admin Panel**:
    - Log in as an admin to access the inventory management system. Add, edit, or remove books, and manage user roles and permissions.

2. **User Features**:
    - Register or log in as a customer to browse books, add items to your cart, and check out with secure payment processing.
    - Use the search bar or filters to navigate through different book categories and authors.

3. **Order Management**:
    - Track order status and view purchase history from the user dashboard.

## Database Structure

The **BookstoreDB** database contains the following primary tables:

- **Users**: Stores user information and roles (Admin or Customer).
- **Books**: Holds book details, including title, author, price, and stock quantity.
- **Categories**: Defines categories for books to enable filtering.
- **Orders**: Logs each user’s orders with purchase and status details.
- **OrderItems**: Contains information about each item in an order, allowing multi-book purchases.

## Project Structure
BookstoreWebApp/ │ ├── Controllers/ # Handles request routing and business logic ├── Models/ # Defines the structure of data and database interactions ├── Views/ # Contains Razor views for UI components ├── wwwroot/ # Holds static files (CSS, JS, images) ├── appsettings.json # Application configuration file └── Program.cs # Main entry point for the application


## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch:
    ```bash
    git checkout -b feature/your-feature-name
    ```
3. Make your changes and commit:
    ```bash
    git commit -m "Add feature"
    ```
4. Push your branch:
    ```bash
    git push origin feature/your-feature-name
    ```
5. Open a pull request for review.

## Acknowledgments

Special thanks to the open-source libraries that helped make this project possible.


