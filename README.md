# BookStore API

**Explore a book catalog through a focused .NET REST API.**

BookStore API is an ASP.NET Core 8 backend that demonstrates a layered request-to-database workflow. It exposes book endpoints, maps data through DTOs and stores records in SQL Server using Entity Framework Core.

Swagger UI provides an interactive entry point for exploring the API. The repository includes EF Core migrations and five seed books, so a configured database has a small catalog to start with.

## Using the API

After setup, open Swagger, list the seeded books and try price ordering. You can retrieve an individual record by ID or submit a new book with its title, author, price and page count.

The project is backend-only: there is no storefront or customer-facing web interface. Its primary user experience is the Swagger page or an HTTP client.

| Method | Endpoint | Current behavior |
| --- | --- | --- |
| `GET` | `/api/Book` | Lists books as DTOs |
| `GET` | `/api/Book?sort=asc` | Orders by price, low to high |
| `GET` | `/api/Book?sort=desc` | Orders by price, high to low |
| `GET` | `/api/Book/{id}` | Returns a book or HTTP 404 |
| `POST` | `/api/Book` | Adds a book; returns HTTP 200 with a text message |
| `PUT` | `/api/Book?id={id}` | Update route exists; see the known issue below |
| `DELETE` | `/api/Book/{id}` | Removes an existing book; returns a text message |

Only `asc` and `desc` are recognized sorting values, and both apply to price. Other values leave the query without an explicit sort order. Page-count sorting is not implemented in the current repository.

### Book Payload

```json
{
  "name": "The Art of Computer Programming",
  "price": 199.99,
  "author": "Donald E. Knuth",
  "pageCount": 672
}
```

`BookDto` contains these four fields and does not expose the database ID. Newly created records therefore cannot have their IDs discovered through the current list response alone.

## Architecture

```text
HTTP request → BookController → BookService → BookRepository
                                    ↕               ↕
                                AutoMapper     AppDbContext → SQL Server
                                DTO / Entity
```

| Project | Responsibility |
| --- | --- |
| `BookStoreApp/` | ASP.NET Core host, controllers, Swagger and dependency injection |
| `DTOs/` | Request and response shapes |
| `Entities/` | Database entity model |
| `Data/` | EF Core context, seed data and migrations |
| `Repositories/` | Database queries and persistence methods |
| `Services/` | Coordination between controller, mapping and repository |
| `Mapping/` | AutoMapper profiles |

The application registers service and repository interfaces with scoped lifetimes. EF Core queries and persistence calls use asynchronous methods. This is a layered architecture with separate class-library projects; the folder structure alone does not imply a complete production architecture.

## Run Locally

Requirements: .NET 8 SDK, an accessible SQL Server instance and an EF Core 8 CLI tool.

```sh
git clone https://github.com/Tunayblg/BookStoreApi.git
cd BookStoreApi
dotnet restore BookStoreApp/BookStoreApp.csproj
```

Configure `ConnectionStrings:DefaultConnection` for your local SQL Server. For example, in PowerShell with Windows integrated authentication:

```powershell
$env:ConnectionStrings__DefaultConnection = 'Server=localhost;Database=BookStoreDb;Trusted_Connection=True;TrustServerCertificate=True'
```

This example assumes a locally trusted development database. Adjust the server and authentication settings for your environment. Do not commit database passwords.

If `dotnet ef` is not installed, install a version matching the project's EF Core major version:

```sh
dotnet tool install --global dotnet-ef --version "8.*"
```

Apply the existing migrations from the repository root, then start the included HTTPS development profile:

```sh
dotnet ef database update --project Data/Data.csproj --startup-project BookStoreApp/BookStoreApp.csproj
dotnet dev-certs https --trust
dotnet run --project BookStoreApp/BookStoreApp.csproj --launch-profile https
```

Swagger is available at `https://localhost:7146/swagger` under this profile. It is enabled only in the Development environment. The application does not automatically apply migrations at startup.

### Example Requests

```sh
curl "https://localhost:7146/api/Book?sort=asc"
curl "https://localhost:7146/api/Book/1"
```

Use Swagger's request editor to submit the JSON payload above. Mutation responses are text messages rather than the created or updated object.

## Current Limitations

- **Update persistence needs a code fix:** `BookRepository.UpdateAsync` calls itself after marking the entity as modified instead of saving changes. Updating an existing record can recurse indefinitely; treat this endpoint as incomplete.
- The update ID is a query parameter, unlike the GET-by-ID and DELETE routes.
- Deleting a nonexistent ID still produces the controller's success response. The service also returns silently when an update ID is missing.
- The current DTO has no explicit range-validation attributes for price or page count.
- Authentication, pagination and text search are not implemented in the inspected request pipeline.

These details describe the current implementation; this README update does not change endpoint behavior.
