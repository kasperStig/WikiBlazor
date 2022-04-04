# About
This project is a Blazor Web Assembly solution, which serves a server and a client to load random Wikipedia articles, view them and attach categories to them.

This solution runs on .NET Core 3.1 and uses Entity Framework v5.0.14 (EF).

## Getting started
Open the solution in Visual Studio, go to `WikiBlazor.Server\appsettings.json` and set the `Server` property of the `DefaultConnection` connection string to your MSSQL instance.
Next, open up the Package Manager Console (PMC) and navigate to `.\WikiBlazor\Server`. 
If you haven't already, you need to install the EF command line tool using the following command `dotnet tool install --global --version 5.0.14 dotnet-ef` in the PMC.
Once that is done, you can apply the existing migration to create and seed the database by executing `dotnet ef database update` in the PMC.
You should now be up and running and ready to launch!

## Swagger
The server endpoints are also available via Swagger on `~/swagger/index.html`.
