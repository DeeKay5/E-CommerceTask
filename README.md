# E-Commerce API Technical Task for Victorian Plumbing by Dawid Kaminski.
The solution is composed of 3 projects: 
API - This contains the endpoint which allows users to create a new order
Infrastructure - A class library containing the data schema along with all the models and DTOs
Core - A class library containing database access resources.

In order to test the API, please first make sure you are using a valid connection string. The example code here connects directly to a SQL Server database and uses windows authentication. To create a new order simply run the API and try the endpoint using Swagger by inserting order details.

Note: When the database is migrated, 5 example products should be seeded into the table (product Ids 1,2,3,4,5). You msut specify the quantity to add to the order. I have also designed it so if a customer id is provided, the system will try to link the order with an existing customer 'account', however if left blank it will simply create a new record in the customer table.
