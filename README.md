# Lab_7
In order to run this code, users will need to
1) restore the SRSDB database using SQL Server Management Studio
2) open visual studio and click "Open a project or solution"
3) open our project folder and click on "SRSWebApplication.sln"
4) once the project has opened, right click on Data Connections on the left hand side and click "Add Connection"
5) connect to the SRSDB
6) find the string "<add name="SRSDBEntities" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=OMEN;initial catalog=SRSDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />" in the Web.config file
7) change "data source=OMEN" to "data source= ENTER_YOUR_SERVER_NAME_HERE"
8) click the play button/run the project & see the working website! 


