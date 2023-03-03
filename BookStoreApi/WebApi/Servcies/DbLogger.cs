namespace WebApi.Servcies
{
    public class DbLoger : ILoggerService
    {
        public void Write(string message)
        {
            System.Console.WriteLine("[DbLogger] - " + message);
        }    
    }
}