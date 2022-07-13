// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NwOrdersAPI.Entities;
using NwOrdersAPI.DTOs;

namespace NwOrdersAPI
{
    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public interface INwDbContext : IDisposable
    {
        DbSet<Category> Categories { get; set; } // Categories
        DbSet<Customer> Customers { get; set; } // Customers
        DbSet<Employee> Employees { get; set; } // Employees
        DbSet<Order> Orders { get; set; } // Orders
        DbSet<OrderDetail> OrderDetails { get; set; } // Order Details
        DbSet<Product> Products { get; set; } // Products
        DbSet<Supplier> Suppliers { get; set; } // Suppliers

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();

        EntityEntry Add(object entity);
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync(params object[] entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default);
        void AddRange(IEnumerable<object> entities);
        void AddRange(params object[] entities);

        EntityEntry Attach(object entity);
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        void AttachRange(IEnumerable<object> entities);
        void AttachRange(params object[] entities);

        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);
        ValueTask<object> FindAsync(Type entityType, params object[] keyValues);
        object Find(Type entityType, params object[] keyValues);

        EntityEntry Remove(object entity);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange(IEnumerable<object> entities);
        void RemoveRange(params object[] entities);

        EntityEntry Update(object entity);
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange(IEnumerable<object> entities);
        void UpdateRange(params object[] entities);

        IQueryable<TResult> FromExpression<TResult> (Expression<Func<IQueryable<TResult>>> expression);

        // Stored Procedures
        Task<int> AddToOrderAsync(int? orderId, int? productId, int? quantity, float? discount);
        Task<int> CreateOrderAsync(string customerId, DateTime? requiredDate, decimal? freight, string shipCity, string shipCountry);
        Task<int> DeleteOrderAsync(int? orderId);
        Task<int> DeleteOrderItemAsync(int? orderId, int? productId);        
        Task<List<SelectOrderReturnModel>> SelectAllOrdersAsync();             
        Task<List<SelectOrderReturnModel>> SelectCurrentOrdersAsync();
        Task<SelectOrderReturnModel> SelectOrderAsync(int? orderId);
        Task<List<SelectOrderItemsReturnModel>> SelectOrderItemsAsync(int? orderId);
        Task<int> UpdateOrderAsync(int? orderId, string customerId, DateTime? requiredDate, decimal? freight, string shipCity, string shipCountry);
        Task<List<Customer>> SelectAllCustomersAsync();
        Task<List<Product>> SelectAllProductsAsync();
    }
}
// </auto-generated>