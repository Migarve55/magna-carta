# magna-carta

Blazor WebApp for hosting online menus and ordering products for restaurants
Final Project for my [Master Degree in Development of Web Apps and Services](https://www.universidadviu.com/es/master-desarrollo-web)

## Features

 - Menu editing: customize a menu for a restaurant with different products
 - Order processing: allow clients to buy products and make orders from a public webpage
 - Order management: see present orders their status and details, and search orders between dates
 - Employee synchronization: show live updates of the orders from each table to improve the coordination between cooks and waiters

## Project structure

 - PublicFrontEnd: public webapp for offering the menu to the clients
 - PrivateFrontEnd: mangaging app for the employees and manager
 - SharedDomain: shared dependencies between the two apps

## Prepare database

Run this command to create and apply all migrations to the database

`dotnet ef database update`

## Build

`dotnet build`