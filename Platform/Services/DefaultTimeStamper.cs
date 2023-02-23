namespace Platform.Services
{
    public class DefaultTimeStamper : ITimeStamper
    {
        public string TimeStamp => DateTime.Now.ToShortTimeString();
    }
}
