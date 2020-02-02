using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PuzzleController : MonoBehaviour
{
	[SerializeField]
    private List<PuzzleObject> _puzzleObjects;
	private Rigidbody _rb;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		bool state = true;
		foreach (PuzzleObject i in _puzzleObjects)
		{
			if (!i.IsActive())
			{
				state = false;
				break;
			}
		}
		if (state)
		{
			_rb.useGravity = true;
		}
	}
}
