using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickUpController : MonoBehaviour
{
	[SerializeField]
	private bool isHeld;

	Rigidbody _rb;
    // Start is called before the first frame update

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

    void Start()
    {
        isHeld = false;
    }

	public bool IsHeld()
	{
		return isHeld;
	}

	public void PickUp()
	{
		_rb.useGravity=false;
		isHeld = true;

	}

	public void Drop()
	{
		_rb.useGravity=true;
		isHeld = false;
	}
	void Update(){
		if(transform.position.y < 0) transform.position = new Vector3(transform.position.x,0,transform.position.z);
	}
}
