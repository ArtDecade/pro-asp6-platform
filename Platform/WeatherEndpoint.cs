using Platform.Services;

namespace Platform
{
    public class WeatherEndpoint
    {
        public async static Task Endpoint(HttpContext context, 
            IResponseFormattter formattter)
        {
            await formattter.Format(context,
                "Endpoint Class: It is cloudy in Milan.");
        } 
    }
}
