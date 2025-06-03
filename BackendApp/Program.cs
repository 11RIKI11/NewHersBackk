using BackendApp.Swagger;
using Core.Model.Binders;
using Infrastructure;
using Infrastructure.Service;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

#region ApiVersionSettings

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

#endregion

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Reddit", Version = "1.0" });
    options.ResolveConflictingActions(apiDescription => apiDescription.First());
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "������� JWT ����� � �������: Bearer {your token}"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    options.SchemaFilter<FormDataSchemaFilter>();
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:ConnectionString"],
    b => b.MigrationsAssembly("Infrastructure")
    )
);

builder.Services.AddAutoMapper(typeof(BackendApp.Mappers.AutoMapper));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var authorizationHeader = context.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(authorizationHeader) &&
                    authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    context.Token = authorizationHeader["Bearer ".Length..].Trim();

                return Task.CompletedTask;
            }
        };

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            RoleClaimType = ClaimTypes.Role,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<JwtTokenGenerator>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<UserEventCalendarService>();
builder.Services.AddScoped<AttendeeService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<EventAddRequestBinder>();
builder.Services.AddScoped<EventUpdateRequestBinder>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0"); });
}

app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStaticFiles();
app.UseDefaultFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
