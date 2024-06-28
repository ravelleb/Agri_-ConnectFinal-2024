Agri-Web Application Website

Agri-Web is a web application designed to manage agricultural products and farmer information. This README file provides an overview of the project, step-by-step setup instructions, guidelines on how to build and run the prototype, and an explanation of the system's functionalities and user roles.

Table of Contents
Overview
Features
Prerequisites
Installation
Configuration
Running the Application
Project Structure
Functionalities and User Roles
Contributing
License
Overview
Agri-Web is designed to streamline the management of farmers and their agricultural products. It provides functionalities for user authentication, product management, and error handling, ensuring a seamless user experience.

Features
Manage farmers and their products.
User authentication and authorization.
Error handling and logging.
Responsive design for various devices.
Prerequisites
Before setting up the project, ensure you have the following tools installed:

.NET 8 SDK
Visual Studio 2022
SQL Server (LocalDB recommended for development)
Installation
Follow these steps to set up the development environment:

Clone the repository:

sh
Copy code
git clone https://github.com/ravelleb/Agri-Web-Part-2.git
cd Agri-Web-Part-2
Open the solution:

Open Agri-Web.sln in Visual Studio.
Restore NuGet packages:

Visual Studio will automatically restore the required NuGet packages on opening the solution. If not, right-click on the solution in Solution Explorer and select "Restore NuGet Packages".
Configuration
Update the database connection string:

Open appsettings.json and update the DefaultConnection string to point to your SQL Server instance:

json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-Agri_Web;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Apply migrations:

Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console) and run the following command:
sh
Copy code
Update-Database
Running the Application
Run the application:

Press F5 or click the "Start" button in Visual Studio to run the application.
Access the application:

Open a web browser and navigate to https://localhost:5001 (or the URL shown in the output window).
Project Structure
Controllers: Contains the controllers for handling HTTP requests.
Models: Contains the model classes representing the data.
Views: Contains the Razor views for the application.
Data: Contains the data context and database migrations.
Functionalities and User Roles
Functionalities
Farmer Management: Add, edit, and delete farmer information.
Product Management: Add, edit, and delete agricultural products.
User Authentication: Register and log in users with role-based access.
Error Handling: Custom error pages and logging for better user experience and debugging.
User Roles
Admin: Full access to all functionalities, including managing users, farmers, and products.
Farmer: Access to manage their own products and view personal information.
Employee: View and manage product stock related to specific farmers.
New System Functionalities
View Products by Farmer: After logging in, an employee can view a list of all products a specific farmer supplies.
Filter Products: The list of products supplied by a farmer can be filtered according to date range or product type.
Restricted Access: Only logged-in users can see data, ensuring secure access.
Enhanced Product Management: Employees can add, edit, and delete products quickly and efficiently.
New System Ease of Use
Optimized Product D![website 1](https://github.com/ravelleb/Agri_-ConnectFinal-2024/assets/102229020/96d1314b-fea0-41a2-9a62-d64e3ffa89e2)
ata Capture: Adding new product data is streamlined for quick entry, reducing time spent on data management.
Contributing
Contributions are welcome! Please follow these steps to contribute:
![Screenshot 2024-06-27 234101](https://github.com/ravelleb/Agri_-ConnectFinal-2024/assets/102229020/bc0710b3-3cc5-495a-86f1-762951688b32)

Fork the repository.
Create a new branch (git checkout -b feature/your-feature).
Commit your changes (git commit -am 'Add some feature').
Push to the branch (git push origin feature/your-feature).
Create a new Pull Request.
License
This project is licensed under the MIT License. See the LICENSE file for details.
