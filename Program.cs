using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Enable OpenAPI document
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Enable Scalar
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Library Borrowing API")
            .WithTheme(ScalarTheme.BluePlanet);
    });
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable authorization
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();