using System.Linq.Expressions;
using Audit.Core;
using Audit.EntityFramework;
using Audit.EntityFramework.Providers;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Entities.Audit;
using Infrastructure.Data.Helpers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        private static readonly Dictionary<Type, Type> AuditTypeMap = new()
        {
            { typeof(ProductEntity), typeof(AuditProductEntity) }
        };
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=OnlineStoreDB;Username=postgres;Password=Jeet@123");
            });

            //services.AddDbContext<Data.AuditDbContext>(options =>
            //{
            //    options.UseNpgsql("Host=localhost;Port=5432;Database=OnlineStoreDB;Username=postgres;Password=Jeet@123");
            //});

            Audit.Core.Configuration.DataProvider = new EntityFrameworkDataProvider()
            {
                DbContextBuilder = ev => new Data.AuditDbContext(),
                AuditTypeMapper = (t, ee) => typeof(AuditLog),
                AuditEntityAction = (evt, entry, auditEntity) =>
                {
                    var a = (dynamic)auditEntity;
                    a.AuditDate = DateTime.UtcNow;
                    a.UserName = evt.Environment.UserName;
                    a.TableName = entry.Table;
                    //a.PrimaryKey = String.Join(",", entry.PrimaryKey.FirstOrDefault());
                    a.PrimaryKey = (int)entry.PrimaryKey.FirstOrDefault().Value;
                    a.Action = entry.Action; // Insert, Update, Delete
                    a.Value = System.Text.Json.JsonSerializer.Serialize(AuditHelper.CreateAuditChangeObject(entry));
                    return Task.FromResult(true); // return false to ignore the audit
                }
            };

            //Audit.Core.Configuration.Setup()
            //.UseEntityFramework(ef => ef
            //    .UseDbContext<Infrastructure.Data.AuditDbContext>()
            //    .AuditTypeExplicitMapper(m => m
            //        .Map<ProductEntity, Audit_ProductEntity>((table, tableHistory) =>
            //        {
            //            Console.WriteLine(table.Name, tableHistory.Name);
            //            tableHistory.Name = table.Name;
            //            tableHistory.Quantity = table.Quantity;
            //            tableHistory.Price = table.Price;
            //            tableHistory.Description = table.Description;
            //            tableHistory.Id = table.Id;
            //        })
            //        //.Map<Table2, Table2History>((otherTable, otherTableHistory) =>
            //        //{
            //        //    FillOtherTableHistoryData(otherTable, otherTableHistory);
            //        //})
            //        .MapExplicit<AuditLog>(entry => IsAnotherTable(entry), (entry, entity) =>
            //        {
            //            entity.NewValues = entry.ToJson();
            //            entity.TableName = entry.EntityType.Name;
            //            entity.AuditDate = DateTime.UtcNow;
            //            entity.UserName = "Jeet";
            //            entity.PrimaryKey = String.Join(",", entry.PrimaryKey.FirstOrDefault());
            //            entity.Action = entry.Action; // Insert, Update, Delete
            //        }))
            //    .IgnoreMatchedProperties(true));

            //Audit.Core.Configuration.DataProvider = new EntityFrameworkDataProvider()
            //{
            //    DbContextBuilder = ev => new Data.AuditDbContext(),
            //    AuditTypeMapper = (t, ee) =>
            //    {
            //        return AuditTypeMap[t];
            //    },
            //    AuditEntityAction = (evt, entry, auditEntity) =>
            //    {
            //        var a = (dynamic)auditEntity;
            //        a.AuditDate = DateTime.UtcNow;
            //        a.UserName = evt.Environment.UserName;
            //        a.Action = entry.Action; // Insert, Update, Delete
            //        return Task.FromResult(true); // return false to ignore the audit
            //    }
            //};

            //Audit.Core.Configuration.Setup()
            //.UseEntityFramework(x => x
            //    .UseDbContext<Infrastructure.Data.AuditDbContext>()
            //    .AuditTypeMapper((entityType) => AuditTypeMap[entityType])
            //    .AuditEntityAction((evt, entry, auditEntity) =>
            //    {
            //        // auditEntity is object
            //        ((dynamic)auditEntity).AuditDate = DateTime.UtcNow;
            //        var a = (dynamic)auditEntity;
            //        a.AuditDate = DateTime.UtcNow;
            //        a.UserName = evt.Environment.UserName;
            //        a.Action = entry.Action; // Insert, Update, Delete
            //    }));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
