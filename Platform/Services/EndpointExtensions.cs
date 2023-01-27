using Platform.Services;

namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointExtensions 
    {
        public static void MapWeather(this IEndpointRouteBuilder app, string path)
        {
            IResponseFormattter formattter = 
                app.ServiceProvider.GetRequiredService<IResponseFormattter>();
            app.MapGet(path, context => Platform.WeatherEndpoint.Endpoint(context, formattter));
        }
    }
}
