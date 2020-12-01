
This is web api project which helps us to interact with DB.

a) Here I have used sql server as database and name of database is InfoDB.mdf which contains one table CustomerInformation.

b) CustomerInformation Table Info

  i)   Customer ID which is identity column 
  ii)  FirstName which accept 50 character 
 iii)  LastName which accept 50 character   
  iv)  Email which accept 50 character 
   v)  Phone number which accept 10 charterer  
  vi)  status which is boolean to maintain if customer is active or inactive
  
c) For communication between database and webpi I have used EntityFramework Database approach

To Execute application please follow below steps.

1. Open the project with Visual studio. 
2. Framework 4.5 is used to develop this project. 
3. Run the web api project and copy web api url form browser. 
4. Open the Webconfig of mvc project (CustomerDetail) and search for key "WebApiUrl" and replace the copied web api url here. 
     E.g key="WebApiUrl" value="http://localhost:55029/"
5. Once this is done run your mvc project. 
6. Now you can use this application. 
7. Pre-requites: visual studio, framework and sql server installed. 

Note: if possible run both application with administrator rights. 

Please find the git repository link below for mvc project (CustomerDetail).
https://github.com/Rohitesh-Kangle/CustomerDetail.git

