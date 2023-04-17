# Zip Code Calculation - ZCC

## Architecture Diagram

<img src="Architecture.jpg" alt="ZipCodeCalculation arquitecture diagram" style="height: 200px"/>

This solution has two projects:

**ZipCodeCalculation** is a `C#` Console application that reads the `ZipCodes.csv` and stores the data into a `MongoDB docker` image in a database called `cities-mdb`

**WebSite** is a ASP.NET + react website, currently is just a form to input the zipcodes but is not using the logic from `ZipCodeCalculation`

## Requirements

### Console

-   .NET CORE 3.1 Runtime
-   Docker

### Website

-   .NET 6.0 Runtime
-   React

## Environment Setup

To prepare the Docker image Run these commands from a commandline (CMD, Powershell, dont use gitbash since step 3 will fail)

1. Make sure the docker dameon is running (Windows run `Docker Desktop`, Linux run `dockerd`)
1. `docker pull mongo`
1. `docker run -d -p 27017:27017 --name cities-mdb mongo`
1. `docker exec -it cities-mdb /bin/bash`
1. `mongosh`
1. `use clients-db`
1. `db.createCollection('Cities')`

## How to run Console application


1. Make sure the docker instance created above is still running
1. Go to the `zcc/ZipCodeCalculation`
1. `dotnet build`
1. `dotnet run`
   <br />

    Running the console application look like this <br />
    <img src="ConsoleSS.png" alt="ZipCodeCalculation console output" style="height: 200px"/><br />
    When the calculation is done you can try another one by pressing `y`

    The zipcode is validated to check for empty and non numeric values, <br />
    <img src="ConsoleSS_02.png" alt="ZipCode validation" style="height: 200px"/>

## How to run Website (react asp.net)

    - React + Netversion
