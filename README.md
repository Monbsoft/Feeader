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
