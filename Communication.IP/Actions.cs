using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication.IP
{
    public static class Actions
    {
        /// <summary>
        /// Initializes shutodown
        /// </summary>
        public static void Shutdown()
        {
            ExecuteCommandLine("shutdown /f /t 5");
        }

        /// <summary>
        /// Initializes shutodown
        /// </summary>
        public static void LogOff()
        {
            ExecuteCommandLine("shutdown /f");
        }

        /// <summary>
        /// Initializes shutodown
        /// </summary>
        public static void Restart()
        {
            ExecuteCommandLine("shutdown /f -r");
        }

        public static void ExecuteCommandLine(string command)
        {
            var cmd = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            cmd.Start();

            //execute specific command
            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
    }
}
