#### Overview

This project serves as the API for the Customer Manager project. It is a RESTful API that provides CRUD operations for managing customers.

#### Setup

- This was build using .NET Core 7
- You should be able to just open the solution in Visual Studio and run it
- You may also run it via command line using `dotnet run` from the root of the project
- The project is configured to run on port 5167, so you can access it via http://localhost:5167
- Swagger documentation is available at http://localhost:5167/swagger

#### Notes

- Migrations will be run automatically on startup
- To reset the migrations, simply remove the file in `Data/db.sqlite` and restart the project
- The database is seeded with 1000 customers on startup
