using Platform;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

((IApplicationBuilder)app).Map("/branch", branch => {
    branch.UseMiddleware<Platform.QueryStringMiddleWare>();
    branch.Use(async (HttpContext context, Func<Task> next) => {
        await context.Response.WriteAsync($"Branch Middleware");
    });
});

app.Map("/", () => "Hello World");
app.UseMiddleware<LocationMiddleware>();

app.UseMiddleware<Platform.QueryStringMiddleWare>();
app.Run();
