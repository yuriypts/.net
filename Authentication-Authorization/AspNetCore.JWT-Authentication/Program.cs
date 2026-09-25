
using AspNetCore.JWT_Authentication.DatabaseContext;
using AspNetCore.JWT_Authentication.Infrastructure;
using AspNetCore.JWT_Authentication.Repositories;
using AspNetCore.JWT_Authentication.Repositories.Interfaces;
using AspNetCore.JWT_Authentication.Services;
using AspNetCore.JWT_Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

namespace AspNetCore.JWT_Authentication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("Jwt"));

        //JwtBearerDefaults.AuthenticationScheme is "Bearer" token in header, which is the default scheme for JWT authentication.
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // Issuer means the server that generates the token. In this case, we are not validating the issuer.
                    ValidateAudience = false, // Audience means the client that receives the token. In this case, we are not validating the audience.
                    ValidateLifetime = true, // Validate the expiration and not before values in the token
                    ValidateIssuerSigningKey = true, // Validate the signing key is part of a trusted list of keys
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
                };
            });

        builder.Services.AddAuthorization();

        builder.Services.AddControllers();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EntityFrameworkConnectionString")));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Enter your JWT token directly"
            };

            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, jwtSecurityScheme);
            options.AddSecurityRequirement(document =>
                new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, document)] = []
                }
            );
        });

        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IJwtService, JwtService>();
        builder.Services.AddSingleton<PasswordHash>();

        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
