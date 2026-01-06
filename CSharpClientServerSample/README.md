
# C# Client-Server Sample (Console Client + ASP.NET Core Minimal API Server)

This sample provides a simple C# solution containing two projects:

- **Server**: ASP.NET Core minimal API exposing `/weatherforecast`.
- **Client**: .NET console app that calls the server and prints the results.

## Prerequisites
- .NET SDK 8.0 or later installed.

## How to run
1. Open a terminal in the solution folder `CSharpClientServerSample`.
2. Restore and build:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Start the server (HTTP on port 5000):
   ```bash
   dotnet run --project Server
   ```
   You should see the server listening on `http://localhost:5000`.
4. In a second terminal, run the client:
   ```bash
   dotnet run --project Client
   ```

You should see a list of weather forecasts returned from the server.

## Notes
- If your server listens on a different port, update `client Program.cs` `BaseAddress` accordingly.
- Swagger is enabled in Development; navigate to `http://localhost:5000/swagger` when the server is running.
