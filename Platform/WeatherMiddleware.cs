namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;

        public WeatherMiddleware(RequestDelegate nextDelegate)
        {
            this.next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/middleware/class")
            {
                await context.Response
                    .WriteAsync($"Middleware Class:  It is snowing in New Providence.");
            } else
            {
                await next(context);
            }
        }
    }
}
