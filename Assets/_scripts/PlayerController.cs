using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {


    public float MoveSpeed = 3f;
    public float RotateSpeed = 3f;

    private CharacterController control = null;
    private Vector3 move = Vector3.zero;

	// Use this for initialization
	void Start () {
        control = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float fltForward = 0;
        float fltHorizontal = 0;

        fltForward = CrossPlatformInputManager.GetAxis("Vertical");
        fltHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        gameObject.transform.Rotate(Vector3.up, fltHorizontal * RotateSpeed * Time.deltaTime);

        move = transform.forward * fltForward * MoveSpeed * Time.deltaTime;
 
        control.SimpleMove(move);
	}

    
}
