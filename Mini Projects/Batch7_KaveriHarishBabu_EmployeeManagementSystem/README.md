# 🛡️ EMS Portal - Employee Management System

![Live Demo Badge](https://img.shields.io/badge/Live%20Demo-Available-success?style=for-the-badge)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)

A modern, fully responsive Single Page Application (SPA) for managing workforce data. Built with a focus on clean UI/UX, this dashboard allows administrators to efficiently track, add, edit, and analyze employee records.

🚀 **[View Live Deployment Here]([https://employee-management-system-harishbabu.netlify.app/])**

---

## 📸 Screenshots

*(Replace these placeholder links with your actual image paths once uploaded)*

| Dashboard View | Employee Directory |
|:---:|:---:|
| <img src="screenshots/dashboard.png" width="400" alt="Dashboard View"> | <img src="screenshots/employees.png" width="400" alt="Employees View"> |

---

## ✨ Key Features

* **Interactive Dashboard:** Real-time KPI counters (Total, Active, Inactive employees), visual department breakdown bars, and a quick-view list of recently added staff.
* **Full CRUD Operations:** Seamlessly Create, Read, Update, and Delete employee profiles via intuitive Bootstrap modals.
* **Smart Data Table:** Sortable columns (by Name, Salary, Join Date, etc.).
  * Real-time search filtering by name or email.
  * Filter by Department or Status (Active/Inactive).
  * Auto-generated, color-coded user avatars based on employee ID.
* **Secure Authentication:** Mock Admin Login/Signup flow to protect dashboard access.
* **Persistent Storage:** Utilizes browser `localStorage` to save all employee data and state between sessions without needing a backend database.
* **Fully Responsive:** Carefully crafted mobile experience with auto-collapsing navbars and stacked grid layouts.

---

## 💻 Technology Stack

* **Frontend:** HTML5, CSS3, Vanilla JavaScript
* **UI Framework:** Bootstrap 5.3
* **Icons:** Bootstrap Icons
* **DOM Manipulation:** jQuery
* **Storage:** Window.localStorage API

---

## 🛠️ How to Open & Run Locally

How to run the app:
1. Extract the ZIP folder.
2. Double-click the index.html file to open it directly in any modern web browser.
3. Login using the default credentials: Username: admin | Password: admin@123

How to run the tests:
1. Open your terminal or command prompt.
2. Navigate to the root folder of this project.
3. Run 'npm install' to install Jest.
4. Run 'npm test' to execute the test suites.
