# BookStore API

**A focused REST API for managing your book catalog.**

Create, browse, update and remove book records with a layered ASP.NET Core 8 API. SQL Server stores the catalog, Entity Framework Core handles data access, and AutoMapper maps between entities and DTOs.

## Features

- List books and sort by price or page count, ascending or descending
- Retrieve an individual book by ID
- Create, update and delete book records
- Map request and response DTOs with AutoMapper
- Start with five seeded book records

## Tech Stack

C# · ASP.NET Core 8 · Entity Framework Core · Microsoft SQL Server · AutoMapper

## Sorting

Use the `sort` query parameter when listing books:

| Order | Query |
| --- | --- |
| Price: low to high | `?sort=price` |
| Price: high to low | `?sort=price_desc` |
| Page count: low to high | `?sort=pageCount` |
| Page count: high to low | `?sort=pageCount_desc` |

## Example Book Payload

Use this JSON shape when creating or updating a book:

```json
{
  "name": "The Art of Computer Programming",
  "price": 199.99,
  "author": "Donald E. Knuth",
  "pageCount": 672
}
```

## Project Structure

| Folder | Responsibility |
| --- | --- |
| `Entities/` | Book data models |
| `DTOs/` | Request and response data shapes |
| `Data/` | Database context and data configuration |
| `Repositories/` | Database operations |
| `Services/` | Application logic between controllers and repositories |
| `Mapping/` | AutoMapper profiles for entities and DTOs |
