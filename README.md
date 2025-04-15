# TSG

Full stack web application using ASP.NET and React

## Run

```sh
docker-compose up --build
```

http://localhost:5173/

## Endpoints

- `POST /api/forms` - receives data, saves it and returns a PDF

  ```json
  {
    "nume": "string",
    "prenume": "string",
    "facultate": "string",
    "motivatie": "string"
  }
  ```

- `GET /api/forms/{id}` - returns a form in JSON format

- `GET /api/test` - returns a "Hello World!"
