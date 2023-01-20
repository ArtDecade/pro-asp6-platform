using System.Diagnostics.Metrics;

namespace Platform
{
    public class Capitol
    {
        private RequestDelegate? next;

        public Capitol() { }
        public Capitol(RequestDelegate nextDelegate)
        {
            next= nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            string[] parts = context.Request.Path.ToString()
                .Split('/', StringSplitOptions.RemoveEmptyEntries);
            if ((parts.Length == 2) && (parts[0] == "capitol"))
            {
                string? capitol = null;
                string country = parts[1];

                switch (country.ToLower())
                {
                    case "uk":
                        capitol = "London";
                        break;
                    case "france":
                        capitol = "Paris";
                        break;
                    case "monaco":
                        context.Response.Redirect($"/population/{country}");
                        return;
                }
                if(capitol!= null)
                {
                    await context.Response
                        .WriteAsync($"{capitol} is the capitol of {country}");
                return;
                }
            }
        }
    }
}
