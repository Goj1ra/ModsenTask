# ModsenTask
This is a Web-API project written in C# using the ASP.NET Core framework. This project aims to provide a simple and scalable way to build RESTful APIs.

Installation
To run this project, you need to have .NET Core SDK installed on your machine. Once you have the SDK installed, clone this repository to your local machine using:

bash
Copy code
git clone https://github.com/your-username/your-repository.git
After cloning the repository, navigate to the project directory using:

bash
Copy code
cd your-repository
Usage
To start the API server, run the following command from the project directory:

arduino
Copy code
dotnet run
By default, the API server will start on port 5000. You can access the API at http://localhost:5000.

Endpoints
This API currently has the following endpoints:

GET /api/values
This endpoint returns a list of sample values.

Example response:

css
Copy code
["value1", "value2", "value3"]
POST /api/values
This endpoint adds a new value to the list of sample values.

Example request:

json
Copy code
{
  "value": "new value"
}
Example response:

json
Copy code
{
  "value": "new value"
}
Contributing
Contributions to this project are always welcome. If you find a bug or have a feature request, please create an issue on this repository.

License
This project is licensed under the MIT License - see the LICENSE file for details.
