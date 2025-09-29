var builder = WebApplication.CreateBuilder(args);

// Configure CORS once
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
        policy
            .SetIsOriginAllowed(_ => true) 
            .AllowAnyOrigin()
            .AllowAnyHeader()              
            .AllowAnyMethod());            
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Sample.ProductsSample.Infraestructure.Interfaces.IProductService, Sample.ProductsSample.Infraestructure.Services.ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
