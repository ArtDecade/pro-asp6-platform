namespace Platform.Services
{
    public class TypeBroker
    {
        private static IResponseFormattter formatter = new HtmlResponseFormatter();

        public static IResponseFormattter Formatter => formatter;
    }
}
