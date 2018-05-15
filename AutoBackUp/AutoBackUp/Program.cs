using System;
using System.IO;
using Newtonsoft.Json;
using AutoBackUp.Models;
using AutoBackUp.Application;
using System.Reflection;

namespace AutoBackUp
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath;
            ApplicationJson appJson = new ApplicationJson();

            Console.WriteLine();

#if DEBUG
            jsonFilePath = "appsettings.json";
#else
                jsonFilePath = args[0];
#endif
            try
            {                
                Console.WriteLine("Reading settings from appsettings.json . . .");
                Console.WriteLine(jsonFilePath);

                appJson = JsonConvert.DeserializeObject<ApplicationJson>(File.ReadAllText(jsonFilePath));

                if (appJson.Application == null || appJson.Server == null)
                    throw new ArgumentNullException("appsettings data is NULL");

                Console.WriteLine("Reading complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading Error:");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine();
            Console.WriteLine("Autobackup starting by " + Environment.UserName + " . . .");
            Console.WriteLine();
            ApplicationHandler appHandler = new ApplicationHandler(appJson.Application, appJson.Server);

            Console.WriteLine();
            Console.WriteLine("AutoBackuping Finished");
            Console.ReadLine();
        }
    }
}
