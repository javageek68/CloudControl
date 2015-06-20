using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetName : MonoBehaviour {

    //public Text txtName = null;
    public InputField input = null;

	// Use this for initialization
	void Start () {
        PlayerData.Load();
        string strName = Constants.LocalPlayer.Name;
        Debug.Log("players name is " + strName);
        input.text = strName;
	}
	

    public void NameValueChanged()
    {
        Constants.LocalPlayer.Name = input.text;
        PlayerData.Save();
    }
}
