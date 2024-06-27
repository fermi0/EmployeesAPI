A simple practice project for controller-based WebAPI using .NET framework. This project utilize practices that tries to be production-ready, such as utilizing Dependency Injection(DI), Data Transfer Object(DTO), repository pattern, interface, filters, pagination and mappers and SQL server.

To run this project, clone the repository and open it in Visual Studio or VSCode.

#### Pre-requisite:
	1. NuGet manager
	2. Microsoft.EntityFrameworkCore.SqlServer
	3. Microsoft.EntityFrameworkCore.Design
	4. Microsoft.EntityFrameworkCore.Tools

If those packages didn't add automatically then, from NuGet manager Add those packages to the project, and start the application:
`dotnet watch run`

This project use SQL for database, which works only in LAN environment, you should create a database, and edit the connection string to your preferences. After creating a database name of your choice, run from the root of your project:
`dotnet tool install --global dotnet-ef`
`dotnet ef migrations <name of migration>`
`dotnet ef database update`

The above command runs the migration update to create the database table using the reference in models, since this is a code-first approach. The first value are NULL, to edit the table, right-click the Tables folder in the SSMS, and click on **edit top 200 rows**. To show the db tables, click on **select top 1000 rows**

Since I used swagger, there is no need to use Postman to manipulate HTTP requests. The swagger is utilized with `https://localhost:<port>/swagger/index.html`. Expand the GET method and click on  **Try it out**. To get all items in the database, click on **Execute**.

A row in the database table can be accessed with parameter, for example:
`https://localhost:7163/api/employees?name=brian`

If items in your database is more than 10, you can use pagination:
`https://localhost:7163/api/Employees?pagenumber=1&pagesize=3`

The above URL will show 3 items in page 1. 

To create item, go to swagger, and hit **POST** and **Try it out**. Edit the Json, and execute. If you refresh your database, you can see your table has been updated with your newly created item. To update or edit the item you already created, hit **PUT**. specify the id of the item you want to update the item. Deleteing any item works the same way by specifying id of any item that you want to delete from the database table.

To publish the API to another machine for testing purposes and see if the API is production ready, in visual studio right-click on the root of the project i.e api and select "publish", and select "Folder". Browse where to publish the API, and click on finish, then close. To edit the settings of publish click on **Show all settings** where you can select self-containment and win-x64, then select the connection string you want to use at runtime and migrate during publish. Click on "Publish" to now publish as an app. You can now navigate to the folder that the API is deployed, and run it as an exe file. If you want to test it in another machine you can transfer the published folder to the target machine, and install The .NET Core Hosting Bundle from [https://dotnet.microsoft.com/permalink/dotnetcore-current-windows-runtime-bundle-installer](https://dotnet.microsoft.com/permalink/dotnetcore-current-windows-runtime-bundle-installer) in target machine. Now run the api.exe to run the program. The program runs on `https://localhost:5000`. You can navigate to swagger as instructed above to further test your published API.
