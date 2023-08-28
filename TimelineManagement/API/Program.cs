using System.Net;
using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.Repositories;
using TimelineManagement.Services;
using TimelineManagement.Utilities.Handlers;
using TokenHandler = TimelineManagement.Utilities.Handlers.TokenHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = _context =>
        {
            var errors = _context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage);

            return new BadRequestObjectResult(new ResponseValidatorHandler
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Validation Error",
                Errors = errors.ToArray()
            });
        };
    });

//Add DbContext to the container
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TimelineManagementDbContext>(option => option.UseSqlServer(connection));

//Add Repositories to the container
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectCollaboratorRepository, ProjectCollaboratorRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskCommentRepository, TaskCommentRepository>();
builder.Services.AddScoped<ITaskHistoryRepository, TaskHistoryRepository>();

//Add Services to the container
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountRoleService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<ProjectCollaboratorService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<SectionService>();
builder.Services.AddScoped<TaskCommentService>();
builder.Services.AddScoped<TaskHistoryService>();
builder.Services.AddScoped<TaskService>();

//Add SmtpClient to container
builder.Services.AddTransient<IEmailHandler, EmailHandler>(_ => new EmailHandler(
    builder.Configuration["EmailService:SmtpServer"],
    int.Parse(builder.Configuration["EmailService:SmtpPort"]),
    builder.Configuration["EmailService:FromEmailAddress"]));


//Register FluentValidation 
builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

//Register TokenHandler
builder.Services.AddScoped<ITokenHandler, TokenHandler>();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// JWT Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTConfig:SecretKey"])),
            ValidateIssuer = true,
            //Usually, this is your application base URL
            ValidIssuer = builder.Configuration["JWTConfig:Issuer"],
            ValidateAudience = true,
            //If the JWT is created using a web service, then this would be the consumer URL.
            ValidAudience = builder.Configuration["JWTConfig:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => {
    x.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v1",
        Title = "Metrodata Coding Camp",
        Description = "ASP.NET Core API 6.0"
    });
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
