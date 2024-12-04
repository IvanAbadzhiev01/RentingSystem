# Rental system

Welcome to the RentingSystem project! It is a car rental web application with different roles and functionalities.

## Navigation

- [What users can do](#what-users-can-do)
- [What the dealer can do](#what-the-dealer-can-do)
- [What the admin can do](#what-the-admin-can-do)
- [Technologies](#technologies)
- [Login Data](#login-data)
- [SetUp](#setup)
- [Screenshots](#screenshots)

## What the user can do

- Browses available cars.
- They start the process of renting a car.
- They reserve cars for a specific period.
- To become a dealer
- Leave reviews
- To see the history of the cars he rented
- To use live chat
- Search for cars by a set filter

## What the dealer can do

- Adding new cars to the system.
- To view reviews of his cars
- Editing of car details.
- To use live chat
- To delete the cars who added them

## What the admin can do

- Everything other users can do
- To approve cars
- To see all the data of users and whether they are dealers or not
- Sees all rental cars

## Technologies

The project uses the following technologies:
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **MS SQL Server**
- **Bootstrap** (to style the interface)
- **SignalR** (for real-time communication)
- **JavaScript, jQuery** (for dynamic client-side actions)
- **nUnit** (for tests)

## Login details

The input data is defined in the `SeedData` classes for all roles:

- **Administrator**:
 - Username: `admin@mail.com`
 - Password: `admin123`

- **Dealer**:
 - Username: `dealer@mail.com`
 - Password: `dealer123`

- **User**:
 - Username: `guest@mail.com`
 - Password: `guest123`

## SetUp

1. **Clone the Project**:
 - Clone repository from [RentingSystem GitHub](https://github.com/IvanAbadzhiev01/RentingSystem).

2. **MSSQL Database Configuration**:
 - Make sure you have **MS SQL Server** installed.

3. **Running migrations with the Package Manager Console**:
 - Open **Package Manager Console** in Visual Studio.
 - Run the following command to run the migrations and create the database:

 Update-Database


After these steps, the project will be ready to work with the configured database.

## Screenshots

**HomePage**
![image](https://github.com/user-attachments/assets/078381f1-dba1-4e08-b8cd-2ab9e4b3a559)

**AllCars**
![image](https://github.com/user-attachments/assets/487f618f-4ec4-4f91-9546-a7e1510b0d37)

**Details**
![image](https://github.com/user-attachments/assets/453847d2-ea84-4496-bf56-fa8128e6a7be)

**Rent**
![image](https://github.com/user-attachments/assets/a85164a0-1249-4411-8ae1-2ea5cd851ae7)

**Review**
![image](https://github.com/user-attachments/assets/525c35e9-979d-4691-8b52-78a9d71d4bec)

**Delete**
![image](https://github.com/user-attachments/assets/7d4fe831-900e-4937-9a1d-c9dd8ae3fdbd)

**Edit**
![image](https://github.com/user-attachments/assets/81b2c167-be9e-4f39-88db-3fcc32f1f937)

**MyCars**
![image](https://github.com/user-attachments/assets/73caab35-df23-47b0-965d-9bf085f20dde)

**AddCar**
![image](https://github.com/user-attachments/assets/d87ad820-d85f-4748-92e3-9a88a9bea96c)

**LiveChat**
![image](https://github.com/user-attachments/assets/404b07c2-932a-4204-91d7-6991f4460894)

**AdminDashBoard**
![image](https://github.com/user-attachments/assets/42a92221-3b75-43eb-a606-ba6499be9cae)

**RentHistory**
![image](https://github.com/user-attachments/assets/09da0c88-91b4-4245-830a-30603d2a6ba0)

**ForReview**
![image](https://github.com/user-attachments/assets/691e1f2e-1afd-483d-b81c-8de4a4f1fd0d)

**AllUsers**
![image](https://github.com/user-attachments/assets/e0ec82ee-ba15-4682-a778-e69f0283f00c)

**AdminMyCar**
![image](https://github.com/user-attachments/assets/2dde3a75-109e-43d4-9ed0-7b33bd354914)

**AllRents**
![image](https://github.com/user-attachments/assets/643590ea-5211-4621-a4d9-0331e463edfe)










