using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GUIProject
{
    public class ServiceDB
    {
        public List<SaveWork> GetAll()
        {
            return Repository.Instance().SaveWorks;
        }

        public void Add(SaveWork work)
        {
            Repository.Instance().SaveWorks.Add(work);
        }

        public void GenerateSaveWork()
        {
            string fileName = @"c:\bdd.json";
            string justText = File.ReadAllText(fileName);
            var myPosts = JsonConvert.DeserializeObject<SaveWork[]>(justText);
            foreach (var post in myPosts)
            {
                SaveWork savework = new SaveWork
                {
                    id = post.id,
                    Name = post.Name,
                    FileSource = post.FileSource,
                    destPath = post.destPath,
                    type = post.type,
                    time = post.time
                };
                new ServiceDB().Add(savework);
            };
        }

        public void WriteSaveWork(SaveWork savework)
        {
            string fileName = @"c:\bdd.json";
            string justText = File.ReadAllText(fileName);
            List<SaveWork> myPosts = JsonConvert.DeserializeObject<List<SaveWork>>(justText);
            int State = 0;
            myPosts.Add(savework);
            string json = System.Text.Json.JsonSerializer.Serialize(myPosts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
            new ServiceDB().Add(savework);
        }

    }
}
