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
	Transform _target;
	private InteractableRenderController _interacRenderer;
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
		_rb.detectCollisions = false;
		_isHeld = true;
		_target = target;

		transform.SetParent(_target);
		transform.position = _target.position + _target.forward * 1.5f + _target.up * -0.25f + _target.right * -0.25f;

		_interacRenderer.SetAwake(false);
	}

	public void Drop()
	{
		_rb.useGravity=true;
		_rb.isKinematic = false;
		_rb.detectCollisions = true;
		_isHeld = false;
		_target = null;
		transform.SetParent(null);
		
		_interacRenderer.SetAwake(true);
	}
}
