using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableRenderController))]
public class PickUpController : MonoBehaviour
{
	[SerializeField]
	private bool _isHeld; 
	private float _pickUpDist;
	private GameObject _holder;

	private InteractableRenderController _interacRenderer;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
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

	public void SetHolder(GameObject other)
	{
		_holder = other;
		_isHeld = true;
	}

	public void Drop()
	{
		_holder = this.gameObject;
		_isHeld = false;
	}

	public float GetPickUpDist()
	{
		return _pickUpDist;
	}
}
