﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Org.Json;
using Android.Util;
using System.Text.Json;

using Android.Provider;
using Java.IO;

namespace TODO_app
{
    internal class FileClass
    {



        //Java.IO ja FileOutputStream ennemmin kun windowsin file toolsit?


        //FileOutputStream fOut = openFileOutput(“ file_name ”, MODE_INTERNAL_READ);
        //String name = “demo”;
        //fOut.write(name.getBytes());
        //fOut.close()




        //Folder location and filename
        private string _fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TODO2.0.JSON");
        private string _settingsFileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Settings.JSON");


        public FileClass()
        {
            //Checks if everything is all right
            CreateFile();
        }


        /// <summary>
        /// If file doesn't exists it will create it
        /// </summary>
        private void CreateFile()
        {

            if (!File.Exists(_fileName))
            {
                File.Create(_fileName);
            }
            if (!File.Exists(_settingsFileName))
            {
                File.Create(_settingsFileName);
            }
        }

        /// <summary>
        /// Writes all text to internal storage. Needs List of Task objects.
        /// </summary>
        /// <param name="tasks"></param>
        internal void WriteFile(List<TaskItem> tasks)
        {
            List<String> taskList = new List<String>();

            //Convert objects to string
            foreach (TaskItem task in tasks)
            {
                taskList.Add(JsonSerializer.Serialize(task));
                
            }
            File.WriteAllLines(_fileName, taskList);
            //Writes to file

        }


        /// <summary>
        /// Reads from internal storage. Returns list of Task objects.
        /// </summary>
        /// <returns></returns>
        internal List<TaskItem> ReadFile()
        {
            
            List<TaskItem> tasks = new List<TaskItem>();

            foreach (string line in System.IO.File.ReadLines(_fileName))
            {
                //Check that the line is not empty
                if (line != null && line != "")
                {
                    tasks.Add(JsonSerializer.Deserialize<TaskItem>(line));
                }
                
            }
            return tasks;
        }

        internal void SaveSettings(Settings settings)
        {
            File.WriteAllText(_settingsFileName, JsonSerializer.Serialize(settings));
        }

        internal Settings ReturnSettings()
        {
            return JsonSerializer.Deserialize<Settings>(File.ReadLines(_settingsFileName).ToString());
        }
    }
}