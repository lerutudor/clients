# clients

This application allows you to add customers into a DB using a microservice. Currently you can add only the Name and Email fields for each customer. Notice that the emails are uniq in the system, so if you enter the same email 2 times, the second time will edit the first client that was saved in the system.

1. How to run the application locally
  1.1 First you need to clone the repository locally 
  1.2 You will need Visual Studio 2017 and SQL Server to support the database. Visual studio link https://visualstudio.microsoft.com/vs/community/ and SQL Server https://www.microsoft.com/en-us/sql-server/sql-server-editions-express
  1.3 Open the .sln file vits Visual Studio
  1.4 Create an SQL database and run the script which is found in the ../Infrastructure/Sql Scripts
  1.5 Open the "Application" folder and modify the appsettings.json file to connect to the database you have just created at 1.4
  1.6 Run the application
  
2. To create a request over the application the easiest way would be to get a tool like PostMan (https://www.getpostman.com/)
  2.1 Here is a sample of request for the "/api/Customer/Save" endpoint
   
      {
        "Name" : "Marry",
        "Email" : "christmas@test.com"
      }
