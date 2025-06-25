# Sticker Shop Management System (StickerShopCMS)

This is a .NET Web API project to manage stickers, inventory, and sales for a small shop. It includes full CRUD functionality and tracks product stock through sales and inventory updates.

## Overview

The project simulates how a sticker store might manage its inventory and sales using a structured backend system. It focuses on:

- Managing product details
- Adding inventory for products
- Recording sales and sale items
- Automatically updating available stock
- Adding products

## Technologies Used

- **.NET 7** - Backend API framework  
- **Entity Framework Core** - For database access  
- **MySQL** - Relational database  
- **Swagger** - For testing and viewing API endpoints  

## Project Layers

- `Models/`  
  Contains entity classes `Product`, `Inventory`, `Sale`, and `SaleItem` that represent the database tables.

- `DTOs/`  
  Used to define what data is sent and received in API requests and responses, separate from internal models.

- `Services/`  
  Handles business logic like updating stock levels, calculating available quantities, and saving new records.

- `Controllers/`  
  Defines API routes for products, sales, inventory, and sale items. Calls services to perform actions.

- `Data/`  
  Contains `AppDbContext` for managing database access through Entity Framework.

## Challenges Faced

It was challenging to ensure accurate stock tracking by subtracting sold quantity from latest stock level

Fixed database relationships between Sale and SaleItem using foreign keys - was super confusing!

Cleaned up test data and switched to auto-increment for better ID control

