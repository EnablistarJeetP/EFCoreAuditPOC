using OnlineStoreCleanArchWebAPI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAppDI();

Infrastructure.Data.AuditDbContext.Configure(builder.Configuration);

var app = builder.Build();

//Audit.Core.Configuration.DataProvider = new EntityFrameworkDataProvider()
//{
//    DbContextBuilder = ev => app.Services.CreateScope().ServiceProvider.GetRequiredService<Audit.EntityFramework.AuditDbContext>(),
//    AuditTypeMapper = (t, ee) => typeof(AuditLog),
//    AuditEntityAction = (evt, entry, auditEntity) =>
//    {
//        var a = (dynamic)auditEntity;
//        a.AuditDate = DateTime.UtcNow;
//        a.UserName = "Jeet";
//        a.TableName = entry.Table;
//        a.PrimaryKey = String.Join(",", entry.PrimaryKey.FirstOrDefault());
//        a.Action = entry.Action; // Insert, Update, Delete
//        a.NewValues = entry.ToJson();
//        return Task.FromResult(true); // return false to ignore the audit
//    }
//};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
