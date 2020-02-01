using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : PuzzleObject
{
	private bool _changing = false;
	[SerializeField]
	private float transitionSpeed = 2.5f;

	private Renderer _renderer;

	private void Start()
	{
		_renderer = GetComponent<Renderer>();
		_renderer.material.SetColor("_StartColor", Color.blue);
		_renderer.material.SetColor("_EndColor", Color.red);
	}

	private void Update() 
	{
		if (_changing)
		{
			_renderer.material.SetFloat("_Active", Mathf.Clamp(_renderer.material.GetFloat("_Active") + transitionSpeed * Time.deltaTime, 0.0f, 1.0f));
			if (_renderer.material.GetFloat("_Active") == 1.0f || _renderer.material.GetFloat("_Active") == 0.0f)
			{
				_changing = false;
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
		if (other.gameObject.tag == "Player")
		{
			if (!_changing)
			{
				_active = !_active;
				_changing = true;
			}
		}
	}
}
