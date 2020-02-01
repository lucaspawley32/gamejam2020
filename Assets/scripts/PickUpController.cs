using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InteractableRenderController))]
public class PickUpController : MonoBehaviour
{
	[SerializeField]
	private bool isHeld;
	
	Rigidbody _rb;
	private InteractableRenderController _interacRenderer;
    // Start is called before the first frame update

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_interacRenderer = GetComponent<InteractableRenderController>();
	}

    void Start()
    {
        _isHeld = false;
		_holder = this.gameObject;
		_pickUpDist = _interacRenderer.GetInteractDistance();
		_interacRenderer.SetStartColor(Color.green);
    }
	

	public bool IsHeld()
	{
		return _isHeld;
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
