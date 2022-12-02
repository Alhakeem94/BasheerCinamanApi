using BasheerCinamanApi.Data;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.UnitOfWork.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{             
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});



builder.Services.AddScoped<ICatagories, CatagoriesRepo>();
builder.Services.AddScoped<ICompanies, CompaniesRepo>();
builder.Services.AddScoped<IProducts, ProductsRepo>();
builder.Services.AddScoped<IProvidor, ProvidorRepo>();
builder.Services.AddScoped<IBatch, BatchesRepo>();
builder.Services.AddScoped<IUsers, UsersRepo>();
builder.Services.AddScoped<ISuperAdmin, SuperAdminRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
