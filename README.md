# SuperShop - Product & Category Management

## Overview
SuperShop is a web-based **Product & Category Management system** built with **ASP.NET Core 9**, **Entity Framework Core**, and **Bootstrap 5**.  
It allows managing products, categories, and product features efficiently with a user-friendly interface.  

This project demonstrates full **CRUD operations**, file uploads, dynamic forms, and real-time updates using **AJAX & jQuery**.

---

## Features

### Category Management
- Add, edit, and delete categories.
- Inline validation for category names.
- Prevent deletion of categories that have associated products.
- Dynamic dropdown for selecting or adding a new category while creating/editing a product.
- Confirmation dialogs and toast notifications for success/error messages.

### Product Management
- Add, edit, and delete products.
- Upload product images with preview functionality.
- Set product features (multiple per product).
- Real-time stock and availability management.
- Dynamic category selection with option to add a new category inline.
- Confirmation dialogs and toast notifications.

### UI Enhancements
- Responsive design using **Bootstrap 5**.
- Tooltips for better UX.
- Datepicker for selecting purchase dates.
- Dynamic feature addition/removal in product forms.

---

## Technology Stack
- **Backend:** ASP.NET Core 9, C#, Entity Framework Core
- **Frontend:** Razor Pages / MVC, Bootstrap 5, jQuery 3.6
- **Database:** SQL Server / LocalDb
- **Other:** AJAX, File Upload, Partial Views, Toast Notifications

---

## Setup Instructions

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (or LocalDb)
- Visual Studio 2022 or later

### Steps
1. Clone the repository:
```bash
git clone https://github.com/Sayeed-titan/CoreMVC-SinglePageApplication-MaterDetails-CRUD.git
cd SuperShop
