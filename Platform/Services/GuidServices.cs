﻿namespace Platform.Services
{
    public class GuidServices : IResponseFormatter
    {
        private Guid guid = Guid.NewGuid();

        async Task IResponseFormatter.Format(HttpContext context, string content)
        {
           await context.Response.WriteAsync($"Guid: {guid}\n{content}");
        }
    }
}
