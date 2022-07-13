// <auto-generated>
// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NwOrdersAPI.Entities;
using NwOrdersAPI.DTOs;

namespace NwOrdersAPI
{
    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public class NwDbContext : DbContext, INwDbContext
    {
        public NwDbContext()
        {
        }

        public NwDbContext(DbContextOptions<NwDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } // Categories
        public DbSet<Customer> Customers { get; set; } // Customers
        public DbSet<Employee> Employees { get; set; } // Employees
        public DbSet<Order> Orders { get; set; } // Orders
        public DbSet<OrderDetail> OrderDetails { get; set; } // Order Details
        public DbSet<Product> Products { get; set; } // Products
        public DbSet<Supplier> Suppliers { get; set; } // Suppliers

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CBHT1LC\MSSQLSERVERDEV;User ID=nwtuser;Password=admin;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=NorthwindOrders");
            }
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());

            modelBuilder.Entity<SelectOrderReturnModel>().HasNoKey();
            modelBuilder.Entity<SelectOrderItemsReturnModel>().HasNoKey();
        }


        // Stored Procedures
        public async Task<int> AddToOrderAsync(int? orderId, int? productId, int? quantity, float? discount)
        {
            var orderIdParam = new SqlParameter { ParameterName = "@orderID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = orderId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!orderId.HasValue)
                orderIdParam.Value = DBNull.Value;

            var productIdParam = new SqlParameter { ParameterName = "@productID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = productId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!productId.HasValue)
                productIdParam.Value = DBNull.Value;

            var quantityParam = new SqlParameter { ParameterName = "@quantity", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = quantity.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!quantity.HasValue)
                quantityParam.Value = DBNull.Value;

            var discountParam = new SqlParameter { ParameterName = "@discount", SqlDbType = SqlDbType.Real, Direction = ParameterDirection.Input, Value = discount.GetValueOrDefault(), Precision = 24, Scale = 0 };
            if (!discount.HasValue)
                discountParam.Value = DBNull.Value;            
            return await Database.ExecuteSqlRawAsync("EXEC [dbo].[AddToOrder] @orderID, @productID, @quantity, @discount", orderIdParam, productIdParam, quantityParam, discountParam);            
        }
        public async Task<int> CreateOrderAsync(string customerId, DateTime? requiredDate, decimal? freight, string shipCity, string shipCountry)
        {
            var customerIdParam = new SqlParameter { ParameterName = "@customerID", SqlDbType = SqlDbType.NChar, Direction = ParameterDirection.Input, Value = customerId, Size = 5 };
            if (customerIdParam.Value == null)
                customerIdParam.Value = DBNull.Value;

            var requiredDateParam = new SqlParameter { ParameterName = "@requiredDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = requiredDate.GetValueOrDefault() };
            if (!requiredDate.HasValue)
                requiredDateParam.Value = DBNull.Value;

            var freightParam = new SqlParameter { ParameterName = "@freight", SqlDbType = SqlDbType.Money, Direction = ParameterDirection.Input, Value = freight.GetValueOrDefault(), Precision = 19, Scale = 4 };
            if (!freight.HasValue)
                freightParam.Value = DBNull.Value;

            var shipCityParam = new SqlParameter { ParameterName = "@shipCity", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = shipCity, Size = 15 };
            if (shipCityParam.Value == null)
                shipCityParam.Value = DBNull.Value;

            var shipCountryParam = new SqlParameter { ParameterName = "@shipCountry", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = shipCountry, Size = 15 };
            if (shipCountryParam.Value == null)
                shipCountryParam.Value = DBNull.Value;

            return await Database.ExecuteSqlRawAsync("EXEC [dbo].[CreateOrder] @customerID, @requiredDate, @freight, @shipCity, @shipCountry", customerIdParam, requiredDateParam, freightParam, shipCityParam, shipCountryParam);            
        }
        public async Task<int> DeleteOrderAsync(int? orderId)
        {
            var orderIdParam = new SqlParameter { ParameterName = "@orderID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = orderId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!orderId.HasValue)
                orderIdParam.Value = DBNull.Value;
            
            return await Database.ExecuteSqlRawAsync("EXEC [dbo].[DeleteOrder] @orderID", orderIdParam);
        }

        public async Task<int> DeleteOrderItemAsync(int? orderId, int? productId)
        {
            var orderIdParam = new SqlParameter { ParameterName = "@orderID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = orderId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!orderId.HasValue)
                orderIdParam.Value = DBNull.Value;

            var productIdParam = new SqlParameter { ParameterName = "@productID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = productId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!productId.HasValue)
                productIdParam.Value = DBNull.Value;

            return await Database.ExecuteSqlRawAsync("EXEC [dbo].[DeleteOrderItem] @orderID, @productID", orderIdParam, productIdParam);
        }

        public async Task<List<SelectOrderReturnModel>> SelectAllOrdersAsync()
        {
            const string sqlCommand = "EXEC [dbo].[SelectAllOrders]";
            var procResultData = await Set<SelectOrderReturnModel>()
                .FromSqlRaw(sqlCommand)
                .ToListAsync();

            return procResultData;
        }

        public async Task<List<SelectOrderReturnModel>> SelectCurrentOrdersAsync()
        {
            const string sqlCommand = "EXEC [dbo].[SelectCurrentOrders]";
            var procResultData = await Set<SelectOrderReturnModel>()
                .FromSqlRaw(sqlCommand)
                .ToListAsync();

            return procResultData;
        }

        public async Task<SelectOrderReturnModel> SelectOrderAsync(int? orderId)
        {
            var orderIdParam = new SqlParameter { ParameterName = "@orderID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = orderId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!orderId.HasValue)
                orderIdParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[SelectOrder] @orderID";
            var procResultData = await Set<SelectOrderReturnModel>()
                .FromSqlRaw(sqlCommand, orderIdParam)
                .ToListAsync();

            return procResultData.Count > 0 ? procResultData[0] : null;
        }
        public async Task<List<SelectOrderItemsReturnModel>> SelectOrderItemsAsync(int? orderId)
        {
            var orderIdParam = new SqlParameter { ParameterName = "@orderID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = orderId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!orderId.HasValue)
                orderIdParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[SelectOrderItems] @orderID";
            var procResultData = await Set<SelectOrderItemsReturnModel>()
                .FromSqlRaw(sqlCommand, orderIdParam)
                .ToListAsync();

            return procResultData;
        }

        public async Task<int> UpdateOrderAsync(int? orderId, string customerId, DateTime? requiredDate, decimal? freight, string shipCity, string shipCountry)
        {
            var orderIdParam = new SqlParameter { ParameterName = "@orderID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = orderId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!orderId.HasValue)
                orderIdParam.Value = DBNull.Value;

            var customerIdParam = new SqlParameter { ParameterName = "@customerID", SqlDbType = SqlDbType.NChar, Direction = ParameterDirection.Input, Value = customerId, Size = 5 };
            if (customerIdParam.Value == null)
                customerIdParam.Value = DBNull.Value;

            var requiredDateParam = new SqlParameter { ParameterName = "@requiredDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = requiredDate.GetValueOrDefault() };
            if (!requiredDate.HasValue)
                requiredDateParam.Value = DBNull.Value;

            var freightParam = new SqlParameter { ParameterName = "@freight", SqlDbType = SqlDbType.Money, Direction = ParameterDirection.Input, Value = freight.GetValueOrDefault(), Precision = 19, Scale = 4 };
            if (!freight.HasValue)
                freightParam.Value = DBNull.Value;

            var shipCityParam = new SqlParameter { ParameterName = "@shipCity", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = shipCity, Size = 15 };
            if (shipCityParam.Value == null)
                shipCityParam.Value = DBNull.Value;

            var shipCountryParam = new SqlParameter { ParameterName = "@shipCountry", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = shipCountry, Size = 15 };
            if (shipCountryParam.Value == null)
                shipCountryParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            return await Database.ExecuteSqlRawAsync("EXEC [dbo].[UpdateOrder] @orderID, @customerID, @requiredDate, @freight, @shipCity, @shipCountry", orderIdParam, customerIdParam, requiredDateParam, freightParam, shipCityParam, shipCountryParam);
        }             

        public async Task<List<Customer>> SelectAllCustomersAsync()
        {
            const string sqlCommand = "EXEC [dbo].[SelectAllCustomers]";
            var procResultData = await Set<Customer>()
                .FromSqlRaw(sqlCommand)
                .ToListAsync();

            return procResultData;
        }

        public async Task<List<Product>> SelectAllProductsAsync()
        {
            const string sqlCommand = "EXEC [dbo].[SelectAllProducts]";
            var procResultData = await Set<Product>()
                .FromSqlRaw(sqlCommand)
                .ToListAsync();

            return procResultData;
        }
    }
}
// </auto-generated>