using System.Diagnostics;

namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Debug.WriteLine("Veritabanına loglandı.");
        }
    }
}
