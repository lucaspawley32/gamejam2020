using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InteractableRenderController))]
public class PickUpController : MonoBehaviour
{
	[SerializeField]
	private bool _isHeld;
	
	Rigidbody _rb;
	private InteractableRenderController _interacRenderer;

	private Transform _target;
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
		_interacRenderer.SetStartColor(Color.green);
    }

	public bool IsHeld()
	{
		return _isHeld;
	}

	public void PickUp(Transform target)
	{
		_rb.useGravity=false;
		_rb.isKinematic = true;
		_isHeld = true;
		_target = target;

		transform.SetParent(target);
		transform.position = target.position + target.forward * 1.5f + target.up * -0.25f + target.right * -0.25f;

		_interacRenderer.SetAwake(false);
	}

	public void Drop()
	{
		_rb.useGravity=true;
		_rb.isKinematic = false;
		_isHeld = false;
		_target = null;
		transform.SetParent(null);
		
		_interacRenderer.SetAwake(true);
	}
}
