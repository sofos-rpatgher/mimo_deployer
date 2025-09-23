using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimo_Interpreter
{
    internal class LogHelper
    {
        private string filePath = "";

        public LogHelper(string logFileName, string dirPath, string logLevel = "INFO")
        {
            string ext = "";
            if (logLevel == "INFO")
            {
                ext = ".log";
            }
            else
            {
                ext = ".logerr";
            }
            // make directory for the current execution's logs
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            filePath = Path.Combine(dirPath, $"{logFileName + ext}");
            WriteHeader();
        }

        private void WriteHeader()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    string logMessage = $"\r\n==================================================================================================\r\nExecution log file\r\n==================================================================================================\r\n";
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de log: {ex.Message}");
            }
        }


        public void WriteLog(string message, string logLevel = "INFO")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] - {message}";
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de log: {ex.Message}");
            }
        }
    }
}
