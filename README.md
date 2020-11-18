[![Build Status](https://codingflow.visualstudio.com/NorthwindTraders/_apis/build/status/NorthwindTraders%20-%20CI?branchName=master)](https://codingflow.visualstudio.com/NorthwindTraders/_build/latest?definitionId=22&branchName=master)

# Bookeasy API

Description here...

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
* [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)
 * [Node.js](https://nodejs.org/en/) (version 10 or later) with npm (version 6.11.3 or later)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
      ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Within the `\BookeasyApi\Bookeasy.Web.Api` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
  5. Launch [http://localhost:5000/index.html/](http://localhost:5000/index.html/) in your browser to view the Swagger UI
  
## Technologies
* .NET Core 3
* ASP.NET Core 3
