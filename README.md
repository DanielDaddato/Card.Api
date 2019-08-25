# Card.Api
RDI test

# Introduction 
This application was made as skill test. The objective is to generate a valid token after insert a cardnumber and validate the token based on card info.

# Publish Application
* To publish application download the project and go to the application folder. 
* Example: "C:\Source\Repos\Card.Api"
then run de command "dotnet publish -c Release"
* This will generate publish files in the path *"<APPLICATION FOLDER>\Card.Api\bin\Release\netcoreapp2.2\publish"*
* You can copy this files to your Application Server.

# Generate an docker image and running on docker
* To generate docker image application download the project and go to the application folder. 
* Example: "C:\Source\Repos\Card.Api"
then run command "docker build --tag card_api:latest C:\Source\Repos\Card.Api\Card.Api\"
* After finish generate image run command "docker run --rm --name card_api -p 80:80 card_api:latest" to create an execute container.
* The application will respond on port 80

# Swagger
* to access swagger just go to http://<DOMAIN>:80/swagger.
* Example: "http://localhost:80/swagger"
  



  
