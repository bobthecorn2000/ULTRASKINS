
using UnityEngine;
using System.IO;
using GameConsole;
using System.Reflection;
using System;

using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection.Emit;


namespace UltraSkins
{
	public class SkinEventHandler : MonoBehaviour
	{
		public GameObject Activator;
		public string path;
		public string pname;
		public ULTRASKINHand UKSH;

		private void Update()
		{
			if (Activator != null && Activator.activeSelf)
			{
				Activator.SetActive(false);
				string message = UKSH.ReloadTextures(false, path);
				
				TextureOverWatch[] TOWS = GameObject.FindWithTag("MainCamera").GetComponentsInChildren<TextureOverWatch>(true);
				foreach (TextureOverWatch TOW in TOWS)
				{
					if (TOW && TOW.gameObject)
					{
						TOW.enabled = true;
					}
				}
				MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage(message, "", "", 0, false);
			}
		}
		public static string GetModFolderPath()
		{
			// Get the path to the current directory where the game executable is located
			//string gameDirectory = Assembly.GetExecutingAssembly().Location;
			//string gameDirectory = Path.GetDirectoryName(Application.dataPath);
			string dlllocation = Assembly.GetExecutingAssembly().Location.ToString();
			string dir = Path.GetDirectoryName(dlllocation);
			string defloc = Path.Combine(dir + "\\Custom");
            // The mod folder is typically named "BepInEx/plugins" or similar
            //string modFolderName = "BepInEx\\plugins\\ultraskins\\custom"; // Adjust this according to your setup
            StringSerializer serializer = new StringSerializer();
            string filecheck = Path.Combine(dir + "\\data.USGC");
            if (!File.Exists(Path.Combine(dir + "\\data.USGC")))
			{
                serializer.SerializeStringToFile(defloc, filecheck);

            }
            
            string deserializedData = serializer.DeserializeStringFromFile(filecheck);
            // Combine the game directory with the mod folder name to get the full path
            //return gameDirectory+modFolderName;
            return deserializedData;
		}
        public class StringSerializer
        {
            public void SerializeStringToFile(string data, string filePath)
            {
                // Convert string to byte array
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);

                // Write byte array to file
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    fileStream.Write(byteArray, 0, byteArray.Length);
                }
            }

            public string DeserializeStringFromFile(string filePath)
            {
                // Read byte array from file
                byte[] byteArray;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    byteArray = new byte[fileStream.Length];
                    fileStream.Read(byteArray, 0, byteArray.Length);
                }

                // Convert byte array to string
                string data = System.Text.Encoding.UTF8.GetString(byteArray);
                return data;
            }
        }
    



    public static void getskinfolder(string dir)
		{

			{
				string[] subfolders = Directory.GetDirectories(dir);


				foreach (string subfolder in subfolders)
				{

					string folder = Path.GetFileName(subfolder);


					if (folder.ToLower() != "custom")
					{


					}

				}

			}
		}
	}
}

