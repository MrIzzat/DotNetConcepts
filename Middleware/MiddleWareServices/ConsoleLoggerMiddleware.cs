namespace Middleware.MiddleWareServices
{
    public class ConsoleLoggerMiddleware :IMiddleware //This middleware needs to be injected into the services in the program.cs fiel
    {// services can be injected directly into this custom middleware
     //The other way to make a middleware is by using conventional middlewares
     //as seen here https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/extensibility?view=aspnetcore-7.0#imiddleware
     //There are differnces between using the interface vs using by convetion which can be seen in the link above

        public async Task InvokeAsync(HttpContext context, RequestDelegate next) 
        {
            Console.WriteLine("Hell yeah Before Request");
            await next(context);//This will call the next middleware in the pipeline
            Console.WriteLine("Hell yeah After request");//This line of code will only be triggered on the way back
        }

        
    }
}
