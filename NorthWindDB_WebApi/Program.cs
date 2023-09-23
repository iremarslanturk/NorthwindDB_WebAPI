using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NorthWindDB_WebApi.Repositories;
using System.Text;
using JWTWebAuthentication.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using NorthWindDB_WebApi;
using NorthWindDB_WebApi.Services;
using NorthWindDB_WebApi.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using log4net.Config;
using log4net;
using AuthServer;
using log4net.Repository.Hierarchy;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddHttpClient("TestApiClient", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
    client.Timeout = TimeSpan.FromSeconds(30);
});

var log4netConfigPath = Path.Combine(AppContext.BaseDirectory, "Log4net.xml");
XmlConfigurator.ConfigureAndWatch(new FileInfo(log4netConfigPath));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDbContext, UserDbContext>();
builder.Services.AddScoped<IJWTManagerRepository, JWTManagerRepository>();


builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerConnection"));
});
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"));
});
builder.Services.AddDbContext<CategoryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CategoryConnection"));
});
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnection"));
});
builder.Services.AddDbContext<TerritoryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TerritoryConnection"));
});
builder.Services.AddDbContext<RegionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RegionConnection"));
});
builder.Services.AddDbContext<ShipperDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShipperConnection"));
});
builder.Services.AddDbContext<SupplierDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SupplierConnection"));
});
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderConnection"));
});
builder.Services.AddDbContext<InvoiceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InvoiceConnection"));
});

builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection"));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

var key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:Key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
});
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();



