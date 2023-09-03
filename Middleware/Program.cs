using Middleware.MiddleWareServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CustomMiddleWare>();
builder.Services.AddTransient<ConsoleLoggerMiddleware>();//To inject the middlewares

var app = builder.Build();

// Configure the HTTP request pipeline. This is like the Configure() method in the startup class

//In order to access the middlewares with the SwaggerUI the middleware code should be added before the if statment
if (app.Environment.IsDevelopment())//checks the environment to see if it's a development (?)
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseClassWithNoImplementationMiddleware();//this should be after the swagger and swaggerUI 
    //There is a better method than this so that static classes don't need to be used
}

//To chain delegates Use() should be used
/*app.Use(async (context, next) =>
{
    Console.WriteLine("Hell yeah Before Request");
    await next();//This will call the next middleware in the pipeline
    Console.WriteLine("Hell yeah After request");
});*/
//In order to create a custum Use() middleware that acts as the end of the middlieware pipeline instead of run()
//just add _ => and remove the next like this
/*app.Use( _ => (async context => 
{
    Console.WriteLine("Hell yeah From Custom Final Middleware");
    await context.Response.WriteAsync("Hell yeah From Custom Final Middleware");

}));*/
app.Map("/favicon.ico", (app) => { });
//This can be used instead of inline middleware after setting it up 
app.UseMiddleware<ConsoleLoggerMiddleware>();


//.Map() is a convention that is used to indicate that the middleware pipeline is being branched
//It completely breaks off the pipeline of the middlewares anything after the middleware in the original branch will not be invoked

app.Map("/map",  app => //This needs to be called app
{
    app.Run(async (context) =>
    {
        Console.WriteLine("hell yeah Map method");
        await context.Response.WriteAsync("hell yeah from Map method");
    });
}); //This will not go to the Run() middleware as it has completely branched off to the middlewares within the app => method

app.MapWhen(context => context.Request.Query.ContainsKey("q"),app =>{
    app.Run( async (context) =>
    {
        await context.Response.WriteAsync("Conditional Hell yeah");
    });
}); //This will check if the request query has a q in it
//if it does then it will go to the middlewares specified in the condition
// app.UseWhen() can be used instead of MapWhen() But the difference is the UseWhen() will go back into the pipeline while MapWhen() does not
//


//What's being passed to the app.Run() method is a delegate method to handle middleware services
app.Run(async context =>
{
    Console.WriteLine("Hell yeah from run");
    await context.Response.WriteAsync("Hell yeah from run");//This writes hell yeah into the response

});//in async with app.Run()
//when opening the website from the link without the extra stuff in the url it will print hell yeah
//In application this is done in a seperate
//this is known as an inline middleware since it's done inside the program.cs class
//middlewares can also be called request delegate
//The run delegate receives only a context parameter which means it doesn't know about the next middleware
//These are usually called terminal delegates because it usually ends the middleware pipeline
//It is more of a convention to use run to indicate the end of the pipeline a

app.Run(async context =>
{
    
    await context.Response.WriteAsync("Hell yeah for second time from run");//This writes hell yeah into the response

});
//This one will not be called as the run middleware before it has terminated the pipeline


//These are system defined middlewares (includding the swaggerUI() methods)
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//In .net 6.0+ there is no startup class anymore everything is done from the program.cs file


/*Don't call next.Invoke after the response has been sent to the client. Changes to HttpResponse after the response has started throw an exception. 
 For example, setting headers and a status code throw an exception. Writing to the response body after calling next:

May cause a protocol violation. For example, writing more than the stated Content-Length.
May corrupt the body format. For example, writing an HTML footer to a CSS file.

HasStarted is a useful hint to indicate if headers have been sent or the body has been written to.*/

//To see what the best practice is to change status code through a middleware in the response:
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-7.0#do-not-modify-the-status-code-or-headers-after-the-response-body-has-starteds


//The built in middlwares:
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0#built-in-middleware