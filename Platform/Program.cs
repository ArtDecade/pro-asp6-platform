using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IResponseFormatter, GuidServices>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

app.MapGet("middleware/function", async (HttpContext context, 
    IResponseFormatter formattter) =>
{
    await formattter.Format(context, "Middleware Function:  It is snowing in Chicago");
});

//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
app.MapEndpoint<WeatherEndpoint>("endpoint/class");

app.MapGet("endpoint/function", async (HttpContext context) =>
{
    IResponseFormatter formatter =
        context.RequestServices.GetRequiredService<IResponseFormatter>();
    await formatter.Format(context, "Endpoint function:  It is sunny in LA.");
});

app.Run();
