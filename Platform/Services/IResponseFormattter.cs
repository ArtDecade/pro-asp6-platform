namespace Platform.Services
{
    public interface IResponseFormattter
    {
        Task Format(HttpContext context, string content);
    }
}
