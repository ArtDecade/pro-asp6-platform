namespace Platform.Services
{
    public class TextRepsonseFormatter : IResponseFormatter
    {
        private int _responseCounter = 0;
        private static TextRepsonseFormatter? shared;
        public async Task Format(HttpContext context, string content)
        {
            await context.Response
                .WriteAsync($"Response {++_responseCounter}: \n{content}");
        }

        public static TextRepsonseFormatter Singleton
        {
            get
            {
                if (shared == null )
                {
                    shared = new TextRepsonseFormatter();   
                }
                return shared;  
            }
        }
    }
}
