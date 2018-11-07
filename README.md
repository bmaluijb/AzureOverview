## Welcome to the Azure Overview project!

This project contains the source code of the Azure Overview website (www.azureoverview.com) and accompanies the Pluralsight course: Microsoft Azure Developer: [Creating and Implementing a Detailed Design for Your Solution.](https://app.pluralsight.com/library/courses/microsoft-azure-solution-detailed-design-creating/table-of-contents)

![enter image description here](https://www.pluralsight.com/content/dam/pluralsight/newsroom/brand-assets/logos/pluralsight-logo-vrt-color-2.png)  

You can download a copy of the code and follow along in the course.

The solution consists of:

 - AzureOverview.MVC
	 - This is the website for the Azure Overview website
	 - Technology: ASP.NET Core MVC 2.1	 
 - AzureOverview.Data
	 - This is a class library that contains classes to connect to the database and work with azure services
	 - Technology: 
	 	- Class library (.NET Standard 2.0)
		- Entity Framework Core 2.1
		
This is a very simple solution that consists out of a website (either NationalCookies.MVC or NationalCookies.Forms) that connects to a database and a cache.

Follow the steps below to get this code working:

### Step 1: Create a database
The website needs a database to get information about azure services. The database that we are using is a SQL Server database. This can be one that you install locally or an Azure SQL database that you run in Azure. 

In any case, make sure that you have a SQL Server running that you can access.

### Step 2: Create an Azure Redis Cache
The website needs a Redis Cache to get information about azure services. it first gets it from the database and then populates the cache with this data for performance. The cache that we are using is an Azure Redis Cache. You can find out how to create an Azure Redis cache in my other Pluralsight course: [Microsoft Azure Developer: Implementing Azure Cache](https://app.pluralsight.com/library/courses/microsoft-azure-cache-implementing/table-of-contents)

### Step 3: Change the connection strings
In order for the website to connect to the database, we need to enter the connection strings to the database and the cache.
We do that here:

-  AzureOverview.MVC / appsettings.json
	- Fill in the DBConnection setting with the value of the connectionstring to your SQL Server
	- Fill in the RedisConnection setting with the value of the connectionstring to your Redis Cache
  

That's it! Now, you can run the AzureOverview.MVC project and follow along with the course. 

Thanks for watching and let me know if you have any questions!
