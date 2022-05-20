# challenge

This project contains the test cases created for a challenge.
These test cases are created in C # with Gherkin language (Specflow), using selenium web driver and chrome as a browser.
 
 Tools and libraries used for creation:

    *VB C#

    *Specflow

    *Selenium

    *Chrome driver

    *NUnit



## Requirements 📋

_1.- Dotnet 3.1..... for install_

        Windows -------->  https://dotnet.microsoft.com/en-us/download/dotnet/3.1

        Linux ---------->  apt-get install -y dotnet-runtime-3.1 dotnet-sdk-3.1


## Execution test cases 🛠️

This instructions are for execution into your machine

_1.- Clone the project into your machine_

    git clone https://github.com/AbrahamGalindo/Projects.git
   
_2.- Go to project path_

    cd Projects/Challenge
   
_3.- Execution build for the project_

    dotnet build Challenge.sln
    
_4.- Execution test cases_

    All TCs
    dotnet test Challenge.sln

    Item TCs
    dotnet test Challenge.sln --filter TestCategory="item" --logger:"console;verbosity=detailed"





## Authors ✒️

* **Abraham Galindo** *