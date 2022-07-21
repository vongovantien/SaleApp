using Amazon.S3;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Sieve.Services;
using System.Text;
using System.Text.Json.Serialization;
using WebAPI.Helpers;
using WebAPI.IServices;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Services.Mail;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{



    var services = builder.Services;
    var env = builder.Environment;
    var configuration = builder.Configuration;

    configuration.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

    services.AddCors();
    services.AddControllers();
    services.AddScoped<SieveProcessor>();
    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.AddDbContext<saledbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("DBConnString"));
    });
    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    var emailConfig = configuration
        .GetSection("EmailConfiguration")
        .Get<MailConfiguration>();
    builder.Services.AddSingleton(emailConfig);

}
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc

.ReadFrom.Configuration(ctx.Configuration)));

//Hangfire
builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Server = 27.74.255.96; Database = saledb; User Id = tienvo; Password = tienV0#%"));
builder.Services.AddHangfireServer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAws3Services, Aws3Services>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddControllers();

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Chat API",
        Description = "Chat API Swagger Surface",
        Contact = new OpenApiContact
        {
            Name = "João Victor Ignacio",
            Email = "ignaciojvig@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/ignaciojv/")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://github.com/ignaciojvig/ChatAPI/blob/master/LICENSE")
        }

    });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

// custom jwt auth middleware
//app.UseMiddleware<JwtMiddleware>();
app.UseSerilogRequestLogging();
app.MapControllers();
app.UseHttpsRedirection();

//jwt
var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");


// Add JWT configuration
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard("/hangfire");
app.Run();
