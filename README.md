# dotnetTenantHelpAPI
A RESTful ASP.NET Core Web API designed to manage residential maintenance requests. It allows **tenants** to report issues in their units and track repairs, while enabling **property managers** to efficiently prioritize, assign, and analyze maintenance work.

This project was built as a **portfolio piece** to demonstrate real-world backend design, role-based authorization, file uploads, and data reporting using modern .NET practices.

## Features
### Tenant Capabilities
- Open maintenance tickets for their unit
- View all their submitted tickets
- Add comments to tickets
- Upload photos to document issues
- Close resolved tickets

## Property Manager Capabilities
- View and manage all maintenance tickets
- Update ticket status (Open, In Progress, Closed)
- Set ticket priority (Low, Medium, High, Emergency)
- Assign technicians to tickets
- Access operational metrics and reports

## Architecture Overview
```
dotnetTenantHelpAPI
├── Controllers
├── Domain
│   ├── Entities
│   ├── Enums
│   └── DTOs
├── Infrastructure
│   ├── Data
│   └── Repositories
├── Services
├── Auth
├── Uploads
└── Program.cs
```

### ER Diagram
```mermaid
	USER {
		int Id
		string Name
		string Email
		string Role
		string UnitNumber
		datetime CreatedAt
	}

	MAINTENANCE_TICKET {
		int Id
		string Title
		string Description
		string Status
		string Priority
		datetime CreatedAt
		dateTime ClosedAt
		int TenantId
		int AssignedTechnicianId
	}

	TICKET_COMMENT {
		int Id
		int TicketId
		int UserId
		string UserRole
		string Message
		datetime CreatedAt
	}

	TICKET_PHOTO {
		int Id
		int TicketId
		string FilePath
		datetime UploadedAt
	}

	METRIC_SNAPSHOT {
		int Id
		int OpenTickets
		int ClosedTickets
		float AverageResolutionHours
		datetime GeneratedAt
	}

    USER ||--o{ MAINTENANCE_TICKET : submits
    USER ||--o{ TICKET_COMMENT : writes
    MAINTENANCE_TICKET ||--o{ TICKET_COMMENT : has
    MAINTENANCE_TICKET ||--o{ TICKET_PHOTO : includes
    USER ||--o{ MAINTENANCE_TICKET : manages
```

## Authentication & Authorization
- JWT-based authentication
- Role-based authorization using claims
  - Tenant
  - PropertyManager

Access to endpoints is restricted by role to reflect real-world multi-tenant systems.

## Technology Stack
- .NET 9(ASP.NET Core Web API)
- Entity Framework Core
- SQL Server and PostgreSQL
- JWT Authentication
- Swagger / OpenAPI
- Cloud-ready file storage (Local for dev, Azure Blob)

## File Uploads
Tenants can upload photos when creating or updating tickets.
- Secure multipart/form-data handling
- Server-side file validation
- File are stored outside application binaries
- Uploads linked to tickets via database references

## Metrics & Reporting
Property managers have access to analytics endpoints, including:
- Total open tickets
- Average ticket resolution time
- Ticket by priority
- Emergency tickets in the current period

## API Endpoints Overview
### Tenant
|Method|Endpoint|Description|
|:---|:---|:---|
|`POST`|`/api/tickets`|Create a new maintenance ticket|
|`GET`|`/api/tickets/my`|View tenant's tickets|
|`POST`|`/api/tickets/{id}/comments`|Add a comment|
|`POST`|`/api/tickets/{id}/photos`|Upload photos|
|`PUT`|`/api/tickets/{id}/close`|Close a ticket|

### Property Manager
|Method|Endpoint|Description|
|:---|:---|:---|
|`GET`|`/api/manager/tickets`|View all tickets|
|`PUT`|`/api/manager/tickets/{id}/status`|Update status|
|`PUT`|`/api/manager/tickets/{id}/priority`|Set priority|
|`PUT`|`/api/manager/tickets/{id}/assign`|Assign technician|
|`GET`|`/api/manager/metrics`|View maintenance tickets|

## API Documentation
Interactive documentation is available via **Swagger**:
`/swagger`
- Role-specific endpoint visibility
- Request/response examples
- Authentication support

## Getting Started
### Prerequisits
- .NET 9 SDK
- SQL Server or PostgreSQL
- Visual Studio / VS Code

### Setup
```
git clone https://github.com/mauriciogbarros/dotnetTenantHelpAPI.git
cd dotnetTenantHelpAPI
dotnet restore
dotnet ef database update
dotnet run
```

## Future Improvements
- Email notifications
- Background job processing
- Azure Blob Storage integration
- Docker support
- Audit logging
- Technician mobile endpoints

## Why this project matters?
This project demonstrates:
- Real-wrold backend API design
- Multi-role authorization
- Secure file uploads
- Clean architecture
- Data modeling and reporting
- Production-ready patterns in .NET

This project is intended to mirror **enterprise SaaS systems** used in property management and operations.

## Contact
If you are reviewing this project and would like to discuss design decisions or potential improvements, feel free to reach out via GitHub.