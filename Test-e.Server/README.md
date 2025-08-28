# Test-e.Server - E-commerce API

A comprehensive e-commerce backend system built with ASP.NET Core 8.0, Entity Framework Core, and the Repository Design Pattern.

## 🏗️ Architecture

This system follows a clean architecture approach with:

- **Repository Pattern**: Abstract data access layer
- **Entity Framework Core**: ORM for database operations
- **DTOs**: Data Transfer Objects for API requests/responses
- **RESTful APIs**: Standard HTTP methods for CRUD operations
- **Dependency Injection**: Built-in .NET Core DI container

## 🗄️ Database Schema

The system includes comprehensive e-commerce tables:

### Core Entities
- **Products**: Main product information with variants
- **Categories**: Hierarchical product categorization
- **Brands**: Product brand management
- **Users**: Customer and admin user management
- **Orders**: Complete order processing system

### Product Management
- **ProductVariants**: Different product variations (size, color, etc.)
- **Attributes & AttributeValues**: Flexible product characteristics
- **Tags**: Product tagging system
- **ProductBadges**: Special product indicators (New, Best Seller, etc.)
- **ProductDiscounts**: Promotional pricing system

### Order Management
- **Orders**: Main order records
- **OrderItems**: Individual items within orders
- **OrderStatuses**: Order lifecycle management
- **OrderAdjustments**: Manual order modifications
- **Payments**: Payment transaction tracking
- **OrderReturns**: Return management system

### User Experience
- **Carts**: Shopping cart functionality
- **Wishlists**: User wishlist management
- **Reviews**: Product review system
- **Addresses**: Shipping and billing addresses

### Supporting Systems
- **DeliveryCompanies**: Shipping carrier management
- **Countries/States/Cities**: Geographic location system
- **Logs**: System activity logging
- **AppSettings**: Application configuration

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Test-e.Server
   ```

2. **Update connection string**
   Edit `appsettings.json` and update the connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=TestEServerDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Restore packages**
   ```bash
   dotnet restore
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the API**
   - API: https://localhost:7000/api
   - Swagger UI: https://localhost:7000/swagger

## 📚 API Endpoints

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `GET /api/products/category/{categoryId}` - Get products by category
- `GET /api/products/brand/{brandId}` - Get products by brand
- `GET /api/products/search?term={searchTerm}` - Search products
- `GET /api/products/tag/{tagId}` - Get products by tag
- `GET /api/products/with-badges` - Get products with active badges
- `GET /api/products/with-discounts` - Get products with active discounts
- `POST /api/products` - Create new product
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product

### Orders
- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get order by ID
- `GET /api/orders/user/{userId}` - Get orders by user
- `GET /api/orders/status/{statusId}` - Get orders by status
- `GET /api/orders/date-range?startDate={date}&endDate={date}` - Get orders by date range
- `POST /api/orders` - Create new order
- `PUT /api/orders/{id}` - Update order
- `PUT /api/orders/{id}/status` - Update order status
- `DELETE /api/orders/{id}` - Delete order

### Users
- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `GET /api/users/{id}/addresses` - Get user addresses
- `POST /api/users` - Create new user
- `PUT /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user

### Categories
- `GET /api/categories` - Get all categories
- `GET /api/categories/{id}` - Get category by ID
- `GET /api/categories/{id}/subcategories` - Get subcategories
- `POST /api/categories` - Create new category
- `PUT /api/categories/{id}` - Update category
- `DELETE /api/categories/{id}` - Delete category

### Cart Management
- `GET /api/cart/{userId}` - Get user's shopping cart
- `POST /api/cart/{userId}/items` - Add item to cart
- `PUT /api/cart/{userId}/items/{itemId}` - Update cart item quantity
- `DELETE /api/cart/{userId}/items/{itemId}` - Remove item from cart
- `DELETE /api/cart/{userId}/clear` - Clear entire cart
- `GET /api/cart/{userId}/total` - Get cart total and item count

### Wishlist Management
- `GET /api/wishlist/{userId}` - Get user's wishlist
- `POST /api/wishlist/{userId}/items` - Add product to wishlist
- `DELETE /api/wishlist/{userId}/items/{itemId}` - Remove product from wishlist
- `DELETE /api/wishlist/{userId}/clear` - Clear entire wishlist
- `GET /api/wishlist/{userId}/count` - Get wishlist item count
- `POST /api/wishlist/{userId}/items/{itemId}/move-to-cart` - Move wishlist item to cart

### Product Reviews
- `GET /api/reviews` - Get all reviews (with optional filtering)
- `GET /api/reviews/{id}` - Get review by ID
- `GET /api/reviews/product/{productId}` - Get reviews for specific product
- `POST /api/reviews` - Create new review
- `PUT /api/reviews/{id}` - Update review
- `DELETE /api/reviews/{id}` - Delete review
- `GET /api/reviews/stats/product/{productId}` - Get review statistics for product
- `PUT /api/reviews/{id}/verify` - Verify a review

### Advanced Search
- `GET /api/search/products` - Advanced product search with filters
- `GET /api/search/suggestions` - Get search suggestions
- `GET /api/search/filters` - Get available search filters
- `GET /api/search/trending` - Get trending products

### Discounts & Campaigns
- `GET /api/discounts/campaigns` - Get all campaigns
- `GET /api/discounts/campaigns/{id}` - Get campaign by ID
- `POST /api/discounts/campaigns` - Create new campaign
- `PUT /api/discounts/campaigns/{id}` - Update campaign
- `DELETE /api/discounts/campaigns/{id}` - Delete campaign
- `POST /api/discounts/campaigns/{id}/products` - Add products to campaign
- `DELETE /api/discounts/campaigns/{id}/products/{productId}` - Remove product from campaign
- `GET /api/discounts/products/{productId}` - Get product discounts
- `GET /api/discounts/active` - Get active campaigns

### Analytics & Dashboard
- `GET /api/dashboard/overview` - Get dashboard overview statistics
- `GET /api/dashboard/sales` - Get sales analytics
- `GET /api/dashboard/products` - Get product analytics
- `GET /api/dashboard/users` - Get user analytics
- `GET /api/dashboard/reviews` - Get review analytics
- `GET /api/dashboard/revenue` - Get revenue analytics

## 🔧 Repository Pattern

The system uses a generic repository pattern for data access:

```csharp
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<int> CountAsync();
}
```

### Specialized Repositories

- **IProductRepository**: Product-specific operations with includes
- **IOrderRepository**: Order management with status tracking

## 📊 Database Relationships

- **One-to-Many**: Products → ProductVariants, Categories → Products
- **Many-to-Many**: Products ↔ Tags, ProductVariants ↔ AttributeValues
- **Self-Referencing**: Categories (hierarchical structure)
- **Complex**: Orders with multiple related entities

## 🛡️ Security Features

- Input validation with Data Annotations
- Exception handling and logging
- CORS configuration for frontend integration
## 🧪 Testing the API

Use the Swagger UI or tools like Postman to test the endpoints:

### Create a Product
```json
POST /api/products
{
  "name": "Sample Product",
  "description": "A sample product description",
  "categoryId": 1,
  "brandId": 1,
  "imageUrl": "https://example.com/image.jpg"
}
```

### Create an Order
```json
POST /api/orders
{
  "userId": 1,
  "addressId": 1,
  "deliveryPrice": 5.99,
  "orderItems": [
    {
      "productVariantId": 1,
      "quantity": 2,
      "note": "Gift wrapping requested"
    }
  ]
}
```

### Add Item to Cart
```json
POST /api/cart/1/items
{
  "productId": 1,
  "productVariantId": 2,
  "quantity": 3
}
```

### Create a Review
```json
POST /api/reviews
{
  "productId": 1,
  "userId": 1,
  "rating": 5,
  "title": "Excellent product!",
  "comment": "This product exceeded my expectations. Highly recommended!"
}
```

### Create a Campaign
```json
POST /api/discounts/campaigns
{
  "name": "Summer Sale 2024",
  "description": "Get 20% off on all summer products",
  "discountType": "Percentage",
  "discountValue": 20,
  "startDate": "2024-06-01T00:00:00Z",
  "endDate": "2024-08-31T23:59:59Z",
  "isActive": true,
  "minimumOrderAmount": 50.00,
  "maximumDiscountAmount": 100.00
}
```

### Advanced Product Search
```json
GET /api/search/products?query=laptop&categoryId=1&minPrice=500&maxPrice=2000&minRating=4&sortBy=price&sortOrder=asc&page=1&pageSize=20
```

## 🔄 Database Migrations

The system uses `EnsureCreated()` for development. For production:

1. **Create initial migration**
   ```bash
   dotnet ef migrations add InitialCreate
   ```

2. **Update database**
   ```bash
   dotnet ef database update
   ```

## 🚀 Deployment

1. **Build the application**
   ```bash
   dotnet publish -c Release
   ```

2. **Configure production connection string**
3. **Set environment variables**
4. **Deploy to your hosting platform**

## 📝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.

## 🤝 Support

For questions or issues, please create an issue in the repository or contact the development team.

---

**Built with ❤️ using ASP.NET Core 8.0**
