# Estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia os arquivos do projeto
COPY src/FIAP.Application/. ./src/FIAP.Application/
COPY src/FIAP.Domain/. ./src/FIAP.Domain/
COPY src/FIAP.ExternalService.WebAPI/. ./src/FIAP.ExternalService.WebAPI/
COPY src/FIAP.Infrastructure.CrossCutting/. ./src/FIAP.Infrastructure.CrossCutting/
COPY src/FIAP.Infrastructure.Data/. ./src/FIAP.Infrastructure.Data/
COPY src/FIAP.Infrastructure.IoC/. ./src/FIAP.Infrastructure.IoC/
COPY src/FIAP.Presentation.API/. ./src/FIAP.Presentation.API/
#COPY *.csproj ./
#COPY *.cs ./
#COPY *.json ./

# Publica a aplicação
RUN dotnet publish ./src/FIAP.Presentation.API/FIAP.Presentation.API.csproj -c Release -o /app

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Adiciona os certificados do Reinf no Container
RUN update-ca-certificates -f

# Copia os arquivos publicados do estágio de construção
COPY --from=build /app .

# Copia os sqls para as migrations
COPY ./sql/.                  /app/sql

# Define o usuário, se necessário (verifique se $APP_UID está definido)
USER $APP_UID

# Expor as portas
EXPOSE 8080/tcp
ENTRYPOINT [ "dotnet", "FIAP.Presentation.API.dll" ]