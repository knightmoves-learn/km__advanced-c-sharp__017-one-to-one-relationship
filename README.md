# 015 Task Based Async Pattern

## Lecture

[![# Entity Framework(Part 1)](https://img.youtube.com/vi/xXRktgfaiJA/0.jpg)](https://www.youtube.com/watch?v=xXRktgfaiJA)

[![# Entity Framework(Part 2)](https://img.youtube.com/vi/iYHDXCxVigo/0.jpg)](https://www.youtube.com/watch?v=iYHDXCxVigo)

## Instructions

In `HomeEnergyApi/Models/HomeDbContext.cs`
- Create a public class `HomeDbContext` extending `DbContext`
    - Create a constructor
        - Should take one argument `options` of type `DbContextOptions<HomeDbContext>`
        - Should extend it's single argument to it's parent's constructor, using the `base()` keyword.
    - Create a public property `Homes` of type `DbSet<Home>`
        - Ensure this property has a getter/setter

In `HomeEnergyApi/Models/Home.cs`
- Create a private property on `Id` of type `int`
    - Give this property the `Key` attribute
    - Ensure this property has getter/setter

In `HomeEnergyApi/Models/HomeRepository.cs`
- Replace `HomesList` with a new private property `context` of type `HomeDbContext`
- With the above change, refactor each method on `HomeRepository` as necessary to ensure they operate the same as before
- Ensure you are calling `context.SaveChanges()` as needed.

In `HomeEnergyApi/Program.cs`
- Refactor each instance of `AddSingleton` to be `AddScoped`
- To the builder, add a DbContext Service with the type `HomeDbContext` supplied
    - Give this service the option of `UseSqlite("Data Source=Homes.db")` 
- Use the following code, to add migration to your api, by adding the following code snippet after `builder.Build()`
``` cs
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HomeDbContext>();
    db.Database.Migrate();
}
```

In your terminal
- Install the tool `dotnet-ef` to dotnet globally
    - The --global flag means you will have `dotnet-ef` available to use anywhere on your current machine. If you are using GitHub Codespaces, you will need to run this command each time you create a new codespace.
- Run `dotnet ef migrations add InitialCreate`
- Run `dotnet ef database update`
    
## Additional Information
- Along with `using` statements being added, any packages needed for the assignment have been pre-installed for you, however in the future you may need to add these yourself.

## Building toward CSTA Standards:
- Decompose problems into smaller components through systematic analysis, using constructs such as procedures, modules, and/or objects (3A-AP-17) https://www.csteachers.org/page/standards
- Create artifacts by using procedures within a program, combinations of data and procedures, or independent but interrelated programs (3A-AP-18) https://www.csteachers.org/page/standards
- Compare and contrast fundamental data structures and their uses (3B-AP-12) https://www.csteachers.org/page/standards
- Construct solutions to problems using student-created components, such as procedures, modules and/or objects (3B-AP-14) https://www.csteachers.org/page/standards
- Demonstrate code reuse by creating programming solutions using libraries and APIs (3B-AP-16) https://www.csteachers.org/page/standards
- Develop and use a series of test cases to verify that a program performs according to its design specifications (3B-AP-21) https://www.csteachers.org/page/standards
- Modify an existing program to add additional functionality and discuss intended and unintended implications (e.g., breaking other functionality) (3B-AP-22) https://www.csteachers.org/page/standards

## Resources
- https://learn.microsoft.com/en-us/ef/
- https://en.wikipedia.org/wiki/Object%E2%80%93relational_mapping
- https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package
- https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install
- https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli#create-your-first-migration
- https://learn.microsoft.com/en-us/ef/core/cli/dotnet#dotnet-ef-database-update

Copyright &copy; 2025 Knight Moves. All Rights Reserved.
