# Feeader

## Configuring the sample to use SQL Server

* Install the EF tool: 

    ```
    dotnet tool install --global dotnet-ef
    ```

* Migrate the database:


    ```
    dotnet ef migrations add InitialCreate --context feeaderdbcontext -p ../Feeader.Infrastructure/Feeader.Infrastructure.csproj -s Feeader.Api.csproj -o Data/Migrations
    ```    

* Update SQL Server database:

    ```
    dotnet ef database update -c feeaderdbcontext -p ../Feeader.Infrastructure/Feeader.Infrastructure.csproj -s  Feeader.Api.csproj
    ```
    
## Crédits

- [[microsoft / dotnet-podcasts](https://github.com/microsoft/dotnet-podcasts)], MIT License, .NET 6 reference application shown at .NET Conf 2021 featuring ASP.NET Core, Blazor, .NET MAUI, Microservices, and more!
- Steve Smith, [[ardalis / CleanArchitecture](https://github.com/ardalis/CleanArchitecture)], MIT License, Clean Architecture Solution Template: A starting point for Clean Architecture with ASP.NET Core, 
-  Vladimir Khorikov, [[vkhorikov / DddInAction](https://github.com/vkhorikov/DddInAction)], Source code for the DDD in Practice Pluralsight course, [info](https://www.pluralsight.com/courses/domain-driven-design-in-practice)
- [[dotnet-architecture / eShopOnWeb](https://github.com/dotnet-architecture/eShopOnWeb)], MIT License, Sample ASP.NET Core 6.0 reference application, powered by Microsoft, demonstrating a layered application architecture with monolithic deployment model. Download the eBook PDF from docs folder. 