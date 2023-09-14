# Technical Interview Exercise V2

As a user, I want to be able to register an account, login, and manage my personal notes in the application so that I can store and access them anytime.

# Technologies

	•	Backend: .NET Core API
	•	Database: SQL Server
	•	ORM: Dapper
	•	Frontend: VueJS with Axios for HTTP requests
	•	Unit Testing: NUnit
	•	Containerization: Docker

# Folder Structure
<pre>
Technical Interview Exercise V2/
│
├── API/                    # ASP.NET Core Web API files
│
├── DataLayer/              # Data access files (e.g., Dapper repositories)
│
├── BusinessLogicLayer/     # Business logic (services, validators)
│
├── UnitTests/              # NUnit tests (data layer, business logic, API)
│
├── VueFrontend/            # Vue.js frontend application
│
└── Docker/                 # Docker configuration files
</pre>

# Backend: .NET Core API
.NET Core is a cross-platform version of .NET for building websites, services, and console apps. Our API is built using ASP.NET Core, a high-performance, modular framework for building web applications. It offers side-by-side versioning, support for Windows, Linux, and macOS, and a lightweight, high-performance, and modular HTTP request pipeline.

<pre>
A brief outline:
	User Controller:
	◦	POST /users/register: Register a new user.
	◦	POST /users/login: Login user and return a JWT.
	◦	GET /users/me: Get the current user's info (authorized).

	Notes Controller:
	◦	POST /notes: Create a new note (authorized).
	◦	GET /notes: Get all notes for the current user (authorized).
	◦	GET /notes/{id}: Get a specific note by ID (authorized).
	◦	PUT /notes/{id}: Update a specific note by ID (authorized).
	◦	DELETE /notes/{id}: Delete a note (authorized).
</pre>

# Database: SQL Server
Microsoft's SQL Server is a leading relational database management system with a rich feature set, including stored procedures, transaction logging, and ACID compliance. We've chosen it for its strong support for .NET applications and its seamless integration with Docker.

**Database Schema:**
<pre>
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL
);

-- Notes table
CREATE TABLE Notes (
    NoteID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    Title VARCHAR(255) NOT NULL,
    Content TEXT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
</pre>

# Data Layer: Dapper
Dapper is a micro ORM for .NET, offering a lightweight way to map database queries to C# objects. Unlike full ORMs, Dapper grants better performance and control over SQL queries.

**Business Logic Layer:**
<pre>
For simplicity, the business layer will consist of:
	•	Validation checks for the note's title and content length.
	•	Password strength validation during registration.
	•	Verify the ownership of notes before allowing CRUD operations.
</pre>

# Unit Tests: NUnit
NUnit is a widely adopted unit testing framework for .NET. It supports both .NET Framework and .NET Core. Its attributes-based approach simplifies test definition, setup, and teardown.

<pre>
The test scenarios will include the following:
	•	Test user registration (successful, user already exists, weak password).
	•	Test user login (successful, wrong credentials).
	•	Test CRUD operations for notes (creation, read, unauthorized access, updates, deletion).
</pre>

# Front-End: VueJS with Axios
Vue.js is a progressive JavaScript framework used for building interactive web interfaces. It focuses on a declarative approach to building UI and allows developers to compose complex UIs from small, single-purpose components. For handling HTTP requests to our backend, we utilize Axios, a promise-based HTTP client for JavaScript. Axios offers a clean API, error handling, request and response interception, and seamless integration with Vue.js.

# Docker
Docker allows us to package our application with all its dependencies into a standardized unit for development and deployment. This ensures consistency across all environments.

**Getting Started:**
	
**Backend Setup:**
<pre>
◦	Navigate to the API directory.
◦	Run dotnet restore to install the necessary packages.
◦	Run dotnet run to start the server.
</pre>
**Database:**
<pre>
◦	Ensure Docker is running.
◦	From the project root, run docker-compose up to start SQL Server in a Docker container.
</pre>
**Frontend:**
<pre>
◦	Navigate to the VueJS application directory.
◦	Run npm install to install dependencies.
◦	Run npm run serve to start the development server.
•	Running Tests
◦	Navigate to the API directory.
◦	Run dotnet test to execute the NUnit tests.
</pre>


