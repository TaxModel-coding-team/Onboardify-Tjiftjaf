![image](./assets/logo.png)

# Welcome to Onboardify
This is the back-end application for TaxModel Onboarding gamification

## Project goal
In collaboration with TaxModel this project aims to digitalize and gamify an Onboarding process.
Since most of this onboarding process was being done manually by someone who would be better off spending their time on other things. Our goal was to make a fun and interactive onboarding system that introduces a new colleague to the company.

This project could be scaled up in the future so it could be used for several different companies. Since this project is a long term pilot transferability is all the more important. 

# Code base
## Repositories

- [Onboardify](https://github.com/TaxModel-coding-team/Onboardify.git)

## Languages and frameworks
**back-end**
- Framework: .NET Core 3.1
- Language: C#
- Working IDE versions: Visual Studio 2019 and newer

**front-end**
- Framework: Angular 12.2.5
- Language: HTML5, CSS, TypeScript, JavaScript

**Deployment**
- Docker

# Getting started
Note that for the software to work a database connection must be made. For instruction how initialize a database please refer to the [Database Initialization](#Database-Initialisation)
For a fresh installation for developers, please make a new directory and clone the repository.
Either by doing it yourself manually or copying the code block below into your Bash or Git Bash enviroment.

```
mkdir Onboardify && cd Onboardify
git clone https://github.com/TaxModel-coding-team/Onboardify.git
```
## Front-end
Make sure to install all required packages for the front-end.
```
npm install
```

You will also need to install the angular CLI and Node.js.
Angular CLI:

```
npm install -g @angular/cli
```
Node.JS:
[Click here to install](https://nodejs.org/en/)


**External tools needed to be installed**

Ngx-cookie-service:

https://www.npmjs.com/package/ngx-cookie-service 
```
npm install ngx-cookie-service
```

Bootstrap:

https://www.techiediaries.com/angular-bootstrap/ 
```
npm install bootstrap
npm install jquey
```

Microsoft Authentication:

https://www.npmjs.com/package/@azure/msal-angular 
```
npm install @azure/msal-angular @azure/msal-browser
```

Bootstrap-icons:

https://icons.getbootstrap.com/
```
npm install bootstrap-icons
```

The application can be run using the following:
```
#The -o will open the front-end in your browser

ng serve -o
```

## Back-end
After cloning the back-end it can be run inside Visual Studio.
Note that this is only a developer enviroment, if you want to run the application in production.
Please pull image from docker hub.

You could also run it without the IDE in the console.
(iis server must be installed)

```
cd \Program Files (x86)\IIS Express
```

```
iisexpress /path:c:\["apppath"]\ /port:["port"] /clr:v2.0
```

If running from Visual Studio please enable running multiple projects at once.
This can be done by moving to the 'solution properties > startup settings' and setting multiple project as start.

## <a name="Database-Initialization">Database Initialization</a>
As a new project working on this software please host a MSSQL server either locally or through fontys services.
Please open the console-package manager inside visual studio under 'View' > 'Console-package manager'.
This empty database can be filled using the following command inside the console-package manager:

```
Add-Migration ['name of migration'] -Context ['DatabaseContext']
```
You can view the Up and Down of the migration in Visual studio to see the made tables and changes.
You can commit these changes by using the following:
```
Update-Database -Context ['DatabaseContext']
```
When the data tables have been made please insert some mockdata or make your own.
After the database initialization complete please change all the connectionstrings in the AppSettings file of each project.

# Contributions
Please refer to the [Contibuting.md](https://github.com/TaxModel-coding-team/Onboardify/blob/main/Contibuting.md) for more information on how to contribute to this project.
