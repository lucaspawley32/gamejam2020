using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
	[SerializeField]
	private bool isHeld;
	[SerializeField]
	private float heldDist;
	[SerializeField]
	GameObject holder;
    // Start is called before the first frame update
	
    void Start()
    {
        isHeld = false;
		holder = this.gameObject;
    }

	public bool IsHeld()
	{
		return isHeld;
	}

	public void SetHolder(GameObject other)
	{
		holder = other;
		isHeld = true;
	}

	public void Drop()
	{
		holder = this.gameObject;
		isHeld = false;
	}
}
