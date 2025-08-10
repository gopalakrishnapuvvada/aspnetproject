using System;
using System.Threading.Tasks;

namespace MyApiProject.Repositories
{
    public abstract class BaseRepository
    {
        // ✅ Common logging method
        protected void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        // ✅ Common error tracking method
        protected void HandleError(Exception ex)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {ex.Message}");
            // You could also write this to a file or DB later
        }

        // ✅ Force subclass to identify itself
        public abstract Task<string> GetEntityNameAsync();
    }
}
