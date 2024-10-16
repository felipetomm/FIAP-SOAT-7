# Tech challenge API
This project represents the application developed during the Postgraduate of Software Architecture, FIAP - SOAT 7.
Its purpose is to serve a local food (like a restaurant) application, with initial controllers to serve routes to manage products, customers and orders.

### Old Project
This project is a migration from the first version, implemented in Java+Spring. The original project can be accessed here: https://github.com/felipetomm/FIAP-Java-Pos-Tech-Challenge-Api

### Prerequisites
- Docker
- .NET 8
- IDE: VSCode

## Tech Challenge
- [Phase 1 (in Java)](https://github.com/felipetomm/FIAP-Java-Pos-Tech-Challenge-Api)
- [Application Diagram](https://github.com/felipetomm/FIAP-SOAT-7/blob/main/FIAP-Fase2.drawio.png)
- [Infra/K8S Diagram](https://github.com/felipetomm/FIAP-SOAT-7/blob/main/FIAP-Fase2-k8s-infra.drawio.png)
- [K8S Files](https://github.com/felipetomm/FIAP-SOAT-7/tree/main/k8s)
- [Postman Collection and Environment](https://github.com/felipetomm/FIAP-SOAT-7/tree/main/postman)

### Docker
The easiest way to run the project is by using Docker. The `docker-compose.yml` file is already configured to run the
application with all the dependencies.

Just run the following command:
```bash
docker-compose up --build
```

Rember to configure your own `.env` file. See the example file `.env-example`.

## Documentation
The Swagger interface at the `/swagger` endpoint. 

Example if you run under docker:
```bash
curl http://localhost:8080/swagger
```