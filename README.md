# GymWebApp

A gym management web application built with ASP.NET Core MVC that allows administrators to manage trainings, trainers, offers, and user reservations. The system supports CRUD operations, AJAX-based actions, and role-based access control to separate administrator and user functionalities.

---

## Features

### Authentication & Authorization
- User registration and login with ASP.NET Identity.
- Role-based access:
  - Administrator – manage offers, trainings, trainers, and reservations.
  - User – book trainings, view available offers, and manage their own reservations.

### Training Management
- Create, edit, update, and delete trainings.
- Assign multiple trainers to each training.
- Track duration, description, start date/time, and capacity.

### Trainer Management
- Manage trainer profiles including name, description, and profile image.
- Link trainers to one or more trainings.

### Reservation System
- Users can reserve a spot for a training.
- Admin can approve or reject reservations.
- Reservation status tracking: Pending, Approved, Rejected.

### Offer Management
- CRUD operations for promotional offers.
- AJAX-based create, edit, and delete without page reload.
- Pagination for better offer browsing.

---

## Technologies Used
- ASP.NET Core MVC – backend & routing
- Entity Framework Core – ORM for database management
- SQL Server – relational database
- ASP.NET Identity – authentication & authorization
- jQuery & AJAX – for dynamic front-end interactions
- Bootstrap 5 – responsive UI components

---

## Getting Started

### 1. Clone repository
```bash
git clone https://github.com/yourusername/GymWebApp.git
cd GymWebApp
