using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Constants
{
    

    public static PlayerData LocalPlayer = new PlayerData();

    /// <summary>
    /// 
    /// </summary>
    public class Files
    {
        public static string strBaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HideNSeek\\";
        public static string strAppConfigFile = "UserApp.config";    
    }

    /// <summary>
    /// 
    /// </summary>
    public class Scenes
    {
        public static string Menu = "Menu";
        public static string LevelMap = "LevelMap";
        public static string Settings = "Settings";
        public static string SetName = "SetName";
        public static string HighScores = "HighScores";
        public static string Upgrades = "Upgrades";
        public static string Achievements = "Achievements";
        public static string Game = "Game";
    }


}

