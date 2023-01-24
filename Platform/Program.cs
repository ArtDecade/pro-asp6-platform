//using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("{first}/{second}/{third}", async context => {
    await context.Response.WriteAsync("Request was routed \n");
    foreach(var kvp in context.Request.RouteValues)
    {
        await context.Response
            .WriteAsync($"{kvp.Key}: {kvp.Value}\n");
    }
});

//app.MapGet("routing", async context =>
//{
//    await context.Response.WriteAsync("Request was routed");
//});
app.MapGet("capital/uk", new Capital().Invoke);
app.MapGet("population/paris", new Population().Invoke);  

app.Run();
