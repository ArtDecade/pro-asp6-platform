using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

//IWebHostEnvironment env = builder.Environment;
IConfiguration config = builder.Configuration;

//"services": {
//"IResponseServices":  "Platform.Services.HtmlResponseFormatter"

builder.Services.AddScoped<IResponseFormatter>(serviceProvider =>
{
    string? typeName = config["services:IResponseFormatter"];
    return (IResponseFormatter)ActivatorUtilities
        .CreateInstance(serviceProvider, typeName == null
            ? typeof(GuidService) : Type.GetType(typeName, true)!);
});
builder.Services.AddScoped<ITimeStamper, DefaultTimeStamper>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

app.MapGet("middleware/function", async (HttpContext context, 
    IResponseFormatter formattter) =>
{
    await formattter.Format(context, "Middleware Function:  It is snowing in Chicago");  
});

//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
app.MapEndpoint<WeatherEndpoint>("endpoint/class");

// app.MapGet("/", () => "Hello, World!");

app.MapGet("endpoint/function", async (HttpContext context) =>
{
    IResponseFormatter formatter =
        context.RequestServices.GetRequiredService<IResponseFormatter>();
    await formatter.Format(context, "Endpoint function:  It is sunny in LA.");
});

app.Run();
