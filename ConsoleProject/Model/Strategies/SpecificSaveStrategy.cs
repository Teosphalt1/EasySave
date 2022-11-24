using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class SpecificSaveStrategy : IStrategySaveType
    {
        public void ExecuteSave()
        {
            string fileName = @"c:\bdd.json";
            if (System.IO.File.Exists(fileName))
            {
                string justText = File.ReadAllText(fileName);
                var myPosts = JsonConvert.DeserializeObject<SaveWork[]>(justText);
                string myId = Console.ReadLine();
                int myIdint = Int32.Parse(myId);
                foreach (var post in myPosts)
                {
                    if (post.id == myIdint)
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

                                    if (post.type == "differential")
                                    {
                                        DateTime lastModifiedTime = File.GetLastWriteTime(newPath);
                                        DateTime Test = Convert.ToDateTime(post.time); //Remplacer la string date par celle récupérée dans le file JSON
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

                                }
                            }
                            catch
                            {
                                Console.WriteLine("Error cant find source of " + post.Name);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error cant find source of " + post.Name);
                        }
                    }

                }
            }
        }
    }
}
