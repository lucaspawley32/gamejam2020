﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public CharacterController characterController;
    
    [SerializeField]
  	float minTilt=-80.0f;
  	[SerializeField]
  	float maxTilt=60.0f;

    public GameObject player;
    public Camera Camera;
    private GameObject objectInHand;
    private float walkSpeed = 6.0f;
    private float sprintSpeed = 9.0f;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private float maxPickupDistance = 2.5f;
    private float pickupCooldown = 0.5f;
    private float lastPickupTime = 0;

    private Vector3 moveDirection = Vector3.zero;
    private float rotSpeed=150.0f;	//Speed of Camera Rotation
  	Vector3 rot;	//Stored x and y rotation
    private Vector3 mousePos;
    private Vector3 worldPos;
    // Start is called before the first frame update
    void Start()
    {
      characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit hit;
      //check if the raycast is hitting anything and if it can be picked up
		Debug.DrawRay(Camera.transform.position - Camera.transform.up * .01f, Camera.transform.forward * maxPickupDistance, Color.red);
      if(Input.GetMouseButton(0) && Time.time > lastPickupTime+pickupCooldown){
          lastPickupTime = Time.time;
          //check if there is no object in hand, and pick it up.
        if(objectInHand == null){
          if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, maxPickupDistance)){
			  if (hit.collider.gameObject.tag == "PickUp")
			  {
            	objectInHand = hit.collider.gameObject;
				//Set objectInHand variables
				if (objectInHand.GetComponent<PickUpController>())
					objectInHand.GetComponent<PickUpController>().PickUp(Camera.transform);
			  }
			  else if (hit.collider.gameObject.tag == "Button")
			  {
				hit.collider.gameObject.GetComponent<ButtonController>().Press();
			  }
          }

        }else{
			if (objectInHand.GetComponent<PickUpController>())
				objectInHand.GetComponent<PickUpController>().Drop();
        	objectInHand = null;
        }
      }

      //check if player is sprinting
      if(Input.GetKey(KeyCode.LeftShift)){
        Debug.Log("Shift!");
        if(speed < sprintSpeed){
          speed = speed + 1.0f;
          if(speed > sprintSpeed){
            speed = sprintSpeed;
          }
        }
      }else{
        if(speed > walkSpeed){
          speed = speed - 1.0f;
          if(speed < walkSpeed){
            speed = sprintSpeed;
          }
        }
      }
        if(characterController.isGrounded){
          //we are grounded, so recalculate
          //move direction directly from Axes

          moveDirection = player.transform.right * Input.GetAxis("Horizontal") + player.transform.forward * Input.GetAxis("Vertical");
          moveDirection *= speed;
          if(Input.GetButton("Jump")){
            moveDirection.y = jumpSpeed;
          }
        }
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        //move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
