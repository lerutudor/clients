# clients

This application allows you to add customers into a in-memory DB using a microservice. Currently you can add only the Name and Email fields for each customer. Notice that the emails are uniq in the system, so if you enter the same email 2 times, the second time will edit the first client that was saved in the system.

<p>1. How to run the application locally</p>
  <p>1.1 First you need to clone the repository locally </p>
  <p>1.2 You will need Visual Studio 2017. Visual studio link https://visualstudio.microsoft.com/vs/community/</p>
  <p>1.3 Open the .sln file vits Visual Studio</p>
  <p>1.4 Run the application</p>
  
<p>2. To create a request over the application the easiest way would be to get a tool like PostMan (https://www.getpostman.com/)</p>
  <p>2.1 Here is a sample of request for the "/api/Customer/Save" endpoint</p>
   
      {
        "Name" : "Marry",
        "Email" : "christmas@test.com"
      }
