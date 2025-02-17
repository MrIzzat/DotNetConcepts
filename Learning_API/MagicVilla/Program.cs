using MagicVilla.Data;
using MagicVilla.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/villalogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();*/

//builder.Host.UseSerilog();
builder.Services.AddDbContext<ApplicationDbContext>(option => { //This is to add the database connection to the right class

    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));  //.GetSection("Connection")
                                                                                            // Can create exception to make sure it's not empty
});
builder.Services.AddControllers(option =>
{
    //option.ReturnHttpNotAcceptable = true; //prohibts returning data format that is not specified
}).AddNewtonsoftJson()// for Http patch?
.AddXmlDataContractSerializerFormatters()// allows xml support for the API
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ILogging, LoggingV2>();// Custom Logger

// Longest Lifetime it's created when the application starts the object is used whenever the application needs an implementation
//builder.Services.AddScoped it creates a new object for every request and provides it where it is requested
//builder.Services.AddTransient every time the object is requested it will create 10 different object and assign it where it's needed

//It's very important for th services to be defined before the builder function is called otherwrise it won't inject
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
