var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

((IApplicationBuilder)app).Map("/branch", branch =>
{
    //branch.UseMiddleware<Platform.QueryStringMiddleware>();

    //branch.Run(async (context) =>
    //{
    //    await context.Response.WriteAsync($"Branch Middleware");
    //});

    branch.Run(new Platform.QueryStringMiddleware().Invoke);
    //branch.Use(async (HttpContext context, Func<Task> next) =>
    //{
    //    await context.Response.WriteAsync($"Branch Middleware");
    //});
});

app.Use(async (context, next) =>
{
    await next();
    await context.Response
        .WriteAsync($"\nStatus Code:  {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/short")
    {
        await context.Response
            .WriteAsync($"Request short-circuited");
    }
    else
    {
        await next();
    }
});

app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Get
            && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware \n");
    }
    await next();
});

app.UseMiddleware<Platform.QueryStringMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();