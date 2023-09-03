using Middleware.MiddleWareServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CustomMiddleWare>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//These are system defined middlewares (except for app.Run())
if (app.Environment.IsDevelopment())//checks the environment to see if it's a development (?)
{
    app.UseClassWithNoImplementationMiddleware(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*app.Run(async context =>
{
    await context.Response.WriteAsync("Hell yeah");

})*/;//in async with app.Run()
//when opening the website from the link without the extra stuff in the url it will print hell yeah
//In application this is done in a seperate class


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//In .net 6.0+ there is no startup class anymore everything is done from the program.cs file