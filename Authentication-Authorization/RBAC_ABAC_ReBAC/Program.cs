

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using RBAC_ABAC_ReBAC.ABAC;
using RBAC_ABAC_ReBAC.Infrastructure;
using RBAC_ABAC_ReBAC.RBAC;
using RBAC_ABAC_ReBAC.ReBAC.RelationStore;
using RBAC_ABAC_ReBAC.Services;
using RBAC_ABAC_ReBAC.Services.Interfaces;

namespace RBAC_ABAC_ReBAC
{
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
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Permissions.DocumentsRead, policy => policy.RequireRole(AppRoles.Admin, AppRoles.Manager, AppRoles.Reader));
                options.AddPolicy(Permissions.DocumentsUpdate, policy => policy.RequireRole(AppRoles.Admin, AppRoles.Manager));
                
                options.AddPolicy(Permissions.DocumentsApprove, policy => {
                    policy.RequireRole(AppRoles.Admin, AppRoles.Manager);
                    policy.AddRequirements(new DocumentReadRequirement());
                });

                options.AddPolicy(Permissions.DocumentsDelete, policy =>
                {
                    policy.RequireRole(AppRoles.Admin);
                    policy.AddRequirements(new DocumentReadRelationshipRequirement());
                });
            });

            builder.Services.AddControllers();

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
            builder.Services.AddSingleton<IJwtService, JwtService>();
            builder.Services.AddSingleton<PasswordHash>();
            
            builder.Services.AddScoped<IAuthorizationHandler, DocumentReadHandler>();

            builder.Services.AddSingleton<IRelationshipStore, RelationshipStore>();
            builder.Services.AddScoped<IAuthorizationHandler, DocumentReadRelationshipHandler>();

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
}
