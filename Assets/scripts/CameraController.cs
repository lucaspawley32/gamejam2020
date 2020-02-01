using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private GameObject player;	//Reference to player object

	[SerializeField]
	private float rotSpeed=150.0f;	//Speed of Camera Rotation
	Vector2 rot;	//Stored x and y rotation

	[SerializeField]
	float minTilt=-80.0f;
	[SerializeField]
	float maxTilt=60.0f;
    
	//Okay, so what is the first thing I need to do for the camera?
		// 1. Mouse LR, UD to turn camera, and also rotate player.

	private void Start() 
	{
		rot = new Vector2(0.0f, 0.0f);
		player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

		// How to access mouse movement?
		float x = Input.GetAxis("Mouse X");
		float y = Input.GetAxis("Mouse Y");

		rot.x += x * rotSpeed * Time.deltaTime;
		rot.y -= y * rotSpeed * Time.deltaTime;

		rot.y = Mathf.Clamp(rot.y, minTilt, maxTilt);
		
		transform.rotation = Quaternion.Euler(rot.y, rot.x, 0.0f);
		player.transform.rotation = Quaternion.Euler(0.0f, rot.x, 0.0f);
    }
}
