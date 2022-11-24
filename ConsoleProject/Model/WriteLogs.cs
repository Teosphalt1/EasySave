using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class WriteLogs
    {
        public static void WriteLogsOnJson(string Name, string newPath, string destPath, TimeSpan ts)
        {
            //Console.Write("\n" + Name);
            //Console.WriteLine("\nFileSource = " + newPath);
            //Console.WriteLine("destPath = " + destPath + @"\" + Path.GetFileName(newPath));
            //Console.WriteLine("time = " + DateTime.Now.ToString());
            //long length = new System.IO.FileInfo(newPath).Length;
            //Console.WriteLine("FileSize = " + length);


            // Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            string elapsedTime = ts.ToString();
            //Console.WriteLine("FileTransferTime = " + elapsedTime);

            string fileName = @"c:\logs.json";

            if (System.IO.File.Exists(fileName))
            {
                string justText = File.ReadAllText(fileName);
                List<Logs> myPosts = JsonConvert.DeserializeObject<List<Logs>>(justText);
                Logs logs = new Logs();
                logs.Name = Name;
                logs.FileSource = newPath;
                logs.destPath = destPath + @"\" + Path.GetFileName(newPath);
                logs.transferTime = elapsedTime;
                long length;
                try
                {
                    length = new System.IO.FileInfo(newPath).Length;
                }
                catch
                {
                    length = 0;
                }
                
                logs.size = (int)length;
                logs.time = DateTime.Now.ToString();
                myPosts.Add(logs);
                string json = System.Text.Json.JsonSerializer.Serialize(myPosts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, json);
            }
        }
    }
}
