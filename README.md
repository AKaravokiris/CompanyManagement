# CompanyManagement
CODING TEST - ASP.NET MVC / C#

the App contains 5 solutions

1) console tester
For testing Dal BLL without the use of web app.
(this is not  unit testing).

2)Common
In here are all the necessesary classes and interfaces , which  DAL ,BLL, and webAPP 
can use as guide for their implementation.

3)DAL - Data Access Layer
this dll is used for the communication of the BLL with the DB using entity framework and 
repository pattern.

4)BLL - Business Logic Layer
this Dll is used to translate the method calls of business to calls for entity framework.

5)WebApp
the Main solution of the App , it uses mvc , it inherits models from Common.dll
based on them Views were created. The controllers to fill the models with data, call 
BLL.dll which calls DAL.dll to get the data from db.

To run clone the repo , build all solutions with this order (Common, DAL, BLL, WebAPP)
change path references to where your dlls are build.
the App was run with sqlexpress and sql default local db. For the webApp a simple IIS express was used
for debbuging and running purposes.

