using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Config;
using E_Commerce_Negocio.Datos;
using E_Commerce_Negocio.Gestores.AuthGestor;
using E_Commerce_Negocio.Gestores.CategoriaGestor;
using E_Commerce_Negocio.Gestores.EncoderGestor;
using E_Commerce_Negocio.Gestores.GeneroGestor;
using E_Commerce_Negocio.Gestores.JwtGestor;
using E_Commerce_Negocio.Gestores.MarcaGestor;
using E_Commerce_Negocio.Gestores.ProductoGestor;
using E_Commerce_Negocio.Gestores.UsuarioGestor;
using E_Commerce_Negocio.Gestores.UsuarioIdentityGestor;
using E_Commerce_Negocio.Repositorios.CategoriaRepo;
using E_Commerce_Negocio.Repositorios.GeneroRepo;
using E_Commerce_Negocio.Repositorios.MarcaRepo;
using E_Commerce_Negocio.Repositorios.ProductoRepo;
using E_Commerce_Negocio.Repositorios.RefreshTokenRepo;
using E_Commerce_Negocio.Repositorios.UsuarioIdentityRepo;
using E_Commerce_Negocio.Repositorios.UsuarioRepo;
using E_Commerce_Web_API.Config;
using E_Commerce_Web_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Debug("Init main");

try
{
    var builder = WebApplication.CreateBuilder(args);


    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
                             builder => builder.MigrationsAssembly("E-Commerce-Web-API"))
    );

    // ???
    //builder.Services.AddIdentity<UsuarioIdentity, IdentityRole>().AddDefaultTokenProviders();

    builder.Services.AddTransient<ApplicationDbContext>();

    // Se obtiene cadena de conexión
    var connectionString = builder.Configuration.GetSection("API:ConnectionString");

    // Se obtiene clave secreta
    var secretKey = builder.Configuration.GetSection("API:ApiSecretKey");

    // Esto se queda en el contenedor de dependencias para que lo utilicen el resto de los servicios.
    builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
    builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

    // Inyección de servicio de envío de mails.
    builder.Services.AddSingleton<IEmailSender, EmailService>();

    // Configuración para access token y refresh token.

    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);

    var tokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        /*
        En producción, ValidateIssuer es = true, ya que con esta se valida que el emisor del token
        sea alguien de confianza. 
        */
        ValidateAudience = false,
        /*
        En producción, ValidateAudience es = true, ya que con esta se valida el destinatario del token.
        Se valida que el destinatario sea el mismo que lo solicita.
        */
        RequireExpirationTime = false,
        /*
        En producción, RequireExpirationTime  es = true. Se mantiene como false hasta que hagamos el
        expiration token.
        */
        ValidateLifetime = true,
    }; ;

    // Inyectamos ValidationParameters como una dependencia, con esto podemos usar los ValidationParameters
    // fuera de Program.cs.
    builder.Services.AddSingleton(tokenValidationParameters);

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
    {
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = tokenValidationParameters;
    });

    builder.Services.AddDefaultIdentity<UsuarioIdentity>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.Configure<IdentityOptions>(options =>
    {
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(24);
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.SignIn.RequireConfirmedAccount = true;
    });

    /*
     * Soporte para CORS:
     * Se pueden habilitar:
     * - 01. Para 1 Dominio
     * - 02. Para N Dominios
     * - 03. Para Todos los Dominios
     */

    builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", build =>
    {
        // Aquí podemos colocar los Dominios que queremos permitir que consuman nuestra API
        // NOTA: no colocar URLS con diagonal al final.
        build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        build.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyHeader();
    }));

    // Inyección de servicios (repositorios)
    builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
    builder.Services.AddScoped<IRepositorioGenero, RepositorioGenero>();
    builder.Services.AddScoped<IRepositorioProducto, RepositorioProducto>();
    builder.Services.AddScoped<IRepositorioMarca, RepositorioMarca>();
    builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
    builder.Services.AddScoped<IRepositorioUsuarioIdentity, RepositorioUsuarioIdentity>();
    builder.Services.AddScoped<IRepositorioRefreshToken, RepositorioRefreshToken>();

    // Inyección de servicios (gestores)
    builder.Services.AddScoped<IGestorCategoria, GestorCategoria>();
    builder.Services.AddScoped<IGestorGenero, GestorGenero>();
    builder.Services.AddScoped<IGestorProducto, GestorProducto>();
    builder.Services.AddScoped<IGestorMarca, GestorMarca>();
    builder.Services.AddScoped<IGestorAuth, GestorAuth>();
    builder.Services.AddScoped<IGestorJwt, GestorJwt>();
    builder.Services.AddScoped<IGestorUsuario, GestorUsuario>();
    builder.Services.AddScoped<IGestorEncoder, GestorEncoder>();
    builder.Services.AddScoped<IGestorUsuarioIdentity, GestorUsuarioIdentity>();

    // Agregamos AutoMapper
    builder.Services.AddAutoMapper(typeof(CategoriaMapper));
    builder.Services.AddAutoMapper(typeof(GeneroMapper));
    builder.Services.AddAutoMapper(typeof(ProductoMapper));
    builder.Services.AddAutoMapper(typeof(MarcaMapper));
    builder.Services.AddAutoMapper(typeof(UsuarioMapper));
    builder.Services.AddAutoMapper(typeof(UsuarioIdentityMapper));

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "E-Commerce-Web-API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer Scheme. \r\n\r\n" +
            "Do not forget to enter prefix 'Bearer', space, and then your Token. \r\n\r\n" +
            "Example: 'Bearer token'"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new string[] { }
            }
        });
    });

    // Configuración para NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    app.UseSwagger();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    // Soporte para CORS
    app.UseCors("CorsPolicy");

    // Soporte para Autenticación
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exc)
{
    logger.Error(exc, "Ocurrió un error al inicializar el programa.");
    throw exc;
}
finally
{
    NLog.LogManager.Shutdown();
}
