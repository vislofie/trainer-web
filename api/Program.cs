using System.Diagnostics;
using System.Text;
using api.Infrastructure;
using api.Models;
using api.Repositories.Implementations;
using api.Repositories.Interfaces;
using api.Services.Implementations;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(o => {});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers()
.AddNewtonsoftJson(options => 
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Trainer API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    var dbUser = builder.Configuration["POSTGRES_USER"];
    var dbPassword = builder.Configuration["POSTGRES_PASSWORD"];
    var dbName = builder.Configuration["POSTGRES_DB"];
    var dbHost = builder.Configuration["POSTGRES_HOST"];

    options.UseNpgsql($"User ID={dbUser};Password={dbPassword};Host={dbHost};Port=5432;Database={dbName}");
});
builder.Services.AddIdentity<AppUser, IdentityRole>(options => 
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme = 
    options.DefaultForbidScheme = 
    options.DefaultScheme = 
    options.DefaultSignInScheme = 
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["SIGNING_KEY"])
        )
    };
});

// SERVICES
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

// REPOSITORIES
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IMuscleGroupsRepository, MuscleGroupsRepository>();
builder.Services.AddScoped<IFileHandlerRepository, FileHandlerLocal>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.z
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cor => cor
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        await context.Database.MigrateAsync();
    }
    
    if (!context.MuscleGroup.Any())
    {
        context.MuscleGroup.AddRange(
            new MuscleGroup { Name = "Neck" },
            new MuscleGroup { Name = "Shoulders" },
            new MuscleGroup { Name = "Chest" },
            new MuscleGroup { Name = "Arms" },
            new MuscleGroup { Name = "Forearms" },
            new MuscleGroup { Name = "Upper back" },
            new MuscleGroup { Name = "Lower back" },
            new MuscleGroup { Name = "Abs" },
            new MuscleGroup { Name = "Glutes" },
            new MuscleGroup { Name = "Front legs" },
            new MuscleGroup { Name = "Back legs" },
            new MuscleGroup { Name = "Calves" }
        );
    }

    if (!context.ExerciseLevels.Any())
    {
        context.ExerciseLevels.AddRange(
            new ExerciseLevel { Name = "Beginner" },
            new ExerciseLevel { Name = "Intermediate" },
            new ExerciseLevel { Name = "Advanced" }
        );
    }
    
    await context.SaveChangesAsync();
}


app.Run();