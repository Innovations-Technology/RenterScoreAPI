# Renter Score API

Rental Score backend service

## Prerequisites

- .NET 8.0 SDK
- A text editor or IDE (Visual Studio Code, Visual Studio, etc.)

## Running the Project

1. Clone the repository
2. Navigate to the project directory
3. Run the following command:

- To run the project locally:
```bash
dotnet run
```

- To run using Docker Compose:
```bash
docker compose up --build
```

To stop the service:
```bash
docker compose down
```
OR
```
ctrl + c
```

## Testing the Project

### Integration Testing

1. Run the Api project.
2. Run the integration testing with the command:
```bash
dotnet test
```


## Endpoints

The service will start on:
- HTTP: http://localhost:5135
- HTTPS: https://localhost:7192

### Available Endpoints:

- Health Check: 
  - GET http://localhost:5135/health
  - Returns 200 OK with "ok" message

### Swagger Documentation

Swagger UI is available at:
- HTTP: http://localhost:5135/swagger
- HTTPS: https://localhost:7192/swagger

## SSL Certificate (Development)

If you see any SSL certificate errors when using HTTPS, you need to trust the development certificate. Run the following command:
```bash
dotnet dev-certs https --trust
```
