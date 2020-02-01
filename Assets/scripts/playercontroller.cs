using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject player;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
      characterController = GetComponent<CharacterController>();
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
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
