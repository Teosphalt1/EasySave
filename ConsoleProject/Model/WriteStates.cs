﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class WriteStates
    {
        public static void WriteStatesOnJson(string Name, string newPath, string destPath, int totalFiles, long totalSize, long dirSize, int filesLeft, string state)
        {
            string fileName = @"c:\states.json";
            if (System.IO.File.Exists(fileName))
            {
                string justText = File.ReadAllText(fileName);
                List<States> myPosts = JsonConvert.DeserializeObject<List<States>>(justText);
                States states = new States();
                states.Name = Name;
                myPosts.RemoveAll((x) => x.Name == states.Name);
                states.FileSource = newPath;
                states.destPath = destPath;
                states.totalFiles = totalFiles;
                states.totalSize = (int)totalSize;
                states.filesLeft = filesLeft;
                states.sizeLeft = (int)dirSize;
                states.time = DateTime.Now.ToString();
                states.state = state;
                myPosts.Add(states);
                
                string json = System.Text.Json.JsonSerializer.Serialize(myPosts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, json);
            }
        }
    }
}