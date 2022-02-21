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

## Considerations
The current solution does not use stored procedures as the limitations of my setup meant I had to use EF 5, which does not have build-in mapping of entities to stored procedures. 
Instead, I would have to create the stored procedures manually and make a migration to set it all up. It would also require me to introduce another layer in between the controllers and the database, 
since it wouldn't be possible to keep the controllers so thin.
The controllers would then simpy pass on the request to that layer, which could then interact with the database. 

If I was using a newer version of .NET Core and was using EF 6, I would simply need to add `modelBuilder.Types().Configure(t => t.MapToStoredProcedures());` to the `OnModelCreating` method of the `DataContext` class, 
and then EF would take care of it all.