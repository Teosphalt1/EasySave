using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIProject
{
    public class ExecuteAllTheSaves
    {
        /// <summary>
        /// Will execute all the different save works registered on bdd.json
        /// will gather the informations to fill logs.json
        /// will gather the informations to update in real time the file state.json
        /// </summary>
        public void ExecuteSave(string blockIfRunning, IList<Thread> threadlist, string extensionToCrypt)
        {
            string fileName = @"c:\bdd.json";
            if (System.IO.File.Exists(fileName))
            {
                string justText = File.ReadAllText(fileName);
                SaveWork[] myPosts = JsonConvert.DeserializeObject<SaveWork[]>(justText);
                TimeSpan ts = new TimeSpan(0);
                string state = "Active";
                int myThread = 1;
                foreach (SaveWork post in myPosts)
                {
                    Thread t = new Thread(()=>DoWork(blockIfRunning, post, state, ts, extensionToCrypt));
                    t.Start();
                    Thread.Sleep(3000);
                    threadlist.Add(t);
                }
            }
        }

        public static void DoWork(string blockIfRunning, SaveWork post, string state, TimeSpan ts, string extensionToCrypt)
        {
            
            try
            {
                foreach (string dirPath in Directory.GetDirectories(post.FileSource, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(post.FileSource, post.destPath));
                    int fCount = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories).Length;
                }
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(post.FileSource);
                    int i = 1;
                    int totalFiles = Directory.GetFiles(post.FileSource, "*.*", SearchOption.AllDirectories).Length;
                    long dirSize = dirInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length);
                    long totalSize = dirSize;
                    string[] MyFiles = Directory.GetFiles(post.FileSource, "*.*", SearchOption.AllDirectories);
                    foreach (string file in MyFiles)
                    {
                        if (file.Contains(".txt"))
                        {
                            MyFiles = MyFiles.Where(o => o != file).ToArray();
                            MyFiles = MyFiles.Prepend(file).ToArray();
                        }
                    }

                    foreach(string newPath in MyFiles)
                    {
                        while ((Process.GetProcessesByName(blockIfRunning).Length > 0))
                        {
                            Thread.Sleep(10);
                        }
                        Thread.Sleep(3000);
                        long actualFileSize = new System.IO.FileInfo(newPath).Length;
                        long sizeleft = dirSize - actualFileSize;
                        dirSize -= actualFileSize;
                        int filesLeft = totalFiles - i;

                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        Stopwatch cryptTimeWatch = new Stopwatch();
                        TimeSpan cryptTime = new TimeSpan(0);

                        string myPath = Path.GetDirectoryName(newPath);
                        i += 1;
                        if (i < totalFiles + 1)
                        {
                            state = "Active";
                        }
                        else
                        {
                            state = "Ended";
                        }
                        if (post.type == "differential")
                        {
                            DateTime lastModifiedTime = File.GetLastWriteTime(newPath);
                            DateTime Test = Convert.ToDateTime(post.time);
                            int compareDateTime = DateTime.Compare(lastModifiedTime, Test);
                            if (compareDateTime > 0)
                            {
                                if (newPath.Contains(extensionToCrypt))
                                {
                                    cryptTimeWatch.Start();
                                    EncryptFile encrypt = new EncryptFile();
                                    encrypt.launchEncrypt(newPath, newPath.Replace(post.FileSource, post.destPath));
                                    cryptTimeWatch.Stop();
                                    cryptTime = cryptTimeWatch.Elapsed;
                                }
                                else
                                {
                                    cryptTime = new TimeSpan(0);
                                }
                                File.Copy(newPath, newPath.Replace(post.FileSource, post.destPath), true);
                            }
                        }
                        else
                        {
                            if (newPath.Contains(extensionToCrypt))
                            {
                                
                                cryptTimeWatch.Start();
                                EncryptFile encrypt = new EncryptFile();
                                encrypt.launchEncrypt(newPath, newPath.Replace(post.FileSource, post.destPath));
                                cryptTimeWatch.Stop();
                                cryptTime = cryptTimeWatch.Elapsed;
                            }
                            else
                            {
                                cryptTime = new TimeSpan(0);
                            }
                            File.Copy(newPath, newPath.Replace(post.FileSource, post.destPath), true);
                        }
                        stopWatch.Stop();
                        ts = stopWatch.Elapsed;
                        WriteLogs.WriteLogsOnJson(post.Name, newPath, post.destPath, ts, cryptTime);
                        WriteStates.WriteStatesOnJson(post.Name, newPath, post.destPath, totalFiles, totalSize, dirSize, filesLeft, state);
                        WriteLogs.WriteLogsOnXML(post.Name, newPath, post.destPath, ts, cryptTime);
                    }
                }
                catch
                {
                    ts = new TimeSpan(-1);
                    TimeSpan cryptTime = new TimeSpan(-1);
                    string newPath = "error";
                    WriteLogs.WriteLogsOnJson(post.Name, newPath, post.destPath, ts, cryptTime);
                    WriteLogs.WriteLogsOnXML(post.Name, newPath, post.destPath, ts, cryptTime);
                }
            }
            catch
            {
                ts = new TimeSpan(-1);
                TimeSpan cryptTime = new TimeSpan(-1);
                string newPath = "error";
                WriteLogs.WriteLogsOnJson(post.Name, newPath, post.destPath, ts, cryptTime);
                WriteLogs.WriteLogsOnXML(post.Name, newPath, post.destPath, ts, cryptTime);
            }
        }
    }
}
