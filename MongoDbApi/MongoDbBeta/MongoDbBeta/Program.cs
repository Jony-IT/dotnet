using MongoDbBeta.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddScoped<AssortmentService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI(); 
}

app.MapControllers();

app.MapGet("/", (HttpContext http) =>
{
    http.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();