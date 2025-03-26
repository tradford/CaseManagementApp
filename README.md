🧾 Case Management App
This is a Blazor application with a SQL Server backend for managing legal cases, clients, attorneys, and case notes. It uses ASP.NET Core Identity for user registration, login, and role-based access control (e.g., Admin, Attorney, Paralegal).
________________________________________
✅ Features
•	User registration and login with ASP.NET Identity
•	Role-based access control (Admin, Attorney, Paralegal)
•	CRUD operations for:
o	Clients
o	Attorneys
o	Brownstein Cases
o	Case Notes
•	QuickGrid-based UI with searching and filtering
•	User profile management
•	Assign roles to users from the UI
•	Upload Documents for Case files
•	Clean Interface and Repository design
________________________________________
⚙️ Setup Instructions
1. Clone the Repo
git clone https://github.com/tradford/CaseManagementApp.git
cd .\CaseManagementApp\
________________________________________
3. Configure the Database
In appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=CaseManagementApp; Trusted_Connection=True;TrustServerCertificate=true"
}
Update with your SQL Server instance name.
________________________________________
3. Run Migrations
dotnet ef database update
Requires the dotnet-ef CLI tool. Install with: dotnet tool install --global dotnet-ef
________________________________________
4. Seed Initial Roles (Optional)
You can add initial roles (Admin, Attorney, Paralegal) in Program.cs or via SQL.
________________________________________
5. Run the App
dotnet run
The app will launch at https://localhost:<portnumber>
________________________________________
👥 Roles & Permissions
Role	Permissions
Admin	Full control over users, roles, and cases
Attorney	Manage cases, attorneys, clients, and add case notes
Paralegal	View cases and assist with notes & clients
________________________________________
📦 Tech Stack
•	Blazor Server (.NET 9)
•	Entity Framework Core
•	SQL Server
•	ASP.NET Core Identity
•	QuickGrid for UI tables
•	Bootstrap 5 for styling
________________________________________
✍️ Author
Trenton Radford 

