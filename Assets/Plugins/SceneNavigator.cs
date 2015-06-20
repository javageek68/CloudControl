using UnityEngine;
using System.Collections;

public class SceneNavigator : MonoBehaviour {

    public void btnSettings()
    {
        Application.LoadLevel(Constants.Scenes.Settings);
    }

    public void btnSetName()
    {
        Application.LoadLevel(Constants.Scenes.SetName);
    }

    public void btnMainMenu()
    {
        Application.LoadLevel(Constants.Scenes.Menu);
    }

    public void btnLevelMap()
    {
        Application.LoadLevel(Constants.Scenes.LevelMap);
    }

    public void btnHighScores()
    {
        Application.LoadLevel(Constants.Scenes.HighScores);
    }

    public void btnUpgrades()
    {
        Application.LoadLevel(Constants.Scenes.Upgrades);
    }

    public void btnAchievements()
    {
        Application.LoadLevel(Constants.Scenes.Achievements);
    }

    public void btnGame()
    {
        Application.LoadLevel(Constants.Scenes.Game);
    }

}
