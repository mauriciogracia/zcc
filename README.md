# Zip Code Distance Calculation

## Simple Architecture Diagram

<img src="Architecture.jpg" alt="ZipCodeCalculation arquitecture diagram" style="height: 300px"/>

**ZipCodeCalculation** is a `C#` Console application that reads the `ZipCodes.csv` and stores the data into a `MongoDB docker` image in a database called `cities-mdb`

1. How to run Console application (include screen shot)
   -NET version

    - input validation (when empty input it asks again...)

    Steps

    - docker pull mongo
    - docker run -d -p 27017:27017 --name cities-mdb mongo
    - docker exec -it cities-mdb /bin/bash
    - mongosh
    - use clients-db
    - db.createCollection('Cities')

2. How to run Website (react asp.net)
    - React + Netversion
