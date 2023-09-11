# Introduction 
Challengue for Movies Management using .NET 6,  Clean Arquitecture, CQRS, MediatR, Identity, Web API with Controllers and other cool stuff. 

# Getting Started

1.	Installation process
- Clone this repo 

- No EF Core 6 Commands
Just run the app because that will run the migrations including seeds and the data will refresh everytime you run the app 

- EF Core 6 commands
we have 2 databases, one for user and roles and the other for the management so is important to use the following commands.

Inside Identity Project: 
  update-database -Context IdentityDbContext

Inside Persistence Project:  
  update-database -Context ChallengeDbContext


- Postman Collection
Click the following URL to have an invite to the workspace:

[Postman Collection](https://app.getpostman.com/join-team?invite_code=f1a9b940eb1a097d9cde362fd9c48e81&target_code=d8bb00a593cd691c120de04346404a0e)



2.	Software dependencies
there are a lot of nugget packages inside the references but to say the most important ones:
- MediatR
- EF Core 6
- EF Core SqlServer
- AutoMapper
- FluentValidation
- Swagger
- ImageSharp
- Token.Jwt
Built with Visual Studio 2022 

3.	Latest releases
This is the v1 with all the functionality and one bonus task of upload image.

4.	API references
This solution uses Swagger so the start page will be the documentation of the API 


# Build and Test

- Postman


Public Workspace:
https://app.getpostman.com/join-team?invite_code=cfbad2c1196ee732f4bcbaa00cc33c5f&target_code=831e6f251aa96a36dbcc8549a8463259

Start with the first request to the last one.

Account
1. RegisterUser - Register the user for step 4 
2. RegisterAdmin - Register the administrator 
3. AuthenticateAdmin - Copy the bearer token for administrator only endpoints
4. AuthenticateUser  - Copy the bearer token for authorization to delete ranking

# Hire me
Linkedin: https://www.linkedin.com/in/robertoflores2790/
my best email: robertoflores2790@gmail.com

 Remember to hire me ;)
