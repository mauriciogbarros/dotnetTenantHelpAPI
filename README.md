# dotnetTenantHelpAPI
A role-based maintenance ticket management API for residential property management, built with .NET and clean architecture principles.

### Motivation
This is a portfolio project to demonstrate real-work backend API design, authentication, authorization, and data modeling using .NET and PostegreSQL.

### Technology Stack
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Swagger / OpenAPI
- FluentValidation

## Key Features
This API allows **tenants** to report maintenance issues in their units by opening **tickets**. The **property managers** to manage **tickets**, assign **technicians**, and view operational metrics.

### Tenant Capabilities
- Open maintenance tickets
- View the tickets of their unit
- Add comments to open tickets
- Upload photos related to issues
- Sign-off a ticket in order for it to be closed

### Property Manager Capabilities
- View all maintenance tickets
- Update tickets status (Open, In Progress, Resolved, Closed)
- Set ticket priority (Low, Medium, High, Emergency)
- Assign technicians
- View maintenance metrics and trends

## Entities
### Property
- Properties
  - Address: string
  - Users: [User]
  - Units: [Unit]

### Unit
- Properties
  - Id: int
  - Number: int
  - Tenant: Tenant
  - Description: string

### User
- Properties
  - Id: int
  - Name: string
  - Email: string
  - Role: string (Tenant, Manager, Technician)
  - PasswordHash: string
  - CreatedAt: datetime
  - DeactivatedAt: datetime

#### Tenant : User
- Properties
  - Unit: Unit
- Methods
  - CreateTicket()
    - Only for their own unit
  - UpdateTicket()
    - Insert a comment to the ticket
    - Insert a photo to the ticket
  - ViewTickets()
    - Only show tickets created by the user

#### Manager : User
- Methods
  - CreateUser()
  - UpdateUser()
  - DeactivateUser()
  - CreateTicket()
    - Only for empty units
  - UpdateTicket()

#### Technician : User
- Properties
- Methods
  - UpdateTicket()

### Ticket
#### Properties
- Id: int
- Unit: Unit
- CreatedBy: Tenant
- CreatedAt: datetime
- Title: string
- Priority: string (Low, Medium, High, Emergency)
- Status: string (Open, In Progress, Resolved, Closed)
- Comments: [TicketComment]
- Photos: [TicketPhoto]

### TicketComment
#### Properties
- Id: int
- TicketId: int
- Comment: string

### TicketPhoto
- Id: int
- TicketId: int
- FilePath : string
- UploadedAt : datetime