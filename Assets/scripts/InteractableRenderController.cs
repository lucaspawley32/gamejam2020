using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRenderController : MonoBehaviour
{
	private Renderer _renderer;
	private Transform _target;
	
	[SerializeField]
	private Color _startColor;
	[SerializeField]
	private Color _endColor;

	[SerializeField]
	private float _interactDist=2.5f;
	[SerializeField]
	private float _intensityBase=.25f;
	[SerializeField]
	private float _intensityFlex=.25f;
	private bool _active;
	private bool _awake;
    
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_renderer = GetComponent<Renderer>();
		_target = GameObject.Find("Player").GetComponent<Transform>();

		if (Shader.Find("Custom/InteractableShader"))
		{
			_renderer.material.shader = Shader.Find("Custom/InteractableShader");
		}
	}
	// Start is called before the first frame update
    void Start()
    {
		_awake = true;
		SetActive(false);

		if (_startColor != null)
		{
			_renderer.material.SetColor("_StartColor", _startColor);
		}
		if (_endColor != null)
		{
			_renderer.material.SetColor("EndColor", _endColor);
		}
    }

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (_awake)
		{
			SetActive(Vector3.Distance(transform.position, _target.position) < _interactDist);
			if (_active)
			{
				_renderer.material.SetFloat("_Glow", _intensityBase + _intensityFlex * Mathf.Cos(Mathf.PI * Time.time));
			}
		}
	}


	///Getters
	public float GetInteractDistance()
	{
		return _interactDist;
	}
	public bool IsActive()
	{
		return _active;
	}


	//Setters
	public void SetAwake(bool awake)
	{
		_awake = awake;
		if (!awake)
		{
			SetActive(false);
		}
	}
	public void SetActive(bool active)
	{
		_active = active;
		_renderer.material.SetFloat("_Glow", (_active) ? _intensityBase : 0.0f);
	}
	public void SetProgress(float progress)
	{
		_renderer.material.SetFloat("_Progress", progress);
	}
	public void SetStartColor(Color startC)
	{
		//Debug.Log("Set Start Color: " + startC);
		_renderer.material.SetColor("_StartColor", startC);
	}
	public void SetEndColor(Color endC)
	{
		//Debug.Log("Set End Color: " + endC);
		_renderer.material.SetColor("_EndColor", endC);
	}
	public void SetGlowColor(Color glowC)
	{
		//Debug.Log("Set Glow Color: " + glowC);
		_renderer.material.SetColor("_GlowColor", glowC);
	}
	public void SetShader(Shader shader)
	{
		//Debug.Log("Set Shader: " + shader);
		if (shader)
		{
			_renderer.material.shader = shader;
		}
		else
		{
			Debug.Log("Failed to set shader for object " + gameObject.name);
		}
	}
}
