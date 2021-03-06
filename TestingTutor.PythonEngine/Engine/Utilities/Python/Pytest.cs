﻿using System.Diagnostics;

namespace TestingTutor.PythonEngine.Engine.Utilities.Python
{
    public class Pytest : IPytest
    {
        public int Run(string arguments, string output, string workingDirectory)
        {
            var process = new Process();
            var startInfo = 
                new ProcessStartInfo()
                {
                    FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    Arguments = $"-Command \"pytest {arguments} > {output}\"",
                    WorkingDirectory = workingDirectory
                };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            var exitCode = process.ExitCode;
            process.Close();
            process.Dispose();
            return exitCode;
        }
    }
}
