using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
	[SerializeField]
	protected bool _active = false;

	public bool IsActive()
	{
		return _active;
	}
	
}
