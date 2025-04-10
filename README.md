# Restaurant-Chain-Management-Rest-API

The Restaurant Shop API is a RESTful web service designed to manage restaurant shops, allowing users to add and retrieve details about various restaurant shops.

### Technologies Used

- C# .NET Core 8.0 – Backend development.  
- MySQL – Database engine.  
- MySqlConnector – Direct database connectivity.  
- Swagger – API documentation and testing.

### Architecture & Engineering Choices

The project follows a layered architecture with clear separation of concerns:

**Layers & Responsibilities:**
- **Controller Layer:** Handles HTTP requests, interacts with the service layer for logic processing, and returns structured API responses.  
- **Service Layer:** Implements business logic, manages data persistence through the repository layer, and maintains separation between controllers and data operations.  
- **Repository Layer:** Uses raw SQL queries with MySqlConnector for database interaction, efficiently handles CRUD operations, and optimizes performance with connection pooling.  
- **Common Utilities:** Provides helper methods, validation logic, and defines reusable constants and SQL queries.

### API Endpoints

- `POST /api/restaurantshop/add`: Adds a new restaurant shop with validation.  
- `GET /api/restaurantshop/list`: Retrieves all restaurant shops with an additional `is_open` field.

### Database Setup

The database is manually created using SQL scripts and accessed via MySqlConnector.

To import database table with prepopulated data:

- **Step 1:** Open MySQL Command Line  
- **Step 2:** Run the SQL Script using:  
  ```bash
  SOURCE /path/to/restaurantshopSQL.sql;
  ```

### Install Dependencies

```bash
dotnet add package MySqlConnector
dotnet add package Swashbuckle.AspNetCore
```

Alternatively, if you're using Visual Studio:

- Open the NuGet Package Manager.
- Search for `Swashbuckle.AspNetCore`.
- Install the latest stable version.
- Search for `MySqlConnector`
- Install the latest stable version.

### Configure MySQL Connection in `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;user=root;password=nikhil;database=restaurantshop;port=3306;SslMode=none;Allow User Variables=true"
}
```

### Run the Application

```bash
dotnet restore  # Install dependencies 
dotnet build    # Build the project
dotnet run      # Run the project
```

#### Running in Visual Studio Code:

- Open Visual Studio (2022 recommended).  
- Click "Open a project or solution".  
- Select `RestaurantShop.sln`.

### API Documentation & Testing

Open [https://localhost:7217/swagger/index.html](https://localhost:7217/swagger/index.html) in the browser.  
Use Swagger UI for API calls.

---

### TODOs for Making the API Production-Ready

- Standardize error handling with proper HTTP status codes and structured logging using Serilog.  
- Optimize database performance by adding indexes and using connection pooling.  
- Implement request rate limiting to prevent API abuse.  
- Add caching mechanisms (Redis or in-memory caching) for frequently requested data.  
- Write unit tests for business logic and integration tests for API endpoints.  
- Secure configurations using environment variables or a vault.  
- Implement API versioning to support future changes.

---

### Familiarity with C# & Frameworks

I have experience working with C# .NET Core, MySqlConnector, Entity Framework Core (EF Core), and MySQL, ensuring adherence to best practices in software development. This project is structured with scalability, efficiency, and security in mind.

---

### Note

This project was a task to showcase my SQL skills, so I chose to use MySQL direct connection with MySqlConnector instead of an ORM like Entity Framework. Since it primarily involves CRUD operations, writing raw SQL allows me to demonstrate my understanding of query execution, data mapping, and database interactions without the abstraction of an ORM.

