using Core.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityDefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(optionsAction =>
{
    optionsAction.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<ApplicationIdentityDbContext>(optionsAction =>
{
    optionsAction.UseSqlServer(identityConnectionString);
});

builder.Services.AddIdentityCore<ApplicationUser>(optionsAction =>
{

})
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
    .AddSignInManager<ApplicationUser>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// configure Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// configure Auttomapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("https://localhost/4200"));
});

// configure redis
builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var options = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
    return ConnectionMultiplexer.Connect(options);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
var context = service.GetRequiredService<ApplicationDbContext>();

var identityContext = service.GetRequiredService<ApplicationIdentityDbContext>();
var userManger = service.GetRequiredService<UserManager<ApplicationUser>>();

var logger = service.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await ApplicationDbContextSeed.SeedAsync(context);

    await identityContext.Database.MigrateAsync();
    await ApplicationIdentityDbContextSeed.SeedUserAsync(userManger);
}
catch (Exception ex)
{
    logger.LogError(ex, "Error occured while migrating proccess!");
}

app.Run();


// To commit 
// Added AddProductDto, AddProductTypeDto and AddProductBrandDto
// Added Create Operation to Product, ProductType and ProductBrand Controllers 