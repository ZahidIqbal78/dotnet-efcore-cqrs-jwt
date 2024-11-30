
## Requirements:
- .NET 9.0
- Microsoft SQL Server
- SEQ (for logging)
- dotnet CLI (optional)

## First Run:
- From the `web.api` directory, execute the following:
    - `dotnet ef database update` to create the initial tables.
- Add `appsettings.json` in the `web.api` directory.
    - Using `appsettings.Development.json` as a guide, add necessary key-values in the `appsettings.json`.
- Start the program by executing:
    - `dotnet run --project employee.web.api.csproj`
    - *Note: Starting the application for the first time will create an initial user.*
- Go to `https://localhost:7186/swagger` to view swagger API doc UI.

### Initial User Credentials
- Email: `admin@email.com`
- Password: `Abcd@1234`

## employee.web.api

This is a WebAPI project consisting of all the APIs, database context, database entities, and feature handlers.

## employee.contract

This is a class library containing all the request and response models.

The initial idea was to keep the `employee controller` in this library but due to version related issues, the `employee controller` could not be placed here.

Doing so would allow publishing the contract as `nuget` package and can be incorporated in another WebAPI app, such as a gateway. That will require redesigning the authentication procedure.