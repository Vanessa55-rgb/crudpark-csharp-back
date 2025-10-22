# 🏁 CrudParking Backend

This repository contains the backend service for **CrudParking**, a parking management system built with **ASP.NET Core** and **PostgreSQL**.  
It provides a RESTful API to handle vehicle entries, exits, users, and parking records efficiently.

---

## 🎯 Project Objective

The goal of this project is to offer a simple and scalable backend for managing parking operations — including vehicle registration, parking time tracking, and fee calculation — using a clean architecture and modern .NET tools.

---

## ⚙️ Installation & Execution

### 🧩 Prerequisites
Make sure you have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL 14+](https://www.postgresql.org/download/)
- [Render](https://render.com/) 
- [Git](https://git-scm.com/)

### 🔽 Clone the repository
```bash
git clone https://github.com/Vanessa55-rgb/crudpark-csharp-back.git
cd crudpark-csharp-back
```

### 📦 Install dependencies
```bash
dotnet restore
```

### ⚙️ Set up environment variables
Create a file named `.env` or set environment variables manually in your system.  
For local development, use the `appsettings.Development.json` file to store your configuration.

Example connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=88.99.38.95;Port=5432;Database=postgres;Username=postgres;Password=54235423"
}
```


### ▶️ Run the project
```bash
dotnet run
```

Once started, the API will be available at:
```
http://localhost:5000
```

You can test it by visiting:
```
http://localhost:5000/home
```

---

## 🗄️ Database Configuration (PostgreSQL)

1. Create a new PostgreSQL database:
   ```sql
   CREATE DATABASE crudparking;
   ```
2. Update your connection string in `appsettings.json` or your environment.
3. Run migrations (if available):
   ```bash
   dotnet ef database update
   ```

---

## 🔁 General Usage Flow

1. **Start the API** using `dotnet run`.
2. **Frontend** or Postman consumes the API endpoints under `/api/...`.
3. Example routes:
   - `GET /home` → Check if the backend is online.
   - `GET /vehicles` → Retrieve all registered vehicles.
   - `POST /vehicles` → Add a new vehicle.
   - `PUT /vehicles/{id}` → Update vehicle info.
   - `DELETE /vehicles/{id}` → Remove a vehicle.
4. The system interacts with the **PostgreSQL** database to store all records.

---

## 👥 Credits

- **Team:** Java_C#
- **Developers:**
  - Andres Marin
  - Santiago Restrepo Arismendy 
  - Vanessa Gomez Lopez

🔗 **Team registration:** [https://teams.crudzaso.com](https://teams.crudzaso.com)


---

## 🧠 Technologies Used

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- C#
- RESTful API Architecture

---

## 🧩 License

This project is open source
