# BookStore API (.NET 8, EF Core, AutoMapper)

This project is a layered RESTful API for managing books, built with ASP.NET Core 8 and Entity Framework Core. It follows clean architecture principles with clearly separated concerns using folders such as `Entities`, `DTOs`, `Repositories`, and `Services`.

---

## Features

- Retrieve all books with optional sorting (by `Price` or `PageCount`)
- Get book by ID
- Add a new book
- Update an existing book
- Delete a book
- AutoMapper integration for clean DTO–entity mapping
- Seed data with 5 initial books

---

## Sorting

 can sort the books by:

- `price` → ascending (`?sort=price`) or descending (`?sort=price_desc`)
- `pageCount` → ascending (`?sort=pageCount`) or descending (`?sort=pageCount_desc`)


## Sample Book JSON (for POST/PUT)

```json
{
  "name": "The Art of Computer Programming",
  "price": 199.99,
  "author": "Donald E. Knuth",
  "pageCount": 672

 Project Structure Highlights

Entities/
Holds core domain models (e.g., Book). This keeps domain logic isolated from infrastructure.

DTOs/
Prevents exposing internal models in API responses or requests. Essential for secure and clean APIs.

Repositories/
Encapsulates database operations. Promotes testability and maintains separation from business logic.

Services/
Contains business rules and handles interactions between repositories and controllers.

Mapping/
Includes AutoMapper configuration for DTO <-> Entity mapping. Keeps mapping logic centralized.

This structure is highly scalable and prepares the codebase for adding validation, authentication, or additional entities in future projects.