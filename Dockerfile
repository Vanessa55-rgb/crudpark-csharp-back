# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos del proyecto
COPY . ./
RUN dotnet restore "CrudParking.csproj"
RUN dotnet publish "CrudParking.csproj" -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar archivos compilados
COPY --from=build /app/out .

# Configurar puerto para Render
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Variables de entorno para PostgreSQL (Render las gestiona automáticamente)
ENV DOTNET_RUNNING_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "CrudParking.dll"]
