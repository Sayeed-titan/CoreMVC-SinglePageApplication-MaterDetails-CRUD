# 🛍️ CoreSPA — Product & Category Management

[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet)](https://dotnet.microsoft.com/) 
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?logo=bootstrap)](https://getbootstrap.com/) 
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?logo=nuget)](https://learn.microsoft.com/en-us/ef/core/)  

CoreSPA is a web-based **Product & Category Management system** built with **ASP.NET Core 9**, **Entity Framework Core**, and **Bootstrap 5**.  
It enables efficient management of products, categories, and product features through a **modern, responsive, and user-friendly interface**.  

This project demonstrates:
- Full **CRUD operations**  
- File upload with image preview  
- Dynamic forms & Master–Details pattern  
- Real-time updates using **AJAX & jQuery**  

🎥 **Demo Video**  
[![Play Demo](https://img.youtube.com/vi/Zgm7d92aWhk/hqdefault.jpg)](https://www.youtube.com/watch?v=Zgm7d92aWhk)

---

## 🚀 Features

### 📂 Category Management
- ➕ Add, ✏️ edit, and ❌ delete categories  
- Inline validation for category names  
- Prevent deletion of categories linked with products  
- Dynamic dropdown for category selection while creating/editing a product  
- Confirmation dialogs + toast notifications for user feedback  

### 📦 Product Management
- CRUD operations for products  
- Image upload with preview thumbnail  
- Assign multiple **product features** per product  
- Manage stock & availability in real-time  
- Inline category creation during product entry  
- Confirmation dialogs + toast notifications  

### 🎨 UI Enhancements
- Fully **responsive design** with **Bootstrap 5**  
- Tooltips for improved UX  
- Datepicker for purchase date selection  
- Dynamic feature rows (add/remove)  

---

## 🛠️ Tech Stack

- **Backend:** ASP.NET Core 8 (C#), Entity Framework Core  
- **Frontend:** Razor Pages / MVC, Bootstrap 5, jQuery 3.6  
- **Database:** SQL Server / LocalDb  
- **Other:** AJAX, File Upload, Partial Views, Toast Notifications  

---

## ⚙️ Setup Instructions

### 📋 Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- SQL Server (or LocalDb)  
- Visual Studio 2022 or later  

### 🏗️ Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Sayeed-titan/CoreMVC-SinglePageApplication-MaterDetails-CRUD.git
   cd CoreSPA


Update the connection string in appsettings.json for your SQL Server instance.

Apply EF Core migrations:

dotnet ef database update


Run the project:

dotnet run


Open in browser:

https://localhost:7008


---

### 🔑 Key Rules for Markdown
- Always **open and close** triple backticks (```) for code blocks.  
- Keep your steps (`1. 2. 3.`) outside of code fences.  
- Use indentation only for code, not for text instructions.

---

👉 So the problem wasn’t HTML at all — it was just missing closing backticks in your code block.  

Do you want me to take your **entire README draft** and give you one **fully corrected Markdown file** (ready to paste on GitHub without breaking anywhere)?
