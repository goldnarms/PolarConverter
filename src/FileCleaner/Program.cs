using Microsoft.WindowsAzure.Jobs;

namespace FileCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new JobHost();
            host.Call(typeof(FileDeleter).GetMethod("DeleteOldFiles"));
        }
    }
}
