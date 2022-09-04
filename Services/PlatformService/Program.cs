var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("PlatformInMemoryDb");
});

builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.

var app = builder.Build();

app.PopulationData();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
