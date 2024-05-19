using UMM;
using UnityEngine;
using System.IO;
using GameConsole;
using System.Reflection;
using System;

using System.Collections.Generic;

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
				UKMod.SetPersistentModData("SkinsFolder", pname, "Tony.UltraSkins");
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
<<<<<<< Updated upstream
	}
}
=======
		public string GetModFolderPath()
		{
			// Get the path to the current directory where the game executable is located
			//string gameDirectory = Assembly.GetExecutingAssembly().Location;
			//string gameDirectory = Path.GetDirectoryName(Application.dataPath);
			string dlllocation = Assembly.GetExecutingAssembly().Location.ToString();
			string dir = Path.GetDirectoryName(dlllocation);
			// The mod folder is typically named "BepInEx/plugins" or similar
			//string modFolderName = "BepInEx\\plugins\\ultraskins\\custom"; // Adjust this according to your setup

			// Combine the game directory with the mod folder name to get the full path
			//return gameDirectory+modFolderName;
			return Path.Combine(dir);
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

>>>>>>> Stashed changes
