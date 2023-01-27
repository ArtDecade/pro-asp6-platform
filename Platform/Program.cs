using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IResponseFormattter, HtmlResponseFormatter>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

app.MapGet("middleware/function", async (HttpContext context, 
    IResponseFormattter formattter) =>
{
    await formattter.Format(context, "Middleware Function:  It is snowing in Chicago");
});

//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
app.MapWeather("endpoint/class");

app.MapGet("endpoint/function", async (HttpContext context,
    IResponseFormattter formatter) =>
{
    await formatter.Format(context, "Endpoint function:  It is sunny in LA.");
});

app.Run();
