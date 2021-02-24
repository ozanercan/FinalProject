using System.Diagnostics;

namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Debug.WriteLine("Dosyaya loglandı.");
        }
    }
}
