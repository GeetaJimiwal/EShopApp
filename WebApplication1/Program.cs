using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;
/*using WebApplication1.Repository;*/
using WebApplication1.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Services;
using WebApplication1.Repository;
using System.Configuration;
using Serilog;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
 Log.Logger = new LoggerConfiguration().
    MinimumLevel.Information()
    .WriteTo.File("lOG/log.txt",rollingInterval:RollingInterval.Minute)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Logging.AddSerilog();
builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

builder.Services.AddTransient<IUseService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ISecurityService, SecurityService>();
builder.Services.AddTransient<IUserCreadentialService, UserCreadentialService>();
builder.Services.AddTransient<ILoginRepository, LoginRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserCreadential, UserCreadentialRepository>();
builder.Services.AddTransient<IMailService, MailService>();
 builder.Services.AddTransient<ICartItemInterface, CartItemRepository>();
builder.Services.AddTransient<ICartItemService, CartItemService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();


builder.Services.AddSendGrid(options =>
    options.ApiKey = builder.Configuration.GetValue<string>("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")
                     ?? throw new Exception("The 'SendGridApiKey' is not configured")
);
builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

