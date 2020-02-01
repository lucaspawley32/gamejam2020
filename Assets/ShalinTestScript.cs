using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShalinTestScript : MonoBehaviour
{
	public GameObject testObj;
    public ButtonController testButtonController;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		testButtonController = testObj.GetComponent<ButtonController>();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (Vector3.Distance(transform.position, testObj.transform.position) < testButtonController.GetPushDistance())
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				testButtonController.Press();
			}
		}
	}
}
