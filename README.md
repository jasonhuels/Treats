# Pierre's Treats

#### _A web appilication for Pierre's treat shop_

#### By _**Jason Huels**_

## Description
_A web application for Pierre's treat shop, where users can see all treats and flavors, but only logged in user's can create, update and delete treats/flavors_

## Specifications

| Behavior | Input | Output|
|---:---|---:---|---:---|


## Setup/Installation Requirements_
* _Clone this repository_
* _Using MySQL:_
    * _CREATE DATABASE pierres-treats;_
    * _USE pierres-treats;_
    * _CREATE TABLE flavors (flavorID int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, description VARCHAR(255));_
    * _CREATE TABLE treats (treatID int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), userID VARCHAR(255));_
    * _CREATE TABLE flavorTreats (flavorTreatID int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, flavorID int(11) DEFAULT '0', treatID int(11) DEFAULT '0')
* _Navigate to the directory_
* _Run "dotnet run" command to open application in the command console_

![ERD](pierres-treats-ERD.png)

## Known Bugs

_N/A_

## Support and contact details

_jasonhuels@yahoo.com_

## Technologies Used

_C#, MySQL, Entity, Identity_

### License

*open source*

Copyright (c) 2019 **_Jason Huels_**