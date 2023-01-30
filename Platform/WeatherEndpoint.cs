using Platform.Services;

namespace Platform
{
    public class WeatherEndpoint
    {
        //private IResponseFormattter formatter;

        //public WeatherEndpoint(IResponseFormattter formatter)
        //{
        //    this.formatter = formatter;
        //}

        public async Task Endpoint(HttpContext context, 
            IResponseFormatter formatter)
        {
            await formatter.Format(context,
                "Endpoint Class: It is cloudy in Milan.");
        } 
    }
}
