# 🛒 E-Commerce API

A **production-ready RESTful API** built with **.NET 9** following **Clean Architecture** principles, **Domain-Driven Design (DDD)**, and **CQRS pattern**. This project demonstrates enterprise-level backend development with comprehensive authentication, authorization, and business logic implementation.

[![.NET](https://img.shields.io/badge/.NET-9.0-purple)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red)](https://www.microsoft.com/en-us/sql-server)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

---

## 📋 Table of Contents

- [Features](#-features)
- [Architecture](#-architecture)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [API Endpoints](#-api-endpoints)
- [Authentication & Authorization](#-authentication--authorization)
- [Database Schema](#-database-schema)
- [Design Patterns](#-design-patterns)
- [Business Rules](#-business-rules)
- [Future Enhancements](#-future-enhancements)
- [Contributing](#-contributing)
- [License](#-license)

---

## ✨ Features

### 🔐 **Authentication & Authorization**
- **JWT-based authentication** with ASP.NET Core Identity
- **Role-based access control** (Admin, Customer)
- Secure user registration and login
- Password hashing with Identity framework
- Token-based API security

### 🛍️ **Product Management**
- Full CRUD operations with pagination
- Image upload and management
- Category-based filtering
- Stock quantity tracking
- Admin-only product mutations

### 🛒 **Shopping Cart**
- Add/remove/update cart items
- Real-time stock validation
- Automatic subtotal calculation
- Cart item limit (100 items)
- Customer-specific cart isolation

### 📦 **Order Processing**
- Create orders from cart
- Order status workflow (Pending → Paid → Shipped → Delivered)
- Order cancellation (Pending orders only)
- Order refund with payment status validation
- Complete order history per customer

### 💳 **Payment System**
- Payment processing with status tracking
- Multiple payment methods (Credit Card, PayPal)
- Payment status workflow (Pending → Completed/Failed/Refunded)
- Automatic order status updates on payment
- Payment history per customer

### ⭐ **Review System**
- Add/edit/delete product reviews
- 1-5 star rating system
- Customer-only review submission
- Review filtering by product/customer

### 📂 **Category Management**
- Category CRUD operations
- Admin-only category mutations
- Product categorization

---

## 🏗️ Architecture

This project follows **Clean Architecture** with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                         API Layer                            │
│  Controllers, DTOs, Middleware, JWT Configuration           │
└───────────────────────┬─────────────────────────────────────┘
                        │
┌───────────────────────▼─────────────────────────────────────┐
│                   Application Layer                          │
│  CQRS Handlers, Validators, Mappings, Interfaces            │
└───────────────────────┬─────────────────────────────────────┘
                        │
┌───────────────────────▼─────────────────────────────────────┐
│                     Core Layer                               │
│  Domain Entities, Enums, Business Logic                     │
└───────────────────────┬─────────────────────────────────────┘
                        │
┌───────────────────────▼─────────────────────────────────────┐
│                 Infrastructure Layer                         │
│  EF Core, Repositories, External Services                   │
└─────────────────────────────────────────────────────────────┘
```

### **Layer Responsibilities**

#### **Core Layer** (Domain)
- Domain entities with encapsulated business logic
- Value objects and enums
- Domain events (future)
- No external dependencies

#### **Application Layer**
- CQRS commands and queries
- MediatR handlers
- FluentValidation validators
- AutoMapper profiles
- Service interfaces

#### **Infrastructure Layer**
- EF Core DbContext and configurations
- Repository implementations
- Unit of Work pattern
- External service implementations (file storage, payment)
- ASP.NET Core Identity setup

#### **API Layer** (Presentation)
- RESTful API controllers
- DTOs (Data Transfer Objects)
- Global exception handling middleware
- JWT authentication configuration
- Dependency injection setup

---

## 🛠️ Tech Stack

### **Backend Framework**
- **.NET 9.0** - Latest LTS version
- **C# 12** - Modern language features
- **ASP.NET Core Web API** - RESTful API framework

### **Database**
- **SQL Server 2022** - Relational database
- **Entity Framework Core 9.0** - ORM
- **EF Core Migrations** - Database versioning

### **Authentication & Security**
- **ASP.NET Core Identity** - User management
- **JWT Bearer Tokens** - Stateless authentication
- **Role-based Authorization** - Access control

### **Architecture & Patterns**
- **Clean Architecture** - Separation of concerns
- **CQRS Pattern** - Command Query Responsibility Segregation
- **MediatR (13.1.0)** - Mediator pattern implementation
- **Repository Pattern** - Data access abstraction
- **Unit of Work** - Transaction management

### **Validation & Mapping**
- **FluentValidation (12.1.0)** - Input validation
- **AutoMapper (12.0.1)** - Object mapping

### **API Documentation**
- **OpenAPI/Swagger** - API documentation

---

## 📁 Project Structure

```
ECommerceApi/
├── Api/                                # Presentation Layer
│   ├── Controllers/                    # API endpoints
│   │   ├── AccountController.cs        # Register/Login
│   │   ├── ProductController.cs
│   │   ├── CategoryController.cs
│   │   ├── CartController.cs
│   │   ├── OrderController.cs
│   │   ├── PaymentController.cs
│   │   └── ReviewController.cs
│   ├── Dto/                            # Data Transfer Objects
│   ├── Middlewares/                    # Global exception handling
│   ├── Services/                       # API-specific services
│   ├── Program.cs                      # Application entry point
│   └── appsettings.json                # Configuration
│
├── Application/                        # Application Layer
│   ├── Features/                       # CQRS Features
│   │   ├── Account/
│   │   │   ├── Register/
│   │   │   │   ├── RegisterCommand.cs
│   │   │   │   ├── RegisterHandler.cs
│   │   │   │   └── RegisterValidator.cs
│   │   │   └── Login/
│   │   ├── Products/
│   │   │   ├── Commands/               # Mutations
│   │   │   └── Queries/                # Reads
│   │   ├── Orders/
│   │   ├── Carts/
│   │   └── ...
│   ├── Interfaces/                     # Service abstractions
│   ├── Mapping/                        # AutoMapper profiles
│   └── Behaviors/                      # MediatR pipeline behaviors
│
├── Core/                               # Domain Layer
│   ├── Entities/                       # Domain models
│   │   ├── Product.cs
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   ├── Cart.cs
│   │   ├── Payment.cs
│   │   └── ...
│   └── Enums/                          # Domain enums
│
└── Infrastructure/                     # Infrastructure Layer
    ├── Data/                           # EF Core DbContext
    ├── Configurations/                 # EF Core entity configurations
    ├── Repositories/                   # Repository implementations
    ├── Services/                       # External service implementations
    ├── Identity/                       # ASP.NET Identity setup
    └── Migrations/                     # Database migrations
```

---

## 🚀 Getting Started

### **Prerequisites**

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server 2022](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### **Installation**

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/ecommerce-api.git
   cd ecommerce-api
   ```

2. **Update connection string**
   
   Open `Api/appsettings.json` and update the connection string:
   ```json
   {
     "ConnectionStrings": {
       "conStr": "server=YOUR_SERVER;database=ECommerceApi;integrated security=true;trustservercertificate=true"
     }
   }
   ```

3. **Apply database migrations**
   ```bash
   cd Infrastructure
   dotnet ef database update --startup-project ../Api
   ```

4. **Run the application**
   ```bash
   cd ../Api
   dotnet run
   ```

5. **Access the API**
   - API: `https://localhost:7067`
   - Swagger UI: `https://localhost:7067/swagger`

### **Default Admin Account**

The application seeds a default admin account:
- **Email:** `admin@ecommerce.com`
- **Password:** `Admin@123`

---

## 📡 API Endpoints

### **Authentication**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| POST | `/api/Account/register` | Register new customer | Public |
| POST | `/api/Account/login` | Login and get JWT token | Public |

### **Products**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/Product` | Get all products (paginated) | Public |
| GET | `/api/Product/{id}` | Get product by ID | Public |
| GET | `/api/Product/category/{id}` | Get products by category | Public |
| POST | `/api/Product` | Create new product | Admin |
| PUT | `/api/Product/{id}` | Update product | Admin |
| PUT | `/api/Product/image/{id}` | Update product image | Admin |
| DELETE | `/api/Product/{id}` | Delete product | Admin |

### **Categories**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/Category` | Get all categories (paginated) | Public |
| GET | `/api/Category/{id}` | Get category by ID | Public |
| POST | `/api/Category` | Create new category | Admin |
| PUT | `/api/Category/{id}` | Update category | Admin |
| DELETE | `/api/Category/{id}` | Delete category | Admin |

### **Shopping Cart**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/Cart/{customerId}` | Get customer's cart | Customer |
| POST | `/api/Cart` | Add item to cart | Customer |
| PUT | `/api/Cart` | Update item quantity | Customer |
| DELETE | `/api/Cart` | Remove item from cart | Customer |
| DELETE | `/api/Cart/{customerId}` | Clear entire cart | Customer |

### **Orders**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/Order/customer/{id}` | Get customer's orders | Customer |
| GET | `/api/Order/{id}` | Get order by ID | Customer |
| POST | `/api/Order` | Create order from cart | Customer |
| PUT | `/api/Order/{id}` | Cancel order | Customer |
| PUT | `/api/Order/status` | Update order status | Customer |
| PUT | `/api/Order/refund/{orderId}` | Refund order | Customer |

### **Payments**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/Payment/{id}` | Get payment by ID | Customer |
| GET | `/api/Payment/order/{id}` | Get payment by order ID | Customer |
| GET | `/api/Payment/customer/{id}` | Get customer's payments | Customer |
| POST | `/api/Payment` | Process payment | Customer |
| PUT | `/api/Payment` | Update payment status | Customer |

### **Reviews**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/Review/{id}` | Get review by ID | Customer |
| GET | `/api/Review/product/{id}` | Get reviews by product | Customer |
| GET | `/api/Review/customer/{id}` | Get reviews by customer | Customer |
| POST | `/api/Review` | Add review | Customer |
| PUT | `/api/Review/{id}` | Update review | Customer |
| DELETE | `/api/Review/{id}` | Delete review | Customer |

### **Customers**
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/Customer` | Get all customers (paginated) | Public |
| GET | `/api/Customer/{id}` | Get customer by ID | Public |
| PUT | `/api/Customer/{id}` | Update customer | Public |
| DELETE | `/api/Customer/{id}` | Delete customer | Public |

---

## 🔐 Authentication & Authorization

### **JWT Token Flow**

1. **Register** → Creates user account with default "Customer" role
2. **Login** → Returns JWT token with user claims and roles
3. **API Request** → Include token in Authorization header: `Bearer {token}`

### **Example Authentication Request**

```bash
# Register
curl -X POST https://localhost:7067/api/Account/register \
  -H "Content-Type: application/json" \
  -d '{
    "name": "John Doe",
    "email": "john@example.com",
    "password": "Password123!",
    "phone": "01012345678",
    "address": "123 Main St"
  }'

# Login
curl -X POST https://localhost:7067/api/Account/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john@example.com",
    "password": "Password123!"
  }'

# Response
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "email": "john@example.com",
  "name": "John Doe"
}

# Use token in subsequent requests
curl -X GET https://localhost:7067/api/Cart/{customerId} \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

### **Roles**

- **Customer**: Can manage their own cart, orders, payments, and reviews
- **Admin**: Can manage products, categories, and all system data

### **JWT Configuration**

Configure JWT settings in `appsettings.json`:
```json
{
  "JwtSettings": {
    "SecretKey": "Your-Super-Secret-Key-Here-Min-32-Characters",
    "Issuer": "YourAppName",
    "Audience": "YourAppUsers",
    "ExpiryMinutes": 60
  }
}
```

---

## 🗄️ Database Schema

### **Core Tables**

- **AspNetUsers** - User accounts (ASP.NET Identity)
- **AspNetRoles** - User roles
- **Customers** - Customer profile information
- **Products** - Product catalog
- **Categories** - Product categories
- **Carts** - Shopping carts
- **CartItems** - Items in carts
- **Orders** - Customer orders
- **OrderItems** - Items in orders
- **Payments** - Payment transactions
- **Reviews** - Product reviews

### **Key Relationships**

```
AspNetUsers 1──1 Customer
Customer 1──1 Cart
Cart 1──* CartItems
CartItems *──1 Product
Customer 1──* Orders
Orders 1──* OrderItems
OrderItems *──1 Product
Orders 1──1 Payment
Product *──1 Category
Customer 1──* Reviews
Product 1──* Reviews
```

---

## 🎨 Design Patterns

### **1. Clean Architecture**
- **Independence of frameworks** - Business logic doesn't depend on external libraries
- **Testability** - Business rules can be tested without UI, database, or external services
- **Independence of UI** - API layer can be replaced without affecting business logic
- **Independence of database** - Can switch from SQL Server to another database with minimal changes

### **2. CQRS (Command Query Responsibility Segregation)**
- **Commands** - Mutations that change state (Create, Update, Delete)
- **Queries** - Read operations that don't change state
- Separation allows for independent optimization and scaling

### **3. Repository Pattern**
- Abstracts data access logic
- Provides a collection-like interface for accessing domain objects
- Enables easy unit testing with mock repositories

### **4. Unit of Work**
- Maintains a list of objects affected by a business transaction
- Coordinates the writing out of changes
- Ensures transaction consistency

### **5. Mediator Pattern (MediatR)**
- Reduces coupling between components
- Handlers are independent and testable
- Easy to add new features without modifying existing code

### **6. Dependency Injection**
- All dependencies are injected through constructors
- Promotes loose coupling and testability
- Configured in `Program.cs`

### **7. Domain-Driven Design**
- **Entities** - Objects with identity (Product, Order, Customer)
- **Value Objects** - Objects without identity (Address, Money in future)
- **Aggregates** - Clusters of entities (Order with OrderItems)
- **Domain Events** - Significant events in the domain (OrderPlaced, PaymentCompleted in future)

---

## 💼 Business Rules

### **Cart Management**
- ✅ Maximum 100 items per cart
- ✅ Cannot add more items than available in stock
- ✅ Cart clears automatically after order creation
- ✅ Price snapshot taken at cart addition time

### **Order Processing**
- ✅ Orders created from cart items only
- ✅ Order status workflow: `Pending → Paid → Shipped → Delivered`
- ✅ Only `Pending` orders can be cancelled
- ✅ Cannot transition `Delivered` back to `Pending`
- ✅ Cannot transition `Cancelled` to `Shipped`

### **Payment System**
- ✅ Payment created automatically with order
- ✅ Payment status workflow: `Pending → Completed/Failed/Refunded`
- ✅ Only `Completed` payments can be refunded
- ✅ Cannot revert `Completed` payment to `Pending`
- ✅ Refunds only available for `Paid` or `Shipped` orders

### **Product Management**
- ✅ Stock quantity must be non-negative
- ✅ Price must be greater than zero
- ✅ Image files limited to 5MB
- ✅ Only `.jpg` and `.png` image formats accepted

### **Review System**
- ✅ Rating must be between 1 and 5 stars
- ✅ Comment maximum length: 250 characters
- ✅ One review per customer per product (future enhancement)

### **Authentication**
- ✅ Password minimum 8 characters (configurable)
- ✅ Email must be unique
- ✅ Egyptian phone number format validation: `01[0-2,5]XXXXXXXX`
- ✅ New users automatically assigned "Customer" role

---

## 🔮 Future Enhancements

### **Phase 1: Core Improvements**
- [ ] Soft delete pattern for all entities
- [ ] Audit fields (CreatedBy, UpdatedBy, DeletedBy)
- [ ] Logging with Serilog
- [ ] Unit tests with xUnit (target 70%+ coverage)
- [ ] Integration tests for API endpoints

### **Phase 2: Advanced Features**
- [ ] Email confirmation on registration
- [ ] Password reset flow
- [ ] Refresh token implementation
- [ ] Product search with full-text indexing
- [ ] Advanced filtering and sorting
- [ ] Wishlist functionality

### **Phase 3: Performance & Scalability**
- [ ] Redis caching for frequently accessed data
- [ ] Rate limiting
- [ ] API versioning
- [ ] Health checks
- [ ] Response compression
- [ ] CORS configuration for production

### **Phase 4: Business Features**
- [ ] Discount codes and promotions
- [ ] Inventory management
- [ ] Multiple addresses per customer
- [ ] Order tracking with status history
- [ ] Email notifications (order confirmation, shipping updates)
- [ ] Admin dashboard

### **Phase 5: DevOps**
- [ ] Docker containerization
- [ ] CI/CD pipeline (GitHub Actions)
- [ ] Kubernetes deployment
- [ ] Monitoring with Application Insights
- [ ] Automated database backups

---

## 📊 Project Statistics

- **Lines of Code**: ~15,000+
- **Total Files**: 220+
- **Entities**: 9 core domain entities
- **API Endpoints**: 45+
- **Design Patterns**: 7 major patterns
- **Database Tables**: 15+ (including Identity tables)

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### **Coding Standards**
- Follow Clean Architecture principles
- Write unit tests for new features
- Use meaningful variable and method names
- Add XML documentation for public APIs
- Validate all inputs with FluentValidation

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 👤 Author

**Your Name**
- GitHub: [mohamedmahmoud345](https://github.com/mohamedmahmoud345)
- LinkedIn: [Mohamed Mahmoud](https://www.linkedin.com/in/mohamed-mahmoud-957214249/)
- Email: mohamed987456mm20@gmail.com

---

## 🙏 Acknowledgments

- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Microsoft ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [MediatR Documentation](https://github.com/jbogard/MediatR)
- [FluentValidation Documentation](https://docs.fluentvalidation.net/)

---

## 📞 Support

If you have any questions or need help, please:
- Open an issue on GitHub
- Contact me via email
- Check the [Wiki](https://github.com/yourusername/ecommerce-api/wiki) for detailed documentation

---

<div align="center">

**⭐ Star this repository if you find it helpful!**

Made with ❤️ using .NET 9

</div>
