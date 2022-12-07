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
            process.StartInfo.FileName = @"C:\Users\teosp\OneDrive\Bureau\A3\Projet.NET\Prosit5\XorTest\XorTest\bin\Debug\net6.0\XorTest.exe";
            process.StartInfo.ArgumentList.Add(FileToEncrypt);
            process.StartInfo.ArgumentList.Add(Destination);
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }
    }
}