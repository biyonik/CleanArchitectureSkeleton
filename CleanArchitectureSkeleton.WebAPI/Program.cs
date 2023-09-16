using CleanArchitectureSkeleton.Application;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Persistence.Contexts;
using CleanArchitectureSkeleton.Persistence.Services;
using CleanArchitectureSkeleton.Presentation;
using static System.AppContext;

var builder = WebApplication.CreateBuilder(args);


// Bind Presentation Layer to the API Layer
builder.Services.AddControllers()
    .AddApplicationPart(
        typeof(PresentationAssemblyReference).Assembly
    );
// Add DbContext to the API Layer
builder.Services.AddDbContext<AppDbContext>();
SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add MediatR to the API Layer
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
});

// Add Services to the API Layer (Dependency Injection)
builder.Services.AddScoped<ICarService, CarManager>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();