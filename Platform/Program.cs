//using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<Population>();
app.UseMiddleware<Capitol>();
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Terminal middleware reached.");
});

app.Run();
