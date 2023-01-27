using Platform.Services;

namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        private IResponseFormattter formatter;

        public WeatherMiddleware(RequestDelegate nextDelegate, 
            IResponseFormattter respFormatter)
        {
            this.next = nextDelegate;
            this.formatter = respFormatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/middleware/class")
            {
                await formatter.Format(context,
                    "Middleware Class:  It is snowing in New Providence.");
            } else
            {
                await next(context);
            }
        }
    }
}
