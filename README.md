# Tech challenge API
This project represents the application developed during the Postgraduate of Software Architecture, FIAP - SOAT 7 - Group 41.
Its purpose is to serve a local food (like a restaurant) application, with initial controllers to serve routes to manage products, customers and orders.

### Old Project
This project is a migration from the first version, implemented in Java+Spring. The original project can be accessed here: https://github.com/felipetomm/FIAP-Java-Pos-Tech-Challenge-Api


### Prerequisites
- Docker
- .NET 8
- IDE: VSCode

## Tech Challenge
- [Phase 1](https://github.com/felipetomm/FIAP-Java-Pos-Tech-Challenge-Api)
- [Infrastructure Diagram](https://github.com/felipetomm/FIAP-SOAT-7/blob/main/FIAP-Fase2.drawio.png)
- [K8S Files](https://github.com/felipetomm/FIAP-SOAT-7/tree/main/k8s)
- ~~Postman~~
- ~~Video~~

### Docker
The easiest way to run the project is by using Docker. The `docker-compose.yml` file is already configured to run the
application with all the dependencies.

Just run the following command:
```bash
docker-compose up --build
```

## Documentation
The Swagger interface at the `/swagger` endpoint. 

Example:
```bash
curl http://localhost:8080/swagger
```