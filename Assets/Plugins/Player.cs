using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

   

    private bool isMine = false;
    public bool IsMine
    {
        get
        {
            return this.isMine;
        }
        set
        {
            this.isMine = value;
        }
    }
    public Component[] controllerComponents = null;
    
    void OnNetworkInstantiate(NetworkMessageInfo info)
    {
        Debug.Log("New character instantiated by " + Network.player.guid);
        Debug.Log("Local palyer " + info.sender.guid);

        //Debug.Log("isMine " + info.networkView.viewID.isMine.ToString());

        if (info.sender.guid == Network.player.guid)
        {
            Debug.Log("local instance");
            isMine = true;
        }
        else
        {
            //since I was instantiated by another player on the network, i need to disable
            //the user controls. otherwise, the user input will go to that character instead of the local one.
            Debug.Log("remote instance");
            isMine = false;
            RemoveControllerComponents();
        }
    }

    private void RemoveControllerComponents()
    {
        Debug.Log("disable char controller pc player");
        if (controllerComponents != null)
        {
            foreach (Component script in controllerComponents)
            {
                Destroy(script);
            }
        }
    }






}
