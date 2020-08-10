| URI                       | Verb   | Operation | Description               | Success                | Failure                        |
|---                        |---     |---        |---                        |---                     |---                             |
| /api/transactions/        | GET    | READ      | Read all resources        | 200 OK                 | 400 Bad Request, 404 Not Found |
| /api/transactions/{id}    | GET    | READ      | Read single resouce       | 200 OK                 | 400 Bad Request, 404 Not Found |
| /api/transactions/        | POST   | CREATE    | Create a new resource     | 201 Created            | ...                            |
| /api/transactions/{id}    | PUT    | UPDATE    | Update an entire resource | 204 No Content         | ...                            |
| /api/transactions/{id}    | PATCH  | UPDATE    | Update partial resource   | 204 No Content         | ...                            |
| /api/transactions/{id}    | DELETE | DELETE    | Deletes a singel resource | 200 OK, 204 No Content | ...                            |