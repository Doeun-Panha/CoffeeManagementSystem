COFFEE MANAGEMENT SYSTEM
========================

A robust and user-friendly management system for coffee shops, built using .NET Framework and SQL Server. This application provides comprehensive tools for both administrative management and staff operations.

KEY FEATURES
------------

ADMIN DASHBOARD
* Employee Management: Add, update, and manage employee records.
* Inventory Control: Track stock levels, update quantities, and manage suppliers.
* Menu Management: Curate your offerings with full CRUD operations for menu items.
* User Management: Control system access and roles for all staff members.
* Reporting: Generate and view detailed sales and performance reports.

STAFF / POS INTERFACE
* Point of Sale (POS): Intuitive interface for staff to process orders quickly.
* Order Tracking: Real-time management of active orders.

TECHNOLOGY STACK
----------------
* Frontend: C# WinForms
* Backend: .NET Framework 4.7.2
* Database: SQL Server
* Architecture: Layered architecture with dedicated Models and UserControls.

PROJECT STRUCTURE
-----------------
* Models/: Core entity classes (Employee, Inventory, Menu, User, etc.) and database helpers.
* UserControls/: Reusable UI components grouped by role (AdminUserControls, EmployeeUserControl).
* Forms/: Main application windows and login forms.
* App.config: Application configuration including database connection strings.

SETUP & INSTALLATION
--------------------

PREREQUISITES
* Visual Studio (2019 or later recommended)
* .NET Framework 4.7.2
* SQL Server

STEPS
1. Clone the Repository:
   git clone https://github.com/Doeun-Panha/CoffeeManagementSystem.git

2. Database Configuration:
   - Open App.config.
   - Update the connectionString for CoffeeDB to point to your local SQL Server instance:

   <connectionStrings>
       <add name="CoffeeDB" connectionString="Server=YOUR_SERVER_NAME;Database=CoffeeManagementSystem;Integrated Security=True;" providerName="System.Data.SqlClient" />
   </connectionStrings>

3. Build and Run:
   - Open CoffeeManagementSystem.sln in Visual Studio.
   - Restore NuGet packages.
   - Build the solution and run the application.

CONTRIBUTING
------------
Contributions are welcome! Please feel free to submit a Pull Request.
