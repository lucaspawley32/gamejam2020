using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(InteractableRenderController))]
public class PressureController : PuzzleObject
{
	//store: 
	/*	Weight needed to trigger
			Could use abstraction, check if object covering middle has one of a certain set of tags
	 */
	
	private InteractableRenderController _interacRenderer;
	
	[SerializeField]
	private float _animSpeed=0.25f;
	private float _animProgress;

	private Vector3 _startPos;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_interacRenderer = GetComponent<InteractableRenderController>();
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		_animProgress = 0.0f;
		_startPos = transform.position;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (_active)
		{
			_animProgress = Mathf.Min(_animProgress + Time.deltaTime, 1.0f);
		}
		else
		{
			_animProgress = Mathf.Max(_animProgress - Time.deltaTime, 0.0f);
		}
		transform.position = _startPos - _animSpeed * _animProgress * transform.up;
		_interacRenderer.SetProgress(_animProgress);
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Player")
		{
			_interacRenderer.SetAwake(false);
			_active = true;
		}
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		//Debug.Log(other.gameObject.tag);
		if (collisionInfo.gameObject.name.Contains("Heavy"))
		{
			_interacRenderer.SetAwake(false);
			_active = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		//Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Player")
		{
			_interacRenderer.SetAwake(true);
			_active = false;
		}
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		//Debug.Log(other.gameObject.tag);
		if (collisionInfo.gameObject.name.Contains("Heavy"))
		{
			_interacRenderer.SetAwake(true);
			_active = false;
		}
	}
}