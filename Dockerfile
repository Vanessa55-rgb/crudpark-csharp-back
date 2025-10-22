# Imagen base oficial de .NET 8 SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copiar archivos del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Imagen final con solo el runtime de ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./

# Establecer variable de entorno para el puerto
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "CrudParking.dll"]
