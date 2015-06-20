using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class PlayerData
{
    public string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static void Load()
    {
        string strErrMsg = string.Empty;
        string strDataFile = Constants.Files.strBaseFolder + Constants.Files.strAppConfigFile;
        Debug.Log("data file " + strDataFile);
        if (PlayerData.Load(strDataFile, ref Constants.LocalPlayer, ref strErrMsg))
        {

        }
        else
        {
            Debug.Log(string.Format("error loading player {0}", strErrMsg));
        }
        if (Constants.LocalPlayer == null) Constants.LocalPlayer = new PlayerData();
    
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strFileName"></param>
    /// <param name="playerData"></param>
    /// <param name="strErrMsg"></param>
    /// <returns></returns>
    public static bool Load(string strFileName, ref PlayerData playerData,ref string strErrMsg)
    {
        bool blnRetVal = true;
        string strContents = string.Empty;

        try
        {
            Debug.Log("data file " + strFileName);
            //make sure the player data file exists before we try to load it
            if (System.IO.File.Exists(strFileName))
            {
                Debug.Log("reading file");
                strContents = System.IO.File.ReadAllText(strFileName);
                playerData = SerializerTools.DeserializeItem<PlayerData>(strContents);
            }
            else
            {
                Debug.Log("file does not exist");
                //the player settings file doesnt exist yet
                playerData = new PlayerData();
                //save the initial copy of it
                Save();
            }
        }
        catch (Exception ex)
        {
            strErrMsg = ex.ToString();
            blnRetVal = false;
        }
        return blnRetVal;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void Save()
    {
        string strErrMsg = string.Empty;
        string strDataFile = Constants.Files.strBaseFolder + Constants.Files.strAppConfigFile;
        if (PlayerData.Save(strDataFile, ref Constants.LocalPlayer, ref strErrMsg))
        {

        }
        else
        {
            Debug.Log(string.Format("error saving player {0}", strErrMsg));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strFileName"></param>
    /// <param name="playerData"></param>
    /// <param name="strErrMsg"></param>
    /// <returns></returns>
    public static bool Save(string strFileName, ref PlayerData playerData, ref string strErrMsg)
    {
        bool blnRetVal = true;
        string strContents = string.Empty;
        string strPath = "";

        try
        {
            //get the path of the config file
            strPath = System.IO.Path.GetDirectoryName(strFileName);
            //make sure the path exists
            if (!System.IO.Directory.Exists(strPath)) System.IO.Directory.CreateDirectory(strPath);
            //save the file
            strContents = SerializerTools.SerializeItem<PlayerData>(playerData);
            System.IO.File.WriteAllText(strFileName, strContents);
        }
        catch (Exception ex)
        {
            strErrMsg = ex.ToString();
            blnRetVal = false;
        }
        return blnRetVal;
    }
}

