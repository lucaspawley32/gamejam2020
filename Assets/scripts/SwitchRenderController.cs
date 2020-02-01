using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRenderController : MonoBehaviour
{
	[SerializeField]
	private bool isActive = false;
	private bool isChanging = false;
	[SerializeField]
	private float transitionSpeed = 2.5f;

	private Renderer render;

	private void Start()
	{
		render = GetComponent<Renderer>();
		render.material.SetColor("_StartColor", Color.blue);
		render.material.SetColor("_EndColor", Color.red);
	}

	private void Update() 
	{
		if (isChanging)
		{
			render.material.SetFloat("_Active", Mathf.Clamp(render.material.GetFloat("_Active") + transitionSpeed * Time.deltaTime, 0.0f, 1.0f));
			if (render.material.GetFloat("_Active") == 1.0f || render.material.GetFloat("_Active") == 0.0f)
			{
				isChanging = false;
				transitionSpeed *= -1;
			}
		}
	}
	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnTriggerEnter(Collider other)
	{
//		Debug.Log(other.gameObject.name);
		if (!isChanging)
		{
			isActive = true;
			isChanging = true;
		}
	}

	public bool IsActive()
	{
		return isActive;
	}
}
