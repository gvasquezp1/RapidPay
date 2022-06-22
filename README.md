# RapidPay
First Steps - Configuration Database

1-Configure your SQL Server Database with the file :appsettings.json 

  "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR SERVER;Database=YOUR DATABASE;Trusted_Connection=True;"
    },

   After that you setup the database connection , you can add the tables with the following sentence in the Package Manager console
  ![image](https://user-images.githubusercontent.com/56619750/175122014-8c4c6eb1-077c-4cfb-8429-fb06aa9e725c.png)

   add-migration InitialCreate

   when the console show "Build succeeded."

   write now the following sentence :

   update-database

2-Now you can see that there is a new database created 

![image](https://user-images.githubusercontent.com/56619750/175122423-602c4e92-e7c9-4e41-9d24-c755032149da.png)

 
Documentation about API

Is a system that allow to manage the credits card and payments with a specific fees per day
Api documentation with Swagger

![image](https://user-images.githubusercontent.com/56619750/174387173-4a80b668-ae5f-4bae-bb6e-3e7862a45b12.png)

Generate token to access API with JWT

![image](https://user-images.githubusercontent.com/56619750/174387437-32bb5c30-ac15-441c-9fad-ea6e69348dfd.png)

Generating ramdom fee
![image](https://user-images.githubusercontent.com/56619750/174389385-07978721-fdcd-4197-94a0-efbc8d7166f4.png)

Result ramdon fee
![image](https://user-images.githubusercontent.com/56619750/174389451-b69ae3b5-5c6c-4a60-a2c4-469199a1089d.png)

Payment with fee
![image](https://user-images.githubusercontent.com/56619750/174390116-7e9a9c34-e27b-4774-ad01-079624db247b.png)






