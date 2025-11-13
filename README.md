# msbuild-example-project

This workspace contains a small MSBuild (SDK-style .NET) example with two class libraries and an xUnit test project.

Structure:
- src/LibA - simple Calculator library
- src/LibB - Multipler library referencing LibA
- src/App - sample console app referencing both libraries
- tests/LibTests - xUnit tests referencing both libs

How to build and test (PowerShell on Windows):

# Ensure .NET SDK (>= 8.0) is installed. Then run:

dotnet build

dotnet test

If you prefer to create a solution and add projects to it:

# Create a solution (optional)
# dotnet new sln -n msbuild-example-project
# dotnet sln add src\LibA\LibA.csproj src\LibB\LibB.csproj src\App\App.csproj tests\LibTests\LibTests.csproj

Notes:
- Projects target net8.0 via `Directory.Build.props`.
- Test project uses xUnit and Microsoft.NET.Test.Sdk.

Sample console app
------------------

There's a sample console app in `src\App` that references both `LibA` and `LibB` and prints example outputs.

To create a solution and add all projects (optional):

```powershell
dotnet new sln -n msbuild-example-project
dotnet sln add src\LibA\LibA.csproj src\LibB\LibB.csproj src\App\App.csproj tests\LibTests\LibTests.csproj
```

To run the console app directly:

```powershell
dotnet run --project src\App\App.csproj
```

To build and run tests:

```powershell
dotnet build
dotnet test
```
