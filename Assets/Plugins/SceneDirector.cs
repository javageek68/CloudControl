using UnityEngine;
using System.Collections;

public class SceneDirector : MonoBehaviour {

    public static SceneDirector instance = null;

    public GameObject playerPrefab;
    public GameObject[] spawnPoints;
    public GameObject BaseLocation;
    

    void Awake()
    {
        SceneDirector.instance = this;
        //load data for the local player
        PlayerData.Load();
    }
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(Constants.Scenes.Menu);
        }
	}

    void OnApplicationPause()
    {
        Application.Quit();
    }


    public Vector3 getSpawnPoint(int idx)
    {
        Vector3 spawnPoint = Vector3.zero;
        if (idx < spawnPoints.Length)
        {
            spawnPoint = spawnPoints[idx].transform.position;
        }
        else
        {
            spawnPoint = spawnPoints[0].transform.position;
        }
        return spawnPoint;
    }
}
