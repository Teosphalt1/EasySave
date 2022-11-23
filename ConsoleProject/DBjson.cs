//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace ConsoleProject
//{
//    public class DBjson
//    {
//        public SaveWork displaySaveWorks()
//        {
//            string fileName = @"c:\bdd.json";

//            if (System.IO.File.Exists(fileName))
//            {
//                string justText = File.ReadAllText(fileName);
//                var myPosts = JsonConvert.DeserializeObject<SaveWork[]>(justText);

//                foreach (var post in myPosts)
//                {
//                    Console.WriteLine($"{post.id} {post.Name} {post.FileSource} {post.destPath} {post.time}");
//                }
//            }
//            return (null);
//        }

//        public SaveWork addNewSaveWork()
//        {
//            string fileName = @"c:\bdd.json";

//            string justText = File.ReadAllText(fileName);
//            List<SaveWork> myPosts = JsonConvert.DeserializeObject<List<SaveWork>>(justText);
//            SaveWork sw = new SaveWork();
//            int count = myPosts.Count;
//            sw.id = count + 1;
//            Console.WriteLine("nom");
//            sw.Name = Console.ReadLine();
//            Console.WriteLine("source");
//            sw.FileSource = Console.ReadLine();
//            Console.WriteLine("destination");
//            sw.destPath = Console.ReadLine();
//            sw.time = DateTime.Now.ToString();

//            myPosts.Add(sw);

//            string json = System.Text.Json.JsonSerializer.Serialize(myPosts, new JsonSerializerOptions { WriteIndented = true });
//            File.WriteAllText(fileName, json);

//            return (sw);
//        }
//    }
//}
