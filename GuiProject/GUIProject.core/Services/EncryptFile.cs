using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProject
{
    public class EncryptFile
    {
        public async Task launchEncrypt(string FileToEncrypt, string Destination)
        {
            Process process = new Process();
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            process.StartInfo.FileName = Path.Combine(sCurrentDirectory, @"..\..\..\..\..\CryptoSoft\bin\Debug\net6.0\CryptoSoft.exe");
            process.StartInfo.ArgumentList.Add(FileToEncrypt);
            process.StartInfo.ArgumentList.Add(Destination);
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }
    }
}