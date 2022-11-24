using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class AllTheSavesStrategy : IStrategySaveType
    {
        public void ExecuteSave()
        {
            string fileName = @"c:\bdd.json";
            if (System.IO.File.Exists(fileName))
            {
                string justText = File.ReadAllText(fileName);
                var myPosts = JsonConvert.DeserializeObject<SaveWork[]>(justText);
                TimeSpan ts = new TimeSpan(0);
                foreach (var post in myPosts)
                {
                    try
                    {
                        foreach (string dirPath in Directory.GetDirectories(post.FileSource, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(post.FileSource, post.destPath));
                        }
                        try
                        {
                            foreach (string newPath in Directory.GetFiles(post.FileSource, "*.*", SearchOption.AllDirectories))
                            {

                                Stopwatch stopWatch = new Stopwatch();
                                stopWatch.Start();


                                if (post.type == "differential")
                                {
                                    DateTime lastModifiedTime = File.GetLastWriteTime(newPath);
                                    DateTime Test = Convert.ToDateTime(post.time);
                                    int compareDateTime = DateTime.Compare(lastModifiedTime, Test);
                                    if (compareDateTime > 0)
                                    {
                                        File.Copy(newPath, newPath.Replace(post.FileSource, post.destPath), true);
                                    }
                                }
                                else
                                {
                                    File.Copy(newPath, newPath.Replace(post.FileSource, post.destPath), true);
                                }
                                stopWatch.Stop();
                                ts = stopWatch.Elapsed;
                                WriteLogs.WriteLogsOnJson(post.Name, newPath, post.destPath, ts);
                            }
                        }
                        catch
                        {
                            ts = new TimeSpan(-1);
                            string newPath = "error";
                            Console.WriteLine("Error cant find source of " + post.Name);
                            WriteLogs.WriteLogsOnJson(post.Name, newPath, post.destPath, ts);
                        }
                    }
                    catch
                    {
                        ts = new TimeSpan(-1);
                        string newPath = "error";
                        Console.WriteLine("Error cant find source of " + post.Name);
                        WriteLogs.WriteLogsOnJson(post.Name, newPath, post.destPath, ts);
                    }
                }
            }
        }
    }
}
