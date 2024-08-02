using Asp.Versioning;
using E_Commerce_Negocio.Datos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"),
                         b => b.MigrationsAssembly("E-Commerce-Web-API"))
);

// Inyección de servicios (repositorios)
//EJEMPLO ---> builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();

// Inyección de servicios (gestores)
//EJEMPLO ---> builder.Services.AddScoped<IGestorUsuarioIdentity, GestorUsuarioIdentity>();

// Agregamos AutoMapper
//EJEMPLO ---> builder.Services.AddAutoMapper(typeof(CategoriaMapper));

//Se obtiene clave secreta
var key = builder.Configuration.GetValue<string>("ApiSettings:PrivateKey");

/*
 * Soporte para CORS:
 * Se pueden habilitar:
 * - 01. Para 1 Dominio
 * - 02. Para N Dominios
 * - 03. Para Todos los Dominios
 */
//EJEMPLO ---> builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", build =>
//{
//    // Aquí podemos colocar los Dominios que queremos permitir que consuman nuestra API
//    // NOTA: no colocar URLS con diagonal al final.
//    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
//    build.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyHeader();
//}));

// Soporte para CORS
//EJEMPLO ---> app.UseCors("CorsPolicy");

// Se configura la Autenticación
//EJEMPLO ---> builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    // En producción se asigna RequireHttpsMetadata = true;
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description =
    //    "Autenticación con Jason Web Token usando el esquema Bearer. \r\n\r\n " +
    //    "Ingresa la palabra 'Bearer' seguido de un [espacio] y después su token en el campo de abajo. \r\n\r\n " +
    //    "Ejemplo: \"Bearer tkljk1231mhj\"",
    //    Name = "Authorization",
    //    In = ParameterLocation.Header,
    //    Scheme = "Bearer"
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            },
    //            Scheme = "oauth2",
    //            Name = "Bearer",
    //            In = ParameterLocation.Header
    //        },
    //        new List<string>()
    //    }
    //});
    //options.SwaggerDoc("v1", new OpenApiInfo
    //{
    //    Version = "v1.0",
    //    Title = "E-Commerce-API V1.0",
    //    Description = "Web API E-Commerce Versión 1",
    //    //TermsOfService = new Uri(""),
    //    //Contact = new OpenApiContact
    //    //{
    //    //    Name = "",
    //    //    Url = new Uri("")
    //    //},
    //    //License = new OpenApiLicense
    //    //{
    //    //    Name = "Licencia E-Commerce",
    //    //    Url = new Uri("")
    //    //}
    //});
    //options.SwaggerDoc("v2", new OpenApiInfo
    //{
    //    Version = "v2.0",
    //    Title = "E-Commerce-API V2.0",
    //    Description = "Web API E-Commerce Versión 2",
    //    //TermsOfService = new Uri(""),
    //    //Contact = new OpenApiContact
    //    //{
    //    //    Name = "",
    //    //    Url = new Uri("")
    //    //},
    //    //License = new OpenApiLicense
    //    //{
    //    //    Name = "Licencia E-Commerce",
    //    //    Url = new Uri("")
    //    //}
    //});
    //options.SwaggerDoc("v3", new OpenApiInfo
    //{
    //    Version = "v3.0",
    //    Title = "E-Commerce-API V3.0",
    //    Description = "Web API E-Commerce Versión 3",
    //    //TermsOfService = new Uri(""),
    //    //Contact = new OpenApiContact
    //    //{
    //    //    Name = "",
    //    //    Url = new Uri("")
    //    //},
    //    //License = new OpenApiLicense
    //    //{
    //    //    Name = "Licencia E-Commerce",
    //    //    Url = new Uri("")
    //    //}
    //});
});

// Soporte para versionado
//var apiVersioningBuilder = builder.Services.AddApiVersioning(option =>
//{
//    option.AssumeDefaultVersionWhenUnspecified = true;
//    option.DefaultApiVersion = new ApiVersion(1, 0);
//    option.ReportApiVersions = true;
//    //Puedo comentar lo de abajo para que en la URL del Controlador figure la versión de la API.
//    //option.ApiVersionReader = ApiVersionReader.Combine(
//    //    new QueryStringApiVersionReader("api-version") // ?api-version=1.0
//    //    //new HeaderApiVersionReader("X-Version"),
//    //    //new MediaTypeApiVersionReader("Ver")
//    //);
//});

//apiVersioningBuilder.AddApiExplorer(
//    options =>
//    {
//        options.GroupNameFormat = "'v'VVV";
//        options.SubstituteApiVersionInUrl = true;
//    }
//);

// Servicios de IConfiguration y JWT:
//EJEMPLO ---> builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
//builder.Services.AddTransient<>();

// Soporte para Autenticación con .NET Identity
//EJEMPLO ---> builder.Services.AddIdentity<>().AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Soporte para Autenticación
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
