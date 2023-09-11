## Job Notes API

The Job Notes API is a robust .NET Core solution built on the ASP.NET Core framework, designed primarily for the management and retrieval of job information. This system integrates with a SQL Server database, offering a suite of features for adding, updating, and deleting job records.

### Table of Contents

- [Dependencies](#dependencies)
- [Database Configuration](#database-configuration)
- [Database Context](#database-context)
- [API Endpoints](#api-endpoints)

### Dependencies

- **EntityFrameworkCore**: This is a vital dependency, responsible for all database operations.
- **SQLServer**: Dependency used for database integration.
- **Tools**: Required for migrations and update database.
- **JobNotesAPI.Data**: Within this namespace, you'll find the `JobsDbContext`. This context ensures seamless integration with the database for all CRUD operations.

The API comes with swagger:
- Swagger is an API platform for building and using API just like a postman.


### Database Configuration

appsettings.json contains the connection string:

```json
{
  "ConnectionStrings": {
    "DbConnection": "server=PC;database=JobSearchDatabase;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

Details:
- **Server**: Local machine, identified as "DESKTOP-QU6GPQN".
- **Database**: Name of the Database.
- **Authentication**: The connection is trusted.

### Database Context

The `JobsDbContext` helps us interact with the database. It's based on EntityFrameworkCore's `DbContext` and focuses on the JobInfo data.

```csharp
public DbSet<JobInfo> Jobs { get; set; }
```

### API Endpoints

The JobsController provides the following endpoints:

1. **Get All Jobs**
    - **URL**: `/api/jobs`
    - **Method**: `GET`
    - **Function**: Fetches all jobs that haven't been marked as removed.

2. **Get All Removed Jobs**
    - **URL**: `/api/jobs/get-removed-jobs`
    - **Method**: `GET`
    - **Function**: Displays all jobs marked as removed.

3. **Add Jobs**
    - **URL**: `/api/jobs`
    - **Method**: `POST`
    - **Function**: Create a new job.

4. **Update Jobs**
    - **URL**: `/api/jobs/{id}`
    - **Method**: `PUT`
    - **Function**: Modifies a job's "searched" status.

5. **Restore Removed Jobs**
    - **URL**: `/api/jobs/restore-removed-job/{id}`
    - **Method**: `PUT`
    - **Function**: Reverts the removal status of a job.

6. **Delete Jobs**
    - **URL**: `/api/jobs/{id}`
    - **Method**: `DELETE`
    - **Function**: Marks a job as removed without deleting in database.

7. **Permanently Delete Jobs**
    - **URL**: `/api/jobs/perm-delete/{id}`
    - **Method**: `DELETE`
    - **Function**: Deletes a job from the database permanently.

8. **Get All Searched Jobs**
    - **URL**: `/api/jobs/get-searched-jobs`
    - **Method**: `GET`
    - **Function**: Lists all jobs that are searched.

