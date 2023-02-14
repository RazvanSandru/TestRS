# C# code for file archiving and downloading

## Configure the code from the Command Line

* Clone this repository:
```
    $ git clone https://github.com/RazvanSandru/TestRS.git
```

* Add user secrets by replacing placeholders(DatabaseServer, UserId and Password) with your data in the following commands:
```
    > dotnet user-secrets init
    > dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=[DatabaseServer];Database=RazvanS;User Id=[UserId];Password=[Password];"
```

* Build and run the project
