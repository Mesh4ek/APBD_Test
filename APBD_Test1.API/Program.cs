// Program.cs

var builder = WebApplication.CreateBuilder(args);

// 1. Configure services
builder.Services.AddControllers();

// 1a. (Optional) Add application services
// builder.Services.AddScoped<IMyService, MyService>();

// 1b. (Optional) Add database context
// builder.Services.AddDbContext<MyDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 2. Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Your API Name",
        Version = "v1",
        Description = "Description of your API"
    });
});

var app = builder.Build();

// 3. Configure middleware pipeline

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// 3a. Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    c.RoutePrefix = string.Empty; // serve at root (/)
});

// 3b. HTTPS redirection
app.UseHttpsRedirection();

// 3c. Authentication/Authorization
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers(); // Map [ApiController] routes

app.Run();