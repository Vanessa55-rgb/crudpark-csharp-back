# 🚗 CRUDPark – Backend (.NET 8 + PostgreSQL + Docker)

## 🎯 Project Objective
**CRUDPark** is a backend API developed in **.NET 8 (C#)** designed to manage the operations of a parking management system.  
It supports complete CRUD (Create, Read, Update, Delete) functionality for key entities such as vehicles, clients, and parking records.  
The project integrates with a **PostgreSQL** database, running within a **Docker** container and deployed on **Render**.

---

## 🌐 Live Deployment
Access the deployed backend here:  
👉 [https://crudpark-csharp-back.onrender.com](https://crudpark-csharp-back.onrender.com)

---

## ⚙️ Installation & Execution Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/Vanessa55-rgb/crudpark-csharp-back.git
cd crudpark-csharp-back
```

### 2. Configure Environment Variables
Create a file named `.env` or configure your Render environment with:
```
DATABASE_URL=Host=88.99.38.95;Database=postgres;Username=postgres;Password=54235423
PORT=5432
```

### 3. Run with Docker
Build and run the container locally:
```bash
docker build -t crudpark-backend .
docker run -p 8080:8080 --env-file .env crudpark-backend
```

### 4. Run Without Docker (optional)
If you want to run the project directly:
```bash
dotnet restore
dotnet run
```

---

## 🗄️ Database Configuration (PostgreSQL)

**Database Engine:** PostgreSQL  
You can run a local instance using Docker:

```bash
docker run --name crudpark-db -e POSTGRES_PASSWORD=yourpassword -p 5432:5432 -d postgres
```

Then, update your connection string:
```
Host=88.99.38.95;Port=5432;Database=postgres;Username=postgres;Password=54235423;
```

---

## 👥 Team Credits

**Team Name:** crudpark-csharp-back  
**Members:**
- Vanessa Gómez López  
- Santiago Restrepo Arismendy
- Andres Marin

**Team Registration:**  
[https://teams.crudzaso.com](https://teams.crudzaso.com)

---

## 🧩 Technologies Used
- **C# / .NET 8**
- **Entity Framework Core**
- **PostgreSQL**
- **Docker**
- **Render**
