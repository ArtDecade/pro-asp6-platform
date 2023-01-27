namespace Platform
{
    public class WeatherEndpoint
    {
        public async static Task Endpoint(HttpContext context)
        {
            await context.Response
                .WriteAsync($"Endpoint Class: It is cold in NH.");
        }
    }
}
