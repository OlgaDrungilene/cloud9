# ☁️ Cloud9 Restaurant Booking System

Fullstack restaurant booking and menu system built with **React + .NET + PostgreSQL**.

The system allows customers to:
- View menu
- Book tables

And allows admins to:
- View bookings
- Assign / unassign tables
- See table availability in real time
- Automatically release expired bookings
- Automatically clean old bookings

---

## 🚀 Tech Stack

### Frontend
- React
- React Router
- CSS Modules
- Fetch API

### Backend
- .NET Minimal API
- Entity Framework Core
- PostgreSQL
- Swagger

---

## 📦 Features

### 👤 Customer
✅ Book table  
✅ Validation  
✅ Booking notes (allergies / requests)  

---

### 🛠 Admin
✅ View all bookings  
✅ Assign table  
✅ Unassign table  
✅ Filter bookings (Assigned / Unassigned)  
✅ Filter tables (Available / Taken)  

---

### 🤖 Automation
✅ Auto release table after 3 hours  
✅ Auto delete booking after 24 hours  
✅ Time window conflict protection  
✅ Availability per booking time  

---

## ⏱ Booking Logic

### Table Release
Tables are automatically released:
BookingTime+3 hours

---

### Booking Deletion
Old bookings are deleted after:
BookingTime+24 hours

---

### Conflict Protection
Table cannot be assigned if another booking exists in:
BookingTime ± 3 hours


---

## 🧠 Admin Table Availability Logic

Tables are available if:
No booking exists within booking time window

---

## 🛠 Installation

### 1️⃣ Clone repo
```bash
git clone https://github.com/yourusername/cloud9.git
cd cloud9

### 2️⃣ Backend Setup
- cd backend
- dotnet restore
- dotnet ef database update
- dotnet run

Backend runs on:
http://localhost:5077
Swagger:
http://localhost:5077/swagger

### 3️⃣ Frontend Setup
cd frontend
npm install
npm start
Frontend runs on:
http://localhost:3000

## 🗄 Database
PostgreSQL is used.
Connection string example:
"DefaultConnection": "Host=localhost;Database=cloud9;Username=postgres;Password=yourpassword"

## 📁 Project Structure
cloud9
│
├ backend
│ ├ Data
│ ├ Models
│ ├ Program.cs
│
├ frontend
│ ├ components
│ ├ pages
│ ├ services
│

## 🔐 Admin Access
Admin page:
/admin

Accessible via:
- Footer admin link
- Direct URL

## 🎨 UI / UX

- Dark theme optimized
- Responsive admin dashboard
- Accessible booking form
- Status indicators for tables
- Real-time table state display

## ♿ Accessibility

Basic accessibility implemented:
- Labels connected to inputs
- Keyboard accessible buttons
- Color contrast optimized for dark UI
- Focus states for inputs and buttons

## Future Improvements

- Email booking confirmation
- Authentication for admin
- Calendar view for bookings
- Table layout visualization
- Availability search for customers
- Booking editing
- Multi-day reservation support

## 👩‍💻 Author

Olga Drungilene
Fullstack Developer (.NET + React)
UX/UI focused

## 📜 License
This project was created for educational purposes.

You are free to view and learn from the code.
Commercial use is not permitted without permission from the author.

© 2026 Olga Drungilene

