var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => {
    if (context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Hi");
    }
    else if (context.Request.Query["custom"] == "fuck")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Fuck");
    }
    else
        await next();
});
app.Run();
