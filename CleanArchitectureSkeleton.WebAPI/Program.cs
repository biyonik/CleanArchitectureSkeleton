using CleanArchitectureSkeleton.Persistence.Contexts;
using CleanArchitectureSkeleton.Presentation;

var builder = WebApplication.CreateBuilder(args);


// Bind Presentation Layer to the API Layer
builder.Services.AddControllers()
    .AddApplicationPart(
        typeof(PresentationAssemblyReference).Assembly
    );
// Add DbContext to the API Layer
builder.Services.AddDbContext<AppDbContext>();

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