namespace Platform
{
    public class QueryStringMiddleware
    {
        private RequestDelegate? next;

        public QueryStringMiddleware()
        {
            // do nothing
        }

        public QueryStringMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Method == HttpMethods.Get 
                && context.Request.Query["custom"] == "true")
            {
                if(!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class-based Middleware \n");
            }
            if (next != null)
            {
                await next(context);
            }
        }
    }
}
