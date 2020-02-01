using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableRenderController))]
public class ButtonController : PuzzleObject
{
	[SerializeField]
	private float _animSpeed=0.5f;
	private float _pushDist;
	private float _animTimer;
	private float _maxAnimTimer;
	private InteractableRenderController _interacRenderer;

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
		_interacRenderer.SetShader(Shader.Find("Custom/InteractableShader"));
		_interacRenderer.SetStartColor(Color.yellow);
		_interacRenderer.SetEndColor(Color.green);

		_animTimer = 0.0f;
		_maxAnimTimer = 1.0f;
		_pushDist = _interacRenderer.GetInteractDistance();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		// If Animating
		if (_active && _animTimer < _maxAnimTimer)
		{
			_animTimer = Mathf.Clamp(_animTimer + Time.deltaTime, 0.0f, _maxAnimTimer);
			if (_animTimer < _maxAnimTimer / 2.0f)
			{
				transform.position -= _animSpeed * transform.forward * Time.deltaTime;
			}
			else
			{
				transform.position += _animSpeed * transform.forward * Time.deltaTime;
			}
			_interacRenderer.SetProgress(Mathf.Clamp(_animTimer / _maxAnimTimer * 2.0f,  0.0f, 1.0f));
		}
	}

	/// <summary>
	/// Triggers when Button is pressed
	/// Disables Interact Glow, Sets active Bool + begins animation
	/// </summary>
	public void Press()
	{
		//Need to adjust renderer components
		_interacRenderer.SetAwake(false);
		_active = true;
	}


	///Getters
	public float GetPushDistance()
	{
		return _pushDist;
	}
	///Setters
}
