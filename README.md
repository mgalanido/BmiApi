# Bmi Web Api

**Overview:**
A .NET Web API application designed to calculate the Body Mass Index (BMI) based on user-provided input parameters. It exposes a POST endpoint that accepts height (in centimeters) and weight (in kilograms) as input. Using these parameters, it computes the BMI and categorizes it according to standard BMI Categories.

**Prerequisites**
* .NET SDK (version 6.0 or later)
* Postman (for API Testing)

**Building and Running the BMI API Project**
1. Unzip the BmiApi.
2. Open the solution in your Visual Studio or Visual Code based on your preference.
3. From your Terminal, restore Dependencies by command: `dotnet restore` (Ensure you are at BmiApi folder)
4. Build the project using the command: `dotnet build`
5. Run the project using the command: `dotnet run`
6. Test the project with Unit Test using the command: `dotnet test`

**Using the Postman Collection**
1. Open Postman on your computer.
2. Click on the "Import" button in the top left corner or press Ctrl + O
3. Choose the "File" tab then select the postman collection JSON file included in this folder.
4. Click Import to load the collection.
5. Navigate to the newly imported collection in the left sidebar of Postman
6. Click "Send" to execute the request and view the response. (Ensure that the BmiApi is currently running)
7. You can change the request body by clicking the Body tab and add the necessary height or weight value.
