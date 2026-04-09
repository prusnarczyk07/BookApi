# Book API

A simple Web API for managing books. Supports creating, reading, updating, deleting books, with sorting, filtering, and pagination.

---

## Technologies

- .NET 10  
- Entity Framework Core  
- SQL Server  
- Scalar for testing API

---

## Endpoints

- **GET /api/books** – get books (returns first page by default, supports pagination)
  - Optional query parameters:  
    - `sortBy=title|author` – sort results  
    - `genre=Fantasy` – filter by genre  
    - `search=Nineteen` – search by part of the title  
    - `page=0&pageSize=10` – pagination  

- **GET /api/books/{id}** – get book by ID  
- **POST /api/books** – add new book  
- **PUT /api/books/{id}** – update book by ID  
- **DELETE /api/books/{id}** – delete book by ID  

### Helper endpoints
- GET `/api/books/genres` – list of unique genres  
- GET `/api/books/authors` – list of unique authors  

---

## Validation

- All fields required (`[Required]`)  
- String length limits (`[StringLength]`)  
- Year range validation (`[Range]`)   

---

## How to run

1. Open the project in Visual Studio or via terminal:
   ```bash
   dotnet run
   ```

2. Open Scalar to test the API:
http://localhost:PORT/scalar/

3. Use the endpoints as documented above:
- GET, POST, PUT, DELETE via Scalar
- Add query parameters for sorting, filtering, and pagination where supported
1. Open project in Visual Studio or run in terminal:  
   ```bash
   dotnet run
