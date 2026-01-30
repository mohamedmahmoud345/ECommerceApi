# ECommerceApi

A comprehensive RESTful E-Commerce API built with **ASP.NET Core 9.0**, following **Clean Architecture** and **CQRS** pattern with MediatR. This API provides a complete backend solution for e-commerce applications including product management, customer management, shopping cart, orders, reviews, and more.

> **⚠️ Note:** This project is currently under active development and not yet complete.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

```
ECommerceApi/
├── Core/                    # Domain Entities & Business Logic
├── Application/             # Use Cases, DTOs, Interfaces & Commands/Queries (CQRS)
├── Infrastructure/          # Data Access, Repositories & External Services
└── Api/                     # REST API Controllers & Configuration
```

### Key Design Patterns

- **Clean Architecture**: Clear separation between domain, application, and infrastructure layers
- **CQRS (Command Query Responsibility Segregation)**: Using MediatR for commands and queries
- **Repository Pattern**: Generic repositories with Unit of Work
- **Dependency Injection**: Built-in ASP.NET Core DI container
- **Domain-Driven Design**: Rich domain models with encapsulated business logic

## ✨ Features

### Current Features

- 📦 **Product Management**
  - CRUD operations for products
  - Product categorization
  - Image upload and storage
  - Stock quantity tracking
  - Price management
  - Pagination support

- 👥 **Customer Management**
  - Customer registration and profile management
  - Email-based customer lookup
  - Address and contact information

- 🏷️ **Category Management**
  - Hierarchical product categories
  - Category-based product filtering

- 🛒 **Shopping Cart**
  - Add/remove items from cart
  - Quantity management
  - Real-time price calculation
  - Cart persistence per customer

- 📝 **Orders**
  - Order creation from cart items
  - Order status tracking (OrderStatus enum)
  - Order history per customer
  - Order item details with pricing

- ⭐ **Product Reviews**
  - Customer product reviews
  - Rating system
  - Review management (add, update, delete)
  - Filter reviews by product or customer

- 💳 **Payment** (Entity defined, implementation in progress)

### Upcoming Features

- Authentication & Authorization (JWT)
- Payment processing integration
- Order status management workflow
- Advanced search and filtering
- Inventory management
- Admin dashboard endpoints
- Email notifications

## 🛠️ Technologies & Frameworks

### Core Technologies
- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core 9.0** - ORM for database operations
- **SQL Server** - Primary database

### Libraries & Packages
- **MediatR** - CQRS implementation
- **AutoMapper** - Object-to-object mapping
- **FluentValidation** - Input validation
- **OpenAPI/Swagger** - API documentation (via Microsoft.AspNetCore.OpenApi)

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 / VS Code / Rider (recommended)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/mohamedmahmoud345/ECommerceApi.git
   cd ECommerceApi
   ```

2. **Configure Database Connection**
   
   Update the connection string in `Api/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "conStr": "Server=(localdb)\\mssqllocaldb;Database=ECommerceDb;Trusted_Connection=true;"
     }
   }
   ```

3. **Apply Database Migrations**
   ```bash
   cd Infrastructure
   dotnet ef database update
   ```
   
   Or from the solution root:
   ```bash
   dotnet ef database update --project Infrastructure --startup-project Api
   ```

4. **Run the Application**
   ```bash
   cd Api
   dotnet run
   ```

5. **Access the API**
   - API: `https://localhost:5001` or `http://localhost:5000`
   - Swagger UI: `https://localhost:5001/openapi` (in Development mode)

## 📚 API Endpoints

### Products
```http
GET    /api/Product?page=1&pageSize=10          # Get all products (paginated)
GET    /api/Product/{id}                        # Get product by ID
GET    /api/Product/category/{id}               # Get products by category
POST   /api/Product                             # Create new product
PUT    /api/Product/{id}                        # Update product
DELETE /api/Product/{id}                        # Delete product
```

### Customers
```http
GET    /api/Customer?page=1&pageSize=10         # Get all customers (paginated)
GET    /api/Customer/{id}                       # Get customer by ID
GET    /api/Customer/email/{email}              # Get customer by email
POST   /api/Customer                            # Create new customer
PUT    /api/Customer/{id}                       # Update customer
DELETE /api/Customer/{id}                       # Delete customer
```

### Categories
```http
GET    /api/Category?page=1&pageSize=10         # Get all categories (paginated)
GET    /api/Category/{id}                       # Get category by ID
POST   /api/Category                            # Create new category
PUT    /api/Category/{id}                       # Update category
DELETE /api/Category/{id}                       # Delete category
```

### Cart
```http
GET    /api/Cart/{customerId}                   # Get cart items by customer
POST   /api/Cart                                # Add item to cart
PUT    /api/Cart/{id}                          # Update cart item quantity
DELETE /api/Cart/{id}                          # Remove item from cart
```

### Orders
```http
GET    /api/Order/{customerId}                  # Get customer orders
POST   /api/Order                               # Create order from cart
```

### Reviews
```http
GET    /api/Review/{id}                         # Get review by ID
GET    /api/Review/product/{id}                 # Get reviews for product
GET    /api/Review/customer/{id}                # Get reviews by customer
POST   /api/Review                              # Add review
PUT    /api/Review/{id}                         # Update review
DELETE /api/Review/{id}                         # Delete review
```

## 📦 Domain Entities

### Core Entities

- **Product**: Products available for sale with pricing, stock, and images
- **Customer**: Registered customers with contact information
- **Category**: Product categories for organization
- **Cart**: Shopping cart for customers
- **CartItem**: Individual items in a cart
- **Order**: Customer orders with status tracking
- **OrderItem**: Individual items in an order
- **Review**: Product reviews and ratings
- **Payment**: Payment information (in progress)

### Enums

- **OrderStatus**: Order state management (Pending, Processing, Shipped, Delivered, Cancelled, etc.)

## 🗂️ Project Structure

```
ECommerceApi/
│
├── Core/                               # Domain Layer
│   ├── Entities/                       # Domain entities
│   │   ├── Product.cs
│   │   ├── Customer.cs
│   │   ├── Category.cs
│   │   ├── Cart.cs
│   │   ├── Order.cs
│   │   └── Review.cs
│   └── Enums/
│       └── OrderStatus.cs
│
├── Application/                        # Application Layer
│   ├── Features/                       # Feature-based organization (CQRS)
│   │   ├── Products/
│   │   │   ├── Commands/              # Product commands (Add, Update, Delete)
│   │   │   └── Queries/               # Product queries (GetAll, GetById)
│   │   ├── Customers/
│   │   ├── Categories/
│   │   ├── Cart/
│   │   ├── Orders/
│   │   └── Reviews/
│   ├── Common/                        # Shared application logic
│   ├── Interfaces/                    # Application interfaces
│   │   ├── IRepositories/
│   │   └── IServices/
│   ├── IUnitOfWorks/
│   ├── Middlewares/                   # Exception handling middleware
│   └── Validators/                    # FluentValidation validators
│
├── Infrastructure/                     # Infrastructure Layer
│   ├── Data/
│   │   └── AppDbContext.cs            # EF Core DbContext
│   ├── Repositories/                  # Repository implementations
│   ├── Migrations/                    # EF Core migrations
│   ├── Dependecies/                   # DI registration
│   └── Services/                      # External service implementations
│
└── Api/                               # Presentation Layer
    ├── Controllers/                   # API controllers
    ├── Dto/                          # Data Transfer Objects
    ├── Services/                     # API-specific services
    ├── wwwroot/                      # Static files (product images)
    ├── Program.cs                    # Application entry point
    └── appsettings.json             # Configuration
```

## 🔧 Configuration

### Database Configuration

The application uses Entity Framework Core with SQL Server. Configure your connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "conStr": "YOUR_CONNECTION_STRING_HERE"
  }
}
```

### File Storage

Product images are stored in `wwwroot/Products/`. The application uses `IFileStorageService` for file operations.

### JSON Serialization

The API is configured to serialize enums as strings for better readability:

```csharp
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
```

## 🧪 Middleware

### Exception Handling

The application includes custom exception handling middleware (`ExceptionHandlingMiddleware`) for centralized error management.

## 🤝 Contributing

This project is under active development. Contributions, issues, and feature requests are welcome!

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 Development Status

### ✅ Completed
- Clean Architecture setup
- CQRS pattern with MediatR
- Product management with image upload
- Customer management
- Category management
- Shopping cart functionality
- Order creation from cart
- Review system
- Pagination support
- Exception handling middleware

### 🚧 In Progress
- Payment processing
- Authentication & Authorization
- Order status workflow
- Advanced validation
- Unit & Integration tests

### 📋 Planned
- Email notifications
- Admin panel endpoints
- Search & filtering improvements
- Caching layer
- API versioning
- Rate limiting
- Docker support
- CI/CD pipeline

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 👤 Author

**Mohamed Mahmoud**
- GitHub: [@mohamedmahmoud345](https://github.com/mohamedmahmoud345)

## 🙏 Acknowledgments

- Built with ASP.NET Core 9.0
- Inspired by Clean Architecture principles
- CQRS pattern implementation with MediatR

---

⭐ If you find this project useful, please consider giving it a star!

**Status**: 🚧 Under Active Development
