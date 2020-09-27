# Web Scraper
Web Scraper allows the user to see the frequency of occurence of a specific url when certain keywords are searched using Google and Bing. For sake of simplicity, static HTML pages are used for search results. This application is developed using .NetCore 3.1, React and Typescript

## Project Structure

### Core
This project contains the core logic of the application. It consists of a web service which invokes the method of counting the number of occurences of a certain term in search results.

### Infrastructure
This project consists of different classes used to perform the web scraping.

### WebAPI
This project consists of the Web API which invokes the web service from Core to perform web scraping

#### Web API / ClientApp
This is the user interface of the application which is developed using React and Typescript

## Running the application
This application is developed using .Net Core 3.1, React and Typescript. To run this application
 - Install [.Net Core](https://dotnet.microsoft.com/download/dotnet-core/3.1)
 - Install the latest version of [Node.js](https://nodejs.org/en/download/)

 - To install the nuget packages, navigate to following directory
```
src
```
and execute following command
```
dotnet restore
```

- To install the dependencies for React application, navigate to following directory
```
src/WebAPI/client-app
```
and execute following command
```
npm install
```
- When installation of npm packages is complete, navigate to following directory
```
src/WebAPI
```
- Now execute following command
```
dotnet run
```
Both Web API and the client application will be running now. To access the website, browse to following url
```
https://localhost:5001
```

## Running the tests
To run the tests included for this project, navigate to `src/tests` and execute following command
```
dotnet test
```