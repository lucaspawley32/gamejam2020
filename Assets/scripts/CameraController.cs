using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private GameObject player;	//Reference to player object

	[SerializeField]
	private float rotSpeed;	//Speed of Camera Rotation
	float rotationX;
	float rotationY;
    
	//Okay, so what is the first thing I need to do for the camera?
		// 1. Mouse LR, UD to turn camera, and also rotate player.

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

		// How to access mouse movement?
		float x = Input.GetAxis("Mouse X");
		float y = Input.GetAxis("Mouse Y");
		
		rotationX += x * rotSpeed * Time.deltaTime;
		rotationY -= y * rotSpeed * Time.deltaTime;

		rotationY = Mathf.Clamp(rotationY, -30.0f, 60.0f);
		
		transform.rotation = Quaternion.Euler(rotationY, rotationX, 0.0f);
		player.transform.rotation = Quaternion.Euler(0.0f, rotationX, 0.0f);

    }
}
