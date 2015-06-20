using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {



    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.1f, 0.1f, 1f);
        Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
    }
}
